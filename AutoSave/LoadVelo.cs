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
using System.Xml;
using System.Reflection;

[assembly: ExtensionApplication(typeof(Warrentech.Velo.VeloView.LoadVelo))]
[assembly: CommandClass(typeof(Warrentech.Velo.VeloView.LoadVelo))]
namespace Warrentech.Velo.VeloView
{
	public class LoadVelo : IExtensionApplication
	{
		static string _fileName = string.Empty;
		static FontChanger _changer=new FontChanger(string.Empty);
		static Document _doc;
		public void Initialize()
		{
			string commandLineString = System.Environment.CommandLine;
			// 参数格式：  #"c:\fdafd\fad f\fd fd.dwg"#
			Match rex = Regex.Match(commandLineString, @"#\""(?<fileName>[a-zA-Z]\:[\w\s\\a-zA-Z0-9_\\\-\.\~]+)\""#");
			if (rex.Success) {
				string closeWindowName = GetAppConfigValue("CloseWindowNameContent");
				_changer = new FontChanger(closeWindowName);
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

		#region GetAppConfigValue
		internal static string GetAppConfigValue(string appKey)
		{
			XmlDocument xDoc = new XmlDocument();
			try {
				xDoc.Load(GetAppConfigFilePath());
				XmlNode xNode;
				XmlElement xElem;
				xNode = xDoc.SelectSingleNode("//appSettings");
				xElem = (XmlElement)xNode.SelectSingleNode("//add[@key='" + appKey + "']");
				if (xElem != null)
					return xElem.GetAttribute("value");
				else
					return "";
			} catch  {
				return "";
			}
		}
		private static string GetAppConfigFilePath()
		{
			string directoryName = Path.Combine(GetDllDirPath(), "bin");
			//string directoryName = GetDllPath();
			string logFilePath = Path.Combine(directoryName, "app.config");
			if (!Directory.Exists(directoryName)) {
				Directory.CreateDirectory(directoryName);
			}
			if (!File.Exists(logFilePath)) {
				File.Create(logFilePath).Close();
			}
			return logFilePath;
		}
		internal static string GetDllDirPath()
		{
			string dllPath = "";
			try {
				var executingAssembly = Assembly.GetExecutingAssembly();//获取当前Dll的相关信息。
				return Path.GetDirectoryName(executingAssembly.Location);
			} catch {
			}
			return dllPath;
		}
		#endregion

	}

}
