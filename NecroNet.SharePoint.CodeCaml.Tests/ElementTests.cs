using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NecroNet.SharePoint.CodeCaml.Elements;

namespace NecroNet.SharePoint.CodeCaml.Tests
{
	[TestFixture]
	public class ElementTests
	{
		private static readonly Guid FieldId = Guid.NewGuid();
		private const string FieldName = "FieldName";
		public string Expected { get; set; }

		[Test]
		public void CQFieldRefElement_GetCaml_ReturnsCorrectCaml()
		{
			var element = new CQFieldRefElement(FieldName);
			var element2 = new CQFieldRefElement(FieldId);
			var element3 = new CQFieldRefElement(FieldId);
			element3.Alias = "alias";
			element3.Ascending = true;
			element3.CreateURL = "url";
			element3.DisplayName = "display";
			element3.Explicit = false;
			element3.Format = "format";
			element3.Key = "Primary";
			element3.Nullable = true;
			element3.LookupId = true;
			element3.RefType = "ref";
			element3.ShowField = "show";
			element3.TextOnly = false;
			element3.Type = CQFunctionType.COUNT;

			Expected = "<FieldRef Name='" + FieldName + "' />";

			Assert.That(element.GetCaml(), Is.EqualTo(Expected));

			Expected = "<FieldRef ID='" + FieldId + "' />";

			Assert.That(element2.GetCaml(), Is.EqualTo(Expected));

			Expected = "<FieldRef ID='" + FieldId +
			           "' Alias='alias' Ascending='TRUE' CreateURL='url' DisplayName='display' Explicit='FALSE' Format='format' Key='Primary' Nullable='TRUE' RefType='ref' ShowField='show' TextOnly='FALSE' Type='COUNT' LookupId='TRUE' />";

			Assert.That(element3.GetCaml(), Is.EqualTo(Expected));
		}

		[Test]
		public void CQValueElement_GetCaml_ReturnsCorrectCaml()
		{
			var value = new CQValueElement("val", CQValueType.Text.ToString());
			var value2 = new CQValueElement("val2", CQValueType.DateTime.ToString(), true);

			Expected = "<Value Type='Text'>val</Value>";

			Assert.That(value.GetCaml(), Is.EqualTo(Expected));

			Expected = "<Value Type='DateTime' IncludeTimeValue='TRUE'>val2</Value>";

			Assert.That(value2.GetCaml(), Is.EqualTo(Expected));
		}

		[Test]
		public void CQBeginsWithElement_GetCaml_ReturnsCorrectCaml()
		{
			const string op = "BeginsWith";
			const string val = "val";
			Expected = string.Format("<{0}><FieldRef ID='{1}' /><Value Type='Text'>{2}</Value></{0}>", op, FieldId, val);

			var element = new CQBeginsWithElement();
			element.FieldRef(FieldId).Value(val);

			Assert.That(element.GetCaml(), Is.EqualTo(Expected));
		}

		[Test]
		public void CQContainsElement_GetCaml_ReturnsCorrectCaml()
		{
			const string op = "Contains";
			const string val = "val";
			Expected = string.Format("<{0}><FieldRef ID='{1}' /><Value Type='Text'>{2}</Value></{0}>", op, FieldId, val);

			var element = new CQContainsElement();
			element.FieldRef(FieldId).Value(val);

			Assert.That(element.GetCaml(), Is.EqualTo(Expected));
		}

		[Test]
		public void CQEqElement_GetCaml_ReturnsCorrectCaml()
		{
			const string op = "Eq";
			const string val = "val";
			Expected = string.Format("<{0}><FieldRef ID='{1}' /><Value Type='Text'>{2}</Value></{0}>", op, FieldId, val);

			var element = new CQEqElement();
			element.FieldRef(FieldId).Value(val);

			Assert.That(element.GetCaml(), Is.EqualTo(Expected));
		}

		[Test]
		public void CQGeqElement_GetCaml_ReturnsCorrectCaml()
		{
			const string op = "Geq";
			const string val = "val";
			Expected = string.Format("<{0}><FieldRef ID='{1}' /><Value Type='Text'>{2}</Value></{0}>", op, FieldId, val);

			var element = new CQGeqElement();
			element.FieldRef(FieldId).Value(val);

			Assert.That(element.GetCaml(), Is.EqualTo(Expected));
		}

		[Test]
		public void CQGtElement_GetCaml_ReturnsCorrectCaml()
		{
			const string op = "Gt";
			const string val = "val";
			Expected = string.Format("<{0}><FieldRef ID='{1}' /><Value Type='Text'>{2}</Value></{0}>", op, FieldId, val);

			var element = new CQGtElement();
			element.FieldRef(FieldId).Value(val);

			Assert.That(element.GetCaml(), Is.EqualTo(Expected));
		}

