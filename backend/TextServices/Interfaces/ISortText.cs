using System.Collections.Generic;

namespace TextServices.Interfaces
{
	public interface ISortText
	{
		IEnumerable<string> SortTextAscending(string textBody, out string sortedBodyText);

		IEnumerable<string> SortTextDescending(string textBody, out string sortedBodyText);
	}
}
