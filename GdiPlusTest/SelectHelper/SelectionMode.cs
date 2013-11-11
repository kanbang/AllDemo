using System;
using System.Collections.Generic;
using System.Text;

namespace GdiPlusTest
{
	public enum SelectionMode
	{
		None,
		NetSelection,   // group selection is active
		Move,           // object(s) are moves
		Size            // object is resized
	}
}
