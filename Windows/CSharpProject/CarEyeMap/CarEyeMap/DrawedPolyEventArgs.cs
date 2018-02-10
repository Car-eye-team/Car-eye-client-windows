using System;
using System.Collections.Generic;

namespace CarEyeMap
{
	/// <summary>
	/// 绘制完多边形区域的事件参数
	/// </summary>
	public class DrawedPolyEventArgs : EventArgs
	{
		/// <summary>
		/// 多边形区域顶点集合
		/// </summary>
		public List<Coordinate> Points { get; private set; }
		/// <summary>
		/// 获取多边形区域的顶点个数
		/// </summary>
		public int Count
		{
			get
			{
				return this.Points == null ? 0 : this.Points.Count;
			}
		}

		/// <summary>
		/// 创建多边形区域绘制参数
		/// </summary>
		/// <param name="aPoints"></param>
		public DrawedPolyEventArgs(List<Coordinate> aPoints)
		{
			this.Points = aPoints;
		}
	}
}
