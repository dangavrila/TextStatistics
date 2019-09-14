using NUnit.Framework;
using System.Collections.Generic;

namespace TextServices.Tests.Sort
{
	public static class DescInputDataTestCases
	{
		private const string DescKeyOne = "desc1";
		private const string DescKeyTwo = "desc2";
		private const string DescKeyThree = "desc3";

		private static readonly Dictionary<string, string> DescKeysDictionary = new Dictionary<string, string>()
		{
			{ DescKeyOne, "The fundamental difficulty\r\nin performing continuous\r\nmath on a digital computer\r\nis that we need to represent\r\ninfinitely many real numbers\r\nwith a finite number\r\nof bit patterns." },
			{ DescKeyTwo,  "Another highly damaging form of numerical error is overflow.\r\nOverflow occurs when numbers with large\r\nmagnitude are approximated as ∞ or −∞.\r\nFurther arithmetic will usually change these\r\ninfinite values into not-a-number values."},
			{ DescKeyThree, "Consider what happens when all the xi are equal to some constant c.\r\nAnalytically, we can see that all the outputs should be equal to\r\n1/n." }
		};

		private static readonly Dictionary<string, string> ExpectedDescKeysDictionary = new Dictionary<string, string>()
		{
			{ DescKeyOne, "with a finite number\r\nThe fundamental difficulty\r\nof bit patterns.\r\nmath on a digital computer\r\nis that we need to represent\r\ninfinitely many real numbers\r\nin performing continuous" },
			{ DescKeyTwo, "Overflow occurs when numbers with large\r\nmagnitude are approximated as ∞ or −∞.\r\ninfinite values into not-a-number values.\r\nFurther arithmetic will usually change these\r\nAnother highly damaging form of numerical error is overflow." },
			{ DescKeyThree, "Consider what happens when all the xi are equal to some constant c.\r\nAnalytically, we can see that all the outputs should be equal to\r\n1/n." }
		};

		public static IEnumerable<TestCaseData> TestCases
		{
			get
			{
				yield return new TestCaseData(DescKeysDictionary[DescKeyOne])
					.Returns(ExpectedDescKeysDictionary[DescKeyOne]);

				yield return new TestCaseData(DescKeysDictionary[DescKeyTwo])
					.Returns(ExpectedDescKeysDictionary[DescKeyTwo]);

				yield return new TestCaseData(DescKeysDictionary[DescKeyThree])
					.Returns(ExpectedDescKeysDictionary[DescKeyThree]);
			}
		}
	}
}
