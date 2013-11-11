using System;
using System.Windows.Forms;
using System.Drawing;

namespace GdiPlusTest
{
	/// <summary>
	/// Base class for all drawing tools
	/// </summary>
	public abstract class Tool
	{
		/// <summary>
		/// Left nous button is pressed
		/// </summary>
		/// <param name="DrawRegion"></param>
		/// <param name="e"></param>
		public virtual void OnMouseDown(DrawRegion drawRegion, MouseEventArgs e)
		{
		}


		/// <summary>
		/// Mouse is moved, left mouse button is pressed or none button is pressed
		/// </summary>
		/// <param name="DrawRegion"></param>
		/// <param name="e"></param>
		public virtual void OnMouseMove(DrawRegion drawRegion, MouseEventArgs e)
		{
		}


		/// <summary>
		/// Left mouse button is released
		/// </summary>
		/// <param name="DrawRegion"></param>
		/// <param name="e"></param>
		public virtual void OnMouseUp(DrawRegion drawRegion, MouseEventArgs e)
		{
		}
	}
}
