using System.Threading;
using System.Threading.Tasks;
using TextWebServices.Models;

namespace TextWebServices.Repository
{
	public interface ITextsCollectionsRepository
	{
		Task Insert(TextItem textItem, CancellationToken cancellationToken);

		Task<TextStatistics> GetStatistics(CancellationToken cancellationToken);
	}
}
