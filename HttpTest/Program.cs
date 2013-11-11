using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace HttpTest
{
	class Program
	{
		static void Main (string[] args)
		{
			TestResponse();
		}

		private static void TestResponse ()
		{
			string response = "";
			string url = string.Format("http://int.dpool.sina.com.cn/iplookup/iplookup.php?f=json&ip={0}", "123.233.157.9");
			try {
				HttpWebRequest loHttp = (HttpWebRequest)WebRequest.Create(url);
				loHttp.UserAgent = "Web Client";
				HttpWebResponse loWebResponse = (HttpWebResponse)loHttp.GetResponse();
				Encoding enc = Encoding.GetEncoding("GBK");
				StreamReader loResponseStream = new StreamReader(loWebResponse.GetResponseStream(), enc);
				response = loResponseStream.ReadToEnd();
				loWebResponse.Close();
				loResponseStream.Close();
				string[] allInfo = response.Split('\t');
				if (allInfo.Length >= 5) {
					response = allInfo[4];
				}
			} catch (Exception ex) {

			}
		}
	}
}
