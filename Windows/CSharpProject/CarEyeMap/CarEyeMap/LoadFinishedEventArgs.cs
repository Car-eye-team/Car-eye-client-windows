using System;

namespace CarEyeMap
{
	/// <summary>
	/// 地图载入完成触发事件参数
	/// </summary>
	public class LoadFinishedEventArgs : EventArgs
	{
		/// <summary>
		/// 中心点的坐标
		/// </summary>
		public Coordinate Center { get; private set; }

		/// <summary>
		/// 创建地图载入完成事件参数
		/// </summary>
		/// <param name="aCenter"></param>
		public LoadFinishedEventArgs(Coordinate aCenter)
		{
			this.Center = aCenter;
		}
	}
}
