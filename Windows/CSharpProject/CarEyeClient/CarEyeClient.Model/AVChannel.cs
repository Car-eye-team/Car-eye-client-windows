using System.ComponentModel;

namespace CarEyeClient.Model
{
	/// <summary>
	/// 音视频逻辑通道类型定义,参见JTT176-2016表2
	/// </summary>
	public enum AVChannel : byte
	{
		/// <summary>
		/// 音视频/视频,驾驶员区域
		/// </summary>
		[Description(@"驾驶员音视频/视频")]
		Chn1 = 1,
		/// <summary>
		/// 音视频/视频,车辆正前方
		/// </summary>
		[Description(@"车辆正前方")]
		Chn2,
		/// <summary>
		/// 音视频/视频,车前门
		/// </summary>
		[Description(@"车前门")]
		Chn3,
		/// <summary>
		/// 音视频/视频,车厢前部
		/// </summary>
		[Description(@"车厢前部音视频/视频")]
		Chn4,
		/// <summary>
		/// 音视频/视频,车厢后部
		/// </summary>
		[Description(@"车厢后部音视频/视频")]
		Chn5,
		/// <summary>
		/// 音视频/视频,车后门
		/// </summary>
		[Description(@"车后门")]
		Chn6,
		/// <summary>
		/// 音视频/视频,行李舱
		/// </summary>
		[Description(@"行李舱")]
		Chn7,
		/// <summary>
		/// 音视频/视频,车辆左侧
		/// </summary>
		[Description(@"车辆左侧")]
		Chn8,
		/// <summary>
		/// 音视频/视频,车辆右侧
		/// </summary>
		[Description(@"车辆右侧")]
		Chn9,
		/// <summary>
		/// 音视频/视频,车辆正后方
		/// </summary>
		[Description(@"车辆正后方")]
		Chn10,
		/// <summary>
		/// 音视频/视频,车厢中部
		/// </summary>
		[Description(@"车厢中部音视频/视频")]
		Chn11,
		/// <summary>
		/// 音视频/视频,车中门
		/// </summary>
		[Description(@"车中门")]
		Chn12,
		/// <summary>
		/// 音视频/视频,驾驶席车门
		/// </summary>
		[Description(@"驾驶席车门")]
		Chn13,
		/// <summary>
		/// 音频,驾驶员区域
		/// </summary>
		[Description(@"驾驶员音频")]
		Chn33 = 33,
		/// <summary>
		/// 音频,车厢前部
		/// </summary>
		[Description(@"车厢前部音频")]
		Chn36 = 36,
		/// <summary>
		/// 音频,车厢后部
		/// </summary>
		[Description(@"车厢后部音频")]
		Chn37 = 37,
	}
}
