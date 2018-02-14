using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CarEyeClient.Model;
using CarEyeClient.Properties;

namespace CarEyeClient.Utils
{
	/// <summary>
	/// 申请服务URL帮助工具类
	/// </summary>
	internal static class UrlApiHelper
	{
		/// <summary>
		/// 服务器申请API的连接开头
		/// </summary>
		private static string SvrUrl => $"http://{Settings.Default.SvrIp}:{Settings.Default.SvrPort}/api/";

		/// <summary>
		/// 基本每个请求都会涉及到终端编号与服务器AK, 故用该方法打包一下
		/// </summary>
		/// <param name="aTerminalId">终端编号</param>
		/// <returns></returns>
		private static string GetTermianlAkUrl(string aTerminalId)
		{
			return $"ak={GlobalCfg.ServerKey}&terminal={aTerminalId}";
		}

		/// <summary>
		/// 将字符串第一个字母进行小写
		/// </summary>
		/// <param name="aStr"></param>
		/// <returns></returns>
		private static string LowerFirstChar(string aStr)
		{
			return aStr.Substring(0, 1).ToLower() + aStr.Substring(1);
		}

		/// <summary>
		/// 获取指定终端编号的获取最新位置信息的URL字符串
		/// 方法名不要随意修改, 与URL联动
		/// </summary>
		/// <param name="aTerminalId">终端编号</param>
		/// <returns></returns>
		public static string GetLastPosition(string aTerminalId)
		{
			return $"{SvrUrl}{LowerFirstChar(MethodBase.GetCurrentMethod().Name)}.action?" +
					$"{GetTermianlAkUrl(aTerminalId)}";
		}

		/// <summary>
		/// 获取指定终端编号在指定时间段内的历史轨迹的URL字符串
		/// 方法名不要随意修改, 与URL联动
		/// </summary>
		/// <param name="aTerminalId">终端编号</param>
		/// <param name="aStart">开始时间</param>
		/// <param name="aEnd">结束时间</param>
		/// <returns></returns>
		public static string GetHistoricalPosition(string aTerminalId, DateTime aStart, DateTime aEnd)
		{
			return $"{SvrUrl}{LowerFirstChar(MethodBase.GetCurrentMethod().Name)}.action?" +
					$"{GetTermianlAkUrl(aTerminalId)}" +
					$"&stime={aStart.ToString(GlobalCfg.TimeFormat)}" +
					$"&etime={aEnd.ToString(GlobalCfg.TimeFormat)}";
		}

		/// <summary>
		/// 对指定终端进行视频控制 开启实时预览或者停止预览
		/// </summary>
		/// <param name="aTerminalId">终端编号</param>
		/// <param name="aChn">通道号</param>
		/// <param name="aType">控制方式</param>
		/// <returns></returns>
		public static string VideoControl(string aTerminalId, AVChannel aChn, VedioControlType aType)
		{
			return $"{SvrUrl}{LowerFirstChar(MethodBase.GetCurrentMethod().Name)}.action?" +
					$"{GetTermianlAkUrl(aTerminalId)}" +
					$"&type={(int)aType}&id={(byte)aChn}";
		}
	}
}
