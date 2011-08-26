using NecroNet.SharePoint.CodeCaml.CamlBuilder;
using NecroNet.SharePoint.CodeCaml.ConstraintInterfaces;
using NecroNet.SharePoint.CodeCaml.Elements.Base;
using NecroNet.SharePoint.CodeCaml.Enums;

namespace NecroNet.SharePoint.CodeCaml.Elements
{
	public class CQValueElement : CQElement
	{
		internal CQValueElement()
		{
		}

		public CQValueElement(ICQElement element, string type)
		{
			_elements.Add(element);
			Type = type;
		}

		public CQValueElement(ICQElement element, string type, bool includeTimeValue)
		{
			_elements.Add(element);
			Type = type;
			IncludeTimeValue = includeTimeValue;
		}

		public CQValueElement(string value, string type)
		{
			InnerText = value;
			Type = type;
		}

		public CQValueElement(string value, string type, bool includeTimeValue)
		{
			InnerText = value;
			Type = type;
			IncludeTimeValue = includeTimeValue;
		}

		[CQAttribute]
		public string Type { get; set; }

		[CQAttribute]
		public bool? IncludeTimeValue { get; set; }

		protected override CQTag Tag
		{
			get { return CQTag.Value; }
		}
	}
}