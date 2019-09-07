using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextWebServices.TextServices
{
	public interface ISortText
	{
		IEnumerable<string> SortParagraphsAsc(string textBody);

		IEnumerable<string> SortParagraphsDesc(string textBody);
	}
}
