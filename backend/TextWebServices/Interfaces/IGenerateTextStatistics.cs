using TextWebServices.Entities;

namespace TextWebServices.Interfaces
{
	interface IGenerateTextStatistics
	{
		TextStatisticsEntity GenerateStatistics(TextEntity textItem);
	}
}
