using System.Runtime.InteropServices;

namespace CarEyeClient.DVR
{
	/// <summary>
	/// RTSP帧信息实体类
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	internal struct CAREYE_RTSP_FRAME_INFO
	{
		/// <summary>
		/// 音视频格式
		/// </summary>
		public uint codec;

		/// <summary>
		/// 视频帧类型
		/// </summary>
		public uint type;
		/// <summary>
		/// 视频帧率
		/// </summary>
		public byte fps;
		/// <summary>
		/// 视频宽
		/// </summary>
		public ushort width;
		/// <summary>
		/// 视频高
		/// </summary>
		public ushort height;

		/// <summary>
		/// 保留参数1
		/// </summary>
		public uint reserved1;
		/// <summary>
		/// 保留参数2
		/// </summary>
		public uint reserved2;

		/// <summary>
		/// 音频采样率
		/// </summary>
		public uint sample_rate;
		/// <summary>
		/// 音频声道数
		/// </summary>
		public uint channels;
		/// <summary>
		/// 音频采样精度
		/// </summary>
		public uint bits_per_sample;

		/// <summary>
		/// 音视频帧大小
		/// </summary>
		public uint length;
		/// <summary>
		/// 时间戳,微秒
		/// </summary>
		public uint timestamp_usec;
		/// <summary>
		/// 时间戳 秒
		/// </summary>
		public uint timestamp_sec;

		/// <summary>
		/// 比特率
		/// </summary>
		public float bitrate;
		/// <summary>
		/// 丢包率
		/// </summary>
		public float losspacket;
	}
}
