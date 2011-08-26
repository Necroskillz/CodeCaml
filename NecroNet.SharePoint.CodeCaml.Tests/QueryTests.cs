using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using NUnit.Framework;

namespace NecroNet.SharePoint.CodeCaml.Tests
{
	[TestFixture]
	public class QueryTests
	{
		private static readonly Guid FieldId = Guid.NewGuid();
		private const string FieldName = "FieldName";
		public string Expected { get; set; }

		[Test]
		public void Query_Where()
		{
			const string val = "val";

			Expected = string.Format("<Where><Eq><FieldRef ID='{0}' /><Value Type='Text'>{1}</Value></Eq></Where>", FieldId, val);

			var query = CQ.Where(CQ.Eq.FieldRef(FieldId).Value(val));

			Assert.That(query, Is.EqualTo(Expected));
		}

		[Test]
		public void Query_Where_DateTime_Today()
		{
			var date = new DateTime(2000, 5, 6);

			Expected =
				string.Format("<Where><Or><Lt><FieldRef ID='{0}' /><Value Type='DateTime'><Today /></Value></Lt><Geq><FieldRef ID='{0}' /><Value Type='DateTime'>{1}</Value></Geq></Or></Where>", FieldId, SPUtility.CreateISO8601DateTimeFromSystemDateTime(date));

			var query = CQ.Where(CQ.Or(CQ.Lt.FieldRef(FieldId).Value(CQ.PredefinedValue.Today()), CQ.Geq.FieldRef(FieldId).Value(date)));

			Assert.That(query, Is.EqualTo(Expected));
		}

		[Test]
		public void Query_Where_DateTime_Now_Bool_IsNull()
		{
			var date = new DateTime(2000, 5, 6, 10, 30, 50);

			Expected =
				string.Format(
				"<Where>" +
					"<And>" +
						"<Leq>" +
							"<FieldRef ID='{0}' />" +
							"<Value Type='DateTime' IncludeTimeValue='TRUE'>{1}</Value>" +
						"</Leq>" +
						"<Or>" +
							"<Gt>" +
								"<FieldRef ID='{0}' />" +
								"<Value Type='DateTime' IncludeTimeValue='TRUE'><Now /></Value>" +
							"</Gt>" +
							"<And>" +
								"<IsNull>" +
									"<FieldRef ID='{0}' />" +
								"</IsNull>" +
								"<Neq>" +
									"<FieldRef ID='{0}' />" +
									"<Value Type='Bool'>TRUE</Value>" +
								"</Neq>" +
							"</And>" +
						"</Or>" +
					"</And>" +
				"</Where>", FieldId, SPUtility.CreateISO8601DateTimeFromSystemDateTime(date));

			var query = CQ.Where(
				CQ.And(
					CQ.Leq.FieldRef(FieldId).Value(date, CQValueOption.IncludeTimeValue),
					CQ.Or(
						CQ.Gt.FieldRef(FieldId).Value(CQ.PredefinedValue.Now(CQValueOption.IncludeTimeValue)),
						CQ.And(
							CQ.IsNull.FieldRef(FieldId),
							CQ.Neq.FieldRef(FieldId).Value(true)
							)
						)
					)
				);


			Assert.That(query, Is.EqualTo(Expected));
		}

		[Test]
		public void Query_Where_In_Now_TodayOffset()
		{
			Expected =
				string.Format("<Where><In><FieldRef ID='{0}' /><Values><Value Type='DateTime'><Today Offset='5' /></Value><Value Type='DateTime'><Now /></Value></Values></In></Where>", FieldId);

			var query = CQ.Where(CQ.In.FieldRef(FieldId).Values(CQ.PredefinedValue.Today(5), CQ.PredefinedValue.Now()));

			Assert.That(query, Is.EqualTo(Expected));
		}

		[Test]
		public void Query_Where_DateRangesOverlap_Month_IsNotNull()
		{
			Expected =
				string.Format("<Where><And><IsNotNull><FieldRef ID='{0}' /></IsNotNull><DateRangesOverlap><FieldRef ID='{0}' /><FieldRef ID='{0}' /><Value Type='DateTime'><Month /></Value></DateRangesOverlap></And></Where>", FieldId);

			var query = CQ.Where(CQ.And(CQ.IsNotNull.FieldRef(FieldId), CQ.DateRangesOverlap.FieldRef(FieldId).FieldRef(FieldId).Value(CQ.PredefinedValue.Month())));

			Assert.That(query, Is.EqualTo(Expected));
		}

