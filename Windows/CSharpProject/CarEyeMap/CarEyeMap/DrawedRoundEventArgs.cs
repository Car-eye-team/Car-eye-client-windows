using System;

namespace CarEyeMap
{
	/// <summary>
	/// 绘制完圆形区域的事件参数
	/// </summary>
	public class DrawedRoundEventArgs : EventArgs
	{
		/// <summary>
		/// 中心点的坐标
		/// </summary>
		public Coordinate Center { get; private set; }
		/// <summary>
		/// 圆形半径(m)
		/// </summary>
		public double Radius { get; set; }

		/// <summary>
		/// 创建圆形区域事件参数
		/// </summary>
		/// <param name="aCenter"></param>
		public DrawedRoundEventArgs(Coordinate aCenter)
		{
			this.Center = aCenter;
		}
	}
}
