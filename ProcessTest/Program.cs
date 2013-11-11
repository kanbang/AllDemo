using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml.Linq;
using System.Diagnostics;
using System.Threading;
using Warrentech.Rainbow.FileConvertHelper;

namespace ProcessTest
{
	class Program
	{
		static void Main(string[] args)
		{
			//ProcessTest();
			YjkProcessTest();
		}

		private static void YjkProcessTest()
		{
			string file = @"E:\360data\重要数据\桌面\幼儿园(1)\幼儿园\幼儿园.yjk";
			try {
				//Process process = new Process();
				//Process.Start(file, "yjk_exportydbdefault");
				//while (true) {
				//    Thread.Sleep(1000);
				//    Process[] processArray = Process.GetProcessesByName("yjks");
				//    if (processArray.Length > 0) {
				//        break;
				//    }
				//}
				string fileExtent = string.Format(".{0}",Path.GetExtension(file));
				IntPtr windowPtr = WinApiHelper.FindWindowHandle("盈建科软件");
				IntPtr btnSetPtr = WinApiHelper.GetControlInptr(windowPtr, "Settings...");
				Console.ReadLine();
			} catch (Exception ex) {

				throw ex;
			}
		}

		private static void ProcessTest()
		{
			Process[] ps = Process.GetProcessesByName("acad");
			foreach (Process p in ps) {
				var path = p.MainModule.FileName.ToString();

			}

		}
	}
}
