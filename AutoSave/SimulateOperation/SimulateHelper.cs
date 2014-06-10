using System;
using System.Diagnostics;
using Autodesk.AutoCAD.ApplicationServices;
using AcadApp = Autodesk.AutoCAD.ApplicationServices.Application;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Warrentech.Velo.VeloView
{
	public class SimulateHelper
	{
		Timer timer;
		int number = 0;

		void timer_Elapsed(object sender)
		{
			TSaveAs();
			Thread.Sleep(10);
			IntPtr windowPtr = WinApiHelper.FindWindowHandle("确认另存为");
			if (windowPtr != IntPtr.Zero) {
				timer.Dispose();
				while (true) {
					if (WinApiHelper.FindWindowHandle("确认另存为") == IntPtr.Zero) {
						Excute();
						break;
					} else {
						IntPtr btnSetPtr = WinApiHelper.GetControlInptr(windowPtr, "是(&Y)");
						if (btnSetPtr != IntPtr.Zero) {
							WinApiHelper.PostMessage1(btnSetPtr);
						} else {
							WinApiHelper.SendKey((int)System.Windows.Forms.Keys.Y);
						}
					}
				}
			}
			windowPtr = WinApiHelper.FindWindowHandle("AutoCAD");
			if (windowPtr != IntPtr.Zero) {
				timer.Dispose();
				int i = 0;
				while (true) {
					if (WinApiHelper.FindWindowHandle("AutoCAD") == IntPtr.Zero) {
						Excute();
						break;
					} else {
						IntPtr btnSetPtr = WinApiHelper.GetControlInptr(windowPtr, "否(&N)");
						if (btnSetPtr != IntPtr.Zero) {
							WinApiHelper.PostMessage1(btnSetPtr);
						} else {
							WinApiHelper.SendKey((int)System.Windows.Forms.Keys.N);
						}
						Thread.Sleep(10);
						i++;
						if (i >= 100) {
							break;
						}
					}
				}
			}
		}

		private void TSaveAs()
		{
			IntPtr windowPtr = WinApiHelper.FindWindowHandle("图形导出");
			if (windowPtr != IntPtr.Zero) {
				IntPtr btnSetPtr = WinApiHelper.GetControlInptr(windowPtr, "保存(&S)");
				if (btnSetPtr != IntPtr.Zero) {
					WinApiHelper.PostMessage1(btnSetPtr);
				}
				number++;
			} else if (number > 0) {
				number++;
				if (number >= 3000) {//5分钟还没关闭
					KillProcess(Process.GetCurrentProcess());
				}
			} else {
				WinApiHelper.ClickMouse();
			}
		}

		public static void KillProcess(Process process)
		{
			string exeName = process.MainModule.FileName;
			string[] exeArray = exeName.Split('\\');
			RunCmd("taskkill /im " + exeArray[exeArray.Length - 1] + " /f ");
		}

		/// <summary>
		/// 运行DOS命令
		/// DOS关闭进程命令(ntsd -c q -p PID )PID为进程的ID
		/// </summary>
		/// <param name="command"></param>
		/// <returns></returns>
		public static string RunCmd(string command)
		{
			//實例一個Process類，啟動一個獨立進程
			System.Diagnostics.Process p = new System.Diagnostics.Process();

			//Process類有一個StartInfo屬性，這個是ProcessStartInfo類，包括了一些屬性和方法，下面我們用到了他的幾個屬性：

			p.StartInfo.FileName = "cmd.exe";           //設定程序名
			p.StartInfo.Arguments = "/c " + command;    //設定程式執行參數
			p.StartInfo.UseShellExecute = false;        //關閉Shell的使用
			p.StartInfo.RedirectStandardInput = true;   //重定向標準輸入
			p.StartInfo.RedirectStandardOutput = true;  //重定向標準輸出
			p.StartInfo.RedirectStandardError = true;   //重定向錯誤輸出
			p.StartInfo.CreateNoWindow = true;          //設置不顯示窗口

			p.Start();   //啟動

			p.StandardInput.WriteLine(command);       //也可以用這種方式輸入要執行的命令
			p.StandardInput.WriteLine("exit");        //不過要記得加上Exit要不然下一行程式執行的時候會當機

			return p.StandardOutput.ReadToEnd();        //從輸出流取得命令執行結果

		}
		public void Excute()
		{
			timer = new Timer(timer_Elapsed, null, 0, 100);
		}

	}
}
