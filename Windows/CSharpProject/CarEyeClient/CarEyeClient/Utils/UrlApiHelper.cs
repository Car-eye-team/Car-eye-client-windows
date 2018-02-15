using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
		private static string GetLastPosition(string aTerminalId)
		{
			return $"{SvrUrl}{LowerFirstChar(MethodBase.GetCurrentMethod().Name)}.action?" +
					$"{GetTermianlAkUrl(aTerminalId)}";
		}

		/// <summary>
		/// 获取指定终端最新的位置信息
		/// </summary>
		/// <param name="aTerminalId">终端编号</param>
		/// <returns>null服务器无响应</returns>
		public static JsonLastPosition GetLastLocation(string aTerminalId)
		{
			string jsonStr = GetApiReply(GetLastPosition(aTerminalId));
			if (string.IsNullOrEmpty(jsonStr))
			{
				return null;
			}
			JsonLastPosition lastLocation = ModelUtils.GetJsonObject<JsonLastPosition>(jsonStr);
			if (lastLocation != null)
			{
				return lastLocation;
			}
			JsonBase errInfo = ModelUtils.GetJsonObject<JsonBase>(jsonStr);
			if (errInfo == null)
			{
				return null;
			}

			// 重新组合返回错误值
			return new JsonLastPosition
			{
				Status = errInfo.Status,
				Message = errInfo.Message
			};
		}

		/// <summary>
		/// 获取指定终端编号在指定时间段内的历史轨迹的URL字符串
		/// 方法名不要随意修改, 与URL联动
		/// </summary>
		/// <param name="aTerminalId">终端编号</param>
		/// <param name="aStart">开始时间</param>
		/// <param name="aEnd">结束时间</param>
		/// <returns></returns>
		private static string GetHistoricalPosition(string aTerminalId, DateTime aStart, DateTime aEnd)
		{
			return $"{SvrUrl}{LowerFirstChar(MethodBase.GetCurrentMethod().Name)}.action?" +
					$"{GetTermianlAkUrl(aTerminalId)}" +
					$"&stime={aStart.ToString(GlobalCfg.TimeFormat)}" +
					$"&etime={aEnd.ToString(GlobalCfg.TimeFormat)}";
		}

		/// <summary>
		/// 获取指定终端编号在指定时间段内的历史轨迹
		/// </summary>
		/// <param name="aTerminalId">终端编号</param>
		/// <param name="aStart">开始时间</param>
		/// <param name="aEnd">结束时间</param>
		/// <returns></returns>
		public static JsonHistoryPosition GetHistory(string aTerminalId, DateTime aStart, DateTime aEnd)
		{
			string jsonStr = GetApiReply(GetHistoricalPosition(aTerminalId, aStart, aEnd));
			if (string.IsNullOrEmpty(jsonStr))
			{
				return null;
			}

			JsonHistoryPosition historyLocation = ModelUtils.GetJsonObject<JsonHistoryPosition>(jsonStr);
			if (historyLocation != null)
			{
				return historyLocation;
			}
			JsonBase errInfo = ModelUtils.GetJsonObject<JsonBase>(jsonStr);
			if (errInfo == null)
			{
				return null;
			}

			// 重新组合返回错误值
			return new JsonHistoryPosition
			{
				Status = errInfo.Status,
				Message = errInfo.Message
			};
		}

		/// <summary>
		/// 对指定终端进行视频控制 开启实时预览或者停止预览的URL
		/// </summary>
		/// <param name="aTerminalId">终端编号</param>
		/// <param name="aChn">通道号</param>
		/// <param name="aType">控制方式</param>
		/// <returns></returns>
		private static string VideoControl(string aTerminalId, AVChannel aChn, VedioControlType aType)
		{
			return $"{SvrUrl}{LowerFirstChar(MethodBase.GetCurrentMethod().Name)}.action?" +
					$"{GetTermianlAkUrl(aTerminalId)}" +
					$"&type={(int)aType}&id={(byte)aChn}";
		}

		/// <summary>
		/// 对指定终端进行视频控制 开启实时预览或者停止预览
		/// </summary>
		/// <param name="aTerminalId">终端编号</param>
		/// <param name="aChn">通道号</param>
		/// <param name="aType">控制方式</param>
		/// <returns>服务器返回的响应数据</returns>
		public static JsonBase ControlVideo(string aTerminalId, AVChannel aChn, VedioControlType aType)
		{
			string jsonStr = GetApiReply(VideoControl(aTerminalId, aChn, aType));
			if (string.IsNullOrEmpty(jsonStr))
			{
				return null;
			}
			
			return ModelUtils.GetJsonObject<JsonBase>(jsonStr);
		}

		/// <summary>
		/// 通过URL获取服务器返回的JSON返回值
		/// </summary>
		/// <param name="aUrl"></param>
		/// <returns></returns>
		private static string GetApiReply(string aUrl)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(aUrl);
			request.Proxy = null;
			request.KeepAlive = false;
			request.Method = "GET";
			request.ContentType = "application/json; charset=UTF-8";
			request.AutomaticDecompression = DecompressionMethods.GZip;

			using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
			{
				using (Stream responseStream = response.GetResponseStream())
				{
					using (StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8))
					{
						return streamReader.ReadToEnd();
					}
				}
			}
		}
	}
}
