using System;
using NecroNet.SharePoint.CodeCaml.ConstraintInterfaces;

namespace NecroNet.SharePoint.CodeCaml.Elements.Base
{
	public abstract class CQOperatorElement : CQElement, ICQOperatorElement
	{
		public ICQOperatorElement FieldRef(string name)
		{
			_elements.Add(CQ.FieldRef(name));
			return this;
		}

		public ICQOperatorElement FieldRef(Guid id)
		{
			_elements.Add(CQ.FieldRef(id));
			return this;
		}

		public ICQOperatorElement FieldRef(ICQFieldRefSetup element)
		{
			_elements.Add(element);
			return this;
		}

		public ICQOperatorElementValue Value(object value, string type)
		{
			_elements.Add(CQ.Value(value, type));
			return this;
		}

		public ICQOperatorElementValue Value(object value, CQValueType type)
		{
			_elements.Add(CQ.Value(value, type));
			return this;
		}

		public ICQOperatorElementValue Value(CQValueElement element)
		{
			_elements.Add(element);
			return this;
		}

		public ICQOperatorElementValue Value(string value)
		{
			_elements.Add(CQ.Value(value));
			return this;
		}

		public ICQOperatorElementValue Value(int value)
		{
			_elements.Add(CQ.Value(value));
			return this;
		}

		public ICQOperatorElementValue Value(DateTime value)
		{
			_elements.Add(CQ.Value(value));
			return this;
		}

		public ICQOperatorElementValue Value(DateTime value, CQValueOption options)
		{
			_elements.Add(CQ.Value(value, options));
			return this;
		}

		public ICQOperatorElementValue Value(bool value)
		{
			_elements.Add(CQ.Value(value));
			return this;
		}

		public ICQOperatorElementValue Values(params CQValueElement[] values)
		{
			_elements.Add(new CQValuesElement(values));
			return this;
		}
	}
}