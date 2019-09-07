using System.Collections.Generic;

namespace TextServices.Entities
{
	public class TextEntity
	{
		public TextEntity()
		{
			Authors = new List<string>();
		}

		public string Id { get; set; }

		public string Title { get; set; }

		public List<string> Authors { get; set; }

		public string Body { get; set; }
	}
}
