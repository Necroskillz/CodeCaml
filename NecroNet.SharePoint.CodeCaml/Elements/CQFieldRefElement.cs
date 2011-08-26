using System;
using NecroNet.SharePoint.CodeCaml.CamlBuilder;
using NecroNet.SharePoint.CodeCaml.ConstraintInterfaces;
using NecroNet.SharePoint.CodeCaml.Elements.Base;
using NecroNet.SharePoint.CodeCaml.Enums;

namespace NecroNet.SharePoint.CodeCaml.Elements
{
	public class CQFieldRefElement : CQElement, ICQFieldRefSetup
	{
		public CQFieldRefElement(string name)
		{
			Name = name;
		}

		public CQFieldRefElement(Guid id)
		{
			ID = id;
		}

		[CQAttribute]
		public string Name { get; set; }

		[CQAttribute]
		public Guid? ID { get; set; }

		[CQAttribute]
		public string Alias { get; set; }

		[CQAttribute]
		public bool? Ascending { get; set; }

		[CQAttribute]
		public string CreateURL { get; set; }

		[CQAttribute]
		public string DisplayName { get; set; }

		[CQAttribute]
		public bool? Explicit { get; set; }

		[CQAttribute]
		public string Format { get; set; }

		[CQAttribute]
		public string Key { get; set; }

		[CQAttribute]
		public string RefType { get; set; }

		[CQAttribute]
		public string ShowField { get; set; }

		[CQAttribute]
		public bool? TextOnly { get; set; }

		[CQAttribute]
		public CQFunctionType? Type { get; set; }

		[CQAttribute]
		public bool? LookupId { get; set; }

		protected override CQTag Tag
		{
			get { return CQTag.FieldRef; }
		}

		ICQFieldRefSetup ICQFieldRefSetup.Alias(string alias)
		{
			Alias = alias;
			return this;
		}

		ICQFieldRefSetup ICQFieldRefSetup.Ascending(bool ascending)
		{
			Ascending = ascending;
			return this;
		}

		ICQFieldRefSetup ICQFieldRefSetup.CreateURL(string createUrl)
		{
			CreateURL = createUrl;
			return this;
		}

		ICQFieldRefSetup ICQFieldRefSetup.DisplayName(string displayName)
		{
			DisplayName = displayName;
			return this;
		}

		ICQFieldRefSetup ICQFieldRefSetup.Explicit(bool @explicit)
		{
			Explicit = @explicit;
			return this;
		}

		ICQFieldRefSetup ICQFieldRefSetup.Format(string format)
		{
			Format = format;
			return this;
		}

		ICQFieldRefSetup ICQFieldRefSetup.Key(string key)
		{
			Key = key;
			return this;
		}

		ICQFieldRefSetup ICQFieldRefSetup.RefType(string refType)
		{
			RefType = refType;
			return this;
		}

		ICQFieldRefSetup ICQFieldRefSetup.ShowField(string showField)
		{
			ShowField = showField;
			return this;
		}

		ICQFieldRefSetup ICQFieldRefSetup.TextOnly(bool textOnly)
		{
			TextOnly = textOnly;
			return this;
		}

		ICQFieldRefSetup ICQFieldRefSetup.Type(CQFunctionType type)
		{
			Type = type;
			return this;
		}

		ICQFieldRefSetup ICQFieldRefSetup.LookupId(bool lookupId)
		{
			LookupId = lookupId;
			return this;
		}
	}
}