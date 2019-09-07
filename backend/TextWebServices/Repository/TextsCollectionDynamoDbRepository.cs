using System.Threading;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using TextWebServices.Models;

namespace TextWebServices.Repository
{
	public class TextsCollectionDynamoDbRepository: ITextsCollectionsRepository
	{
		private readonly IAmazonDynamoDB _dynamoClient;
		private readonly DynamoDBContext _context;

		public TextsCollectionDynamoDbRepository(IAmazonDynamoDB dynamoClient)
		{
			_dynamoClient = dynamoClient;
			_context = new DynamoDBContext(dynamoClient);
		}

		public Task InsertAsync(TextItem textItem, CancellationToken cancellationToken)
		{
			return _context.SaveAsync(textItem, cancellationToken);
		}

		public Task<TextItem> GetTextItemAsync(string id, CancellationToken cancellationToken)
		{
			return _context.LoadAsync<TextItem>(id, cancellationToken);
		}

		public Task<TextStatistics> GetStatisticsAsync(string textId, CancellationToken cancellationToken)
		{
			return _context.LoadAsync<TextStatistics>(textId, cancellationToken);
		}
	}
}
