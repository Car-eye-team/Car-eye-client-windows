using System.Runtime.InteropServices;

namespace CarEyeClient.DVR
{
	/// <summary>
	/// 本地区域定义，为了防止与WIN32中定义的RECT冲突，其实定义是一样的。。。
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	internal struct DVRRect
	{
		/// <summary>
		/// 左侧位置
		/// </summary>
		public int left;

		/// <summary>
		/// 顶部位置
		/// </summary>
		public int top;

		/// <summary>
		/// 右侧位置
		/// </summary>
		public int right;

		/// <summary>
		/// 底部位置
		/// </summary>
		public int bottom;
	}
}
