using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;

namespace Warrentech.AcadReDevelop.SetUp
{
	public partial class MainForm : Form
	{
		CheckBox[] _myCheckBox = new CheckBox[10];
		string[] _locationString = new string[10];
		readonly string KeyName = "AcadLocation";
		readonly string DllName = "Warrentech.AcadReDevelop.MainMenu.dll";

		public MainForm ()
		{
			InitializeComponent();
		}

		private void MainForm_Load (object sender, EventArgs e)
		{

			_myCheckBox[0] = chcSixCN;
			_myCheckBox[1] = chcSixEN;
			_myCheckBox[2] = chcSevenCN;
			_myCheckBox[3] = chcSevenEN;
			_myCheckBox[4] = chcEightCN;
			_myCheckBox[5] = chcEightEN;
			_myCheckBox[6] = chcNineCN;
			_myCheckBox[7] = chcNineEN;
			_myCheckBox[8] = chcTenCN;
			_myCheckBox[9] = chcTenEN;
			_locationString[0] = "SOFTWARE\\Autodesk\\AutoCAD\\R16.2\\ACAD-4001:804"; //2006中文版
			_locationString[1] = "SOFTWARE\\Autodesk\\AutoCAD\\R16.2\\ACAD-4001:409";//2006英文版
			_locationString[2] = "SOFTWARE\\Autodesk\\AutoCAD\\R17.0\\ACAD-5001:804";//2007中文版
			_locationString[3] = "SOFTWARE\\Autodesk\\AutoCAD\\R17.0\\ACAD-5001:409";//2007英文版
			_locationString[4] = "SOFTWARE\\Autodesk\\AutoCAD\\R17.1\\ACAD-6001:804";//2008中文版
			_locationString[5] = "SOFTWARE\\Autodesk\\AutoCAD\\R17.1\\ACAD-6001:409";//2008英文版
			_locationString[6] = "SOFTWARE\\Autodesk\\AutoCAD\\R17.2\\ACAD-7001:804";//2009中文版
			_locationString[7] = "SOFTWARE\\Autodesk\\AutoCAD\\R17.2\\ACAD-7001:409";//2009英文版
			_locationString[8] = "SOFTWARE\\Autodesk\\AutoCAD\\R18.0\\ACAD-8001:804";//2010中文版
			_locationString[9] = "SOFTWARE\\Autodesk\\AutoCAD\\R18.0\\ACAD-8001:409";//2010英文版
			for (int i = 0; i < 10; i++) {
				//得到电脑中安装的版本
				_myCheckBox[i].Enabled = IsRegeditItemExist(_locationString[i], KeyName);
				Application.DoEvents();
			}
		}
		/// <summary>
		/// 判断路径为keypath，键名为keyname的是否存在 
		/// </summary>
		/// <param name="keypath">读取路径</param>
		/// <param name="keyname">键名</param>
		/// <returns>判断keyname是否存在</returns>
		private bool IsRegeditItemExist (string keypath, string keyname)
		{
			RegistryKey key = Registry.LocalMachine.OpenSubKey(keypath);//不为null表示有这个项目
			if (key != null && key.GetValue(keyname) != null) {
				return true;
			} else {
				return false;
			}

		}
		//注册程序 
		public void RegApp (string keypath, string location)
		{
			RegistryKey appkey = Registry.LocalMachine.OpenSubKey(keypath + "\\Applications", true);//打开Applications
			RegistryKey rk = appkey.CreateSubKey("W.Plug-in");
			rk.SetValue("DESCRIPTION", "初始化W.插件", RegistryValueKind.String);
			rk.SetValue("LOADCTRLS", 2, RegistryValueKind.DWord);
			rk.SetValue("LOADER", location, RegistryValueKind.String);
			rk.SetValue("MANAGED", 1, RegistryValueKind.DWord);
			appkey.Close();
		}

		public static void UnRegApp (string keypath)//卸载
		{
			RegistryKey appkey = Registry.LocalMachine.OpenSubKey(keypath + "\\Applications", true);//打开Applications
			appkey.DeleteSubKeyTree("W.Plug-in");
		}

		public void CopyDirectory (string sourceDirName, string destDirName)
		{

			if (!Directory.Exists(destDirName)) {
				Directory.CreateDirectory(destDirName);
				File.SetAttributes(destDirName, File.GetAttributes(sourceDirName));
			}

			if (destDirName[destDirName.Length - 1] != Path.DirectorySeparatorChar) {
				destDirName = destDirName + Path.DirectorySeparatorChar;
			}

			string[] files = Directory.GetFiles(sourceDirName);
			foreach (string file in files) {
				File.Copy(file, destDirName + Path.GetFileName(file), true);
				File.SetAttributes(destDirName + Path.GetFileName(file), FileAttributes.Normal);
			}

			string[] dirs = Directory.GetDirectories(sourceDirName);
			foreach (string dir in dirs) {
				CopyDirectory(dir, destDirName + Path.GetFileName(dir));
			}
		}

		private void btnSetUp_Click (object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			DialogResult result = folderBrowserDialog.ShowDialog();
			if (result == DialogResult.OK) {
				string targetPath = "";
				if (!string.IsNullOrEmpty(folderBrowserDialog.SelectedPath)) {
					string sourcePath = Environment.CurrentDirectory;
					targetPath = folderBrowserDialog.SelectedPath + @"\W.Plug-in";
					CopyDirectory(sourcePath, targetPath);
				}

				bool isOK = false;
				string mainMenuPath = string.Format(@"{0}\{1}", targetPath, DllName);
				for (int i = 0; i < 10; i++) {
					if (_myCheckBox[i].Enabled == true && _myCheckBox[i].Checked == true) {
						//注册
						RegApp(_locationString[i], mainMenuPath);
						isOK = true;
					}
				}
				if (isOK) {
					MessageBox.Show("安装成功");
				} else {
					MessageBox.Show("安装失败");
				}
			}
		}

		private void btnUnLoad_Click (object sender, EventArgs e)
		{
			bool isOK = false;

			for (int i = 0; i < 10; i++) {
				if (_myCheckBox[i].Enabled == true && _myCheckBox[i].Checked == true) {
					//注册
					UnRegApp(_locationString[i]);
					isOK = true;
				}
			}
			if (isOK) {
				MessageBox.Show("卸载成功");
			} else {
				MessageBox.Show("卸载失败");
			}
		}

	}
}
