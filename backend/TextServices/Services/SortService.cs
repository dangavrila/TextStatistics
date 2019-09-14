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
		public IEnumerable<string> SortTextAscending(string textBody, out string sortedBodyText)
		{
			sortedBodyText = String.Empty;
			var paragraphs = new List<string>();

			string[] textLines = textBody.Split(new char[]{'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);

			var mappingTextLines = MapStringLines(textLines);

			StringBuilder sb = new StringBuilder(sortedBodyText);
			foreach (var keyValuePair in mappingTextLines.ToImmutableSortedDictionary())
			{
				paragraphs.Add(keyValuePair.Value);
				sb.Append(keyValuePair.Value);
				sb.Append("\r\n");
			}

			var builtString = sb.ToString();

			sortedBodyText = builtString.Substring(0, builtString.Length - 2);

			return paragraphs;
		}

		public IEnumerable<string> SortTextDescending(string textBody, out string sortedBodyText)
		{
			sortedBodyText = String.Empty;
			var paragraphs = new List<string>();

			string[] textLines = textBody.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

			var mappingTextLines = MapStringLines(textLines);

			StringBuilder sb = new StringBuilder(sortedBodyText);
			var sortedLinesArray = mappingTextLines.ToImmutableSortedDictionary().Keys.ToArray();
			for (int i = sortedLinesArray.Length - 1; i >= 0; i--)
			{
				var stringLine = mappingTextLines[sortedLinesArray[i]];
				paragraphs.Add(stringLine);
				sb.Append(stringLine);
				sb.Append("\r\n");
			}

			sortedBodyText = sb.ToString();

			return paragraphs;
		}

		private Dictionary<string, string> MapStringLines(string[] lines)
		{
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
	}
}
