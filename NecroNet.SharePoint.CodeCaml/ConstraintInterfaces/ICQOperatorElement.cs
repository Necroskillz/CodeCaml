using System;
using NecroNet.SharePoint.CodeCaml.Elements;

namespace NecroNet.SharePoint.CodeCaml.ConstraintInterfaces
{
	public interface ICQOperatorElement : ICQOperatorElementValue
	{
		/// <summary>
		/// Inserts &lt;FieldRef&gt; element with specified Name.
		/// </summary>
		ICQOperatorElement FieldRef(string name);

		/// <summary>
		/// Inserts &lt;FieldRef&gt; element with specified ID.
		/// </summary>
		ICQOperatorElement FieldRef(Guid id);

		/// <summary>
		/// Inserts specified &lt;FieldRef&gt; element.
		/// </summary>
		ICQOperatorElement FieldRef(ICQFieldRefSetup element);

		/// <summary>
		/// Inserts &lt;Value&gt; element with specified value and type.
		/// </summary>
		ICQOperatorElementValue Value(object value, string type);

		/// <summary>
		/// Inserts &lt;Value&gt; element with specified value and type.
		/// </summary>
		ICQOperatorElementValue Value(object value, CQValueType type);

		/// <summary>
		/// Inserts specified &lt;Value&gt; element.
		/// </summary>
		ICQOperatorElementValue Value(CQValueElement element);

		/// <summary>
		/// Inserts &lt;Value&gt; element with specified value. Type will be 'Text'.
		/// </summary>
		ICQOperatorElementValue Value(string value);

		/// <summary>
		/// Inserts &lt;Value&gt; element with specified value. Type will be 'Integer'.
		/// </summary>
		ICQOperatorElementValue Value(int value);

		/// <summary>
		/// Inserts &lt;Value&gt; element with specified value. Type will be 'DateTime'.
		/// </summary>
		ICQOperatorElementValue Value(DateTime value);

		/// <summary>
		/// Inserts &lt;Value&gt; element with specified value and specifies whether to include time value in the comparison. Type will be 'DateTime'.
		/// </summary>
		ICQOperatorElementValue Value(DateTime value, CQValueOption options);

		/// <summary>
		/// Inserts &lt;Value&gt; element with specified value. Type will be 'Bool'.
		/// </summary>
		ICQOperatorElementValue Value(bool value);

		/// <summary>
		/// Inserts &lt;Values&gt; element with specified nested Value elements.
		/// </summary>
		ICQOperatorElementValue Values(params CQValueElement[] values);
	}
}