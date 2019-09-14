using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using TextServices.Interfaces;

namespace TextServices.Services
{
	public class SortService: ISortText
	{
		private delegate string PerformSorting(Dictionary<string, string> mappingDictionary,
			List<string> linesCollection);

		public IEnumerable<string> SortTextAscending(string textBody, out string sortedBodyText)
		{
			sortedBodyText = String.Empty;
			var linesList = new List<string>();

			var mappingTextLines = MapStringLines(textBody);

			PerformSorting sortingHandler = SortLinesAscendent;
			sortedBodyText = sortingHandler.Invoke(mappingTextLines, linesList);

			return linesList;
		}

		public IEnumerable<string> SortTextDescending(string textBody, out string sortedBodyText)
		{
			sortedBodyText = String.Empty;
			var linesList = new List<string>();

			var mappingTextLines = MapStringLines(textBody);

			PerformSorting sortingDelegate = SortLinesDescendent;
			sortedBodyText = sortingDelegate.Invoke(mappingTextLines, linesList);

			return linesList;
		}

		/// <summary>
		/// Splits a body of text into lines by carriage return special characters
		/// and then maps each line to it's initial letter, or more, if there happens to exist lines with same initial letter.
		/// </summary>
		/// <param name="textBody">Input text</param>
		/// <returns>A dictionary of initial letter(s) and lines.</returns>
		private Dictionary<string, string> MapStringLines(string textBody)
		{
			string[] lines = textBody.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

			Dictionary<string, string> mappingTextLines = new Dictionary<string, string>();
			for (var i = 0; i < lines.Length; i++)
			{
				var j = 1;
				while (j < lines[i].Length
				       && mappingTextLines.ContainsKey(lines[i].Substring(0, j)))
				{
					j++;
				}
				mappingTextLines[lines[i].Substring(0, j)] = lines[i];
			}

			return mappingTextLines;
		}

		private string SortLinesAscendent(Dictionary<string, string> mappingDictionary, List<string> linesCollection)
		{
			StringBuilder sb = new StringBuilder();
			foreach (var keyValuePair in mappingDictionary.ToImmutableSortedDictionary())
			{
				linesCollection.Add(keyValuePair.Value);
				sb.Append(keyValuePair.Value);
				sb.Append("\r\n");
			}

			var builtString = sb.ToString();

			return builtString.Substring(0, builtString.Length - 2);
		}

		private string SortLinesDescendent(Dictionary<string, string> mappingDictionary, List<string> linesCollection)
		{
			StringBuilder sb = new StringBuilder();
			var sortedLinesArray = mappingDictionary.ToImmutableSortedDictionary().Keys.ToArray();
			for (int i = sortedLinesArray.Length - 1; i >= 0; i--)
			{
				var stringLine = mappingDictionary[sortedLinesArray[i]];
				linesCollection.Add(stringLine);
				sb.Append(stringLine);
				sb.Append("\r\n");
			}

			var builtString = sb.ToString();

			return builtString.Substring(0, builtString.Length - 2);
		}
	}
}
