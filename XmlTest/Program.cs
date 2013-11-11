using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml.Linq;

namespace XmlTest
{
	class Program
	{
		static void Main (string[] args)
		{
			TestXElement();
		}

		private static void TestXElement ()
		{
			string province = "";
			string url = string.Format("http://www.youdao.com/smartresult-xml/search.s?type=ip&q={0}", "60.31.255.255");
			try {
				XElement element = XElement.Load(url);
				string location = element.Element("product").Element("location").Value;
				List<string> names = new List<string>() { "北京", "天津", "上海", "重庆", "河北", "山西", "辽宁", "吉林", "黑龙江", "江苏", "浙江", "安徽", "福建", "江西", "山东", "河南", "湖北", "湖南", "广东", "海南", "四川", "贵州", "云南", "陕西", "甘肃", "青海", "台湾", "广西", "内蒙古", "西藏", "宁夏", "新疆", "香港", "澳门" };
				foreach (var item in names) {
					if (location.IndexOf(item) == 0) {
						province = item;
						break;
					}
				}
			} catch (Exception ex) {

			}
		}
	}
}
