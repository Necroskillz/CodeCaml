using System;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using NecroNet.SharePoint.CodeCaml.ConstraintInterfaces;
using NecroNet.SharePoint.CodeCaml.Elements;
using NecroNet.SharePoint.CodeCaml.Enums;

namespace NecroNet.SharePoint.CodeCaml
{
	/// <summary>
	/// Provides API for building CAML queries.
	/// </summary>
	public static class CQ
	{
		private static readonly CQValue _predefinedValue = new CQValue();

		/// <summary>
		/// Inserts element with predefined value (Today, Now, Month, UserID).
		/// </summary>
		public static CQValue PredefinedValue
		{
			get { return _predefinedValue; }
		}

		/// <summary>
		/// Concatenates various query parts (e.g. Where, OrderBy, GroupBy) togather.
		/// </summary>
		public static string Concat(params string[] queryParts)
		{
			return String.Concat(queryParts);
		}

		/// <summary>
		/// Inserts &lt;OrderBy&gt; element with specified FieldRefs.
		/// </summary>
		public static string OrderBy(params ICQFieldRefSetup[] fieldRefs)
		{
			return new CQOrderByElement(fieldRefs).GetCaml();
		}

		/// <summary>
		/// Inserts &lt;OrderBy&gt; element with specified FieldRefs and specified options (attributes).
		/// </summary>
		public static string OrderBy(CQOrderByOption options, params ICQFieldRefSetup[] fieldRefs)
		{
			return new CQOrderByElement(fieldRefs)
			       	{
			       		Override = (options & CQOrderByOption.Override) != 0,
			       		UseIndexForOrderBy = (options & CQOrderByOption.UseIndexForOrderBy) != 0
			       	}.GetCaml();
		}

		/// <summary>
		/// Inserts &lt;GroupBy&gt; element with specified FieldRefs.
		/// </summary>
		public static string GroupBy(params ICQFieldRefSetup[] fieldRefs)
		{
			return new CQGroupByElement(fieldRefs).GetCaml();
		}

		/// <summary>
		/// Inserts &lt;GroupBy&gt; element with specified FieldRefs and specified options (attributes).
		/// </summary>
		public static string GroupBy(CQGroupByOption options, params ICQFieldRefSetup[] fieldRefs)
		{
			return new CQGroupByElement(fieldRefs) { Collapse = (options & CQGroupByOption.Collapse) != 0 }.GetCaml();
		}


		/// <summary>
		/// Inserts &lt;Where&gt; element with specified nested element.
		/// </summary>
		public static string Where(ICQElement element)
		{
			return new CQWhereElement(element).GetCaml();
		}

		/// <summary>
		/// Returns a set of FieldRefs to be used as ViewFields parameter of SharePoint query object.
		/// </summary>
		public static string ViewFields(params ICQFieldRefSetup[] fieldRefs)
		{
			var builder = new StringBuilder();
			foreach (var fieldRef in fieldRefs)
			{
				builder.Append(fieldRef.GetCaml());
			}

			return builder.ToString();
		}

		/// <summary>
		/// Returns &lt;Webs&gt; element with specified scope, to be used as Webs parameter of SharePoint data query.
		/// </summary>
		public static string Webs(CQQueryScope scope)
		{
			return new CQWebsElement(scope).GetCaml();
		}

		/// <summary>
		/// Returns &lt;List&gt; element to be inserted into Lists element.
		/// </summary>
		public static ICQListElement List(Guid id)
		{
			return new CQListElement(id);
		}

		/// <summary>
		/// Returns &lt;WithIndex&gt; element to be inserted into Lists element.
		/// </summary>
		public static ICQListElement WithIndex(Guid fieldId, string value)
		{
			return new CQWithIndexElement(fieldId, value);
		}

		/// <summary>
		/// Returns &lt;Lists&gt; element to be used as List parameter of SharePoint data query.
		/// </summary>
		public static CQListsElement Lists(params ICQListElement[] elements)
		{
			return new CQListsElement(elements);
		}

		/// <summary>
		/// Returns &lt;Lists&gt; element with specified attributes (configured by CQ.ListsAttributes), to be used as List parameter of SharePoint data query.
		/// </summary>
		public static CQListsElement Lists(ICQListsAttributesSetup attributes, params ICQListElement[] elements)
		{
			return new CQListsElement(attributes, elements);
		}

		/// <summary>
		/// Specifies attribute configuration for Lists().
		/// </summary>
		public static ICQListsAttributesSetup ListsAttributes
		{
			get
			{
				return new CQListsAttributes();
			}
		}

		/// <summary>
		/// Returns view attributes to be used as ViewAttributes parameter of SharePoint query.
		/// </summary>
		public static CQViewAttributes ViewAttributes
		{
			get
			{
				return new CQViewAttributes();
			}
		}

		/// <summary>
		/// Inserts &lt;FieldRef&gt; element with specified Name. Can be fluently configured.
		/// </summary>
		public static ICQFieldRefSetup FieldRef(string name)
		{
			return new CQFieldRefElement(name);
		}

		/// <summary>
		/// Inserts &lt;FieldRef&gt; element with specified ID. Can be fluently configured.
		/// </summary>
		public static ICQFieldRefSetup FieldRef(Guid id)
		{
			return new CQFieldRefElement(id);
		}

		/// <summary>
		/// Inserts &lt;Value&gt; element with specified value and type.
		/// </summary>
		public static CQValueElement Value(object value, string type)
		{
			return new CQValueElement(value.ToString(), type);
		}

		/// <summary>
		/// Inserts &lt;Value&gt; element with specified value and type.
		/// </summary>
		public static CQValueElement Value(object value, CQValueType type)
		{
			return new CQValueElement(value.ToString(), type.ToString());
		}

