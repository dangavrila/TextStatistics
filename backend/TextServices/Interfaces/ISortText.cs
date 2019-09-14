using System.Collections.Generic;

namespace TextServices.Interfaces
{
	/// <summary>
	/// Public interface for exposing sorting functionality by the service
	/// </summary>
	public interface ISortText
	{
		/// <summary>
		/// Sorts a body of text by its lines in ascending order by its first letter(s).
		/// </summary>
		/// <param name="textBody">Text input</param>
		/// <param name="sortedBodyText">Body of text in sorted order</param>
		/// <returns>A read-only list of sorted lines of text</returns>
		IEnumerable<string> SortTextAscending(string textBody, out string sortedBodyText);

		/// <summary>
		/// Sorts a body of text by its lines in descendent order by its first letter(s).
		/// </summary>
		/// <param name="textBody">Text input</param>
		/// <param name="sortedBodyText">A read-only list of sorted lines of text</param>
		/// <returns></returns>
		IEnumerable<string> SortTextDescending(string textBody, out string sortedBodyText);
	}
}
