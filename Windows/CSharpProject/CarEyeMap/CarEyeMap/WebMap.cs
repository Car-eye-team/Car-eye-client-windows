using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows.Forms;

namespace CarEyeMap
{
	/// <summary>
	/// 地图执行窗口方法触发事件委托声明
	/// </summary>
	public delegate object MapExternalEventHandler(object sender, MapExternalEventArgs e);
	/// <summary>
	/// 地图鼠标移动事件委托
	/// </summary>
	/// <param name="sender">地图控件</param>
	/// <param name="e">当前鼠标所在地图经纬度</param>
	public delegate void CursorMoveEventHandler(object sender, Coordinate e);

	// PermissionSet部分为允许浏览器控件执行JS代码
	/// <summary>
	/// 网络地图控件
	/// </summary>
	[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
	[ComVisible(true)]
	[DefaultEvent("ExternalChanged")]
	public partial class WebMap : UserControl
	{
		/// <summary>
		/// 设置或获取是否显示脚本执行错误
		/// </summary>
		[Description("设置或获取是否显示脚本执行错误"),
		Category("地图"),
		DefaultValue(true),
		Browsable(true)]
		public bool ShowScriptError
		{
			get
			{
				return !this.wbMap.ScriptErrorsSuppressed;
			}
			set
			{
				this.wbMap.ScriptErrorsSuppressed = !value;
			}
		}
		
		/// <summary>
		/// 地图载入默认显示中心坐标
		/// </summary>
		[Description("地图载入显示默认中心坐标"),
		Category("地图"),
		Browsable(true)]
		public Coordinate Default { get; set; } = BdMapHtml.DEFAULT;

		/// <summary>
		/// 地图HTML单元
		/// </summary>
		private readonly BdMapHtml mHtml = new BdMapHtml();

		/// <summary>
		/// 是否使能比例尺控件
		/// </summary>
		[Description("是否使能比例尺控件"),
		Category("地图"),
		DefaultValue(true),
		Browsable(true)]
		public bool EnableScale
		{
			get
			{
				return this.mHtml.EnableScale;
			}
			set
			{
				if (this.mHtml.EnableScale != value)
				{
					this.mHtml.EnableScale = value;
					Reload();
				}
			}
		}

		/// <summary>
		/// 是否使能鹰眼地图控件
		/// </summary>
		[Description("是否使能鹰眼地图控件"),
		Category("地图"),
		DefaultValue(true),
		Browsable(true)]
		public bool EnableOverviewMap
		{
			get
			{
				return this.mHtml.EnableOverviewMap;
			}
			set
			{
				if (this.mHtml.EnableOverviewMap != value)
				{
					this.mHtml.EnableOverviewMap = value;
					Reload();
				}
			}
		}

		/// <summary>
		/// 是否使能地图类型控件
		/// </summary>
		[Description("是否使能地图类型控件"),
		Category("地图"),
		DefaultValue(true),
		Browsable(true)]
		public bool EnableMapType
		{
			get
			{
				return this.mHtml.EnableMapType;
			}
			set
			{
				if (this.mHtml.EnableMapType != value)
				{
					this.mHtml.EnableMapType = value;
					Reload();
				}
			}
		}

		/// <summary>
		/// 是否使能骨头棒控件
		/// </summary>
		[Description("是否使能骨头棒控件"),
		Category("地图"),
		DefaultValue(true),
		Browsable(true)]
		public bool EnableNavigation
		{
			get
			{
				return this.mHtml.EnableNavigation;
			}
			set
			{
				if (this.mHtml.EnableNavigation != value)
				{
					this.mHtml.EnableNavigation = value;
					Reload();
				}
			}
		}

		/// <summary>
		/// 是否使能滚珠放大缩小功能
		/// </summary>
		[Description("是否使能滚珠放大缩小功能"),
		Category("地图"),
		DefaultValue(true),
		Browsable(true)]
		public bool EnableScrollWheel
		{
			get
			{
				return this.mHtml.EnableScrollWheel;
			}
			set
			{
				if (this.mHtml.EnableScrollWheel != value)
				{
					this.mHtml.EnableScrollWheel = value;
					Reload();
				}
			}
		}
		/// <summary>
		/// 是否使能键盘上下左右移动功能
		/// </summary>
		[Description("是否使能键盘上下左右移动功能"),
		Category("地图"),
		DefaultValue(true),
		Browsable(true)]
		public bool EnableKeyboard
		{
			get
			{
				return this.mHtml.EnableKeyboard;
			}
			set
			{
				if (this.mHtml.EnableKeyboard != value)
				{
					this.mHtml.EnableKeyboard = value;
					Reload();
				}
			}
		}

		/// <summary>
		/// 是否使能Hashtable类
		/// </summary>
		[Description("是否使能Hashtable类"),
		Category("地图"),
		DefaultValue(false),
		Browsable(true)]
		public bool EnableHashtable
		{
			get
			{
				return this.mHtml.EnableHashtable;
			}
			set
			{
				if (this.mHtml.EnableHashtable != value)
				{
					this.mHtml.EnableHashtable = value;
					Reload();
				}
			}
		}

		/// <summary>
		/// JS需要引用的API URL
		/// </summary>
		[Description("JS需要引用的API URL"),
		Category("地图"),
		Browsable(true)]
		public string[] ApiURLs
		{
			get
			{
				return this.mHtml.ApiURLs;
			}
			set
			{
				if (this.mHtml.ApiURLs != value)
				{
					this.mHtml.ApiURLs = value;
					Reload();
				}
			}
		}

		/// <summary>
		/// 用户JS代码
		/// </summary>
		[Description("用户JS代码"),
		Category("地图"),
		Browsable(true)]
		public string JsCode
		{
			get
			{
				return this.mHtml.JsCode;
			}
			set
			{
				if (this.mHtml.JsCode != value)
				{
					this.mHtml.JsCode = value;
					Reload();
				}
			}
		}

		/// <summary>
		/// 获取当前显示的地图页面
		/// </summary>
		private HtmlDocument Document
		{
			get
			{
				return this.wbMap.Document;
			}
		}

		/// <summary>
		/// 地图是否载入完成
		/// </summary>
		private bool mLoadCompleted = false;

		/// <summary>
		/// 地图执行窗口方法触发事件
		/// </summary>
		[Description("地图执行窗口方法触发事件"),
		Browsable(true),
		Category("地图")]
		public event MapExternalEventHandler ExternalChanged;
		/// <summary>
		/// 光标移动触发事件，可获取当前光标所在位置的地图经纬度
		/// </summary>
		[Description("光标移动触发事件，可获取当前光标所在位置的地图经纬度"),
		Browsable(true),
		Category("地图")]
		public event CursorMoveEventHandler CursorMoved;
		/// <summary>
		/// 地图载入完成事件
		/// </summary>
		[Description("地图载入完成事件"),
		Browsable(true),
		Category("地图")]
		public event EventHandler<LoadFinishedEventArgs> LoadFinished;
		/// <summary>
		/// 开启圆形区域绘制工具，绘制完区域触发事件
		/// </summary>
		[Description("开启圆形区域绘制工具，绘制完区域触发事件"),
		Browsable(true),
		Category("地图")]
		public event EventHandler<DrawedRoundEventArgs> DrawedRound;
		/// <summary>
		/// 开启矩形区域绘制工具，绘制完区域触发事件
		/// </summary>
		[Description("开启矩形区域绘制工具，绘制完区域触发事件"),
		Browsable(true),
		Category("地图")]
		public event EventHandler<DrawedRectEventArgs> DrawedRect;
		/// <summary>
		/// 开启多边形区域绘制工具，绘制完区域触发事件
		/// </summary>
		[Description("开启多边形区域绘制工具，绘制完区域触发事件"),
		Browsable(true),
		Category("地图")]
		public event EventHandler<DrawedPolyEventArgs> DrawedPoly;
		/// <summary>
		/// 开启路线绘制工具，绘制完路线后触发事件
		/// </summary>
		[Description("开启路线绘制工具，绘制完路线后触发事件"),
		Browsable(true),
		Category("地图")]
		public event EventHandler<DrawedRouteEventArgs> DrawedRoute;

		/// <summary>
		/// CarEye网络地图控件
		/// </summary>
		public WebMap()
		{
			InitializeComponent();
			this.wbMap.ObjectForScripting = this;   // 使能JS代码调用C#代码
		}

		/// <summary>
		/// 刷新地图
		/// </summary>
		public new void Refresh()
		{
			this.mLoadCompleted = true;
			Reload();
		}

		/// <summary>
		/// 重新载入地图
		/// </summary>
		private void Reload()
		{
			if (this.mLoadCompleted)
			{
				this.mLoadCompleted = false;
				this.wbMap.DocumentText = mHtml.ToString();
			}
		}

		/// <summary>
		/// 执行地图页面中的动态脚本函数
		/// </summary>
		/// <param name="aScript">脚本函数名</param>
		/// <param name="aArgs">参数集合</param>
		/// <returns></returns>
		public object InvokeScript(string aScript, params object[] aArgs)
		{
			return this.Document.InvokeScript(aScript, aArgs);
		}

		/// <summary>
		/// 执行地图页面中的不带参数的动态脚本函数
		/// </summary>
		/// <param name="aScript">脚本函数名</param>
		/// <returns></returns>
		public object InvokeScript(string aScript)
		{
			return this.Document.InvokeScript(aScript);
		}

		/// <summary>
		/// 关闭工具，使地图进入漫游状态
		/// </summary>
		public void CloseTool()
		{
			this.InvokeScript("CloseTool");
		}

		/// <summary>
		/// 地图进入拉框放大状态
		/// </summary>
		public void ZoomIn()
		{
			this.InvokeScript("ZoomSwitch", new object[] { 1 });
		}

		/// <summary>
		/// 地图进入拉框缩小状态
		/// </summary>
		public void ZoomOut()
		{
			this.InvokeScript("ZoomSwitch", new object[] { 2 });
		}

		/// <summary>
		/// 开启标注功能
		/// </summary>
		public void OpenMarkTool()
		{
			this.InvokeScript("OpenMarkTool");
		}

		/// <summary>
		/// 清空地图中的所有图层标志
		/// </summary>
		public void Clear()
		{
			this.InvokeScript("ClearMap");
		}

		/// <summary>
		/// 在地图中显示圆形区域
		/// </summary>
		/// <param name="aPoint">中心坐标</param>
		/// <param name="aRadius">半径(m)</param>
		/// <param name="aCenter">是否居中显示</param>
		public void ShowRound(Coordinate aPoint, UInt32 aRadius, bool aCenter = true)
		{
			this.InvokeScript("ShowRound", new object[] { aPoint.X, aPoint.Y, aRadius, aCenter });
		}

		/// <summary>
		/// 在地图中显示矩形区域
		/// </summary>
		/// <param name="aSPnt">起始坐标</param>
		/// <param name="aEPnt">结束坐标</param>
		/// <param name="aCenter">是否居中显示</param>
		public void ShowRect(Coordinate aSPnt, Coordinate aEPnt, bool aCenter = true)
		{
			this.InvokeScript("ShowRect",
								new object[] { aSPnt.X, aSPnt.Y, aEPnt.X, aEPnt.Y, aCenter });
		}

		/// <summary>
		/// 在地图中显示多边形区域
		/// </summary>
		/// <param name="aList">坐标集合</param>
		/// <param name="aCenter">是否居中显示</param>
		public void ShowPoly(List<Coordinate> aList, bool aCenter = true)
		{
			if (aList == null || aList.Count <= 0)
			{
				return;
			}

			string tmp_str = String.Join(";", aList);
			this.InvokeScript("ShowPoly", tmp_str, aCenter);
		}

		/// <summary>
		/// 在地图中显示路线
		/// </summary>
		/// <param name="aList">路线坐标点集合</param>
		/// <param name="aCenter">是否居中显示</param>
		public void ShowRoute(List<Coordinate> aList, bool aCenter = true)
		{
			if (aList == null || aList.Count <= 0)
			{
				return;
			}

			string tmp_str = String.Join(";", aList);
			this.InvokeScript("ShowRoute", tmp_str, aCenter);
		}

		/// <summary>
		/// 在指定的地图中创建一条线段并置中显示
		/// </summary>
		/// <param name="aSPt">起始坐标</param>
		/// <param name="aEPt">结束坐标</param>
		/// <param name="aCenter">是否居中显示路段</param>
		public void ShowLine(Coordinate aSPt, Coordinate aEPt, bool aCenter = true)
		{
			this.InvokeScript("ShowLine",
							aSPt.X, aSPt.Y, aEPt.X, aEPt.Y, aCenter);
		}

		/// <summary>
		/// 将地图中心显示在指定坐标
		/// </summary>
		/// <param name="aPoint"></param>
		public void SetCenter(Coordinate aPoint)
		{
			this.InvokeScript("SetCenter", aPoint.X, aPoint.Y);
		}

		/// <summary>
		/// 将地图中心显示在指定坐标
		/// </summary>
		/// <param name="aLng"></param>
		/// <param name="aLat"></param>
		public void SetCenter(double aLng, double aLat)
		{
			this.InvokeScript("SetCenter", aLng, aLat);
		}

		/// <summary>
		/// 获取地图当前显示的中心点
		/// </summary>
		/// <returns></returns>
		public Coordinate GetCenter()
		{
			string tmp_str = Convert.ToString(this.InvokeScript("GetMapCenter"));
			if (string.IsNullOrEmpty(tmp_str))
			{
				return Coordinate.Empty;
			}

			return new Coordinate(tmp_str);
		}

		/// <summary>
		/// 进行地图本地搜索
		/// </summary>
		/// <param name="aKeyword"></param>
		public void LocalSearch(string aKeyword)
		{
			if (string.IsNullOrEmpty(aKeyword))
			{
				return;
			}
			this.InvokeScript("MapLocalSearch", aKeyword);
		}

		/// <summary>
		/// 清空搜索结果
		/// </summary>
		public void ClearSearchResult()
		{
			this.InvokeScript("ClearSearchResult");
		}

		/// <summary>
		/// 在指定位置添加一个Marker
		/// </summary>
		/// <param name="aPoint"></param>
		public void AddMarker(Coordinate aPoint)
		{
			this.InvokeScript("AddLocationMarker", aPoint.X, aPoint.Y);
		}

		/// <summary>
		/// 开启距离测量工具
		/// </summary>
		public void OpenDistanceTool()
		{
			this.InvokeScript("OpenDistanceTool");
		}

		/// <summary>
		/// 开启面积测量工具
		/// </summary>
		public void OpenAreaTool()
		{
			this.InvokeScript("OpenAreaTool");
		}

		/// <summary>
		/// 开启圆形区域绘制工具
		/// </summary>
		public void OpenRoundTool()
		{
			this.InvokeScript("OpenCircleTool");
		}

		/// <summary>
		/// 开启矩形区域绘制工具
		/// </summary>
		public void OpenRectTool()
		{
			this.InvokeScript("OpenRectTool");
		}

		/// <summary>
		/// 开启多边形区域绘制工具
		/// </summary>
		public void OpenPolyTool()
		{
			this.InvokeScript("OpenPolyTool");
		}

		/// <summary>
		/// 开启路线绘制工具
		/// </summary>
		public void OpenRouteTool()
		{
			this.InvokeScript("OpenRouteTool");
		}

		/// <summary>
		/// 按键处理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void wbMap_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			OnPreviewKeyDown(e);
		}

		/// <summary>
		/// 代码载入完成触发事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void wbMap_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			// 创建地图
			ShowLoading("地图加载中，请稍候...");
			this.InvokeScript("INST_CreateMap", this.Default.X, this.Default.Y);
			this.mLoadCompleted = true;
			// 必须在此处设置禁用滚动条,WIN10创意者更新后INST.Taxi.Client项目中在初始界面设置禁用滚动条会报异常...
			// 			if (this.wbMap.ScrollBarsEnabled)
			// 			{
			// 				this.wbMap.ScrollBarsEnabled = false;
			// 			}
		}

