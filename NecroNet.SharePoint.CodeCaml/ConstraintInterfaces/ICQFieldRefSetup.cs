namespace NecroNet.SharePoint.CodeCaml.ConstraintInterfaces
{
	public interface ICQFieldRefSetup : ICQElement
	{
		ICQFieldRefSetup Alias(string alias);
		ICQFieldRefSetup Ascending(bool ascending);
		ICQFieldRefSetup CreateURL(string createUrl);
		ICQFieldRefSetup DisplayName(string displayName);
		ICQFieldRefSetup Explicit(bool @explicit);
		ICQFieldRefSetup Format(string format);
		ICQFieldRefSetup Key(string key);
		ICQFieldRefSetup RefType(string refType);
		ICQFieldRefSetup ShowField(string showField);
		ICQFieldRefSetup TextOnly(bool textOnly);
		ICQFieldRefSetup Type(CQFunctionType type);
		ICQFieldRefSetup LookupId(bool lookupId);
	}
}