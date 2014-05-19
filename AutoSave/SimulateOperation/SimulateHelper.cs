using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Warrentech.Velo.VeloView
{
	public class SimulateHelper
	{
		Timer timer = new Timer(1000);
		FontChangeHelper helper = new FontChangeHelper();
		public SimulateHelper()
		{
			timer.Elapsed += timer_Elapsed;
		}

		void timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			IntPtr windowPtr = WinApiHelper.FindWindowHandle("图形另存为");
			if (windowPtr != IntPtr.Zero) {
				IntPtr btnSetPtr = WinApiHelper.GetControlInptr(windowPtr, "保存(&S)");
				if (btnSetPtr == IntPtr.Zero) {
					btnSetPtr = WinApiHelper.GetControlInptr(windowPtr, "是(&Y)");
				}
				if (btnSetPtr != IntPtr.Zero) {
					WinApiHelper.PostMessage1(btnSetPtr);
				}
			}
		}
		public void Excute()
		{
			timer.Start();
		}

	}
}
