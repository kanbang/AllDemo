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
		string _fileName = string.Empty;
		FontChanger _changer = new FontChanger();
		public void Initialize()
		{
			string commandLineString = System.Environment.CommandLine;
			// 参数格式：  #"c:\fdafd\fad f\fd fd.dwg"#
			Match rex = Regex.Match(commandLineString, @"#\""(?<fileName>[a-zA-Z]\:[\w\s\\a-zA-Z0-9_\\\-\.]+)\""#");
			if (rex.Success) {
				_fileName = rex.Groups["fileName"].Value;
				AcadApplication comApp = AutoApp.Application.AcadApplication as AcadApplication;
				comApp.EndCommand += new _DAcadApplicationEvents_EndCommandEventHandler(EndCommand);
			}
		}

		public void EndCommand(string commandName)
		{

			if (commandName.ToLower().Contains("commandline") || commandName.ToLower().Contains("ribbon")
				|| commandName.ToLower().Contains("jsexec")) {
				if (!File.Exists(_fileName)) {
					return;
				}
				SaveAs();
				AcadApplication comApp = AutoApp.Application.AcadApplication as AcadApplication;
				comApp.EndCommand -= new _DAcadApplicationEvents_EndCommandEventHandler(EndCommand);
			}

		}

		private void SaveAs()
		{
			SimulateHelper helper = new SimulateHelper();
			helper.Excute();
			_changer.AddEvents();

			if (File.Exists(_fileName)) {
			
				var doc=AutoApp.Application.DocumentManager.Open(_fileName,false);
				AutoApp.Application.DocumentManager.MdiActiveDocument = doc;
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
