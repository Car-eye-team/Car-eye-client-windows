using System;
using System.Runtime.InteropServices;

namespace CarEyeClient.DVR
{
	/// <summary>
	/// 媒体播放的委托回调方法
	/// </summary>
	/// <param name="channelId">播放通道号，从1开始</param>
	/// <param name="channelPtr">CarEyePlayer_OpenStream方法中的userPtr参数</param>
	/// <param name="frameType">帧类型，参见AVFramelag中定义</param>
	/// <param name="log">调试信息等</param>
	/// <param name="frameInfo">帧信息</param>
	/// <returns></returns>
	internal delegate int MediaSourceCallBack(int channelId, IntPtr channelPtr, int frameType, string pBuf, [MarshalAs(UnmanagedType.LPArray)] CAREYE_RTSP_FRAME_INFO[] frameInfo);

	/// <summary>
	/// 播放器本地方法类，libCarEyePlayer.dll的方法导出
	/// </summary>
	internal static class PlayerMethods
	{
		/// <summary>
		/// 播放器初始化
		/// </summary>
		/// <param name="key">有效的激活密钥</param>
		/// <returns></returns>
		[DllImport("libCarEyePlayer.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?CarEyePlayer_Init@@YAHPBD@Z")]
		public static extern int CarEyePlayer_Init([In()] [MarshalAs(UnmanagedType.LPStr)] string key);

		/// <summary>
		/// 释放播放器
		/// </summary>
		[DllImport("libCarEyePlayer.dll", EntryPoint = "?CarEyePlayer_Release@@YAXXZ")]
		public static extern void CarEyePlayer_Release();

		/// <summary>
		/// 打开媒体流
		/// </summary>
		/// <param name="url">RTSP流链接</param>
		/// <param name="hWnd">要绘制视频的窗口句柄</param>
		/// <param name="renderFormat">绘制方式</param>
		/// <param name="rtpovertcp">RTC是否为基于TCP方式，0为否，1为是</param>
		/// <param name="username">用户名</param>
		/// <param name="password">密码</param>
		/// <param name="callback">回调方法，用于播放事件通知</param>
		/// <param name="userPtr">用户自定义指针，一般传入当前的窗体，不是窗体句柄</param>
		/// <param name="bHardDecode">是否硬件解码，0为否，1为是</param>
		/// <returns></returns>
		[DllImport("libCarEyePlayer.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?CarEyePlayer_OpenStream@@YAHPBDPAUHWND__@@W4__RENDER_FORMAT@@H00P6GHHPAHHPADPAUCAREYE_RTSP_FRAME_INFO@@@ZPAX_N@Z")]
		public static extern int CarEyePlayer_OpenStream(string url, IntPtr hWnd, RENDER_FORMAT renderFormat,
										int rtpovertcp, string username, string password, MediaSourceCallBack callback, IntPtr userPtr, bool bHardDecode);

		/// <summary>
		/// 关闭指定通道的流媒体播放
		/// </summary>
		/// <param name="channelId">通道号，从1开始</param>
		[DllImport("libCarEyePlayer.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?CarEyePlayer_CloseStream@@YAXH@Z")]
		public static extern void CarEyePlayer_CloseStream(int channelId);

		/// <summary>
		/// 设置帧缓存
		/// </summary>
		/// <param name="channelId">播放通道，从1开始</param>
		/// <param name="cache">缓存帧数</param>
		/// <returns></returns>
		[DllImport("libCarEyePlayer.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?CarEyePlayer_SetFrameCache@@YAHHH@Z")]
		public static extern int CarEyePlayer_SetFrameCache(int channelId, int cache);

		/// <summary>
		/// 设置是否根据比例播放，只有在播放开始后调用该方法才会生效
		/// </summary>
		/// <param name="channelId">播放通道号，从1开始</param>
		/// <param name="shownToScale">0为全屏播放，1为根据比例播放</param>
		/// <returns></returns>
		[DllImport("libCarEyePlayer.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?CarEyePlayer_SetShownToScale@@YAHHH@Z")]
		public static extern int CarEyePlayer_SetShownToScale(int channelId, int shownToScale);

		/// <summary>
		/// 设置解码方式
		/// </summary>
		/// <param name="channelId">播放通道号，从1开始</param>
		/// <param name="decodeKeyframeOnly">是否仅解码显示关键帧，0为否，1为是</param>
		/// <returns></returns>
		[DllImport("libCarEyePlayer.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?CarEyePlayer_SetDecodeType@@YAHHH@Z")]
		public static extern int CarEyePlayer_SetDecodeType(int channelId, int decodeKeyframeOnly);

		/// <summary>
		/// 设置播放绘制的区域
		/// </summary>
		/// <param name="channelId">播放通道号，从1开始</param>
		/// <param name="lpSrcRect">播放绘制的区域</param>
		/// <returns></returns>
		[DllImport("libCarEyePlayer.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?CarEyePlayer_SetRenderRect@@YAHHPAUtagRECT@@@Z")]
		public static extern int CarEyePlayer_SetRenderRect(int channelId, ref DVRRect lpSrcRect);

		/// <summary>
		/// 设置是否显示OSD信息，仅软解码时才有效
		/// </summary>
		/// <param name="channelId">播放通道号，从1开始</param>
		/// <param name="show">1显示，0不显示</param>
		/// <returns></returns>
		[DllImport("libCarEyePlayer.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?CarEyePlayer_ShowStatisticalInfo@@YAHHH@Z")]
		public static extern int CarEyePlayer_ShowStatisticalInfo(int channelId, int show);

