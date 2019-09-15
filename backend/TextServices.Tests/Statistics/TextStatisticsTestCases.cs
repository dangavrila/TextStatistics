using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TextServices.Entities;

namespace TextServices.Tests.Statistics
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
	public class TextStatisticsTestCases : IEnumerable<TestCaseData>
	{
		private const string InputTextOne = "Chapter 2Linear AlgebraLinear algebra is a branch of mathematics that is widely used-throughout scienceand engineering^. Yet because linear algebra $$ is a form of continuous rather thandiscrete mathematics; many computer scientists # have little experience with it. Agood understanding of linear algebra is essential for understanding and workingwith many machine learning-algorithms, especially' deep learning algorithms. We`~therefore precede our introduction to deep learning with: a focused presentation ofthe key linear algebra prerequisites!If you are already /backslash familiar with_ linear algebra, \\feel free to skip this chapter. Ifyou [have] previous < experience > with these \"concepts\" but need a detailed reference &sheet to review key formulas (abc), we recommend The Matrix Cookbook (Petersen andPedersen, 2006). If you have had no exposure=at all to linear algebra, this chapterwill teach you enough to read this book, but we highly recommend @ that you alsoconsult another resource focused exclusively-on teaching/linear algebra, such asShilov (1977). This chapter completely omits many important linear ? algebra topicsthat are not essential for understanding deep learning.";
		private const string InputTextTwo = "3.5 Conditional Probability\r\nIn many cases, we are interested in the probability of some event, given that some\r\nother event has happened. This is called a conditional probability. We denote\r\nthe conditional probability that y = y given x = x as P(y = y | x = x)";
		private readonly Dictionary<string, TextStatisticsEntity> _expectedResultsDictionary;

		public TextStatisticsTestCases()
		{
			_expectedResultsDictionary = new Dictionary<string, TextStatisticsEntity>()
			{
				{ nameof(InputTextOne), new TextStatisticsEntity()
										{
											Paragraphs = 1,
											SpecialCharacterCount =  32,
											CharacterCount = 1195,
											Words = 166,
											Lines = 1,
											Hyphens = 3
										}
				},
				{ nameof(InputTextTwo), new TextStatisticsEntity()
										{
											Paragraphs = 3,
											SpecialCharacterCount = 7,
											CharacterCount = 259,
											Words = 49,
											Lines = 4
										}
				}
			};
		}

		public IEnumerator<TestCaseData> GetEnumerator()
		{
			yield return new TestCaseData(InputTextOne).Returns(_expectedResultsDictionary[nameof(InputTextOne)]);
			yield return new TestCaseData(InputTextTwo).Returns(_expectedResultsDictionary[nameof(InputTextTwo)]);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
