using System;

namespace TextServices.Entities
{
	public class TextStatisticsEntity: IEquatable<TextStatisticsEntity>
	{
		public int Id { get; set; }

		public int Paragraphs { get; set; }

		public int SpecialCharacterCount { get; set; }

		public int CharacterCount { get; set; }

		public int Words { get; set; }

		public int Lines { get; set; }

		public int Hyphens { get; set; }

		public bool Equals(TextStatisticsEntity other)
		{
			return other != null
			    && other.Id == Id
				&& other.CharacterCount == CharacterCount
				&& other.Hyphens == Hyphens
				&& other.Lines == Lines
				&& other.Paragraphs == Paragraphs
				&& other.SpecialCharacterCount == SpecialCharacterCount
				&& other.Words == Words;
		}
	}
}
