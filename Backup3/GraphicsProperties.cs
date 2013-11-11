using System;
using System.Windows.Forms;
using System.Drawing;


namespace DrawTools
{
	/// <summary>
	/// Helper class used to show properties
	/// for one or more graphic objects
	/// </summary>
	public class GraphicsProperties
	{
        private Color color;
        private int penWidth;
        private bool colorDefined;
        private bool penWidthDefined;

        public GraphicsProperties()
        {
            color = Color.Black;
            penWidth = 1;
            colorDefined = false;
            penWidthDefined = false;
        }

        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        public int PenWidth
        {
            get
            {
                return penWidth;
            }
            set
            {
                penWidth = value;
            }
        }

        public bool ColorDefined
        {
            get
            {
                return colorDefined;
            }
            set
            {
                colorDefined = value;
            }
        }

        public bool PenWidthDefined
        {
            get
            {
                return penWidthDefined;
            }
            set
            {
                penWidthDefined = value;
            }
        }
	}
}
