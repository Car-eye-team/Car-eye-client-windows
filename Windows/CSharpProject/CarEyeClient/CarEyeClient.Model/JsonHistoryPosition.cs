using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CarEyeClient.Model
{
	/// <summary>
	/// 历史轨迹信息的JSON实体类
	/// </summary>
	[DataContract]
	public class JsonHistoryPosition : JsonBase
	{
		/// <summary>
		/// 总记录数
		/// </summary>
		[DataMember(Name = "totalCount")]
		public int Count { get; set; }
		/// <summary>
		/// 历史轨迹集合
		/// </summary>
		[DataMember(Name = "list")]
		public List<JsonHistoryItem> Items { get; set; }
	}
}
