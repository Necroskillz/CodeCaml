using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NecroNet.SharePoint.CodeCaml.ConstraintInterfaces
{
	public interface ICQElement
	{
		/// <summary>
		/// Used internaly to get CAML markup from elements.
		/// </summary>
		string GetCaml();
	}
}
