using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using Microsoft.Win32;
using System.Drawing.Drawing2D;
using System.Diagnostics;

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
			//int intTest = Convert.ToInt32(double.MinValue);
			//intTest = Convert.ToInt32(double.NegativeInfinity);
			//intTest = Convert.ToInt32(double.PositiveInfinity);
			//intTest = Convert.ToInt32(double.MaxValue);
			//intTest = Convert.ToInt32(double.MinValue);//全部异常

			//while (true) {
			//    string s = Console.ReadLine();
			//    string[] array = s.Split('-');
			//    foreach (var item in array) {
			//        Console.WriteLine(item);
			//    }
			//    if (array.Length > 0) {
			//        Console.WriteLine(s.Remove(s.Length - array[array.Length - 1].Length));
			//    }
			//}
			#region 测试矩阵
			//List<Point> list = new List<Point>();
			//Point point = new Point(100, 100);
			//Point point2 = new Point(100, 200);
			//Point point3 = new Point(200, 100);
			//Point point4 = new Point(200, 200);

			//Matrix matrix = new Matrix();
			//matrix.Scale(1, -1);
			//matrix.Translate(-95, -205);
			//Point[] array = new Point[] { point, point2, point3, point4 };
			//matrix.TransformPoints(array);
			//Console.WriteLine(array[0]);
			//Console.WriteLine(array[1]);
			//Console.WriteLine(array[2]);
			//Console.WriteLine(array[3]);
			#endregion

			#region 测试交互赋值
			//double a = double.MaxValue;
			//double b = double.MinValue;
			//Console.WriteLine(a);
			//Console.WriteLine(b);
			//a = a / 100;
			//b = b / 100;
			//b = a + b;
			//a = b - a;
			//b = b - a;
			//a = a * 100;
			//b = b * 100;
			//Console.WriteLine(a.Equals(double.MinValue));
			//Console.WriteLine(b.Equals(double.MaxValue));

			#endregion

			#region 测试字典遍历
			//Dictionary<string, int> dic = new Dictionary<string, int>();
			//dic.Add("1", 1);
			//dic.Add("2", 1);
			//dic.Add("3", 1);
			//dic.Add("4", 1);
			//int i = 5;
			//string[] array = new string[dic.Count];
			//dic.Keys.CopyTo(array, 0);
			//foreach (var item in array) {
			//    dic.Add(i.ToString(), i);
			//    i++;

			//}

			//foreach (var item in dic) {
			//    Console.WriteLine(item.Key);

			//}
			#endregion
			#region 测试List
			//List<int> list = new List<int>();
			//list.Add(1);
			//list.Add(2);
			//list.Add(3);
			//list.Add(4);
			//list.GetRange(0, 1);
			//list.GetRange(list.Count - 1, 1);

			#endregion
			#region 测试取余和计算
			//int count = 1000000;
			//int last = count - 1;
			//Stopwatch myWatch = new Stopwatch();
			//myWatch.Start();

			//for (int i = 0; i < count; i++) {
			//    int j = (i + 1) % count;
			//}
			//myWatch.Stop();
			//Console.WriteLine(myWatch.ElapsedMilliseconds);
			//myWatch.Reset();
			//myWatch.Start();
			//for (int i = 0; i < count; i++) {
			//    int j = i == last ? 0 : i + 1;
			//}
			//myWatch.Stop();
			//Console.WriteLine(myWatch.ElapsedMilliseconds);

			#endregion
			#region 测试++i和i++
			for (int i = 0; i < 5; i++) {
				Console.WriteLine(i);

			}
			for (int i = 0; i < 5; ++i) {
				Console.WriteLine(i);

			}
			#endregion

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
