using System.Text.RegularExpressions;
using TextServices.Entities;
using TextServices.Interfaces;

namespace TextServices.Services
{
	public class TextStatisticsService: IGenerateTextStatistics
	{
		private const string RxLineCountPattern = "[^\\r\\n]+";
		private const string RxParagraphCountPattern = "([.\\r|\\n|\\0]$)";
		private const string RxHyphensCountPattern = "(-)";
		private const string RxWordCountPattern = "(\\s*\\S+)";
		private const string RxCharCountPattern = "(.)";
		private const string RxSpecialCharCountPattern = "[@|!|?|//|#|$|%|\\^|&|\\[|\\]|\\(|\\)|\\_|\\-|=|;|:|\\'|\\\"|<|>|\\|\\/|\\`|~]";
		//[@|!|?|//|#|$|%|\^|&|\[|\]|\(|\)|\_|\-|=|;|:|\'|\"|<|>|\\|\/|\`|~]

		public TextStatisticsEntity GenerateStatistics(string textItem)
		{
			var result = new TextStatisticsEntity
			{
				Lines = GetConstructCount(textItem, RxLineCountPattern),
				Paragraphs = GetConstructCount(textItem, RxParagraphCountPattern),
				Hyphens = GetConstructCount(textItem, RxHyphensCountPattern),
				Words = GetConstructCount(textItem, RxWordCountPattern),
				CharacterCount = GetConstructCount(textItem, RxCharCountPattern),
				SpecialCharacterCount = GetConstructCount(textItem, RxSpecialCharCountPattern)
			};

			return result;
		}

		private int GetConstructCount(string text, string pattern, RegexOptions options = RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.ECMAScript)
		{
			int result = 0;
			var match = Regex.Match(text, pattern, options);

			while (match.Success)
			{
				result++;
				match = match.NextMatch();
			}

			return result;
		}
	}
}
