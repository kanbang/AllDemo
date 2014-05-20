using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace ReportFont
{
	class Program
	{
		static void Main(string[] args)
		{
			//acad.exe _TranslateV3_C:\...
			string tag = "translatev3";
			if (args.Length > 0) {
				string value = args[0].ToLower();
				int index = value.IndexOf(tag);
				if (index >= 0) {
					index += tag.Length + 1;
					string path = value.Substring(index);
					string cmdString = "\"" + path + "\"";
					Process.Start(cmdString);
					FontChanger changer = new FontChanger();
					string file = "1.txt";
					while (true) {
						if (File.Exists(file)) {
							File.Delete(file);
							break;
						}
						Thread.Sleep(1000);
					}
				}
			}
		}

	}
}
