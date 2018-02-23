using System.Runtime.InteropServices;

namespace CarEyeClient.DVR
{
	/// <summary>
	/// 位置定义，防止跟系统定义的Point冲突
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	internal struct DVRPoint
	{
		/// <summary>
		/// X轴坐标
		/// </summary>
		public int x;

		/// <summary>
		/// Y轴坐标
		/// </summary>
		public int y;
	}
}
