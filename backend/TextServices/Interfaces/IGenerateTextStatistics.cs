using TextServices.Entities;

namespace TextServices.Interfaces
{
	interface IGenerateTextStatistics
	{
		TextStatisticsEntity GenerateStatistics(TextEntity textItem);
	}
}
