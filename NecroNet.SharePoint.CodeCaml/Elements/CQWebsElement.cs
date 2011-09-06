using NecroNet.SharePoint.CodeCaml.Elements.Base;
using NecroNet.SharePoint.CodeCaml.Enums;

namespace NecroNet.SharePoint.CodeCaml.Elements
{
	public class CQWebsElement : CQElement
	{
		protected override CQTag Tag
		{
			get { return CQTag.Webs; }
		}

		public CQWebsElement(CQQueryScope scope)
		{
			Scope = scope;
		}

		[CQAttribute]
		public CQQueryScope Scope { get; set; }
	}
}
