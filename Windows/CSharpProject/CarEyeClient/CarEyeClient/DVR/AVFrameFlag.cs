namespace CarEyeClient.DVR
{
	/// <summary>
	/// 音视频帧标识
	/// </summary>
	internal static class AVFrameFlag
	{
		/// <summary>
		/// 视频帧标志
		/// </summary>
		public const int CAREYE_SDK_VIDEO_FRAME_FLAG = 0x00000001;
		/// <summary>
		/// 音频帧标志
		/// </summary>
		public const int CAREYE_SDK_AUDIO_FRAME_FLAG = 0x00000002;
		/// <summary>
		/// 事件帧标志
		/// </summary>
		public const int CAREYE_SDK_EVENT_FRAME_FLAG = 0x00000004;
		/// <summary>
		/// RTP帧标志
		/// </summary>
		public const int CAREYE_SDK_RTP_FRAME_FLAG = 0x00000008;
		/// <summary>
		/// SDP帧标志
		/// </summary>
		public const int CAREYE_SDK_SDP_FRAME_FLAG = 0x00000010;
		/// <summary>
		/// 媒体类型标志
		/// </summary>
		public const int CAREYE_SDK_MEDIA_INFO_FLAG = 0x00000020;
		/// <summary>
		/// 解码视频类型标志
		/// </summary>
		public const int CAREYE_SDK_DECODE_VIDEO_FLAG = 0x00000040;
		/// <summary>
		/// 解码音频类型标志
		/// </summary>
		public const int CAREYE_SDK_DECODE_AUDO_FLAG = 0x00000080;
		/// <summary>
		/// ERROR
		/// </summary>
		public const int CAREYE_SDK_EVENT_CODEC_ERROR = 0x63657272;
		/// <summary>
		/// EXIT
		/// </summary>
		public const int CAREYE_SDK_EVENT_CODEC_EXIT = 0x65786974;
		/// <summary>
		/// Screen shot start
		/// </summary>
		public const int CAREYE_SDK_EVENT_CODEC_SHOT_START = 0x12001;
		/// <summary>
		/// Screen shot stop
		/// </summary>
		public const int CAREYE_SDK_EVENT_CODEC_SLOT_STOP = 0x12002;
		/// <summary>
		/// Record Start
		/// </summary>
		public const int CAREYE_SDK_EVENT_CODEC_RECORD_START = 0x12003;
		/// <summary>
		/// Record Stop
		/// </summary>
		public const int CAREYE_SDK_EVENT_CODEC_RECORD_STOP = 0x12004;
	}
}
