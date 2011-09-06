using System;
using NecroNet.SharePoint.CodeCaml.ConstraintInterfaces;
using NecroNet.SharePoint.CodeCaml.Elements.Base;
using NecroNet.SharePoint.CodeCaml.Enums;

namespace NecroNet.SharePoint.CodeCaml.Elements
{
	public class CQWithIndexElement : CQElement, ICQListElement
	{
		protected override CQTag Tag
		{
			get { return CQTag.WithIndex; }
		}

		public CQWithIndexElement(Guid fieldId, string value)
		{
			FieldId = fieldId;
			Value = value;
			Type = CQValueType.Text.ToString();
		}

		[CQAttribute]
		public Guid FieldId { get; set; }

		[CQAttribute]
		public string Type { get; set; }

		[CQAttribute]
		public string Value { get; set; }
	}
}
