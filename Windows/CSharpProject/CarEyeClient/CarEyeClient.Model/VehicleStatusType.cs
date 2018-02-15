using System.ComponentModel;

namespace CarEyeClient.Model
{
	/// <summary>
	/// 车辆状态定义
	/// </summary>
	public enum VehicleStatusType
	{
		/// <summary>
		/// 长时间离线
		/// </summary>
		[Description(@"长时间离线")]
		LongOffline = 1,
		/// <summary>
		/// 离线
		/// </summary>
		[Description(@"离线")]
		Offline = 2,
		/// <summary>
		/// 熄火
		/// </summary>
		[Description(@"熄火")]
		Flameout = 3,
		/// <summary>
		/// 停车
		/// </summary>
		[Description(@"停车")]
		Parking = 4,
		/// <summary>
		/// 行驶中
		/// </summary>
		[Description(@"行驶中")]
		Driving = 5,
		/// <summary>
		/// 报警
		/// </summary>
		[Description(@"报警")]
		Alarm = 6,
		/// <summary>
		/// 在线
		/// </summary>
		[Description(@"在线")]
		Online = 7,
	}
}
