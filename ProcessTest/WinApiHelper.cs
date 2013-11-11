using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;

namespace Warrentech.Rainbow.FileConvertHelper
{
	class WinApiHelper
	{
		const int WM_CLOSE = 0x0010;
		/// <summary> 
		/// 获得待测程序主窗体的句柄 
		/// </summary> 
		/// <param name="lpClassName">待测窗体的类名，若设置为null则返回它找到的第一个窗体名称的实例 
		/// （这与OOP中所说的类不是一个概念，在这之前还没有OOP）</param> 
		/// <param name="lpWindowName">窗体名称</param> 
		/// <returns>返回窗体win32的句柄类型</returns> 
		[DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto)]
		static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
		public static IntPtr FindWindowHandle(string caption)
		{
			IntPtr mwh = IntPtr.Zero;
			bool formFound = false;
			int attempts = 0;
			do {
				mwh = FindWindow(null, caption);
				if (mwh == IntPtr.Zero) {
					Thread.Sleep(100);
					++attempts;
				} else {
					formFound = true;
				}
			} while (!formFound && attempts < 100);
			if (mwh != IntPtr.Zero) {
				return mwh;
			} else {
				return mwh;
			}
		}

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);//0关闭，1正常，2最小，3最大

		[DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
		public static extern bool SetF(IntPtr hWnd);//设置此窗体为活动窗体
		[DllImport("User32.dll", EntryPoint = "SendMessage")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
		public static void CloseWindowHandle(IntPtr hWnd)
		{
			SendMessage(hWnd, WM_CLOSE, 0, 0);
		}

		[DllImport("user32.dll")]
		public static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);
		///   <summary>      
		///   窗口置前      
		///   </summary>      
		///   <param   name="hWnd">窗口句柄</param>      
		public static void SetWindowPos(IntPtr hWnd)
		{
			SetWindowPos(hWnd, -1, 0, 0, 0, 0, 0x4000 | 0x0001 | 0x0002);
		}

		/// <summary> 
		/// 获得待测控件的句柄 
		/// </summary> 
		/// <param name="hwndParent">控件所在窗体的句柄</param> 
		/// <param name="hwndChildAfter">告诉函数从哪里开始找（IntPtr.Zero则从下一个子控件开始查找）</param> 
		/// <param name="lpszClass">目标控件的类名</param> 
		/// <param name="lpszWindow">窗体名称</param> 
		/// <returns>返回控件的句柄</returns> 
		[DllImport("user32.dll", EntryPoint = "FindWindowEx", CharSet = CharSet.Auto)]
		static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
		public static IntPtr GetControlInptr(IntPtr mwh, string caption)
		{
			Console.WriteLine(string.Format("寻找{0}的句柄", caption));
			IntPtr tb = FindWindowEx(mwh, IntPtr.Zero, null, caption);
			if(tb == IntPtr.Zero)
				throw new Exception(string.Format("找不到{0}", caption));
			else
				Console.WriteLine("Setting的句柄是:" + tb);
			return tb;
		}

		/// <summary>
		/// 鼠标单击控件
		/// </summary>
		/// <param name="hWnd">控件句柄</param>
		/// <param name="Msg">发送给控件Window消息</param>
		/// <param name="wParam">当鼠标案件被单击时，其它几个功能键是否被按下</param>
		/// <param name="lParam">鼠标单击字控件的位置，0表示在控件左上角</param>
		/// <returns>返回true则单击成功，否则单击失败</returns>
		[DllImport("user32.dll", EntryPoint = "PostMessage", CharSet = CharSet.Auto)]
		static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
		public static void PostMessage1(IntPtr hWnd)
		{
			Console.WriteLine("点击按钮!");
			uint WM_LBUTTONDOWM = 0x0201;
			uint WM_LBUTTONUP = 0x0202;
			PostMessage(hWnd, WM_LBUTTONDOWM, 0, 0);//按下鼠标左键
			PostMessage(hWnd, WM_LBUTTONUP, 0, 0);//放下鼠标左键
		}
	}
}
