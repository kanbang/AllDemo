using System;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Permissions;
using System.Globalization;
using System.Collections;
using System.Diagnostics;
using System.Reflection;


namespace GdiPlusTest
{
	/// <summary>
	/// List of graphic objects
	/// </summary>
	public class GraphicsList
	{
		private ArrayList graphicsList;

		private const string entryCount = "Count";
		private const string entryType = "Type";

		public GraphicsList()
		{
			graphicsList = new ArrayList();
		}

		public void Draw(Graphics g)
		{
			int n = graphicsList.Count;
			DrawObject o;

			// Enumerate list in reverse order
			// to get first object on the top
			for (int i = n - 1; i >= 0; i--) {
				o = (DrawObject)graphicsList[i];
				//todo 测试高亮颜色所用，确认后删除
				o.HighlightColor = DrawRegion.Highlight;
				o.Draw(g);
			}
		}

		/// <summary>
		/// Clear all objects in the list
		/// </summary>
		/// <returns>
		/// true if at least one object is deleted
		/// </returns>
		public bool Clear()
		{
			bool result = (graphicsList.Count > 0);
			graphicsList.Clear();
			return result;
		}

		/// <summary>
		/// Count and this [nIndex] allow to read all graphics objects
		/// from GraphicsList in the loop.
		/// </summary>
		public int Count
		{
			get
			{
				return graphicsList.Count;
			}
		}

		public DrawObject this[int index]
		{
			get
			{
				if (index < 0 || index >= graphicsList.Count)
					return null;

				return ((DrawObject)graphicsList[index]);
			}
		}

		/// <summary>
		/// SelectedCount and GetSelectedObject allow to read
		/// selected objects in the loop
		/// </summary>
		public int SelectionCount
		{
			get
			{
				int n = 0;

				foreach (DrawObject o in graphicsList) {
					if (o.Selected)
						n++;
				}

				return n;
			}
		}

		public DrawObject GetSelectedObject(int index)
		{
			int n = -1;

			foreach (DrawObject o in graphicsList) {
				if (o.Selected) {
					n++;

					if (n == index)
						return o;
				}
			}

			return null;
		}

		public void Add(DrawObject obj)
		{
			// insert to the top of z-order
			graphicsList.Insert(0, obj);
		}

		public void SelectInRectangle(Rectangle rectangle)
		{

			foreach (DrawObject o in graphicsList) {
				if (o.IntersectsWith(rectangle))
					o.Selected = true;
			}

		}

		public void UnselectAll()
		{
			foreach (DrawObject o in graphicsList) {
				o.Selected = false;
			}
		}

		public void SelectAll()
		{
			foreach (DrawObject o in graphicsList) {
				o.Selected = true;
			}
		}

		/// <summary>
		/// Delete selected items
		/// </summary>
		/// <returns>
		/// true if at least one object is deleted
		/// </returns>
		public bool DeleteSelection()
		{
			bool result = false;

			int n = graphicsList.Count;

			for (int i = n - 1; i >= 0; i--) {
				if (((DrawObject)graphicsList[i]).Selected) {
					graphicsList.RemoveAt(i);
					result = true;
				}
			}

			return result;
		}
	}
}
