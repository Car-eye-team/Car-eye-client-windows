using System;
using System.Collections.Generic;

namespace CarEyeMap
{
	/// <summary>
	/// 绘制完路线的事件参数
	/// </summary>
	public class DrawedRouteEventArgs : EventArgs
	{
		/// <summary>
		/// 路线拐点集合
		/// </summary>
		public List<Coordinate> Points { get; private set; }
		/// <summary>
		/// 获取路线的拐点个数
		/// </summary>
		public int Count
		{
			get
			{
				return this.Points == null ? 0 : this.Points.Count;
			}
		}

		/// <summary>
		/// 创建路线绘制参数
		/// </summary>
		/// <param name="aPoints"></param>
		public DrawedRouteEventArgs(List<Coordinate> aPoints)
		{
			this.Points = aPoints;
		}
	}
}
