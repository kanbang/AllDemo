using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ReportFont
{
	public class FontChanger
	{
		FontChangeHelper _fontChangeHelper = new FontChangeHelper();

		public FontChanger()
		{
			Timer timer=new Timer(timer_Elapsed,null,100,100);
		}
		void timer_Elapsed(object stage)
		{
			_fontChangeHelper.Reportfont();
		}

	}

}