		[Test]
		public void CQIncludesElement_GetCaml_ReturnsCorrectCaml()
		{
			const string op = "Includes";
			const string val = "val";
			Expected = string.Format("<{0}><FieldRef ID='{1}' /><Value Type='Text'>{2}</Value></{0}>", op, FieldId, val);

			var element = new CQIncludesElement();
			element.FieldRef(FieldId).Value(val);

			Assert.That(element.GetCaml(), Is.EqualTo(Expected));
		}

		[Test]
		public void CQIsNullElement_GetCaml_ReturnsCorrectCaml()
		{
			const string op = "IsNull";
			Expected = string.Format("<{0}><FieldRef ID='{1}' /></{0}>", op, FieldId);

			var element = new CQIsNullElement();
			element.FieldRef(FieldId);

			Assert.That(element.GetCaml(), Is.EqualTo(Expected));
		}

		[Test]
		public void CQIsNotNullElement_GetCaml_ReturnsCorrectCaml()
		{
			const string op = "IsNotNull";
			Expected = string.Format("<{0}><FieldRef ID='{1}' /></{0}>", op, FieldId);

			var element = new CQIsNotNullElement();
			element.FieldRef(FieldId);

			Assert.That(element.GetCaml(), Is.EqualTo(Expected));
		}

		[Test]
		public void CQLeqElement_GetCaml_ReturnsCorrectCaml()
		{
			const string op = "Leq";
			const string val = "val";
			Expected = string.Format("<{0}><FieldRef ID='{1}' /><Value Type='Text'>{2}</Value></{0}>", op, FieldId, val);

			var element = new CQLeqElement();
			element.FieldRef(FieldId).Value(val);

			Assert.That(element.GetCaml(), Is.EqualTo(Expected));
		}

		[Test]
		public void CQLtElement_GetCaml_ReturnsCorrectCaml()
		{
			const string op = "Lt";
			const string val = "val";
			Expected = string.Format("<{0}><FieldRef ID='{1}' /><Value Type='Text'>{2}</Value></{0}>", op, FieldId, val);

			var element = new CQLtElement();
			element.FieldRef(FieldId).Value(val);

			Assert.That(element.GetCaml(), Is.EqualTo(Expected));
		}

		[Test]
		public void CQNeqElement_GetCaml_ReturnsCorrectCaml()
		{
			const string op = "Neq";
			const string val = "val";
			Expected = string.Format("<{0}><FieldRef ID='{1}' /><Value Type='Text'>{2}</Value></{0}>", op, FieldId, val);

			var element = new CQNeqElement();
			element.FieldRef(FieldId).Value(val);

			Assert.That(element.GetCaml(), Is.EqualTo(Expected));
		}

		[Test]
		public void CQNotIncludesElement_GetCaml_ReturnsCorrectCaml()
		{
			const string op = "NotIncludes";
			const string val = "val";
			Expected = string.Format("<{0}><FieldRef ID='{1}' /><Value Type='Text'>{2}</Value></{0}>", op, FieldId, val);

			var element = new CQNotIncludesElement();
			element.FieldRef(FieldId).Value(val);

			Assert.That(element.GetCaml(), Is.EqualTo(Expected));
		}

		[Test]
		public void CQDateRangesOverlapElement_GetCaml_ReturnsCorrectCaml()
		{
			const string op = "DateRangesOverlap";
			const string val = "val";
			Expected = string.Format("<{0}><FieldRef ID='{1}' /><FieldRef Name='{3}' /><Value Type='Text'>{2}</Value></{0}>", op, FieldId, val, FieldName);

			var element = new CQDateRangesOverlapElement();
			element.FieldRef(FieldId).FieldRef(FieldName).Value(val);

			Assert.That(element.GetCaml(), Is.EqualTo(Expected));
		}

		[Test]
		public void CQInElement_GetCaml_ReturnsCorrectCaml()
		{
			const string op = "In";
			const string val = "val";
			const string val2 = "val2";
			Expected = string.Format("<{0}><FieldRef ID='{1}' /><Values><Value Type='Text'>{2}</Value><Value Type='Text'>{3}</Value></Values></{0}>", op, FieldId, val, val2);

			var element = new CQInElement();
			element.FieldRef(FieldId).Values(CQ.Value(val), CQ.Value(val2));

			Assert.That(element.GetCaml(), Is.EqualTo(Expected));
		}

		[Test]
		public void CQNowElement_GetCaml_ReturnsCorrectCaml()
		{
			var element = new CQNowElement();

			Expected = "<Now />";

			Assert.That(element.GetCaml(), Is.EqualTo(Expected));
		}

