using System;

namespace CarEyeMap
{
	/// <summary>
	/// 绘制完矩形区域的事件参数
	/// </summary>
	public class DrawedRectEventArgs : EventArgs
	{
		/// <summary>
		/// 西南角坐标，经纬度最小点坐标
		/// </summary>
		public Coordinate Min { get; private set; }
		/// <summary>
		/// 东北角坐标，经纬度最大点坐标
		/// </summary>
		public Coordinate Max { get; private set; }

		/// <summary>
		/// 创建矩形区域事件参数
		/// </summary>
		/// <param name="aMin">西南角坐标</param>
		/// <param name="aMax">东北角坐标</param>
		public DrawedRectEventArgs(Coordinate aMin, Coordinate aMax)
		{
			this.Min = aMin;
			this.Max = aMax;
		}
	}
}
