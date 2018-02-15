using System.Runtime.Serialization;

namespace CarEyeClient.Model
{
	/// <summary>
	/// 最新位置信息的JSON实体类
	/// </summary>
	[DataContract]
	public class JsonLastPosition : JsonBase
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
		/// 车辆状态
		/// </summary>
		[DataMember(Name = "carstatus")]
		public int VehicleStatus { get; set; }
		/// <summary>
		/// 获取车辆状态描述
		/// </summary>
		public string StatusDescription { get => ((VehicleStatusType)VehicleStatus).ToDescription(); }
		/// <summary>
		/// 终端类型
		/// </summary>
		[DataMember(Name = "devicetype")]
		public string TerminalType { get; set; }
		/// <summary>
		/// 获取终端类型描述
		/// </summary>
		public string TypeDescription
		{
			get
			{
				if (string.IsNullOrEmpty(TerminalType))
				{
					return "无";
				}
				return ((TerminalType)TerminalType[0]).ToDescription();
			}
		}
	}
}
