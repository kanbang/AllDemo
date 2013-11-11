using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.Revit.UI;
using Warrentech.Velo.RevitUI;

namespace RevitTest
{
	public class ExternalApp : IExternalApplication
	{

		public Result OnStartup(UIControlledApplication application)
		{
			try {
				
				return Result.Succeeded;
			} catch (Exception ex) {
				TaskDialog.Show("CreateRibbonUI", ex.ToString());
				return Result.Succeeded;
			}
		}
		public Result OnShutdown(UIControlledApplication application)
		{
			return Result.Succeeded;
		}
	}
}
