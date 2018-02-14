using System.Runtime.Serialization;

namespace CarEyeClient.Model
{
	/// <summary>
	/// 从服务器获取的JSON代码基类型
	/// </summary>
	[DataContract]
	public class JsonBase
	{
		/// <summary>
		/// 状态码
		/// </summary>
		[DataMember(Name = "status")]
		public int Status { get; set; }
		/// <summary>
		/// 状态码对应的消息描述
		/// </summary>
		[DataMember(Name = "message")]
		public string Message { get; set; }
	}
}
