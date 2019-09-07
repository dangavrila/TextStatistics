using TextWebServices.Entities;

namespace TextWebServices.TextServices
{
	interface IGenerateTextStatistics
	{
		TextStatistics GenerateStatistics(TextEntity textItem);
	}
}
