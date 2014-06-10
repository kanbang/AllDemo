using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Customization;
using Autodesk.AutoCAD.Runtime;
using AutoApp = Autodesk.AutoCAD.ApplicationServices;
using AcadApp = Autodesk.AutoCAD.ApplicationServices.Application;
using Autodesk.AutoCAD.EditorInput;
using System.Text.RegularExpressions;
using Autodesk.AutoCAD.Interop;

[assembly: ExtensionApplication(typeof(Warrentech.Velo.VeloView.LoadVelo))]
[assembly: CommandClass(typeof(Warrentech.Velo.VeloView.LoadVelo))]
namespace Warrentech.Velo.VeloView
{
	public class LoadVelo : IExtensionApplication
	{
		static string _fileName = string.Empty;
		static FontChanger _changer = new FontChanger();
		static Document _doc;
		static System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();
		public void Initialize()
		{
			string commandLineString = System.Environment.CommandLine;
			// 参数格式：  #"c:\fdafd\fad f\fd fd.dwg"#
			Match rex = Regex.Match(commandLineString, @"#\""(?<fileName>[a-zA-Z]\:[\w\s\\a-zA-Z0-9_\\\-\.\~]+)\""#");
			if (rex.Success) {
				_timer = new System.Windows.Forms.Timer();
				_timer.Tick += new EventHandler(_timer_Tick);
				_timer.Start();
				_changer.StartCloseWindow();
				_fileName = rex.Groups["fileName"].Value;
				AcadApplication comApp = AutoApp.Application.AcadApplication as AcadApplication;
				comApp.EndCommand += new _DAcadApplicationEvents_EndCommandEventHandler(EndCommand);
			}
		}

		void _timer_Tick(object sender, EventArgs e)
		{
			if (File.Exists(_fileName) && AutoApp.Application.DocumentManager.MdiActiveDocument != null) {
				_timer.Stop();
				_doc = AutoApp.Application.DocumentManager.Open(_fileName, false);
				AutoApp.Application.DocumentManager.MdiActiveDocument.SendStringToExecute("CustomSaveAs ", true, false, true);
			}
		}

		public void EndCommand(string commandName)
		{
			Debug.WriteLine(commandName);
			if (commandName.ToLower().Contains("commandline")) {
			} else if (commandName.ToLower().Contains("成功地生成")) {
				Quit();
			}
		}

		private static void Quit()
		{
			AutoApp.Application.DocumentManager.MdiActiveDocument.SendStringToExecute("_quit ", true, false, true);
			Console.WriteLine("5S exit");
			_timer = new System.Windows.Forms.Timer();
			_timer.Interval = 10000;
			_timer.Tick += new EventHandler(KillProcess);
			_timer.Start();
			AutoApp.Application.DocumentManager.MdiActiveDocument.SendStringToExecute("KillProgress ", true, false, true);
		}
		[CommandMethod("KillProgress", CommandFlags.Session)]
		public static void KillProgress()
		{
			SimulateHelper.KillProcess(Process.GetCurrentProcess());
		}
		static void KillProcess(object sender, EventArgs e)
		{
			if (AutoApp.Application.DocumentManager.MdiActiveDocument == null) {
				SimulateHelper.KillProcess(Process.GetCurrentProcess());
			}
		}
		[CommandMethod("CustomSaveAs", CommandFlags.Session)]
		public static void CustomSaveAs()
		{
			if (_doc != null) {
				SetActive(_doc);
				AutoApp.Application.DocumentManager.MdiActiveDocument.SendStringToExecute("tsaveas ", true, false, true);
				SimulateHelper helper = new SimulateHelper();
				helper.Excute();
				Quit();
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
