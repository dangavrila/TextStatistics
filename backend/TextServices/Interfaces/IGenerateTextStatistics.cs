using TextServices.Entities;

namespace TextServices.Interfaces
{
	public interface IGenerateTextStatistics
	{
		TextStatisticsEntity GenerateStatistics(string textItem);
	}
}
