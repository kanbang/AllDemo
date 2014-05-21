using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Xml;

namespace Warrentech.Velo.VeloView
{
	public class FontChangeHelper
	{
		public delegate bool CallBack(int hwnd, int y);
		#region API声明
		[DllImport("user32.dll")]
		public static extern int EnumWindows(CallBack x, int y);

		[DllImport("user32.dll", EntryPoint = "EnumChildWindows")]//枚举子窗体
		public static extern bool EnumChildWindows(int hwndParent, CallBack EnumFunc, int lParam);

		[DllImport("User32.dll", EntryPoint = "FindWindow")]//找指定窗体
		private static extern int FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32")]
		public static extern int GetWindowText(int hwnd, StringBuilder lptrString, int nMaxCount);

		[DllImport("user32")]
		public static extern int IsWindowVisible(int hwnd);
		[DllImport("User32.Dll")]
		public static extern void GetClassName(int hwnd, StringBuilder s, int nMaxCount);


		[DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Ansi)]
		public static extern int SendMessage(int hwnd, int msg, int wParam, int lParam);

		[DllImport("User32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Ansi)]
		public static extern int SendMessage(int hWnd, int uMsg, int wParam, StringBuilder lParam);

		const int LB_SETTOPINDEX = 0x0197;
		const int LB_SETCURSEL = 0x0186;
		const int LB_GETCOUNT = 0x18B;

		const int WM_GETTEXT = 0x000D;
		const int BM_CLICK = 0x00F5;

		const int VK_UP = 0x26;//方向键
		const int VK_DOWN = 0x28;
		const int WM_CHAR = 0x102;
		const int WM_KEYDOWN = 0x100;
		const int WM_CLOSE = 0x0010;
		#endregion

		#region 相当于public变量
		int _globalUserName;
		int _sumbitButtonHwnd;
		int _publicTxtIndexN;
		private string[] _closeWindowName;

		public FontChangeHelper()
		{
			_closeWindowName = GetAppConfigValue("CloseWindowNameContent").Split(';');
		}
		#endregion


		#region 查找AutoCAD替换字体的窗口，返回得到这个窗口的句柄
		public bool Report(int hwnd, int lParam)
		{
			if (IsWindowVisible(hwnd) == 1) {
				StringBuilder sb = new StringBuilder(512);

				GetWindowText(hwnd, sb, sb.Capacity);
				string cadString = sb.ToString();
				foreach (var item in _closeWindowName) {
					if (item.Length > 0) {
						if (cadString.ToLower().Contains(item)) {
							SendMessage(hwnd, WM_CLOSE, 0, 0);
						}
					}
				}
			}
			return true;
		}
		#endregion

		#region 在这个替换字体的主窗口内查找子窗口
		public bool Reportfa(int hwnd, int lParam)//循环查找替换listbox
		{
			string lpszParentClass = "ListBox"; //整个窗口的类名
			StringBuilder sbClassName = new StringBuilder(255);
			GetClassName(hwnd, sbClassName, 255);
			//由于现查找到这个确定按钮，所以先设置这个值
			if (sbClassName.ToString() == "Button") {
				StringBuilder strButton = new StringBuilder(10);//用来存放窗口标题
				GetWindowText(hwnd, strButton, strButton.Capacity);
				if (strButton.ToString() == "确定") {
					_sumbitButtonHwnd = hwnd;//得到确定的按钮
				}
			}

			if (lpszParentClass == sbClassName.ToString()) {
				//找到一个listbox，就看他的标题是不是空，空的舍弃
				StringBuilder str = new StringBuilder(512);//用来存放窗口标题
				GetWindowText(hwnd, str, str.Capacity);
				string strEnd = string.Empty;
				strEnd = str.ToString();//转换为字符串
				if (strEnd.Length > 0)//如果长度大于0,就找到这个啦
                {
					if (_publicTxtIndexN == 0) {
						GetfontIndex(hwnd);
					}
					//设置listbox值
					SendMessage(hwnd, LB_SETCURSEL, _publicTxtIndexN, 0);
					//下移一行       
					SendMessage(hwnd, WM_KEYDOWN, VK_DOWN, 0);
					//发送确定按钮
					SendMessage(_sumbitButtonHwnd, BM_CLICK, 0, 0);

					return false;
				}

			}
			return true;

		}
		#endregion

		#region 得到hztxt.shx的位置,设置PublicTxtIndexN
		public void GetfontIndex(int hwnd)
		{
			//先查找一共有多少项
			int ListCount;
			ListCount = SendMessage(hwnd, LB_GETCOUNT, 0, 0);
			StringBuilder strshx = new StringBuilder(20);//用来存放窗口标题
			for (int i = 0; i <= ListCount - 1; i++) {
				//设定某项来比较
				SendMessage(hwnd, LB_SETCURSEL, i, 0);
				//SendMessage(hwnd, LB_SETTOPINDEX, i, 0);//
				SendMessage(hwnd, WM_GETTEXT, strshx.Capacity, strshx);
				if (strshx.ToString() == "gbcbig.shx|1|000000") {
					//得到hztxt前一个值
					_publicTxtIndexN = i - 1;
					break;
				}
			}
		}
		#endregion

		//循环查找替换
		public void Reportfont()
		{
			int Nub = 1;
			while (Nub > 0) {
				EnumWindows(this.Report, 0);//这里会得到下面的kaka的值
				int kaka;
				kaka = _globalUserName;//替换字体的对话框的句柄
				//EnumChildWindows(kaka, this.Reportfa, 0);
			}
		}
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
			} catch {
				return "";
			}
		}
		private static string GetAppConfigFilePath()
		{
			string directoryName = GetDllDirPath();
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
