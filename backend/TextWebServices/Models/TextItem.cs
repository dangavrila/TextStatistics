using System.Collections.Generic;
using Amazon.DynamoDBv2.DataModel;

namespace TextWebServices.Models
{
	[DynamoDBTable("TextsCollection")]
	public class TextItem
	{
		[DynamoDBHashKey]
		public string Id { get; set; }

		[DynamoDBProperty]
		public string Title { get; set; }

		[DynamoDBProperty("Authors")]
		public List<string> Authors { get; set; }

		[DynamoDBProperty]
		public string Body { get; set; }
	}
}