		#region JS代码触发的事件

		/// <summary>
		/// 地图文档调用方法，用于调用窗口方法
		/// </summary>
		/// <param name="aMethod">方法名</param>
		/// <param name="aArgs">参数集合</param>
		public object OnExternal(string aMethod, params object[] aArgs)
		{
			if (this.ExternalChanged != null)
			{
				return this.ExternalChanged(this, new MapExternalEventArgs(aMethod, aArgs));
			}

			return default(object);
		}

		/// <summary>
		/// 光标移动触发事件
		/// </summary>
		/// <param name="aLng"></param>
		/// <param name="aLat"></param>
		public void OnCursorMoved(double aLng, double aLat)
		{
			if (this.CursorMoved != null)
			{
				this.CursorMoved(this, new Coordinate(aLng, aLat));
			}
		}

		/// <summary>
		/// 绘制完圆形区域触发事件
		/// </summary>
		/// <param name="aLng"></param>
		/// <param name="aLat"></param>
		/// <param name="aRadius"></param>
		public void OnDrawedRound(double aLng, double aLat, double aRadius)
		{
			if (this.DrawedRound != null)
			{
				DrawedRoundEventArgs tmp_args = new DrawedRoundEventArgs(new Coordinate(aLng, aLat));
				tmp_args.Radius = aRadius;
				this.DrawedRound(this, tmp_args);
			}
		}

