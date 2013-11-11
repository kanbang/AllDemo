using System.IO;

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Warrentech.Velo.RevitUI
{
	[Autodesk.Revit.Attributes.Transaction(TransactionMode.Manual)]
	[Autodesk.Revit.Attributes.Regeneration(RegenerationOption.Manual)]
	[Autodesk.Revit.Attributes.Journaling(JournalingMode.NoCommandData)]
	public class SimulateMouseClick : IExternalCommand
	{
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			var app = commandData.Application;
			var uidoc = app.ActiveUIDocument;
			var doc = uidoc.Document;
			IntPtr windowPtr = Process.GetCurrentProcess().MainWindowHandle;
			IntPtr btnSetPtr = WinApiHelper.GetControlInptr(windowPtr, "");
			List<RibbonPanel> list = commandData.Application.GetRibbonPanels("GICD");
			WinApiHelper.PostMessage1(btnSetPtr);
			btnSetPtr = WinApiHelper.GetControlInptr(windowPtr, "", btnSetPtr);
			WinApiHelper.PostMessage1(btnSetPtr);
			btnSetPtr = WinApiHelper.GetControlInptr(windowPtr, "", btnSetPtr);
			WinApiHelper.PostMessage1(btnSetPtr);
			btnSetPtr = WinApiHelper.GetControlInptr(windowPtr, "", btnSetPtr);
			WinApiHelper.PostMessage1(btnSetPtr);
			btnSetPtr = WinApiHelper.GetControlInptr(windowPtr, "", btnSetPtr);
			WinApiHelper.PostMessage1(btnSetPtr);
			btnSetPtr = WinApiHelper.GetControlInptr(windowPtr, "", btnSetPtr);
			WinApiHelper.PostMessage1(btnSetPtr);
			btnSetPtr = WinApiHelper.GetControlInptr(windowPtr, "", btnSetPtr);
			WinApiHelper.PostMessage1(btnSetPtr);
			btnSetPtr = WinApiHelper.GetControlInptr(windowPtr, "", btnSetPtr);
			WinApiHelper.PostMessage1(btnSetPtr);
			WinApiHelper.PostMessage1(btnSetPtr);
			btnSetPtr = WinApiHelper.GetControlInptr(windowPtr, "", btnSetPtr);
			WinApiHelper.PostMessage1(btnSetPtr);
			btnSetPtr = WinApiHelper.GetControlInptr(windowPtr, "", btnSetPtr);
			WinApiHelper.PostMessage1(btnSetPtr);
			btnSetPtr = WinApiHelper.GetControlInptr(windowPtr, "", btnSetPtr);
			WinApiHelper.PostMessage1(btnSetPtr);
			btnSetPtr = WinApiHelper.GetControlInptr(windowPtr, "", btnSetPtr);
			WinApiHelper.PostMessage1(btnSetPtr);
			btnSetPtr = WinApiHelper.GetControlInptr(windowPtr, "", btnSetPtr);
			WinApiHelper.PostMessage1(btnSetPtr);
			btnSetPtr = WinApiHelper.GetControlInptr(windowPtr, "", btnSetPtr);
			WinApiHelper.PostMessage1(btnSetPtr);
			btnSetPtr = WinApiHelper.GetControlInptr(windowPtr, "", btnSetPtr);
			WinApiHelper.PostMessage1(btnSetPtr);
			WinApiHelper.PostMessage1(btnSetPtr);
			btnSetPtr = WinApiHelper.GetControlInptr(windowPtr, "", btnSetPtr);
			WinApiHelper.PostMessage1(btnSetPtr);
			btnSetPtr = WinApiHelper.GetControlInptr(windowPtr, "", btnSetPtr);
			WinApiHelper.PostMessage1(btnSetPtr);
			btnSetPtr = WinApiHelper.GetControlInptr(windowPtr, "", btnSetPtr);
			WinApiHelper.PostMessage1(btnSetPtr);
			btnSetPtr = WinApiHelper.GetControlInptr(windowPtr, "", btnSetPtr);
			WinApiHelper.PostMessage1(btnSetPtr);
			btnSetPtr = WinApiHelper.GetControlInptr(windowPtr, "", btnSetPtr);
			WinApiHelper.PostMessage1(btnSetPtr);
			btnSetPtr = WinApiHelper.GetControlInptr(windowPtr, "", btnSetPtr);
			WinApiHelper.PostMessage1(btnSetPtr);
			btnSetPtr = WinApiHelper.GetControlInptr(windowPtr, "", btnSetPtr);
			WinApiHelper.PostMessage1(btnSetPtr);

			return Result.Succeeded;
		}


	}
}