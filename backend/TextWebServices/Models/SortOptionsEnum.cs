using System;

namespace TextWebServices.Models
{
	[Flags]
	public enum SortOptionsEnum: short
	{
		ASC = 0,
		DESC = 1,
		NTILE = 2
	}
}
