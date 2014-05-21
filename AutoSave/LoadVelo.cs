using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Customization;
using Autodesk.AutoCAD.Interop;
using Autodesk.AutoCAD.Runtime;
using AutoApp = Autodesk.AutoCAD.ApplicationServices;
using AcadApp = Autodesk.AutoCAD.ApplicationServices.Application;
using Autodesk.AutoCAD.EditorInput;
using System.Text.RegularExpressions;

[assembly: ExtensionApplication(typeof(Warrentech.Velo.VeloView.LoadVelo))]
[assembly: CommandClass(typeof(Warrentech.Velo.VeloView.LoadVelo))]
namespace Warrentech.Velo.VeloView
{
	public class LoadVelo : IExtensionApplication
	{
		static string _fileName = string.Empty;
		static FontChanger _changer = new FontChanger();
		static Document _doc;
		public void Initialize()
		{
			string commandLineString = System.Environment.CommandLine;
			// 参数格式：  #"c:\fdafd\fad f\fd fd.dwg"#
			Match rex = Regex.Match(commandLineString, @"#\""(?<fileName>[a-zA-Z]\:[\w\s\\a-zA-Z0-9_\\\-\.\~]+)\""#");
			if (rex.Success) {
				_changer.StartCloseWindow();
				_fileName = rex.Groups["fileName"].Value;
				AcadApplication comApp = AutoApp.Application.AcadApplication as AcadApplication;
				comApp.EndCommand += new _DAcadApplicationEvents_EndCommandEventHandler(EndCommand);
			}
		}

		public void EndCommand(string commandName)
		{

			if (commandName.ToLower().Contains("ribbon")) {
				if (File.Exists(_fileName)) {
					_doc = AutoApp.Application.DocumentManager.Open(_fileName, false);
					AutoApp.Application.DocumentManager.MdiActiveDocument.SendStringToExecute("CustomSaveAs ", true, false, true);
				}
			} else if (commandName.ToLower().Contains("保存成功")) {
				SimulateHelper.KillProcess(Process.GetCurrentProcess());
			}
		}

		[CommandMethod("CustomSaveAs", CommandFlags.Session)]
		public static void CustomSaveAs()
		{
			if (_doc != null) {
				SetActive(_doc);
				AutoApp.Application.DocumentManager.MdiActiveDocument.SendStringToExecute("saveas ", true, false, true);
				SimulateHelper helper = new SimulateHelper();
				helper.Excute();
			}
		}

		private static void SetActive(Document orgionDoc)
		{
			if (AutoApp.Application.DocumentManager.MdiActiveDocument != orgionDoc) {
				AutoApp.Application.DocumentManager.MdiActiveDocument = orgionDoc;
			}
		}

		#region IExtensionApplication 成员


		public void Terminate()
		{
			_changer.RemoveEvents();
		}

		#endregion
	}

}
