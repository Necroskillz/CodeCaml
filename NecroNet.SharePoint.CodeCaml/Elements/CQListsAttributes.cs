using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NecroNet.SharePoint.CodeCaml.ConstraintInterfaces;
using NecroNet.SharePoint.CodeCaml.Elements.Base;
using NecroNet.SharePoint.CodeCaml.Enums;

namespace NecroNet.SharePoint.CodeCaml.Elements
{
	public class CQListsAttributes : ICQListsAttributesSetup
	{
		[CQAttribute]
		public int? ServerTemplate { get; set; }

		[CQAttribute]
		public int? BaseType { get; set; }

		[CQAttribute]
		public bool? Hidden { get; set; }

		[CQAttribute]
		public int? MaxListLimit { get; set; }

		ICQListsAttributesSetup ICQListsAttributesSetup.ServerTemplate(int serverTemplate)
		{
			ServerTemplate = serverTemplate;
			return this;
		}

		ICQListsAttributesSetup ICQListsAttributesSetup.BaseType(CQListBaseType baseType)
		{
			BaseType = (int)baseType;
			return this;
		}

		ICQListsAttributesSetup ICQListsAttributesSetup.Hidden(bool includeHidden)
		{
			Hidden = includeHidden;
			return this;
		}

		ICQListsAttributesSetup ICQListsAttributesSetup.MaxListLimit(int maxListLimit)
		{
			MaxListLimit = maxListLimit;
			return this;
		}
	}
}
