using CarEyeClient.Model;
using CarEyeClient.Utils;

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
			mFrmMap?.InvokeIfRequired((frm) =>
			{
				frm.LocatedVehicle(aLocation, aIsCenter);
				frm.Show();
			});
		}

		/// <summary>
		/// 播放历史轨迹信息
		/// </summary>
		/// <param name="aHistory"></param>
		public void PlayHistory(JsonHistoryPosition aHistory)
		{
			mFrmMap?.InvokeIfRequired((frm) => frm.PlayHistory(aHistory));
		}

		/// <summary>
		/// 使能对应终端通道的视频预览窗口
		/// </summary>
		/// <param name="aTerminalId"></param>
		/// <param name="aChn"></param>
		public void EnableDVR(string aTerminalId, AVChannel aChn)
		{
			mFrmDVR?.InvokeIfRequired((frm) => frm.AddVideoToken(new DVR.DVRToken()
			{
				TerminalId = aTerminalId,
				LogicChn = aChn,
			}));
		}
	}
}
