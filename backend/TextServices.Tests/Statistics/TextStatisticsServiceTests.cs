using NUnit.Framework;
using TextServices.Entities;
using TextServices.Interfaces;

namespace TextServices.Tests.Statistics
{
	public class TextStatisticsServiceTest
	{
		private readonly IGenerateTextStatistics _generateTextStatistics;

		public TextStatisticsServiceTest()
		{
			_generateTextStatistics = new Services.TextStatisticsService();
		}

		[Test]
		[TestCaseSource(typeof(TextStatisticsTestCases))]
		public TextStatisticsEntity GenerateStatisticsTest(string input)
		{
			return _generateTextStatistics.GenerateStatistics(input);
		}
	}
}
