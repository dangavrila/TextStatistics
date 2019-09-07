namespace TextWebServices.Entities
{
	public class TextStatisticsEntity
	{
		public int Id { get; set; }

		public int TextId { get; set; }

		public int Paragraphs { get; set; }

		public int SpecialCharacterCount { get; set; }

		public int CharacterCount { get; set; }

		public int Words { get; set; }

		public int Lines { get; set; }
	}
}
