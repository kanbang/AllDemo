using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using Microsoft.Win32;

namespace BaseTest
{
	class Program
	{
		static void Main(string[] args)
		{
			//TestString();
			//while (true) {
			//    Console.WriteLine(GetPathNameForDisplay(Console.ReadLine()));
			//}
			//double s = 0;
			//double value = 1 / s;
			//int ss = Convert.ToInt32(true);
			//ss = Convert.ToInt32(false);
			//ss = Convert.ToInt32(null);
			//Dictionary<int, int> dic = new Dictionary<int, int>();
			//dic[1] = 0;
			//Dictionary<int, List<int>> dic2 = new Dictionary<int, List<int>>();
			//dic2[1] = new List<int>();
			//Console.WriteLine("23\u044c\u043c");
			//Console.WriteLine("hьъ\u044A");


			////如何获得系统字体列表
			//System.Drawing.Text.InstalledFontCollection fonts = new System.Drawing.Text.InstalledFontCollection();
			//foreach (System.Drawing.FontFamily family in fonts.Families) {
			//    Console.WriteLine(family.Name);
			//}
			while (true) {
				string s = Console.ReadLine();
				string[] array = s.Split('-');
				foreach (var item in array) {
					Console.WriteLine(item);
				}
				if (array.Length > 0) {
					Console.WriteLine(s.Remove(s.Length - array[array.Length - 1].Length));
				}
			}

			Console.ReadLine();

		}

		private static void TestString()
		{
			int value = 200;
			Console.WriteLine(value.ToString("00#"));
		}
		private static string GetPathNameForDisplay(string pathName)
		{
			int maxLength = "233333123232233333333333333333333333331233333333333333333333".Length;
			string[] tokens = pathName.Split(Path.DirectorySeparatorChar);
			int splitLength = Path.DirectorySeparatorChar.ToString().Length;
			string newPath = pathName;
			if (tokens.Length > 3) {
				string drive = tokens[0];
				string lastDirectory = tokens[tokens.Length - 2];
				string fileName = tokens[tokens.Length - 1];
				int len = drive.Length + lastDirectory.Length + fileName.Length;
				int remLen = maxLength - len - 3 - splitLength * 3;
				if (remLen > 0) {
					for (int i = 1; i < tokens.Length - 2; i++) {
						len += tokens[i].Length + splitLength;
						remLen = maxLength - len;
						if (remLen > 0) {
							drive = string.Format("{0}{1}{2}", drive, Path.DirectorySeparatorChar, tokens[i]);
						} else {
							newPath = string.Format(@"{0}{1}...{1}{2}{1}{3}", drive, Path.DirectorySeparatorChar, lastDirectory, fileName);
							break;
						}
					}

				} else {
					newPath = string.Format(@"{0}{1}...{1}{2}{1}{3}", drive, Path.DirectorySeparatorChar, lastDirectory, fileName);
				}
			}
			return newPath;

		}

	}
}