		/// <summary>
		/// Inserts &lt;Value&gt; element with specified value. Type will be 'Text'.
		/// </summary>
		public static CQValueElement Value(string value)
		{
			return new CQValueElement(value, CQValueType.Text.ToString());
		}

		/// <summary>
		/// Inserts &lt;Value&gt; element with specified value. Type will be 'Integer'.
		/// </summary>
		public static CQValueElement Value(int value)
		{
			return new CQValueElement(value.ToString(), CQValueType.Integer.ToString());
		}

		/// <summary>
		/// Inserts &lt;Value&gt; element with specified value. Type will be 'DateTime'.
		/// </summary>
		public static CQValueElement Value(DateTime value)
		{
			return new CQValueElement(value.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture), CQValueType.DateTime.ToString());
		}

		/// <summary>
		/// Inserts &lt;Value&gt; element with specified value and specifies whether to include time value in the comparison. Type will be 'DateTime'.
		/// </summary>
		public static CQValueElement Value(DateTime value, CQValueOption options)
		{
			return new CQValueElement(value.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture), CQValueType.DateTime.ToString(), (options & CQValueOption.IncludeTimeValue) != 0);
		}

		/// <summary>
		/// Inserts &lt;Value&gt; element with specified value. Type will be 'Bool'.
		/// </summary>
		public static CQValueElement Value(bool value)
		{
			return new CQValueElement(value.ToString().ToUpper(), CQValueType.Bool.ToString());
		}

		/// <summary>
		/// Inserts &lt;And&gt; element with specified nested elements.
		/// </summary>
		public static CQAndElement And(ICQElement left, ICQElement right)
		{
			return new CQAndElement(left, right);
		}

		/// <summary>
		/// Inserts &lt;Or&gt; element with specified nested elements.
		/// </summary>
		public static CQOrElement Or(ICQElement left, ICQElement right)
		{
			return new CQOrElement(left, right);
		}

		/// <summary>
		/// Inserts &lt;Membership&gt; element with specified type. FieldRefs are inserted with fluent API.
		/// </summary>
		public static ICQOperatorElementFieldRef Membership(string type)
		{
			return new CQMembershipElement(type);
		}

		/// <summary>
		/// Inserts &lt;Eq&gt; element. FieldRefs and Values are inserted with fluent API.
		/// </summary>
		public static ICQOperatorElement Eq
		{
			get
			{
				return new CQEqElement();
			}
		}

		/// <summary>
		/// Inserts &lt;Neq&gt; element. FieldRefs and Values are inserted with fluent API.
		/// </summary>
		public static ICQOperatorElement Neq
		{
			get
			{
				return new CQNeqElement();
			}
		}

		/// <summary>
		/// Inserts &lt;Leq&gt; element. FieldRefs and Values are inserted with fluent API.
		/// </summary>
		public static ICQOperatorElement Leq
		{
			get
			{
				return new CQLeqElement();
			}
		}

		/// <summary>
		/// Inserts &lt;Geq&gt; element. FieldRefs and Values are inserted with fluent API.
		/// </summary>
		public static ICQOperatorElement Geq
		{
			get
			{
				return new CQGeqElement();
			}
		}

		/// <summary>
		/// Inserts &lt;Lt&gt; element. FieldRefs and Values are inserted with fluent API.
		/// </summary>
		public static ICQOperatorElement Lt
		{
			get
			{
				return new CQLtElement();
			}
		}

		/// <summary>
		/// Inserts &lt;Gt&gt; element. FieldRefs and Values are inserted with fluent API.
		/// </summary>
		public static ICQOperatorElement Gt
		{
			get
			{
				return new CQGtElement();
			}
		}

		/// <summary>
		/// Inserts &lt;IsNull&gt; element. FieldRefs are inserted with fluent API.
		/// </summary>
		public static ICQOperatorElement IsNull
		{
			get
			{
				return new CQIsNullElement();
			}
		}

		/// <summary>
		/// Inserts &lt;IsNotNull&gt; element. FieldRefs and Values are inserted with fluent API.
		/// </summary>
		public static ICQOperatorElement IsNotNull
		{
			get
			{
				return new CQIsNotNullElement();
			}
		}

		/// <summary>
		/// Inserts &lt;Contains&gt; element. FieldRefs and Values are inserted with fluent API.
		/// </summary>
		public static ICQOperatorElement Contains
		{
			get
			{
				return new CQContainsElement();
			}
		}

		/// <summary>
		/// Inserts &lt;BeginsWith&gt; element. FieldRefs and Values are inserted with fluent API.
		/// </summary>
		public static ICQOperatorElement BeginsWith
		{
			get
			{
				return new CQBeginsWithElement();
			}
		}

		/// <summary>
		/// Inserts &lt;DateRangesOverlap&gt; element. FieldRefs and Values are inserted with fluent API.
		/// </summary>
		public static ICQOperatorElement DateRangesOverlap
		{
			get
			{
				return new CQDateRangesOverlapElement();
			}
		}

		/// <summary>
		/// Inserts &lt;Includes&gt; element. FieldRefs and Values are inserted with fluent API.
		/// </summary>
		public static ICQOperatorElement Includes
		{
			get
			{
				return new CQIncludesElement();
			}
		}

		/// <summary>
		/// Inserts &lt;NotIncludes&gt; element. FieldRefs and Values are inserted with fluent API.
		/// </summary>
		public static ICQOperatorElement NotIncludes
		{
			get
			{
				return new CQNotIncludesElement();
			}
		}

		/// <summary>
		/// Inserts &lt;In&gt; element. FieldRefs and Values collection are inserted with fluent API.
		/// </summary>
		public static ICQOperatorElement In
		{
			get
			{
				return new CQInElement();
			}
		}
	}
}
