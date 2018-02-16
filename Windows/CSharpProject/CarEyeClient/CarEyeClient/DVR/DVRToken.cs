using CarEyeClient.Model;

namespace CarEyeClient.DVR
{
	/// <summary>
	/// 视频预览属性单元
	/// </summary>
	internal class DVRToken
	{
		/// <summary>
		/// 终端编号
		/// </summary>
		public string TerminalId { get; set; }
		/// <summary>
		/// 逻辑通道号
		/// </summary>
		public AVChannel LogicChn { get; set; }
		/// <summary>
		/// 视频直播流地址
		/// </summary>
		public string Url { get; set; }

		public override string ToString()
		{
			return string.Format("{0}-{1}", this.TerminalId, this.LogicChn.ToDescription());
		}
	}
}
