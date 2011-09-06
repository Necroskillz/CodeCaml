using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.Utilities;
using NUnit.Framework;
using NecroNet.SharePoint.CodeCaml.Elements;

namespace NecroNet.SharePoint.CodeCaml.Tests
{
	[TestFixture]
	public class HelpersTests
	{
		private static readonly Guid FieldId = Guid.NewGuid();
		private const string FieldName = "FieldName";

		[Test]
		public void CQFieldRef_Create_Name()
		{
			var fieldRef = CQ.FieldRef(FieldName) as CQFieldRefElement;

			Assert.That(fieldRef, Is.Not.Null);
			Assert.That(fieldRef.Name, Is.EqualTo(FieldName));
		}

		[Test]
		public void CQFieldRef_Create_FluentApiSetsAttributes()
		{
			const string alias = "alias";
			const string url = "url";
			const string displayName = "display";
			const string format = "format";
			const string key = "Primary";
			const string refType = "ref";
			const string showField = "show";

			var fieldRef = CQ.FieldRef(FieldId)
				.Alias(alias)
				.Ascending(true)
				.CreateURL(url)
				.DisplayName(displayName)
				.Explicit(true)
				.Format(format)
				.Key(key)
				.LookupId(true)
				.Nullable(true)
				.RefType(refType)
				.ShowField(showField)
				.TextOnly(true)
				.Type(CQFunctionType.AVG) as CQFieldRefElement;

			Assert.That(fieldRef, Is.Not.Null);
			Assert.That(fieldRef.ID, Is.EqualTo(FieldId));
			Assert.That(fieldRef.Alias, Is.EqualTo(alias));
			Assert.That(fieldRef.CreateURL, Is.EqualTo(url));
			Assert.That(fieldRef.DisplayName, Is.EqualTo(displayName));
			Assert.That(fieldRef.Format, Is.EqualTo(format));
			Assert.That(fieldRef.Key, Is.EqualTo(key));
			Assert.That(fieldRef.RefType, Is.EqualTo(refType));
			Assert.That(fieldRef.ShowField, Is.EqualTo(showField));
			Assert.That(fieldRef.Ascending, Is.True);
			Assert.That(fieldRef.Explicit, Is.True);
			Assert.That(fieldRef.Nullable, Is.True);
			Assert.That(fieldRef.LookupId, Is.True);
			Assert.That(fieldRef.TextOnly, Is.True);
			Assert.That(fieldRef.Type, Is.EqualTo(CQFunctionType.AVG));
		}

		[Test]
		public void CQValue_Create_String()
		{
			const string val = "val";

			var value = CQ.Value(val);

			Assert.That(value.InnerText, Is.EqualTo(val));
			Assert.That(value.Type, Is.EqualTo(CQValueType.Text.ToString()));
		}

		[Test]
		public void CQValue_Create_Int()
		{
			const int val = 1;

			var value = CQ.Value(val);

			Assert.That(value.InnerText, Is.EqualTo(val.ToString()));
			Assert.That(value.Type, Is.EqualTo(CQValueType.Integer.ToString()));
		}

		[Test]
		public void CQValue_Create_DateTime()
		{
			var val = DateTime.Now;

			var value = CQ.Value(val);

			Assert.That(value.InnerText, Is.EqualTo(SPUtility.CreateISO8601DateTimeFromSystemDateTime(val)));
			Assert.That(value.Type, Is.EqualTo(CQValueType.DateTime.ToString()));
		}

		[Test]
		public void CQValue_Create_DateTimeIncludeTime()
		{
			var val = DateTime.Now;

			var value = CQ.Value(val, CQValueOption.IncludeTimeValue);

			Assert.That(value.InnerText, Is.EqualTo(SPUtility.CreateISO8601DateTimeFromSystemDateTime(val)));
			Assert.That(value.Type, Is.EqualTo(CQValueType.DateTime.ToString()));
			Assert.That(value.IncludeTimeValue, Is.True);
		}

		[Test]
		public void CQValue_Create_ObjectCQValueType()
		{
			object val = "0x0120";

			var value = CQ.Value(val, CQValueType.ContentTypeId);

			Assert.That(value.InnerText, Is.EqualTo(val));
			Assert.That(value.Type, Is.EqualTo(CQValueType.ContentTypeId.ToString()));
		}

		[Test]
		public void CQValue_Create_ObjectString()
		{
			object val = "val";
			const string type = "type";

			var value = CQ.Value(val, type);

			Assert.That(value.InnerText, Is.EqualTo(val));
			Assert.That(value.Type, Is.EqualTo(type));
		}

		[Test]
		public void CQValue_Create_Bool()
		{
			const bool val = true;

			var value = CQ.Value(val);

			Assert.That(value.InnerText, Is.EqualTo(val.ToString().ToUpper()));
			Assert.That(value.Type, Is.EqualTo(CQValueType.Bool.ToString()));
		}
	}
}
