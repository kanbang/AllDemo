using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using System.Threading;
using System.Windows.Forms;
using AcadApp = Autodesk.AutoCAD.ApplicationServices.Application;

namespace Warrentech.Velo.VeloView
{
	public class FontChanger
	{
		DocumentCollection _creatNew = AcadApp.DocumentManager;
		FontChangeHelper _fontChangeHelper = new FontChangeHelper();
		Thread _thread;

		void OnDocumentCreateStartedHandler (object sender, DocumentCollectionEventArgs e)
		{
			Editor ed = AcadApp.DocumentManager.MdiActiveDocument.Editor;

			ed.WriteMessage("OnDocumentCreateStartedHandler");

			try {
				if (_thread != null) {
					_thread.Abort();
				}
				_thread = new Thread(new ThreadStart(_fontChangeHelper.Reportfont));
				_thread.Start();
			} catch {
			}
		}

		void DocumentCreatedHandler (object sender, DocumentCollectionEventArgs e)
		{
			if (_thread != null) {
				_thread.Abort();
			}

		}

		private void AddEvents ()
		{
			//把事件处理函数与相应的事件进行连接
			_creatNew.DocumentCreateStarted += OnDocumentCreateStartedHandler;
			_creatNew.DocumentCreated += DocumentCreatedHandler;
		}

		void DocumentManager_DocumentActivated(object sender, DocumentCollectionEventArgs e)
		{
			MessageBox.Show("DocumentManager_DocumentActivated");
		}

		public void RemoveEvents ()
		{
			//断开所有的事件处理函数
			_creatNew.DocumentCreateStarted -= OnDocumentCreateStartedHandler;
			_creatNew.DocumentCreated -= DocumentCreatedHandler;
		}
		public void StartCloseWindow()
		{
			AddEvents();
			try {
				if (_thread != null) {
					_thread.Abort();
				}
				_thread = new Thread(new ThreadStart(_fontChangeHelper.Reportfont));
				_thread.Start();
			} catch {
			}
		}
	}

}
