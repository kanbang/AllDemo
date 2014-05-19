using System;
using System.Collections.Generic;
using System.Text;
using Autodesk.AutoCAD.Runtime;
using AcadApp = Autodesk.AutoCAD.ApplicationServices.Application;

[assembly: CommandClass(typeof(Warrentech.Velo.VeloView.SaveAndQuitCommand))]
namespace Warrentech.Velo.VeloView
{
	public class SaveAndQuitCommand
	{
		const string Cmd_Save = "GCD_QSave";
		const string Cmd_Quit = "GCD_Quit";

		#region QSave
		public static Action<int> QuickSaveHandler;

		[CommandMethod(Cmd_Save, CommandFlags.Session)]
		public static void QuickSave()
		{
			Action<int> handler = QuickSaveHandler;
			if (handler != null) {
				handler(1);
			} else {
				AcadApp.DocumentManager.MdiActiveDocument.SendStringToExecute(".qsave ", false, false, false);
			}
		}
		#endregion

		#region Quit
		public static Action<int> QuitHandler;

		[CommandMethod(Cmd_Quit, CommandFlags.Session)]
		public static void Quit()
		{
			Action<int> handler = QuitHandler;
			if (handler != null) {
				handler(0);
			} else {
				AcadApp.DocumentManager.MdiActiveDocument.SendStringToExecute(".Quit ", false, false, false);
			}
		}
		#endregion
	}
}
