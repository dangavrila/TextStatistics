﻿using Amazon.DynamoDBv2.DataModel;

namespace TextWebServices.Models
{
	[DynamoDBTable("TextStatistics")]
	public class TextStatistics
	{
		[DynamoDBHashKey]
		public string Id { get; set; }

		public int Paragraphs { get; set; }

		public int SpecialCharacterCount { get; set; }

		public int CharacterCount { get; set; }

		public int Words { get; set; }

		public int Lines { get; set; }
	}
}
