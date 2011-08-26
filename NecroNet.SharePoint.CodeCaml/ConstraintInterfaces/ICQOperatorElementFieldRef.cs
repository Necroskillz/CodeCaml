using System;

namespace NecroNet.SharePoint.CodeCaml.ConstraintInterfaces
{
	public interface ICQOperatorElementFieldRef : ICQElement
	{
		/// <summary>
		/// Inserts &lt;FieldRef&gt; element with specified Name.
		/// </summary>
		ICQOperatorElementFieldRef FieldRef(string name);

		/// <summary>
		/// Inserts &lt;FieldRef&gt; element with specified ID.
		/// </summary>
		ICQOperatorElementFieldRef FieldRef(Guid id);

		/// <summary>
		/// Inserts specified &lt;FieldRef&gt; element.
		/// </summary>
		ICQOperatorElementFieldRef FieldRef(ICQFieldRefSetup element);
	}
}