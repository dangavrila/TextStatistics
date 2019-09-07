using System.Collections.Generic;

namespace TextWebServices.Interfaces
{
	public interface ISortText
	{
		IEnumerable<string> SortParagraphsAsc(string textBody);

		IEnumerable<string> SortParagraphsDesc(string textBody);
	}
}
