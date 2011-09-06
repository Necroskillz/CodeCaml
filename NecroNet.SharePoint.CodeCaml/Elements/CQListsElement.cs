using System.Collections.Generic;
using NecroNet.SharePoint.CodeCaml.ConstraintInterfaces;
using NecroNet.SharePoint.CodeCaml.Elements.Base;
using NecroNet.SharePoint.CodeCaml.Enums;

namespace NecroNet.SharePoint.CodeCaml.Elements
{
	public class CQListsElement : CQElement
	{
		protected override CQTag Tag
		{
			get { return CQTag.Lists; }
		}

		public CQListsElement(IEnumerable<ICQListElement> elements)
		{
			foreach (var element in elements)
			{
				_elements.Add(element);
			}
		}

		public CQListsElement(ICQListsAttributesSetup attributeSetup, IEnumerable<ICQListElement> elements) : this(elements)
		{
			var attributes = (CQListsAttributes) attributeSetup;

			ServerTemplate = attributes.ServerTemplate;
			BaseType = attributes.BaseType;
			Hidden = attributes.Hidden;
			MaxListLimit = attributes.MaxListLimit;
		}

		[CQAttribute]
		public int? ServerTemplate { get; set; }

		[CQAttribute]
		public int? BaseType { get; set; }

		[CQAttribute]
		public bool? Hidden { get; set; }

		[CQAttribute]
		public int? MaxListLimit { get; set; }
	}
}
