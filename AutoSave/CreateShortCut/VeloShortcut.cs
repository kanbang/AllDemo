using System;
using System.Collections.Generic;
using System.Text;
using IWshRuntimeLibrary;
using Microsoft.Win32;

namespace Warrentech.Velo.EasyInstall
{
	class VeloShortcut
	{
		public static void CreateAcadShortcut(AcadVersion cadVersion)
		{
			// 1. 判断autocad是否安装
			string autocadRegPath = GetAcadRegPath(cadVersion);
			string acadLocation = "";
			RegistryKey cadRegRoot = Registry.LocalMachine.OpenSubKey(autocadRegPath, RegistryKeyPermissionCheck.ReadSubTree);
			if (cadRegRoot == null) {
				return;
			}

			acadLocation = cadRegRoot.GetValue("AcadLocation", "").ToString();

			// 2. 在桌面创建快捷方式
			WshShell shell = new WshShell();
			string shortcutName = string.Format(@"{0}\{1}{2}.lnk",
				Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
				"GCD2013 For ", cadVersion);

			IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutName);

			shortcut.TargetPath = string.Format(@"{0}\acad.exe", acadLocation);
			shortcut.Arguments = " -nologo /#gcd#";

			shortcut.WorkingDirectory = string.Format(@"{0}\UserDataCache\", acadLocation);
			shortcut.WindowStyle = 1;
			shortcut.Description = "广联达施工图软件";
			string dllName = System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.Name;
			string dllFullPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
			string dllPath = dllFullPath.Substring(0, dllFullPath.LastIndexOf(dllName));
			shortcut.IconLocation = string.Format("{0}", dllPath + "\\GCD.ico");

			shortcut.Save();
		}

		static string GetAcadRegPath(AcadVersion cadVersion)
		{
			switch (cadVersion) {
				case AcadVersion.Acad2008:
					return @"SOFTWARE\Autodesk\AutoCAD\R17.1\ACAD-6001:804";
				case AcadVersion.Acad2010:
					return @"SOFTWARE\Autodesk\AutoCAD\R18.0\ACAD-8001:804";
				case AcadVersion.Acad2012:
					return @"SOFTWARE\Autodesk\AutoCAD\R18.2\ACAD-A001:804";
				default:
					throw new IndexOutOfRangeException();
			}
		}
	}
}
