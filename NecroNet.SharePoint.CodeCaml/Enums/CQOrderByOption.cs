using System;

namespace NecroNet.SharePoint.CodeCaml
{
	[Flags]
	public enum CQOrderByOption
	{
		Override = 0x01,
		UseIndexForOrderBy = 0x02
	}
}