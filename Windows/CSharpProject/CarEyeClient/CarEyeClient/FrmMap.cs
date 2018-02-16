using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CarEyeClient.Model;
using CarEyeClient.Utils;
using CarEyeMap;

namespace CarEyeClient
{
	/// <summary>
	/// 地图子窗体
	/// </summary>
	public partial class FrmMap : FrmChild
	{
		/// <summary>
		/// 主窗体
		/// </summary>
		private FrmMain mParent;
		/// <summary>
		/// 轨迹数据
		/// </summary>
		private List<JsonHistoryItem> mHistory = new List<JsonHistoryItem>();
		/// <summary>
		/// 播放轨迹的车辆信息
		/// </summary>
		private JsonHistoryItem mHistoryVehicle;
		/// <summary>
		/// 播放索引
		/// </summary>
		private int mPlayIndex = 0;

		public FrmMap(FrmMain aParent)
		{
			InitializeComponent();
			// 添加本实例指定的JS代码
			this.wbMap.JsCode = MapHelper.GetMainMap();
			mParent = aParent;
		}
		
		/// <summary>
		/// 定位车辆到地图中
		/// </summary>
		/// <param name="aLocation"></param>
		/// <param name="aIsCenter"></param>
		public void LocatedVehicle(JsonLastPosition aLocation, bool aIsCenter = true)
		{
			if (aLocation == null)
			{
				return;
			}

			this.wbMap.BeginInvokeIfRequired((map) =>
			{
				map.LocatedVehicle(aLocation);

				if (aIsCenter)
				{
					map.SetCenter(aLocation.BdLongitude, aLocation.BdLatitude);
				}
			});
		}

		/// <summary>
		/// 播放历史轨迹信息
		/// </summary>
		/// <param name="aHistory"></param>
		public void PlayHistory(JsonHistoryPosition aHistory)
		{
			mHistory.Clear();
			var sortLst = aHistory.Items.OrderBy(x => x.GpsTime);
			mHistoryVehicle = sortLst.FirstOrDefault();
			mHistory.AddRange(sortLst);
			List<Coordinate> points = new List<Coordinate>(aHistory.Count);
			foreach (var history in sortLst)
			{
				Coordinate tmpPoint = new Coordinate(history.BdLongitude, history.BdLatitude);
				points.Add(tmpPoint);
			}
			this.wbMap.ShowRoute(points);
			this.btnPlay.Visible = true;
			this.btnStop.Visible = true;
			this.btnPlay.Checked = true;
			this.mPlayIndex = 0;
			this.tmrPlay.Start();
		}

		/// <summary>
		/// 载入完后在进行加载车辆
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void wbMap_LoadFinished(object sender, CarEyeMap.LoadFinishedEventArgs e)
		{
			this.lblLocation.Text = e.Center.ToString();
		}

		/// <summary>
		/// 当鼠标移动时在标签控件中实时显示鼠标所处经纬度
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void wbMap_CursorMoved(object sender, CarEyeMap.Coordinate e)
		{
			this.lblLocation.Text = e.ToString();
		}

		/// <summary>
		/// 重新载入地图
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRefresh_Click(object sender, EventArgs e)
		{
			wbMap.Refresh();
		}

		/// <summary>
		/// 拖动地图, 即默认状态, 关闭所有工具
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDrag_Click(object sender, EventArgs e)
		{
			wbMap.CloseTool();
		}

		/// <summary>
		/// 开启测距工具
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDistance_Click(object sender, EventArgs e)
		{
			wbMap.OpenDistanceTool();
		}

		/// <summary>
		/// 开启面积测量工具
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnArea_Click(object sender, EventArgs e)
		{
			wbMap.OpenAreaTool();
		}

		/// <summary>
		/// 清空地图中的所有附加图层
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnClear_Click(object sender, EventArgs e)
		{
			wbMap.Clear();
		}

		/// <summary>
		/// 搜索经纬度或者地点
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSearch_Click(object sender, EventArgs e)
		{
			string searchStr = this.txtSearch.Text.Trim();
			if (string.IsNullOrEmpty(searchStr))
			{
				// 空字符不进行搜索
				return;
			}
			
			// 先查看是否为坐标
			Coordinate centerPoint = new Coordinate(searchStr);
			if (!centerPoint.IsEmpty)
			{
				// 有效坐标
				this.wbMap.SetCenter(centerPoint);
				return;
			}

			this.wbMap.LocalSearch(searchStr);
		}

		/// <summary>
		/// 检测到回车进行搜索
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				this.btnSearch_Click(null, null);
				return;
			}
		}

		/// <summary>
		/// 暂停或者播放
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPlay_Click(object sender, EventArgs e)
		{
			if (this.btnPlay.Checked)
			{
				this.btnPlay.Checked = false;
				this.tmrPlay.Stop();
			}
			else
			{
				this.btnPlay.Checked = true;
				this.tmrPlay.Start();
			}
		}

		/// <summary>
		/// 停止播放
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnStop_Click(object sender, EventArgs e)
		{
			this.tmrPlay.Stop();
			this.wbMap.Clear();
			this.btnPlay.Visible = false;
			this.btnStop.Visible = false;
		}
		
		/// <summary>
		/// 轨迹播放定时器
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tmrPlay_Tick(object sender, EventArgs e)
		{
			if (this.mPlayIndex < 0 || this.mHistory == null
				|| this.mHistory.Count < 1 || this.mHistoryVehicle == null)
			{
				return;
			}

			if (this.mPlayIndex >= this.mHistory.Count)
			{
				// 播放完毕时的情况
				this.btnPlay.Checked = false;
				this.tmrPlay.Stop();
				return;
			}

			JsonHistoryItem history = this.mHistory[mPlayIndex++];

			// 根据情况创建不同方向的小车图层
			this.wbMap.LocatedHistory(new object[] {this.mHistoryVehicle.LicensePlate,
									history.BdLongitude, history.BdLatitude,
									history.Direction, MapHelper.NORMAL_COLOR });
		}
	}
}
