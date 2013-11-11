using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;

namespace RevitTest
{
	public partial class PostCommandFrm : System.Windows.Forms.Form
	{
		private ExternalCommandData _cmdDataForm;
		private string _msgForm;
		private ElementSet _elementsForm;
		int i = 0;
		private string[] _list;
		public PostCommandFrm()
		{
			InitializeComponent();
		}
		//重载一个构造函数，用来传递参数
		public PostCommandFrm(ExternalCommandData cmdData, string msg, ElementSet elements)
		{
			InitializeComponent();
			_cmdDataForm = cmdData;
			_msgForm = msg;
			_elementsForm = elements;
			_list = Enum.GetNames(typeof(PostableCommand));

		}
		private void button1_Click(object sender, EventArgs e)
		{
			PostableCommand command=PostableCommand.AcquireCoordinates;
			Enum.TryParse<PostableCommand>(_list[i],out command);
			label1.Text = _list[i];
			_cmdDataForm.Application.PostCommand(RevitCommandId.LookupPostableCommandId(command));
			i++;
		}
	}
}
