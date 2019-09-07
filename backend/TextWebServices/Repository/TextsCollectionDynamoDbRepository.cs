using System;
using System.Threading;
using System.Threading.Tasks;
using TextWebServices.Models;

namespace TextWebServices.Repository
{
	public class TextsCollectionDynamoDbRepository: ITextsCollectionsRepository
	{
		public Task Insert(TextItem textItem, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<TextStatistics> GetStatistics(CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
