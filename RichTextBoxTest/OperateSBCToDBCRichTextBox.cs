using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RichTextBoxTest
{
	public partial class OperateSBCToDBCRichTextBox : RichTextBox
	{
		private int _selectionStart = 0;
		private string _oldValue = string.Empty;
		private bool _canUndo = false;

		public string Text
		{
			get { return base.Text; }
			set { SetText(value); }
		}

		public OperateSBCToDBCRichTextBox()
		{
			InitializeComponent();
			this.LanguageOption = RichTextBoxLanguageOptions.UIFonts;
			this.AutoWordSelection = false;
		}

		void OperateSBCToDBCRichTextBox_TextChanged(object sender, EventArgs e)
		{
			SetText(Text);
			this.ClearUndo();
		}

		protected override void OnTextChanged(EventArgs e)
		{
			if (_oldValue != Text) {
				_oldValue = Text;
				base.OnTextChanged(e);
			}
			//DeselectAll();
		}
		public void SetText(string text)
		{
			int curIndex = this.SelectionStart;//当前光标位置
			this.LanguageOption = RichTextBoxLanguageOptions.UIFonts;
			_oldValue = base.Text = ToDBC(text).ToUpper();
			this.SelectionStart = curIndex;
			this.Font = new System.Drawing.Font("GicdSteel", this.Font.Size);
		}

		/// 转半角的函数(DBC case)   
		/// 任意字符串  
		/// 半角字符串  
		///全角空格为12288，半角空格为32  
		///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248  
		private string ToDBC(string input)
		{
			if (string.IsNullOrEmpty(input)) {
				return input;
			}
			char[] c = input.ToCharArray();
			for (int i = 0; i < c.Length; i++) {
				if (c[i] == 12288) {
					c[i] = (char)32;
					continue;
				}
				if (c[i] > 65280 && c[i] < 65375)
					c[i] = (char)(c[i] - 65248);
			}
			return new string(c);
		}

		public OperateSBCToDBCRichTextBox(IContainer container)
		{
			container.Add(this);
			InitializeComponent();
			this.AutoWordSelection = false;
			this.KeyPress += new KeyPressEventHandler(OperateSBCToDBCRichTextBox_KeyPress);
			this.KeyDown += new KeyEventHandler(OperateSBCToDBCRichTextBox_KeyDown);
			this.KeyUp += new KeyEventHandler(OperateSBCToDBCRichTextBox_KeyUp);
		}

		void OperateSBCToDBCRichTextBox_KeyUp(object sender, KeyEventArgs e)
		{
			if (!string.IsNullOrEmpty(Text)) {
				SelectionStart = Text.Length;
			}
		}

		void OperateSBCToDBCRichTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && (e.KeyCode == Keys.Z)) {
				while (this.CanUndo) {
					if (this.UndoActionName.Equals("键入")) {
						this.Undo();
						break;
					}
					this.Undo();
				}
			}
		}

		void OperateSBCToDBCRichTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 12288) {
				e.KeyChar = (char)32;
			}
			if (e.KeyChar > 65280 && e.KeyChar < 65375) {
				e.KeyChar = (char)(e.KeyChar - 65248);
			}
			if (e.KeyChar >= 97 && e.KeyChar <= 122) {
				e.KeyChar -= (char)32;
			}
			this.LanguageOption = RichTextBoxLanguageOptions.UIFonts;
			this.Font = new System.Drawing.Font("GicdSteel", this.Font.Size);
			DeselectAll();

		}

		private bool _selecting = false;
		private int _startPosition = 0;

		protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
		{
			try {
				if (_selecting) {
					int charPosition = base.GetCharIndexFromPosition(new System.Drawing.Point(e.X, e.Y));
					if (charPosition >= this.Text.Length) {
						return;
					}
					int length = 0;
					if (charPosition > _startPosition) {
						length = charPosition - _startPosition;
						this.Select(_startPosition, length + 1);
					} else if (charPosition < _startPosition) {
						length = _startPosition - charPosition;
						this.Select(charPosition, length);
					} else if (charPosition == this.Text.Length) {
						this.Select(charPosition - 1, 1);
					} else {
						this.Select(charPosition, 1);
					}

				}
				base.OnMouseMove(e);
			} catch (System.Exception ex) {

			}

		}

		protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
		{
			this._selecting = true;
			_startPosition = this.SelectionStart;
			base.OnMouseDown(e);
		}

		protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
		{
			this._selecting = false;
			base.OnMouseUp(e);
		}
	}
}
