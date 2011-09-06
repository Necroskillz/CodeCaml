using System.Collections.Generic;
using NecroNet.SharePoint.CodeCaml.ConstraintInterfaces;
using NecroNet.SharePoint.CodeCaml.Elements.Base;
using NecroNet.SharePoint.CodeCaml.Enums;

namespace NecroNet.SharePoint.CodeCaml.Elements
{
	public class CQGroupByElement : CQElement
	{
		public CQGroupByElement(IEnumerable<ICQFieldRefSetup> fieldRefs)
		{
			foreach (var fieldRef in fieldRefs)
			{
				_elements.Add(fieldRef);
			}
		}

		protected override CQTag Tag
		{
			get { return CQTag.GroupBy; }
		}

		[CQAttribute]
		public bool? Collapse { get; set; }
	}
}
