﻿using System;
using NecroNet.SharePoint.CodeCaml.ConstraintInterfaces;
using NecroNet.SharePoint.CodeCaml.Elements.Base;
using NecroNet.SharePoint.CodeCaml.Enums;

namespace NecroNet.SharePoint.CodeCaml.Elements
{
	public class CQListElement : CQElement, ICQListElement
	{
		protected override CQTag Tag
		{
			get { return CQTag.List; }
		}

		public CQListElement(Guid id)
		{
			ID = id;
		}

		[CQAttribute]
		public Guid ID { get; set; }
	}
}