		/// <summary>
		/// 绘制完矩形区域触发事件
		/// </summary>
		/// <param name="aSLng"></param>
		/// <param name="aSLat"></param>
		/// <param name="aELng"></param>
		/// <param name="aELat"></param>
		public void OnDrawedRect(double aSLng, double aSLat, double aELng, double aELat)
		{
			if (this.DrawedRect != null)
			{
				DrawedRectEventArgs tmp_args = new DrawedRectEventArgs(new Coordinate(aSLng, aSLat),
															new Coordinate(aELng, aELat));
				this.DrawedRect(this, tmp_args);
			}
		}

		/// <summary>
		/// 将包含经纬度的字符串整理为经纬度字符串集合
		/// </summary>
		/// <param name="aPoints">包含经纬度的字符串,每组用;分割,经纬度间使用,号分割</param>
		/// <returns></returns>
		private static List<Coordinate> GetCoordinates(string aPoints)
		{
			// 传递进来的参数最后带有;号
			string str_list = aPoints.TrimEnd(';');
			if (string.IsNullOrEmpty(str_list))
			{
				return null;
			}

			string[] pos_list = str_list.Split(';');
			List<Coordinate> tmp_list = new List<Coordinate>();
			foreach (string tmp_str in pos_list)
			{
				tmp_list.Add(new Coordinate(tmp_str));
			}

			return tmp_list;
		}

