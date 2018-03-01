using System;
using System.Runtime.InteropServices;

namespace CarEyeClient.DVR
{
	/// <summary>
	/// 播放器OSD结构体
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	internal struct CAREYE_PALYER_OSD
	{
		/// <summary>
		/// OSD缓存
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
		public byte[] stOSD;
		/// <summary>
		/// 透明度 0~255
		/// </summary>
		public UInt32 alpha;
		/// <summary>
		/// 前景色RGB值
		/// </summary>
		public UInt32 color;
		/// <summary>
		/// 背景色RGB值
		/// </summary>
		public UInt32 shadowcolor;
		/// <summary>
		/// OSD基于图像右上角显示区域
		/// </summary>
		public DVRRect rect;
		/// <summary>
		/// 尺寸大小 仅支持D3D
		/// </summary>
		public int size;
	}
}
