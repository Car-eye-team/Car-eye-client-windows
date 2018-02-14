using System.ComponentModel;

namespace CarEyeClient.Model
{
	/// <summary>
	/// 终端类型定义
	/// </summary>
	public enum TerminalType
	{
		/// <summary>
		/// 部标
		/// </summary>
		[Description(@"部标")]
		Standard = '7',
		/// <summary>
		/// 商用车
		/// </summary>
		[Description(@"商用车")]
		Commercial = '6',
		/// <summary>
		/// 乘用车
		/// </summary>
		[Description(@"乘用车")]
		Passenger = 'A',
		/// <summary>
		/// 专用车
		/// </summary>
		[Description(@"专用车")]
		Special = 'B',
		/// <summary>
		/// GPS定位器
		/// </summary>
		[Description(@"GPS定位器")]
		GPS = 'C',
		/// <summary>
		/// 海联盛世OBD
		/// </summary>
		[Description(@"海联盛世OBD")]
		OBD_HL = 'D',
	}
}
