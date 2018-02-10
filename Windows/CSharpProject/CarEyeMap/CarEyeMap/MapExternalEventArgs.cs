using System;

namespace CarEyeMap
{
	/// <summary>
	/// 地图扩展方法事件触发参数定义
	/// </summary>
	public class MapExternalEventArgs : EventArgs
	{
		/// <summary>
		/// 要执行的方法名
		/// </summary>
		public string Method { get; set; }
		/// <summary>
		/// 方法参数
		/// </summary>
		public object[] Arguments { get; set; }

		/// <summary>
		/// 创建一个空的地图扩展方法事件参数
		/// </summary>
		public MapExternalEventArgs()
		{

		}

		/// <summary>
		/// 创建指定方法的地图扩展方法事件参数
		/// </summary>
		/// <param name="aMethod"></param>
		/// <param name="aArgs"></param>
		public MapExternalEventArgs(string aMethod, object[] aArgs)
		{
			this.Method = aMethod;
			this.Arguments = aArgs;
		}
	}
}
