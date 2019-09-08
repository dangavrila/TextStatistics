using Amazon.DynamoDBv2;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TextServices.Interfaces;
using TextServices.Services;
using TextWebServices.Repository;
using TextWebServices.Security;

namespace TextWebServices
{
	public class Startup
	{
		public const string AppS3BucketKey = "AppS3Bucket";

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public static IConfiguration Configuration { get; private set; }

		// This method gets called by the runtime. Use this method to add services to the container
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc(options =>
			{
				options.InputFormatters.Insert(0, new TextPlainInputFormatter());
			})
			.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			// Add S3 to the ASP.NET Core dependency injection framework.
			services.AddAWSService<Amazon.S3.IAmazonS3>();

			// Add Cognito authorization group requirement
			services.AddAuthorization(
				options =>
				{
					var cognitoGroupName = Configuration["Cognito:GroupName"];
					options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
						.AddRequirements(new CognitoGroupAuthorizationRequirement(cognitoGroupName))
						.Build();
					options.AddPolicy($"In{cognitoGroupName}", policy => policy.Requirements.Add(new CognitoGroupAuthorizationRequirement(cognitoGroupName)));
				}
			);

			// Add Cognito authorization handler
			services.AddSingleton<IAuthorizationHandler, CognitoGroupAuthorizationHandler>();
			services.AddAuthentication(
		options =>
				{
					options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				}
			).AddJwtBearer(options =>
			{
				options.Audience = Configuration["Cognito:AppClientId"];
				options.Authority = string.Format(
					Configuration["Cognito:OpenIDConnectAuthorityFormat"]
					, Configuration["Cognito:Region"]
					, Configuration["Cognito:PoolId"]);
				options.RequireHttpsMetadata = false; // to be set to true in production
			});

			// Add DynamoDB client
			var awsOptions = Configuration.GetAWSOptions();
			services.AddDefaultAWSOptions(awsOptions);
			services.AddAWSService<IAmazonDynamoDB>();

			// Auto Mapper Configurations
			var mappingConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new MappingProfile());
			});
			IMapper mapper = mappingConfig.CreateMapper();
			services.AddSingleton(mapper);

			services.AddSingleton<ITextsCollectionsRepository, TextsCollectionDynamoDbRepository>();
			services.AddTransient<ISortText, SortService>();
			services.AddTransient<IGenerateTextStatistics, TextStatisticsService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			//app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}
