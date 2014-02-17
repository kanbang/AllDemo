using System;
using System.Collections.Specialized;
using System.Data;

using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Interop;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Windows;
using Autodesk.AutoCAD.ApplicationServices;

[assembly: CommandClass(typeof(Warrentech.AcadReDevelop.MainMenu.Menus))]
namespace Warrentech.AcadReDevelop.MainMenu
{
	public class Menus
	{
		static bool IsAutoChangeFont = false;
		FontChanger _fontChanger = new FontChanger();

		public void AddMenuCom ()
		{
			//COM方式获取AutoCAD应用程序对象
			AcadApplication acadApp = (AcadApplication)Application.AcadApplication;
			//为AutoCAD添加一个新的菜单 主菜单
			AcadPopupMenu mainMenu = acadApp.MenuGroups.Item(0).Menus.Add("W.插件");
			//声明一个AutoCAD弹出菜单项，用于获取添加的菜单项对象
			AddTestMenu(mainMenu);
			AddFontChangerMenu(mainMenu);
			AddPileFoundationMenu(mainMenu);

			//将定义的菜单显示在AutoCAD菜单栏的最后
			mainMenu.InsertInMenuBar(acadApp.MenuBar.Count + 1);
		}
		/// <summary>
		/// 添加桩基信息的菜单
		/// </summary>
		/// <param name="mainMenu"></param>
		private static void AddPileFoundationMenu (AcadPopupMenu mainMenu)
		{
			AcadPopupMenuItem popMenuItemPileFoundation;
			//在新建的菜单中添加一个一级菜单 桩基
			AcadPopupMenu popMenuPileFoundation = mainMenu.AddSubMenu(mainMenu.Count + 1, "桩基功能 ");

			//添加子菜单
			popMenuItemPileFoundation = popMenuPileFoundation.AddMenuItem(popMenuPileFoundation.Count + 1, "桩信息", "GetPileInfo ");
			popMenuItemPileFoundation.HelpString = "读取桩的基本信息";//状态栏提示信息   
			popMenuPileFoundation.AddSeparator(popMenuPileFoundation.Count + 1);

			//添加子菜单
			popMenuItemPileFoundation = popMenuPileFoundation.AddMenuItem(popMenuPileFoundation.Count + 1, "桩位置", "GetPileCoordinate ");
			popMenuItemPileFoundation.HelpString = "选取区域，读取桩的坐标";//状态栏提示信息   
			popMenuPileFoundation.AddSeparator(popMenuPileFoundation.Count + 1);


			//添加一个分隔条以区分不同类型的命令
			mainMenu.AddSeparator(mainMenu.Count + 1);
		}
		/// <summary>
		/// 添加字体自动替换的菜单
		/// </summary>
		/// <param name="mainMenu"></param>
		private static void AddFontChangerMenu (AcadPopupMenu mainMenu)
		{
			//声明一个AutoCAD弹出菜单项，用于获取添加的菜单项对象
			AcadPopupMenuItem popMenuItemFont;
			//在新建的菜单中添加一个一级菜单
			AcadPopupMenu popMenuFont = mainMenu.AddSubMenu(mainMenu.Count + 1, "字体替换 ");

			//添加子菜单
			popMenuItemFont = popMenuFont.AddMenuItem(popMenuFont.Count + 1, "开启", "StartFontChange ");
			popMenuItemFont.HelpString = "开启字体自动替换";//状态栏提示信息   
			popMenuFont.AddSeparator(popMenuFont.Count + 1);

			//添加子菜单
			popMenuItemFont = popMenuFont.AddMenuItem(popMenuFont.Count + 1, "关闭", "StopFontChange ");
			popMenuItemFont.HelpString = "关闭字体自动替换";//状态栏提示信息   
			popMenuFont.AddSeparator(popMenuFont.Count + 1);

			//添加一个分隔条以区分不同类型的命令
			mainMenu.AddSeparator(mainMenu.Count + 1);
		}

		/// <summary>
		/// 添加测试菜单
		/// </summary>
		/// <param name="mainMenu"></param>
		private static void AddTestMenu (AcadPopupMenu mainMenu)
		{
			AcadPopupMenuItem popMenuItemTest;
			//在新建的菜单中添加一个一级菜单
			AcadPopupMenu popMenuTest = mainMenu.AddSubMenu(mainMenu.Count + 1, "测试功能 ");

			//添加子菜单
			popMenuItemTest = popMenuTest.AddMenuItem(popMenuTest.Count + 1, "欢迎", "HelloWorld ");
			popMenuItemTest.HelpString = "欢迎";//状态栏提示信息   
			popMenuTest.AddSeparator(popMenuTest.Count + 1);

			//添加子菜单
			popMenuItemTest = popMenuTest.AddMenuItem(popMenuTest.Count + 1, "图层信息", "GetLayerPro ");
			popMenuItemTest.HelpString = "图层信息";//状态栏提示信息   
			popMenuTest.AddSeparator(popMenuTest.Count + 1);

			//添加一个分隔条以区分不同类型的命令
			mainMenu.AddSeparator(mainMenu.Count + 1);
		}

		#region 测试功能

		[CommandMethod("HelloWorld")]
		public void HelloWorld ()
		{
			Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
			ed.WriteMessage("Hello World 测试");
		}

		[CommandMethod("GetLayerPro")]
		public static void GetLayerPro ()
		{
			Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
			//得到当前文档图形数据库        
			Database db = HostApplicationServices.WorkingDatabase;
			using (Transaction trans = db.TransactionManager.StartTransaction()) {
				//获取数据库的图层表对象                
				LayerTable lt = (LayerTable)trans.GetObject(db.LayerTableId, OpenMode.ForRead);
				//循环遍历每个图层                 
				foreach (ObjectId layerId in lt) {
					LayerTableRecord ltr = (LayerTableRecord)trans.GetObject(layerId, OpenMode.ForRead);
					if (ltr != null) {
						Autodesk.AutoCAD.Colors.Color layerColor = ltr.Color;
						ed.WriteMessage("\n图层名称为：" + ltr.Name);

						ed.WriteMessage("\n图层颜色为：" + layerColor.ToString());
					}
				}
				trans.Commit();
			}
		}

		#endregion

		#region 测试功能

		[CommandMethod("StartFontChange")]
		public void StartFontChange ()
		{
			Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;

			if (IsAutoChangeFont) {
				ed.WriteMessage("已开启自动替换字体功能");
			} else {
				IsAutoChangeFont = true;
				_fontChanger.AddEvents();
				ed.WriteMessage("开启自动替换字体功能成功");
			}
		}

		[CommandMethod("StopFontChange")]
		public void StopFontChange ()
		{
			Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;

			if (IsAutoChangeFont) {
				IsAutoChangeFont = false;
				_fontChanger.RemoveEvents();
				ed.WriteMessage("关闭自动替换字体功能成功");
			} else {
				ed.WriteMessage("已关闭自动替换字体功能");
			}
		}

		#endregion

		#region 桩基功能
		[CommandMethod("GetPileInfo")]
		public void GetPileInfo ()
		{
			Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
			ed.WriteMessage("读取桩的基本信息");
		}
		[CommandMethod("GetPileCoordinate")]
		public void GetPileCoordinate ()
		{
			Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
			ed.WriteMessage("选取区域，读取桩的坐标");
		}
		#endregion

	}
}