		/// <summary>
		/// 绘制完多边形区域触发事件
		/// </summary>
		/// <param name="aLst"></param>
		public void OnDrawedPoly(string aLst)
		{
			if (this.DrawedPoly != null)
			{
				DrawedPolyEventArgs tmp_args = new DrawedPolyEventArgs(GetCoordinates(aLst));
				this.DrawedPoly(this, tmp_args);
			}
		}

		/// <summary>
		/// 绘制完路线触发事件
		/// </summary>
		/// <param name="aLst"></param>
		public void OnDrawedRoute(string aLst)
		{
			if (this.DrawedRoute != null)
			{
				this.DrawedRoute(this, new DrawedRouteEventArgs(GetCoordinates(aLst)));
			}
		}

		/// <summary>
		/// 地图页面弹出对话框
		/// </summary>
		/// <param name="aMsg"></param>
		public bool MsgBox(string aMsg)
		{
			return MessageBox.Show(aMsg, "CarEye提示", MessageBoxButtons.OKCancel,
								MessageBoxIcon.Asterisk) == DialogResult.OK;
		}

		/// <summary>
		/// 获取当前程序运行的路径, 以'\'结尾
		/// </summary>
		/// <returns></returns>
		public string GetCurrentPath()
		{
			string str = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
			if (!str.EndsWith("\\"))
			{
				str = string.Concat(str, "\\");
			}
			return str;
		}

