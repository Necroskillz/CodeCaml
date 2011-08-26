using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using NecroNet.SharePoint.CodeCaml.Elements;

namespace NecroNet.SharePoint.CodeCaml
{
	public class CQValue
	{
		internal CQValue()
		{
		}

		/// <summary>
		/// Inserts &lt;Now&gt; element.
		/// </summary>
		public CQValueElement Now()
		{
			return new CQValueElement(new CQNowElement(), CQValueType.DateTime.ToString());
		}

		/// <summary>
		/// Inserts &lt;Now&gt; element. Specifies if time value should be included in comparison.
		/// </summary>
		public CQValueElement Now(CQValueOption options)
		{
			return new CQValueElement(new CQNowElement(), CQValueType.DateTime.ToString(), (options & CQValueOption.IncludeTimeValue) != 0);
		}

		/// <summary>
		/// Inserts &lt;Today&gt; element.
		/// </summary>
		public CQValueElement Today()
		{
			return new CQValueElement(new CQTodayElement(), CQValueType.DateTime.ToString());
		}

		/// <summary>
		/// Inserts &lt;Today&gt; element with specified Offset.
		/// </summary>
		public CQValueElement Today(int offset)
		{
			return new CQValueElement(new CQTodayElement(offset), CQValueType.DateTime.ToString());
		}

		/// <summary>
		/// Inserts &lt;Month&gt; element.
		/// </summary>
		public CQValueElement Month()
		{
			return new CQValueElement(new CQMonthElement(), CQValueType.DateTime.ToString());
		}

		/// <summary>
		/// Inserts &lt;UserID&gt; element.
		/// </summary>
		public CQValueElement UserID()
		{
			return new CQValueElement(new CQUserIDElement(), CQValueType.Integer.ToString());
		}
	}
}
