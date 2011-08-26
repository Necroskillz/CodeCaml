using System.Collections.Generic;
using System.Linq;
using System.Text;
using NecroNet.SharePoint.CodeCaml.CamlBuilder;
using NecroNet.SharePoint.CodeCaml.ConstraintInterfaces;
using NecroNet.SharePoint.CodeCaml.Enums;

namespace NecroNet.SharePoint.CodeCaml.Elements.Base
{
	public abstract class CQElement : ICQElement
	{
		protected abstract CQTag Tag { get; }

		public string InnerText { get; set; }

		protected readonly List<ICQElement> _elements = new List<ICQElement>();

		/// <summary>
		/// Used internaly to get CAML markup from elements.
		/// </summary>
		public virtual string GetCaml()
		{
			var tag = new CamlTag(Tag.ToString());
			var properties = GetType().GetProperties();

			foreach (var property in properties)
			{
				var attribute = (CQAttributeAttribute)property.GetCustomAttributes(typeof(CQAttributeAttribute), true).FirstOrDefault();
				if (attribute == null) continue;

				var name = attribute.Name ?? property.Name;

				tag.MergeAttribute(name, property.GetValue(this, null));
			}

			if (_elements.Count != 0)
			{
				var builder = new StringBuilder();

				foreach (var element in _elements)
				{
					builder.Append(element.GetCaml());
				}

				tag.InnerText = builder.ToString();
			}
			else
			{
				tag.InnerText = InnerText;
			}

			return tag.ToString();
		}
	}
}