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
		private const string CognitoGroupName = "GenerateStatistics";
		private const string OpenIDConnectAuthorityFormat = "https://cognito-idp.{0}.amazonaws.com/{1}";
		private const string CognitoPoolId = "us-east-2_k83bo5YdJ";
		private const string AWSRegion = "us-east-2";
		private const string CognitoApplicationClientId = "5ffr8ce8bo382bbpmjf9mmondp";


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
					options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
						.AddRequirements(new CognitoGroupAuthorizationRequirement(CognitoGroupName))
						.Build();
					options.AddPolicy($"In{CognitoGroupName}", policy => policy.Requirements.Add(new CognitoGroupAuthorizationRequirement(CognitoGroupName)));
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
				options.Audience = CognitoApplicationClientId;
				options.Authority = string.Format(OpenIDConnectAuthorityFormat, AWSRegion, CognitoPoolId);
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
