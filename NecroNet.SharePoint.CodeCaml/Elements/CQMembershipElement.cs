using System;
using NecroNet.SharePoint.CodeCaml.ConstraintInterfaces;
using NecroNet.SharePoint.CodeCaml.Elements.Base;
using NecroNet.SharePoint.CodeCaml.Enums;

namespace NecroNet.SharePoint.CodeCaml.Elements
{
	public class CQMembershipElement : CQElement, ICQOperatorElementFieldRef
	{
		public CQMembershipElement(string type)
		{
			Type = type;
		}

		[CQAttribute]
		public string Type { get; set; }

		protected override CQTag Tag
		{
			get { return CQTag.Membership; }
		}

		public ICQOperatorElementFieldRef FieldRef(string name)
		{
			_elements.Add(CQ.FieldRef(name));
			return this;
		}

		public ICQOperatorElementFieldRef FieldRef(Guid id)
		{
			_elements.Add(CQ.FieldRef(id));
			return this;
		}

		public ICQOperatorElementFieldRef FieldRef(ICQFieldRefSetup element)
		{
			_elements.Add(element);
			return this;
		}
	}
}
