using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarEyeClient.Model;

namespace CarEyeClient
{
	/// <summary>
	/// 主窗体中各子窗体可调用的部分
	/// </summary>
	partial class FrmMain
	{
		/// <summary>
		/// 定位车辆到地图中
		/// </summary>
		/// <param name="aLocation"></param>
		/// <param name="aIsCenter"></param>
		public void LocatedVehicle(JsonLastPosition aLocation, bool aIsCenter = true)
		{
			mFrmMap?.LocatedVehicle(aLocation, aIsCenter);
		}

		/// <summary>
		/// 播放历史轨迹信息
		/// </summary>
		/// <param name="aHistory"></param>
		public void PlayHistory(JsonHistoryPosition aHistory)
		{
			mFrmMap?.PlayHistory(aHistory);
		}

		/// <summary>
		/// 使能对应终端通道的视频预览窗口
		/// </summary>
		/// <param name="aTerminalId"></param>
		/// <param name="aChn"></param>
		public void EnableDVR(string aTerminalId, AVChannel aChn)
		{

		}
	}
}