		/// <summary>
		/// 显示是否显示OSD信息, 并设置OSD信息样式
		/// </summary>
		/// <param name="channelId">播放通道号，从1开始</param>
		/// <param name="show">1显示，0不显示</param>
		/// <param name="osd">OSD样式结构</param>
		/// <returns></returns>
		[DllImport("libCarEyePlayer.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?CarEyePlayer_ShowOSD@@YAHHHUtagCAREYE_PALYER_OSD@@@Z")]
		public static extern int CarEyePlayer_ShowOSD(int channelId, int show, CAREYE_PALYER_OSD osd);

		/// <summary>
		/// 获取媒体信息
		/// </summary>
		/// <param name="channelId">播放通道号，从1开始</param>
		/// <param name="mediaInfo">播放的媒体信息</param>
		/// <returns></returns>
		[DllImport("libCarEyePlayer.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?CarEyePlayer_GetMediaInfo@@YAHHAAUtagCAREYE_MEDIA_INFO@@@Z")]
		public static extern int CarEyePlayer_GetMediaInfo(int channelId, ref CAREYE_MEDIA_INFO mediaInfo);

		/// <summary>
		/// 设置拖拽开始位置
		/// </summary>
		/// <param name="channelId">播放通道号，从1开始</param>
		/// <param name="pt">起始位置</param>
		/// <returns></returns>
		[DllImport("libCarEyePlayer.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?CarEyePlayer_SetDragStartPoint@@YAHHUtagPOINT@@@Z")]
		public static extern int CarEyePlayer_SetDragStartPoint(int channelId, DVRPoint pt);

		/// <summary>
		/// 设置拖拽结束位置
		/// </summary>
		/// <param name="channelId">播放通道号，从1开始</param>
		/// <param name="pt">结束位置</param>
		/// <returns></returns>
		[DllImport("libCarEyePlayer.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?CarEyePlayer_SetDragEndPoint@@YAHHUtagPOINT@@@Z")]
		public static extern int CarEyePlayer_SetDragEndPoint(int channelId, DVRPoint pt);

		/// <summary>
		/// 复位拖拽位置
		/// </summary>
		/// <param name="channelId">播放通道号，从1开始</param>
		/// <returns></returns>
		[DllImport("libCarEyePlayer.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?CarEyePlayer_ResetDragPoint@@YAHH@Z")]
		public static extern int CarEyePlayer_ResetDragPoint(int channelId);

		/// <summary>
		/// 开始录制MP4媒体文件
		/// </summary>
		/// <param name="channelId">播放通道号，从1开始</param>
		/// <returns></returns>
		[DllImport("libCarEyePlayer.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?CarEyePlayer_StartManuRecording@@YAHH@Z")]
		public static extern int CarEyePlayer_StartManuRecording(int channelId);

		/// <summary>
		/// 结束MP4的录制
		/// </summary>
		/// <param name="channelId">播放通道号，从1开始</param>
		/// <returns></returns>
		[DllImport("libCarEyePlayer.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?CarEyePlayer_StopManuRecording@@YAHH@Z")]
		public static extern int CarEyePlayer_StopManuRecording(int channelId);

		/// <summary>
		/// 播放音频
		/// </summary>
		/// <param name="channelId">播放通道号，从1开始</param>
		/// <returns></returns>
		[DllImport("libCarEyePlayer.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?CarEyePlayer_PlaySound@@YAHH@Z")]
		public static extern int CarEyePlayer_PlaySound(int channelId);

		/// <summary>
		/// 结束播放
		/// </summary>
		/// <returns></returns>
		[DllImport("libCarEyePlayer.dll", EntryPoint = "?CarEyePlayer_StopSound@@YAHXZ")]
		public static extern int CarEyePlayer_StopSound();

		/// <summary>
		/// 设置多媒体文件录制存放的目录
		/// </summary>
		/// <param name="channelId">播放通道号，从1开始</param>
		/// <param name="recordPath">存放目录</param>
		/// <returns></returns>
		[DllImport("libCarEyePlayer.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?CarEyePlayer_SetManuRecordPath@@YAHHPBD@Z")]
		public static extern int CarEyePlayer_SetManuRecordPath(int channelId, [In()] [MarshalAs(UnmanagedType.LPStr)] string recordPath);

		/// <summary>
		/// 设置抓拍照片存放目录
		/// </summary>
		/// <param name="channelId">播放通道号，从1开始</param>
		/// <param name="shotPath">存放目录</param>
		/// <returns></returns>
		[DllImport("libCarEyePlayer.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?CarEyePlayer_SetManuPicShotPath@@YAHHPBD@Z")]
		public static extern int CarEyePlayer_SetManuPicShotPath(int channelId, [In()] [MarshalAs(UnmanagedType.LPStr)] string shotPath);

		/// <summary>
		/// 开始抓拍照片
		/// </summary>
		/// <param name="channelId">播放通道号，从1开始</param>
		/// <returns></returns>
		[DllImport("libCarEyePlayer.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?CarEyePlayer_StartManuPicShot@@YAHH@Z")]
		public static extern int CarEyePlayer_StartManuPicShot(int channelId);

		/// <summary>
		/// 停止抓拍照片
		/// </summary>
		/// <param name="channelId">播放通道号，从1开始</param>
		/// <returns></returns>
		[DllImport("libCarEyePlayer.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?CarEyePlayer_StopManuPicShot@@YAHH@Z")]
		public static extern int CarEyePlayer_StopManuPicShot(int channelId);
	}
}
