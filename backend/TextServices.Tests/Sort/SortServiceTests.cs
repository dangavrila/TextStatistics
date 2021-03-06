﻿using NUnit.Framework;
using TextServices.Interfaces;
using TextServices.Services;

namespace TextServices.Tests.Sort
{
	public class SortServiceTests
	{
		private readonly ISortText _sortTextService;

		public SortServiceTests()
		{
			_sortTextService = new SortService();
		}

		[Test]
		[TestCaseSource(typeof(AscInputDataTestCases), nameof(AscInputDataTestCases.TestCases))]
		public string SortTextAscendingTest(string input)
		{
			// Arrange
			string result = null;

			// Act
			_sortTextService.SortTextAscending(input, out result);

			// Assert
			return result;
		}

		[Test]
		[TestCaseSource(typeof(DescInputDataTestCases), nameof(DescInputDataTestCases.TestCases))]
		public string SortTextDescendingTest(string input)
		{
			// Arrange
			string result = null;

			// Act
			_sortTextService.SortTextDescending(input, out result);

			// Assert
			return result;
		}
	}
}