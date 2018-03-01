using System.Runtime.InteropServices;

namespace CarEyeClient.DVR
{
	/// <summary>
	/// 多媒体内容信息结构体
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	internal struct CAREYE_MEDIA_INFO
	{
		/// <summary>
		/// 音视频格式
		/// </summary>
		public uint video_codec;
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
		/// 音视频格式
		/// </summary>
		public uint audio_codec;
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
		/// 保留参数1
		/// </summary>
		public uint reserved1;
		/// <summary>
		/// 保留参数2
		/// </summary>
		public uint reserved2;
	}
}
