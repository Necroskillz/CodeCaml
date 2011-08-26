using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NecroNet.SharePoint.CodeCaml.CamlBuilder;
using Assert = NUnit.Framework.Assert;

namespace NecroNet.SharePoint.CodeCaml.Tests
{
	[TestFixture]
	public class CamlTagTests
	{
		public string Expected { get; set; }

		[Test]
		public void CamlTag_CreatesSelfClosingTagWithSpecifiedName()
		{
			Expected = "<Tag />";
			
			var tag = new CamlTag("Tag");
			var caml = tag.ToString();

			Assert.That(caml, Is.EqualTo(Expected));
		}

		[Test]
		public void CamlTag_CreatesTagWithAttribute()
		{
			Expected = "<Tag Attr='a1' />";

			var tag = new CamlTag("Tag");
			tag.MergeAttribute("Attr", "a1");
			var caml = tag.ToString();

			Assert.That(caml, Is.EqualTo(Expected));
		}

		[Test]
		public void CamlTag_CreatesTagWithAttributes()
		{
			Expected = "<Tag Attr='a1' Xy='zz' />";

			var tag = new CamlTag("Tag");
			tag.MergeAttribute("Attr", "a1");
			tag.MergeAttribute("Xy", "zz");
			var caml = tag.ToString();

			Assert.That(caml, Is.EqualTo(Expected));
		}

		[Test]
		public void CamlTag_CreatesTagWithInnerValue()
		{
			Expected = "<Tag>x</Tag>";

			var tag = new CamlTag("Tag");
			tag.InnerText = "x";
			var caml = tag.ToString();

			Assert.That(caml, Is.EqualTo(Expected));
		}

		[Test]
		public void CamlTag_CreatesTagWithValueAndAttributes()
		{
			Expected = "<Tag Attr='a1' Xy='zz'>x</Tag>";

			var tag = new CamlTag("Tag");
			tag.MergeAttribute("Attr", "a1");
			tag.MergeAttribute("Xy", "zz");
			tag.InnerText = "x";
			var caml = tag.ToString();

			Assert.That(caml, Is.EqualTo(Expected));
		}

		[Test]
		public void CamlTag_CreatesTagWithInnerTag()
		{
			Expected = "<Tag><Tag2 /></Tag>";

			var tag = new CamlTag("Tag");
			var tag2 = new CamlTag("Tag2");
			tag.InnerText = tag2.ToString();
			var caml = tag.ToString();

			Assert.That(caml, Is.EqualTo(Expected));
		}
	}
}
