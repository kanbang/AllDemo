using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using System.Threading;

namespace Warrentech.Velo.VeloView
{
	public class FontChanger
	{
		DocumentCollection _creatNew = Application.DocumentManager;
		FontChangeHelper _fontChangeHelper = new FontChangeHelper();
		Thread _thread;

		void OnDocumentCreateStartedHandler (object sender, DocumentCollectionEventArgs e)
		{
			Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;

			ed.WriteMessage("OnDocumentCreateStartedHandler");

			try {
				if (Application.DocumentManager.MdiActiveDocument != null) {
					ed.WriteMessage("开始自动替换字体");
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
			if (Application.DocumentManager.MdiActiveDocument != null) {
				Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
				ed.WriteMessage("自动替换字体结束");
			}
		}

		public void AddEvents ()
		{
			//把事件处理函数与相应的事件进行连接
			_creatNew.DocumentCreateStarted += OnDocumentCreateStartedHandler;
			_creatNew.DocumentCreated += DocumentCreatedHandler;
		}

		public void RemoveEvents ()
		{
			//断开所有的事件处理函数
			_creatNew.DocumentCreateStarted -= OnDocumentCreateStartedHandler;
			_creatNew.DocumentCreated -= DocumentCreatedHandler;
		}
	}

}
