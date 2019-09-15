using NUnit.Framework;
using System.Collections.Generic;

namespace TextServices.Tests.Sort
{
	/// <summary>
	/// Text cited from:
	/// @book{Goodfellow-et-al-2016,
	/// title={Deep Learning},
	/// author={Ian Goodfellow and Yoshua Bengio and Aaron Courville},
	/// publisher={MIT Press},
	/// note={\url{http://www.deeplearningbook.org}},
	/// year={2016}
	/// }
	/// </summary>
	public static class AscInputDataTestCases
	{
		private static readonly Dictionary<string, string> AscKeysDictionary = new Dictionary<string, string>()
		{
			{ AscKeyOne, "The fundamental difficulty\r\nin performing continuous\r\nmath on a digital computer\r\nis that we need to represent\r\ninfinitely many real numbers\r\nwith a finite number\r\nof bit patterns." },
			{ AscKeyTwo,  "Another highly damaging form of numerical error is overflow.\r\nOverflow occurs when numbers with large\r\nmagnitude are approximated as ∞ or −∞.\r\nFurther arithmetic will usually change these\r\ninfinite values into not-a-number values."},
			{ AscKeyThree, "Consider what happens when all the xi are equal to some constant c.\r\nAnalytically, we can see that all the outputs should be equal to\r\n1/n." }
		};

		private static readonly Dictionary<string, string> ExpectedAscKeysDictionary = new Dictionary<string, string>()
		{
			{ AscKeyOne, "in performing continuous\r\ninfinitely many real numbers\r\nis that we need to represent\r\nmath on a digital computer\r\nof bit patterns.\r\nThe fundamental difficulty\r\nwith a finite number" },
			{ AscKeyTwo, "Another highly damaging form of numerical error is overflow.\r\nFurther arithmetic will usually change these\r\ninfinite values into not-a-number values.\r\nmagnitude are approximated as ∞ or −∞.\r\nOverflow occurs when numbers with large" },
			{ AscKeyThree, "1/n.\r\nAnalytically, we can see that all the outputs should be equal to\r\nConsider what happens when all the xi are equal to some constant c." }
		};

		private const string AscKeyOne = "asc1";
		private const string AscKeyTwo = "asc2";
		private const string AscKeyThree = "asc3";

		public static IEnumerable<TestCaseData> TestCases
		{
			get
			{
				yield return new TestCaseData(AscKeysDictionary[AscKeyOne])
					.Returns(ExpectedAscKeysDictionary[AscKeyOne]);

				yield return new TestCaseData(AscKeysDictionary[AscKeyTwo])
					.Returns(ExpectedAscKeysDictionary[AscKeyTwo]);

				yield return new TestCaseData(AscKeysDictionary[AscKeyThree])
					.Returns(ExpectedAscKeysDictionary[AscKeyThree]);
			}
		}
	}
}
