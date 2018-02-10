using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CarEyeMap.Demo
{
	public partial class FrmDemo : Form
	{
		public FrmDemo()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 鼠标在地图上移动时触发的事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void demoMap_CursorMoved(object sender, Coordinate e)
		{
			this.lblCursor.Text = e.ToString();
		}

		/// <summary>
		/// 绘制完多边形时触发的事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void demoMap_DrawedPoly(object sender, DrawedPolyEventArgs e)
		{
			MessageBox.Show("绘制多边形完成！");
		}

		/// <summary>
		/// 绘制完圆形区域触发的事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void demoMap_DrawedRound(object sender, DrawedRoundEventArgs e)
		{
			MessageBox.Show($"中心点：{e.Center},半径：{e.Radius}米");
		}

		/// <summary>
		/// JS代码调用外部方法触发的事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <returns></returns>
		private object demoMap_ExternalChanged(object sender, MapExternalEventArgs e)
		{
			Debug.WriteLine(string.Format("方法名：{0},参数：{1}", e.Method, e.Arguments[0]));
			return default(object);
		}

		/// <summary>
		/// 地图载入完成触发事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void demoMap_LoadFinished(object sender, LoadFinishedEventArgs e)
		{
			MessageBox.Show("载入坐标：" + e.Center.ToString());
		}

		/// <summary>
		/// 漫游按钮
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPan_Click(object sender, EventArgs e)
		{
			this.demoMap.CloseTool();
		}

		/// <summary>
		/// 拉框放大按钮
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnZoomIn_Click(object sender, EventArgs e)
		{
			this.demoMap.ZoomIn();
		}

		/// <summary>
		/// 拉框缩小按钮
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnZoomOut_Click(object sender, EventArgs e)
		{
			this.demoMap.ZoomOut();
		}

		/// <summary>
		/// 测距按钮
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDistance_Click(object sender, EventArgs e)
		{
			this.demoMap.OpenDistanceTool();
		}

		/// <summary>
		/// 测量面积按钮
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnArea_Click(object sender, EventArgs e)
		{
			this.demoMap.OpenAreaTool();
		}

		/// <summary>
		/// 添加标注按钮
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnMark_Click(object sender, EventArgs e)
		{
			this.demoMap.OpenMarkTool();
		}

		/// <summary>
		/// 绘制圆形区域
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRound_Click(object sender, EventArgs e)
		{
			this.demoMap.OpenRoundTool();
		}

		/// <summary>
		/// 绘制矩形区域
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRect_Click(object sender, EventArgs e)
		{
			this.demoMap.OpenRectTool();
		}

		/// <summary>
		/// 绘制多边形区域
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPoly_Click(object sender, EventArgs e)
		{
			this.demoMap.OpenPolyTool();
		}

		/// <summary>
		/// 绘制路线
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRoute_Click(object sender, EventArgs e)
		{
			this.demoMap.OpenRouteTool();
		}

		/// <summary>
		/// 显示一个圆形区域
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnShowRound_Click(object sender, EventArgs e)
		{
			this.demoMap.ShowRound(this.demoMap.Default, 100);
		}

		/// <summary>
		/// 地图根据经纬度定位
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != '\r')
			{
				return;
			}

			this.demoMap.SetCenter(new Coordinate(this.txtSearch.Text.Trim()));
		}

		/// <summary>
		/// 清空搜索结果
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSearch_Click(object sender, EventArgs e)
		{
			this.demoMap.ClearSearchResult();
		}

		/// <summary>
		///	清空地图并做一个JS委托调用测试
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnClear_Click(object sender, EventArgs e)
		{
			this.demoMap.Clear();
			this.demoMap.InvokeScript("External", "ExtTest", 123456, 4656156);
		}

		/// <summary>
		/// 刷新, 重新载入地图
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRefresh_Click(object sender, EventArgs e)
		{
			this.demoMap.Refresh();
		}
	}
}
