using System.Runtime.Serialization;

namespace CarEyeClient.Model
{
	/// <summary>
	/// 历史轨迹数据项实体类
	/// </summary>
	[DataContract]
	public class JsonHistoryItem
	{
		/// <summary>
		/// 车牌号码
		/// </summary>
		[DataMember(Name = "carnumber")]
		public string LicensePlate { get; set; }
		/// <summary>
		/// 终端编号
		/// </summary>
		[DataMember(Name = "terminal")]
		public string TerminalId { get; set; }
		/// <summary>
		/// 车辆索引
		/// </summary>
		[DataMember(Name = "carid")]
		public decimal VehicleIndex { get; set; }
		/// <summary>
		/// 车辆实时速度, 公里/小时
		/// </summary>
		[DataMember(Name = "speed")]
		public double Speed { get; set; }
		/// <summary>
		/// 方向, 正北为0度
		/// </summary>
		[DataMember(Name = "direction")]
		public int Direction { get; set; }
		/// <summary>
		/// 海拔高度, 单位米
		/// </summary>
		[DataMember(Name = "altitude")]
		public int Altitude { get; set; }
		/// <summary>
		/// 经度
		/// </summary>
		[DataMember(Name = "lng")]
		public double Longitude { get; set; }
		/// <summary>
		/// 纬度
		/// </summary>
		[DataMember(Name = "lat")]
		public double Latitude { get; set; }
		/// <summary>
		/// 百度地图中的经度
		/// </summary>
		[DataMember(Name = "blng")]
		public double BdLongitude { get; set; }
		/// <summary>
		/// 百度地图中的纬度
		/// </summary>
		[DataMember(Name = "blat")]
		public double BdLatitude { get; set; }
		/// <summary>
		/// 详细地理地址描述
		/// </summary>
		[DataMember(Name = "address")]
		public string Address { get; set; }
		/// <summary>
		/// 里程, 单位公里
		/// </summary>
		[DataMember(Name = "mileage")]
		public double Mileage { get; set; }
		/// <summary>
		/// 本条位置信息定位时间
		/// </summary>
		[DataMember(Name = "createtime")]
		public string LocationTime { get; set; }
		/// <summary>
		/// GPS时间
		/// </summary>
		[DataMember(Name = "gpstime")]
		public string GpsTime { get; set; }
		/// <summary>
		/// 报警名称
		/// </summary>
		[DataMember(Name = "alarmname")]
		public string AlarmName { get; set; }
		/// <summary>
		/// 报警类型
		/// </summary>
		[DataMember(Name = "alarmtype")]
		public string AlarmType { get; set; }
	}
}
