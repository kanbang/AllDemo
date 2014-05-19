using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Customization;
using Autodesk.AutoCAD.Interop;
using Autodesk.AutoCAD.Runtime;
using Warrentech.Velo.EasyInstall;
using AutoApp = Autodesk.AutoCAD.ApplicationServices;
using AcadApp = Autodesk.AutoCAD.ApplicationServices.Application;
using Autodesk.AutoCAD.EditorInput;

[assembly: ExtensionApplication(typeof(Warrentech.Velo.VeloView.LoadVelo))]
[assembly: CommandClass(typeof(Warrentech.Velo.VeloView.LoadVelo))]
namespace Warrentech.Velo.VeloView
{
	public class LoadVelo : IExtensionApplication
	{
		FontChanger change = new FontChanger();

		public void Initialize()
		{
			change.AddEvents();
			SimulateHelper helper = new SimulateHelper();
			helper.Excute();

			AcadApplication comApp = AutoApp.Application.AcadApplication as AcadApplication;
			comApp.EndCommand += new _DAcadApplicationEvents_EndCommandEventHandler(EndCommand);
		}

		public void EndCommand(string commandName)
		{
			int index = commandName.IndexOf("V3");
			Document doc = AcadApp.DocumentManager.MdiActiveDocument;
			Editor ed = doc.Editor;
			ed.WriteMessage(string.Format("\nV3 {0|\n"),commandName);

			if (index >= 0) {
				index += 2;
				string docPath = commandName.Substring(index);
				if (!File.Exists(docPath)) {
					return;
				}
				doc = AutoApp.Application.DocumentManager.MdiActiveDocument;
				if (IsFileOpened(docPath)) {
					doc = SetDocumentActive(docPath);
				} else {
					doc = AcadApp.DocumentManager.Open(docPath, false);

				}
				doc.SendStringToExecute("saveas ", false, false, false);
			}

		}
		/// <summary>
		/// 判断文件是否在cad中打开了
		/// </summary>
		/// <param name="dwgFileFullName"></param>
		public static bool IsFileOpened(string dwgFileFullName)
		{
			AcadDocuments acadDocs = ((AcadApplication)AcadApp.AcadApplication).Documents;
			for (int i = 0; i < acadDocs.Count; i++) {
				if (acadDocs.Item(i).FullName.ToLower().Equals(dwgFileFullName.ToLower())) {
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// 设置当前激活的文档
		/// </summary>
		/// <param name="dwgDocName">带路径名</param>
		/// <returns>返回当前文档</returns>
		public static Document SetDocumentActive(string dwgDocName)
		{
			DocumentCollection docs = AcadApp.DocumentManager;
			foreach (Document doc in docs) {
				if (doc.Name.ToLower().Equals(dwgDocName.ToLower())) {
					if (!doc.IsActive) {
						AcadApp.DocumentManager.MdiActiveDocument = doc;
					}
					return doc;
				}
			}
			return AcadApp.DocumentManager.MdiActiveDocument;
		}

		#region IExtensionApplication 成员


		public void Terminate()
		{
			change.RemoveEvents();
		}

		#endregion
	}

}
