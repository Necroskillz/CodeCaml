using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NecroNet.SharePoint.CodeCaml.CamlBuilder
{
	public class CamlTag
	{
		private const string SelfClosingTemplate = "<{0}{1} />";
		private const string NormalTemplate = "<{0}{1}>{2}</{0}>";
		private const string AttributeTemplate = "{0}='{1}'";

		public string Name { get; set; }
		public Dictionary<string, object> Attributes { get; set; }
		public string InnerText { get; set; }

		public CamlTag(string name)
		{
			Name = name;
			Attributes = new Dictionary<string, object>();
		}

		public void MergeAttribute(string name, object value)
		{
			if(value == null)
			{
				return;
			}

			Attributes.Add(name, GetValue(value));
		}

		private object GetValue(object value)
		{
			if(value is bool?)
			{
				return ((bool?) value).Value.ToString().ToUpper();
			}

			return value;
		}

		public override string ToString()
		{
			string attributes = string.Empty;

			if(Attributes.Count != 0)
			{
				var builder = new StringBuilder();
				foreach (var attribute in Attributes)
				{
					builder.Append(" ");
					builder.Append(string.Format(AttributeTemplate, attribute.Key, attribute.Value));
				}

				attributes = builder.ToString();
			}

			if(string.IsNullOrEmpty(InnerText))
			{
				return string.Format(SelfClosingTemplate, Name, attributes);
			}

			return string.Format(NormalTemplate, Name, attributes, InnerText);
		}

		public string GetAttributes()
		{
			var builder = new StringBuilder();
			foreach (var attribute in Attributes)
			{
				builder.Append(" ");
				builder.Append(string.Format(AttributeTemplate, attribute.Key, attribute.Value));
			}

			return builder.ToString().Trim();
		}
	}
}
