using System.ComponentModel;

namespace CarEyeClient.Model
{
	/// <summary>
	/// 视频控制类型定义
	/// </summary>
	public enum VedioControlType
    {
		/// <summary>
		/// 实时预览
		/// </summary>
		[Description(@"实时预览")]
		RealTime = 0,
		/// <summary>
		/// 停止预览
		/// </summary>
		[Description(@"停止预览")]
		Stop = 1,
    }
}
