using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NecroNet.SharePoint.CodeCaml.CamlBuilder;
using NecroNet.SharePoint.CodeCaml.ConstraintInterfaces;
using NecroNet.SharePoint.CodeCaml.Elements.Base;
using NecroNet.SharePoint.CodeCaml.Enums;

namespace NecroNet.SharePoint.CodeCaml.Elements
{
	public class CQOrderByElement : CQElement
	{
		public CQOrderByElement(IEnumerable<ICQFieldRefSetup> fieldRefs)
		{
			foreach (var fieldRef in fieldRefs)
			{
				_elements.Add(fieldRef);
			}
		}

		protected override CQTag Tag
		{
			get { return CQTag.OrderBy; }
		}

		[CQAttribute]
		public bool? Override { get; set; }

		[CQAttribute]
		public bool? UseIndexForOrderBy { get; set; }
	}
}
