using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace TimerTest
{
	class Program
	{
		static void Main(string[] args)
		{
			CalculatePer5Minute();//每五分钟计算一次
			Console.ReadLine();
		}

		private static void CalculatePer5Minute()
		{
			Timer timer = new Timer();
			timer.Interval = 300000;
			timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
			while (true) {
				var minute = DateTime.Now.Minute;
				if (minute % 5 == 0) {
					break;//在整五分点的时候进行计算
				}
			}
			timer.Start();
		}

		static void timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			Console.WriteLine(DateTime.Now.ToString());
		}

	}
}
