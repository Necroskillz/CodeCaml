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
