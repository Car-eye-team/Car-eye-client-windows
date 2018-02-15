using System;
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
		public FrmMap()
		{
			InitializeComponent();
			// 添加本实例指定的JS代码
			this.wbMap.JsCode = MapHelper.GetMainMap();
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

//			this.wbMap.ClearSearchResult();
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
	}
}
