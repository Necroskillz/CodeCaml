using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace NecroNet.SharePoint.CodeCaml.Tests
{
	[TestFixture]
	public class QueryOptionsTests
	{
		private static readonly Guid FieldId = Guid.NewGuid();
		private const string FieldName = "FieldName";
		public string Expected { get; set; }

		[Test]
		public void ViewFields_ReturnsCorrectCaml()
		{
			Expected = string.Format("<FieldRef ID='{0}' /><FieldRef Name='{1}' />", FieldId, FieldName);

			var viewFields = CQ.ViewFields(CQ.FieldRef(FieldId), CQ.FieldRef(FieldName));

			Assert.That(viewFields, Is.EqualTo(Expected));
		}

		[Test]
		public void ViewAttributes_ReturnsCorrectCaml()
		{
			Expected = "Scope='Recursive' ModerationType='HideUnapproved'";

			var viewAttributes = CQ.ViewAttributes.Scope(CQViewScope.Recursive).Attribute("ModerationType", "HideUnapproved");

			Assert.That((string)viewAttributes, Is.EqualTo(Expected));
		}

		[Test]
		public void Webs_ReturnsCorrectCaml()
		{
			Expected = "<Webs Scope='SiteCollection' />";

			var webs = CQ.Webs(CQQueryScope.SiteCollection);

			Assert.That(webs, Is.EqualTo(Expected));
		}

		[Test]
		public void List_ReturnsCorrectCaml()
		{
			Expected = string.Format("<List ID='{0}' />", FieldId);

			var list = CQ.List(FieldId);

			Assert.That(list.GetCaml(), Is.EqualTo(Expected));
		}

		[Test]
		public void WithIndex_ReturnsCorrectCaml()
		{
			const string val = "val";

			Expected = string.Format("<WithIndex FieldId='{0}' Type='Text' Value='{1}' />", FieldId, val);

			var withIndex = CQ.WithIndex(FieldId, val);

			Assert.That(withIndex.GetCaml(), Is.EqualTo(Expected));
		}

		[Test]
		public void Lists_ReturnsCorrectCaml()
		{
			const string val = "val";

			Expected = string.Format("<Lists><List ID='{0}' /><WithIndex FieldId='{0}' Type='Text' Value='{1}' /></Lists>",
			                         FieldId, val);

			var lists = CQ.Lists(CQ.List(FieldId), CQ.WithIndex(FieldId, val));

			Assert.That(lists, Is.EqualTo(Expected));
		}

		[Test]
		public void Lists_WithAttributes_ReturnsCorrectCaml()
		{
			Expected =
				string.Format("<Lists ServerTemplate='104' BaseType='1' Hidden='TRUE' MaxListLimit='500'><List ID='{0}' /></Lists>", FieldId);

			var lists =
				CQ.Lists(
					CQ.ListsAttributes.BaseType(CQListBaseType.DocumentLibrary).Hidden(true).MaxListLimit(500).ServerTemplate(104),
					CQ.List(FieldId)
					);

			Assert.That(lists, Is.EqualTo(Expected));
		}
	}
}