		[Test]
		public void Query_Where_Contains_BeginsWith()
		{
			const string val = "val";
			const string val2 = "val2";
			const string type = "type";

			Expected =
				string.Format("<Where><Or><Contains><FieldRef ID='{0}' /><Value Type='Text'>{1}</Value></Contains><BeginsWith><FieldRef ID='{0}' /><Value Type='{2}'>{3}</Value></BeginsWith></Or></Where>", FieldId, val, type, val2);

			var query =
				CQ.Where(
					CQ.Or(
						CQ.Contains.FieldRef(FieldId).Value(val, CQValueType.Text),
						CQ.BeginsWith.FieldRef(FieldId).Value(val2, type)
						)
					);

			Assert.That(query, Is.EqualTo(Expected));
		}

		[Test]
		public void Query_Where_Includes_NotIncludes()
		{
			Expected =
				string.Format(
					"<Where><And><Includes><FieldRef ID='{0}' LookupId='TRUE' /><Value Type='Integer'><UserID /></Value></Includes><NotIncludes><FieldRef ID='{0}' /><Value Type='Integer'>2</Value></NotIncludes></And></Where>", FieldId);

			var query =
				CQ.Where(
					CQ.And(
						CQ.Includes.FieldRef(CQ.FieldRef(FieldId).LookupId(true)).Value(CQ.PredefinedValue.UserID()),
				        CQ.NotIncludes.FieldRef(FieldId).Value(2)
						)
					);

			Assert.That(query, Is.EqualTo(Expected));
		}

		[Test]
		public void Query_Where_Membership()
		{
			Expected = string.Format("<Where><Membership Type='CurrentUserGroups'><FieldRef ID='{0}' /></Membership></Where>", FieldId);

			var query = CQ.Where(CQ.Membership(CQMembershipType.CurrentUserGroups).FieldRef(FieldId));

			Assert.That(query, Is.EqualTo(Expected));
		}

		[Test]
		public void Query_OrderBy()
		{
			Expected = string.Format("<OrderBy Override='TRUE' UseIndexForOrderBy='TRUE'><FieldRef ID='{0}' /><FieldRef Name='{1}' /></OrderBy>", FieldId, FieldName);

			var query = CQ.OrderBy(CQOrderByOption.Override | CQOrderByOption.UseIndexForOrderBy, CQ.FieldRef(FieldId), CQ.FieldRef(FieldName));

			Assert.That(query, Is.EqualTo(Expected));
		}

		[Test]
		public void Query_Where_OrderBy()
		{
			Expected =
				string.Format(
					"<Where><Eq><FieldRef ID='{0}' /><Value Type='DateTime' IncludeTimeValue='TRUE'><Now /></Value></Eq></Where><OrderBy><FieldRef Name='{1}' /></OrderBy>", FieldId, FieldName);

			var query =
				CQ.Concat(
					CQ.Where(
						CQ.Eq.FieldRef(FieldId).Value(CQ.PredefinedValue.Now(CQValueOption.IncludeTimeValue))
						),
					CQ.OrderBy(CQ.FieldRef(FieldName))
					);

			Assert.That(query, Is.EqualTo(Expected));
		}

		[Test]
		public void Query_GroupBy()
		{
			Expected = string.Format("<GroupBy><FieldRef ID='{0}' /><FieldRef Name='{1}' /></GroupBy>", FieldId,
			                         FieldName);

			var query = CQ.GroupBy(CQ.FieldRef(FieldId), CQ.FieldRef(FieldName));

			Assert.That(query, Is.EqualTo(Expected));
		}

		[Test]
		public void Query_GroupBy_Collapse()
		{
			Expected = string.Format("<GroupBy Collapse='TRUE'><FieldRef ID='{0}' /><FieldRef Name='{1}' /></GroupBy>", FieldId,
									 FieldName);

			var query = CQ.GroupBy(CQGroupByOption.Collapse, CQ.FieldRef(FieldId), CQ.FieldRef(FieldName));

			Assert.That(query, Is.EqualTo(Expected));
		}
	}
}