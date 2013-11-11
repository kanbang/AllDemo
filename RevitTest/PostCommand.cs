using System.IO;

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Diagnostics;
using System;
using RevitTest;

namespace Warrentech.Velo.RevitUI
{
	[Autodesk.Revit.Attributes.Transaction(TransactionMode.Manual)]
	[Autodesk.Revit.Attributes.Regeneration(RegenerationOption.Manual)]
	[Autodesk.Revit.Attributes.Journaling(JournalingMode.NoCommandData)]
	public class PostCommand : IExternalCommand
	{
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			var app = commandData.Application;
			var uidoc = app.ActiveUIDocument;
			var doc = uidoc.Document;
			PostCommandFrm frm = new PostCommandFrm(commandData, message, elements);
			frm.Show();
			return Result.Succeeded;
		}


	}
}