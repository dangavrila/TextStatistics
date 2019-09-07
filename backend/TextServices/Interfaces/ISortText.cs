using System.Collections.Generic;

namespace TextServices.Interfaces
{
	public interface ISortText
	{
		IEnumerable<string> SortParagraphsAsc(string textBody);

		IEnumerable<string> SortParagraphsDesc(string textBody);
	}
}
