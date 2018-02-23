namespace CarEyeClient.DVR
{
	/// <summary>
	/// 音视频帧标识
	/// </summary>
	internal static class AVFrameFlag
	{
		/* 视频编码 */
		public const int EASY_SDK_VIDEO_CODEC_H264 = 0x1C;      /* H264  */
		public const int EASY_SDK_VIDEO_CODEC_H265 = 0x48323635; /* 1211250229 */
		public const int EASY_SDK_VIDEO_CODEC_MJPEG = 0x08;     /* MJPEG */
		public const int EASY_SDK_VIDEO_CODEC_MPEG4 = 0x0D;      /* MPEG4 */

		/* 音频编码 */
		public const int EASY_SDK_AUDIO_CODEC_AAC = 0x15002;    /* AAC */
		public const int EASY_SDK_AUDIO_CODEC_G711U = 0x10006;      /* G711 ulaw*/
		public const int EASY_SDK_AUDIO_CODEC_G711A = 0x10007;       /* G711 alaw*/
		public const int EASY_SDK_AUDIO_CODEC_G726 = 0x1100B;       /* G726 */

		public const int EASY_SDK_EVENT_CODEC_ERROR = 0x63657272;   /* ERROR */
		public const int EASY_SDK_EVENT_CODEC_EXIT = 0x65786974; /* EXIT */
		public const int EASY_SDK_EVENT_CODEC_SHOT_START = 0x12001;  /* Screen shot start*/
		public const int EASY_SDK_EVENT_CODEC_SLOT_STOP = 0x12002;  /* Screen shot stop */
		public const int EASY_SDK_EVENT_CODEC_RECORD_START = 0x12003;   /* Record Start */
		public const int EASY_SDK_EVENT_CODEC_RECORD_STOP = 0x12004; /* Record Stop */

		/// <summary>
		/// 视频帧标志
		/// </summary>
		public const int EASY_SDK_VIDEO_FRAME_FLAG = 0x00000001;
		/// <summary>
		/// 音频帧标志
		/// </summary>
		public const int EASY_SDK_AUDIO_FRAME_FLAG = 0x00000002;
		/// <summary>
		/// 事件帧标志
		/// </summary>
		public const int EASY_SDK_EVENT_FRAME_FLAG = 0x00000004;
		/// <summary>
		/// RTP帧标志
		/// </summary>
		public const int EASY_SDK_RTP_FRAME_FLAG = 0x00000008;
		/// <summary>
		/// SDP帧标志
		/// </summary>
		public const int EASY_SDK_SDP_FRAME_FLAG = 0x00000010;
		/// <summary>
		/// 媒体类型标志
		/// </summary>
		public const int EASY_SDK_MEDIA_INFO_FLAG = 0x00000020;
	}
}
