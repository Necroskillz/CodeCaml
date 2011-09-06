using NecroNet.SharePoint.CodeCaml.CamlBuilder;

namespace NecroNet.SharePoint.CodeCaml.Elements
{
	public class CQViewAttributes
	{
		private readonly CamlTag _attributes = new CamlTag("ViewAttributes");

		/// <summary>
		/// Inserts view attribute 'Scope' with specified value.
		/// </summary>
		public CQViewAttributes Scope(CQViewScope scope)
		{
			_attributes.MergeAttribute("Scope", scope.ToString());
			return this;
		}

		/// <summary>
		/// Inserts view attribute with specified name and value.
		/// </summary>
		public CQViewAttributes Attribute(string name, object value)
		{
			_attributes.MergeAttribute(name, value);
			return this;
		}

		public static implicit operator string(CQViewAttributes viewAttributes)
		{
			return viewAttributes._attributes.GetAttributes();
		}
	}
}
