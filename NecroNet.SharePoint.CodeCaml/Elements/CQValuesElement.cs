using System.Collections.Generic;
using NecroNet.SharePoint.CodeCaml.ConstraintInterfaces;
using NecroNet.SharePoint.CodeCaml.Elements.Base;
using NecroNet.SharePoint.CodeCaml.Enums;

namespace NecroNet.SharePoint.CodeCaml.Elements
{
	public class CQValuesElement : CQElement, ICQOperatorElementValue
	{
		public CQValuesElement(IEnumerable<CQValueElement> values)
		{
			foreach (var value in values)
			{
				_elements.Add(value);
			}
		}

		protected override CQTag Tag
		{
			get { return CQTag.Values; }
		}
	}
}