		/// <summary>
		/// 显示载入进度框
		/// </summary>
		/// <param name="aMsg"></param>
		public void ShowLoading(string aMsg)
		{
			if (this.lblLoading.InvokeRequired)
			{
				try
				{
					this.lblLoading.Invoke(new Action<string>(ShowLoading), aMsg);
				}
				catch (System.Exception)
				{

				}
				return;
			}

			this.lblLoading.Text = aMsg;
			this.lblLoading.Location = new Point((this.wbMap.Width - this.lblLoading.Width) / 2,
												(this.wbMap.Height - this.lblLoading.Height) / 2);
			this.lblLoading.Show();
		}

		/// <summary>
		/// 隐藏Loading框，HTML代码调用
		/// </summary>
		public void HideLoading()
		{
			if (this.lblLoading.InvokeRequired)
			{
				try
				{
					this.lblLoading.Invoke(new Action(() => this.lblLoading.Hide()));
				}
				catch (System.Exception)
				{

				}
				return;
			}

			this.lblLoading.Hide();
		}

		/// <summary>
		/// 载入完成，HTML代码调用
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public void OnLoadFinished(double x, double y)
		{
			this.LoadFinished?.Invoke(this, new LoadFinishedEventArgs(new Coordinate(x, y)));
		}

		#endregion

		/// <summary>
		/// 控件载入过程
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			this.wbMap.DocumentText = mHtml.ToString();
		}

		/// <summary>
		/// 绘制边框颜色
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lblLoading_Paint(object sender, PaintEventArgs e)
		{
			Rectangle myRectangle = new Rectangle(new Point(0, 0), this.lblLoading.Size);
			// 画个边框
			ControlPaint.DrawBorder(e.Graphics, myRectangle, this.lblLoading.ForeColor, ButtonBorderStyle.Solid);
		}
	}
}
