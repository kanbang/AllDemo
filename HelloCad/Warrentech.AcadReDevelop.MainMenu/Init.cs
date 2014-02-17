using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

[assembly: ExtensionApplication(typeof(Warrentech.AcadReDevelop.MainMenu.Init))]
namespace Warrentech.AcadReDevelop.MainMenu
{

	public class Init : IExtensionApplication
	{
		public void Initialize ()
		{
			//启动菜单
			Menus menus = new Menus();//Menus类就是创建菜单的那个
			menus.AddMenuCom();
			Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
			ed.WriteMessage("W.插件初始化完成。");
			
		}
		public void Terminate ()
		{
		}
	}
}
