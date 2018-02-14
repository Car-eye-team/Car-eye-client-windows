using System;
using CarEyeClient.Model;
using CarEyeClient.Utils;
using System.Threading;
using System.Windows.Forms;

namespace CarEyeClient
{
	/// <summary>
	/// 地图子窗体
	/// </summary>
	public partial class FrmMap : FrmChild
	{
		/// <summary>
		/// 地图是否准备好标识
		/// </summary>
		private bool mIsMapReady = false;
		/// <summary>
		/// 第一次地图未载入时定位的位置信息
		/// </summary>
		private JsonLastPosition mFirstLocation;

		public FrmMap()
		{
			InitializeComponent();
			// 添加本实例指定的JS代码
			this.wbMap.JsCode = MapHelper.GetMainMap();
		}

		/// <summary>
		/// 窗体载入过程
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FrmMap_Load(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// 定位车辆到地图中
		/// </summary>
		/// <param name="aInfo"></param>
		/// <param name="aIsCenter"></param>
		public void LocatedVehicle(JsonLastPosition aInfo, bool aIsCenter = true)
		{
			if (aInfo == null)
			{
				return;
			}
			if (!mIsMapReady)
			{
				mFirstLocation = aInfo;
				return;
			}

			this.wbMap.BeginInvokeIfRequired((map) =>
			{
				map.LocatedVehicle(aInfo);

				if (aIsCenter)
				{
					map.SetCenter(aInfo.BdLongitude, aInfo.BdLatitude);
				}
			});
		}

		/// <summary>
		/// 载入完后在进行加载车辆
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void wbMap_LoadFinished(object sender, CarEyeMap.LoadFinishedEventArgs e)
		{
			mIsMapReady = true;
			if (mFirstLocation != null)
			{
				LocatedVehicle(mFirstLocation);
				mFirstLocation = null;
			}
		}
	}
}
