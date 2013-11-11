using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace RegexTest
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			Regex regex = new Regex(textBox1.Text);
			Match match = regex.Match(textBox2.Text);
			label1.Text = match.Success.ToString();
			label2.Text = string.Empty;
			if (match.Success) {
				string[] names = regex.GetGroupNames();
				foreach (var item in names) {
					label2.Text += string.Format("name {2} isSuccess:{0} value:{1} \n ", match.Groups[item].Success, match.Groups[item].Value,item);
				}

			}
		}
	}
}
