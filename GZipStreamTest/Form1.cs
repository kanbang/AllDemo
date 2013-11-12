using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GZipStreamTest
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string directoryName = @"C:\Users\LiXiaolei\Desktop\PKPM\59#-中联环詹亮";
			string fileName = @"C:\Users\LiXiaolei\Desktop\PKPM\59#-中联环詹亮.rar";
			GZipCompress.Compress(directoryName, fileName);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			string directoryName = @"C:\Users\LiXiaolei\Desktop\PKPM\59#-中联环詹亮";
			string fileName = @"C:\Users\LiXiaolei\Desktop\PKPM\59#-中联环詹亮.rar";
			GZipCompress.DeCompress(fileName, directoryName);

		}
	}
}
