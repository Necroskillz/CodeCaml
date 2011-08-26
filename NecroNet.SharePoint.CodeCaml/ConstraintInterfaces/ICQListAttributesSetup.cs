using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NecroNet.SharePoint.CodeCaml.Enums;

namespace NecroNet.SharePoint.CodeCaml.ConstraintInterfaces
{
	public interface ICQListsAttributesSetup
	{
		ICQListsAttributesSetup ServerTemplate(int serverTemplate);
		ICQListsAttributesSetup BaseType(CQListBaseType baseType);
		ICQListsAttributesSetup Hidden(bool includeHidden);
		ICQListsAttributesSetup MaxListLimit(int maxListLimit);
	}
}
