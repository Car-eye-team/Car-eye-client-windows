using System.ComponentModel;

namespace CarEyeClient.DVR
{
	/// <summary>
	/// 分屏样式定义
	/// </summary>
	internal enum SplitScreenType
	{
		/// <summary>
		/// 全屏
		/// </summary>
		[Description(@"全屏")]
		Full = 1,
		/// <summary>
		/// 4分屏
		/// </summary>
		[Description(@"4分屏")]
		Four = 4,
		/// <summary>
		/// 6分屏
		/// </summary>
		[Description(@"6分屏")]
		Six = 6,
		/// <summary>
		/// 8分屏
		/// </summary>
		[Description(@"8分屏")]
		Eight = 8,
		/// <summary>
		/// 9分屏
		/// </summary>
		[Description(@"9分屏")]
		Nine = 9,
		/// <summary>
		/// 16分屏
		/// </summary>
		[Description(@"16分屏")]
		Sixteen = 16,
	}
}
