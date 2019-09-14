using NUnit.Framework;
using TextServices.Interfaces;
using TextServices.Services;

namespace TextServices.Tests
{
	public class SortServiceTests
	{
		private readonly ISortText _sortTextService;
		private string textBody = string.Empty;

		public SortServiceTests()
		{
			_sortTextService = new SortService();
		}

		[SetUp]
		public void Setup()
		{
			textBody =
				"A matrix is a 2-D array of numbers, so each element is identified\r\nby two indices instead of just one. We usually give matrices uppercase\r\nvariable names with bold typeface, such as A. If a real-valued matrix A has\r\na height of m and a width of n, then we say that A ∈ Rm×n. We usually\r\nidentify the elements of a matrix using its name in italic but not bold font,\r\nand the indices are listed with separating commas. For example, A1,1 is the\r\nupper left entry of A and Am,n is the bottom right entry. We can identify\r\nall the numbers with vertical coordinate i by writing a “:” for the horizontal\r\ncoordinate.";
		}

		[Test]
		public void SortTextAscendingTest()
		{
			var result = _sortTextService.SortTextAscending(textBody, out var sortedText);
			Assert.IsNotNull(result);
			Assert.IsNotNull(sortedText);
		}

		[Test]
		public void SortTextDescendingTest()
		{
			var result = _sortTextService.SortTextDescending(textBody, out var sortedTextDesc);
			Assert.IsNotNull(result);
			Assert.IsNotNull(sortedTextDesc);
		}
	}
}