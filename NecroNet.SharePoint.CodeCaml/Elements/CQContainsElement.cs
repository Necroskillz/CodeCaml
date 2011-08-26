using NecroNet.SharePoint.CodeCaml.Elements.Base;
using NecroNet.SharePoint.CodeCaml.Enums;

namespace NecroNet.SharePoint.CodeCaml.Elements
{
	public class CQContainsElement : CQOperatorElement
	{
		protected override CQTag Tag
		{
			get { return CQTag.Contains; }
		}
	}
}