		[Test]
		public void CQTodayElement_GetCaml_ReturnsCorrectCaml()
		{
			var element = new CQTodayElement();
			var element2 = new CQTodayElement(10);

			Expected = "<Today />";

			Assert.That(element.GetCaml(), Is.EqualTo(Expected));

			Expected = "<Today Offset='10' />";

			Assert.That(element2.GetCaml(), Is.EqualTo(Expected));
		}

		[Test]
		public void CQMonthElement_GetCaml_ReturnsCorrectCaml()
		{
			Expected = "<Month />";

			var element = new CQMonthElement();

			Assert.That(element.GetCaml(), Is.EqualTo(Expected));
		}

		[Test]
		public void CQUserIDElement_GetCaml_ReturnsCorrectCaml()
		{
			Expected = "<UserID />";

			var element = new CQUserIDElement();

			Assert.That(element.GetCaml(), Is.EqualTo(Expected));
		}

		[Test]
		public void CQAndElement_GetCaml_ReturnsCorrectCaml()
		{
			const string val = "val";
			const string val2 = "val2";

			Expected =
				string.Format(
					"<And><Neq><FieldRef ID='{0}' /><Value Type='Text'>{1}</Value></Neq><Eq><FieldRef ID='{0}' /><Value Type='Text'>{2}</Value></Eq></And>",
					FieldId, val, val2);

			var left = new CQNeqElement();
			left.FieldRef(FieldId).Value(val);

			var right = new CQEqElement();
			right.FieldRef(FieldId).Value(val2);

			var element = new CQAndElement(left, right);

			Assert.That(element.GetCaml(), Is.EqualTo(Expected));
		}

		[Test]
		public void CQOrElement_GetCaml_ReturnsCorrectCaml()
		{
			const string val = "val";
			const string val2 = "val2";

			Expected =
				string.Format(
					"<Or><Neq><FieldRef ID='{0}' /><Value Type='Text'>{1}</Value></Neq><Eq><FieldRef ID='{0}' /><Value Type='Text'>{2}</Value></Eq></Or>",
					FieldId, val, val2);

			var left = new CQNeqElement();
			left.FieldRef(FieldId).Value(val);

			var right = new CQEqElement();
			right.FieldRef(FieldId).Value(val2);

			var element = new CQOrElement(left, right);

			Assert.That(element.GetCaml(), Is.EqualTo(Expected));
		}

		[Test]
		public void CQWhereElement_GetCaml_ReturnsCorrectCaml()
		{
			const string val = "val";
			const string val2 = "val2";

			Expected =
				string.Format(
					"<Where><Or><Neq><FieldRef ID='{0}' /><Value Type='Text'>{1}</Value></Neq><Eq><FieldRef ID='{0}' /><Value Type='Text'>{2}</Value></Eq></Or></Where>",
					FieldId, val, val2);

			var left = new CQNeqElement();
			left.FieldRef(FieldId).Value(val);

			var right = new CQEqElement();
			right.FieldRef(FieldId).Value(val2);

			var element = new CQWhereElement(new CQOrElement(left, right));

			Assert.That(element.GetCaml(), Is.EqualTo(Expected));
		}

		[Test]
		public void CQMembershiplement_GetCaml_ReturnsCorrectCaml()
		{
			var element = new CQMembershipElement(CQMembershipType.CurrentUserGroups);
			element.FieldRef(FieldId);

			var element2 = new CQMembershipElement(CQMembershipType.SPWebAllUsers);
			element2.FieldRef(FieldName);

			var element3 = new CQMembershipElement(CQMembershipType.SPWebUsers);
			element3.FieldRef(CQ.FieldRef(FieldId));

			Expected = string.Format("<Membership Type='CurrentUserGroups'><FieldRef ID='{0}' /></Membership>", FieldId);

			Assert.That(element.GetCaml(), Is.EqualTo(Expected));

			Expected = string.Format("<Membership Type='SPWeb.AllUsers'><FieldRef Name='{0}' /></Membership>", FieldName);

			Assert.That(element2.GetCaml(), Is.EqualTo(Expected));

			Expected = string.Format("<Membership Type='SPWeb.Users'><FieldRef ID='{0}' /></Membership>", FieldId);

			Assert.That(element3.GetCaml(), Is.EqualTo(Expected));
		}

		[Test]
		public void CQOrderByElement_GetCaml_ReturnsCorretCaml()
		{
			Expected = string.Format("<OrderBy><FieldRef ID='{0}' /></OrderBy>", FieldId);

			var fieldRef = new CQFieldRefElement(FieldId);
			var orderBy = new CQOrderByElement(new[] {fieldRef});

			Assert.That(orderBy.GetCaml(), Is.EqualTo(Expected));
		}
	}
}
