using System.Threading;
using System.Threading.Tasks;
using TextWebServices.Models;

namespace TextWebServices.Repository
{
	public interface ITextsCollectionsRepository
	{
		Task InsertAsync(TextItem textItem, CancellationToken cancellationToken);

		Task<TextItem> GetTextItemAsync(string id, CancellationToken cancellationToken);

		Task<TextStatistics> GetStatisticsAsync(string textItemId, CancellationToken cancellationToken);
	}
}
