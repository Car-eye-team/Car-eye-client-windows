using System;
using System.Text;

namespace CarEyeMap
{
	/// <summary>
	/// 百度地图HTML管理类
	/// </summary>
	internal class BdMapHtml
	{
		/// <summary>
		/// 默认的坐标位置
		/// </summary>
		public static readonly Coordinate DEFAULT = new Coordinate(113.875779, 22.581783);
		/// <summary>
		/// 百度地图的APP Key, 此处请使用自己申请的百度地图AK,该AK有使用次数限制
		/// </summary>
		private const string BaiduKey = "Nf3lxFZIRCSgC6P57tUyGO3waw7kWw2w";
		/// <summary>
		/// 地图名称
		/// </summary>
		private readonly string Name = "CarEyeMap";
		/// <summary>
		/// HTML代码头
		/// </summary>
		private const string HTML_HEAD = "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n";
		/// <summary>
		/// META HTML代码
		/// </summary>
		private const string HTML_META = "<meta http-equiv=\"{0}\" content=\"{1}\" />\r\n";
		/// <summary>
		/// 地图样式
		/// </summary>
		private const string HTML_STYLE = "	<style type=\"text/css\">\r\n"
										+ "		body, html,#allmap {width: 100%;height: 100%;overflow: hidden;margin:0;font-family:\"微软雅黑\";}\r\n"
										+ "	</style>\r\n";
		/// <summary>
		/// JS API代码
		/// </summary>
		private const string HTML_API = "	<script type=\"text/javascript\" src=\"{0}\"></script>\r\n";

		/// <summary>
		/// JS代码开始
		/// </summary>
		private const string HTML_JSHEAD = "<script type=\"text/javascript\" language=\"javascript\">\r\n";

		/// <summary>
		/// HTML主体代码，需要输出地图名
		/// </summary>
		private const string HTML_BODY = "</head>\r\n\r\n"
										+ "<body>\r\n"
										+ "	<!--百度地图容器-->\r\n"
										+ "	<div style=\"width: 100%; height: 100%;\" id=\"{0}\" onmousedown=\"OnMouseDown(event)\" onselectstart=\"return false\"></div>\r\n"
										+ "</body>\r\n"
										+ "</html>\r\n";

		/// <summary>
		/// Meta代码Builder
		/// </summary>
		private readonly StringBuilder mMetaBuilder = new StringBuilder();
		/// <summary>
		/// JS API引用Builder
		/// </summary>
		private readonly StringBuilder mJsApiBuilder = new StringBuilder();

		/// <summary>
		/// 默认位置
		/// </summary>
		public Coordinate Default = DEFAULT;

		/// <summary>
		/// 是否使能比例尺控件
		/// </summary>
		public bool EnableScale { get; set; }
		/// <summary>
		/// 是否使能鹰眼地图控件
		/// </summary>
		public bool EnableOverviewMap { get; set; }
		/// <summary>
		/// 是否使能地图类型切换控件
		/// </summary>
		public bool EnableMapType { get; set; }
		/// <summary>
		/// 是否使能骨头棒控件
		/// </summary>
		public bool EnableNavigation { get; set; }
		/// <summary>
		/// 是否使能滚珠放大缩小功能
		/// </summary>
		public bool EnableScrollWheel { get; set; }
		/// <summary>
		/// 是否使能键盘上下左右移动功能
		/// </summary>
		public bool EnableKeyboard { get; set; }
		/// <summary>
		/// 是否使能Hashtable类
		/// </summary>
		public bool EnableHashtable { get; set; }
		/// <summary>
		/// JS需要引用的API URL
		/// </summary>
		public string[] ApiURLs { get; set; }
		/// <summary>
		/// JS代码
		/// </summary>
		public string JsCode { get; set; }

		/// <summary>
		/// 创建一个地图代码
		/// </summary>
		public BdMapHtml()
		{
			this.EnableScale = true;
			this.EnableOverviewMap = true;
			this.EnableMapType = true;
			this.EnableNavigation = true;
			this.EnableScrollWheel = true;
			this.EnableKeyboard = true;

			// 添加默认的META头
			AddMeta("Content-Type", "text/html; charset=utf-8");
			if (IsNeedCompatible())
			{
				AddMeta("X-UA-Compatible", "IE=Edge,chrome=1");
			}

			// 默认API引用
			AddAPI($"http://api.map.baidu.com/api?v=2.0&ak={BaiduKey}");
			AddAPI("http://api.map.baidu.com/library/RectangleZoom/1.2/src/RectangleZoom_min.js");
			AddAPI("http://api.map.baidu.com/library/DistanceTool/1.2/src/DistanceTool_min.js");
			AddAPI("http://api.map.baidu.com/library/MarkerTool/1.2/src/MarkerTool.js");
			AddAPI("http://api.map.baidu.com/library/GeoUtils/1.2/src/GeoUtils_min.js");
			AddAPI("http://api.map.baidu.com/library/DrawingManager/1.4/src/DrawingManager_min.js");
		}

		/// <summary>
		/// 根据系统判断是否添加X-UA-Compatible META特性
		/// </summary>
		/// <returns></returns>
		private bool IsNeedCompatible()
		{
			// WIN7以下系统无需关心
			Version osVersion = Environment.OSVersion.Version;
			if (osVersion.Major < 6)
			{
				// VISTA以前的版本
				return true;
			}
			else if (osVersion.Major == 6 && osVersion.Minor < 2)
			{
				// VISTA跟WIN7系统
				return true;
			}

			return false;
		}

		/// <summary>
		/// 添加META设置
		/// </summary>
		/// <param name="aEquiv"></param>
		/// <param name="aContent"></param>
		/// <returns></returns>
		public BdMapHtml AddMeta(string aEquiv, string aContent)
		{
			this.mMetaBuilder.AppendFormat(HTML_META, aEquiv, aContent);
			return this;
		}

		/// <summary>
		/// 添加JS API地址
		/// </summary>
		/// <param name="aUrl"></param>
		/// <returns></returns>
		private BdMapHtml AddAPI(string aUrl)
		{
			this.mJsApiBuilder.AppendFormat(HTML_API, aUrl);
			return this;
		}

		/// <summary>
		/// 地图增加比例尺控件
		/// </summary>
		/// <returns></returns>
		private string AddScaleControl()
		{
			return "	// 比例尺\r\n"
					+ "	MapPanel.addControl(new BMap.ScaleControl({ anchor: BMAP_ANCHOR_BOTTOM_LEFT }));\r\n";
		}

		/// <summary>
		/// 添加鹰眼控件
		/// </summary>
		/// <returns></returns>
		private string AddOverviewMapControl()
		{
			return "	// 鹰眼地图\r\n"
					+ "	var eye_ctrl = new BMap.OverviewMapControl({ anchor: BMAP_ANCHOR_TOP_RIGHT, isOpen: false, size: new BMap.Size(215, 198) });\r\n"
					+ "	MapPanel.addControl(eye_ctrl);\r\n";
		}

		/// <summary>
		/// 添加地图类型控件
		/// </summary>
		/// <returns></returns>
		private string AddMapTypeControl()
		{
			return "	// 地图类型\r\n"
					+ "	var type_ctrl = new BMap.MapTypeControl({offset: new BMap.Size(20, 1)});\r\n"
					+ "	MapPanel.addControl(type_ctrl);\r\n";
		}

		/// <summary>
		/// 添加骨头棒控件
		/// </summary>
		/// <returns></returns>
		private string AddNavigationControl()
		{
			return "	// 添加标准控件，骨头棒  addControl 向地图添加一个控件,可以是自定义的也可以是现成的\r\n"
					+ "	// MapControl  骨头棒控件 可以放缩和移动地图\r\n"
					+ "	MapPanel.addControl(new BMap.NavigationControl({ anchor: BMAP_ANCHOR_TOP_LEFT, type: BMAP_NAVIGATION_CONTROL_LARGE }));\r\n";
		}
		
		/// <summary>
		/// 启用地图滚轮放大缩小
		/// </summary>
		/// <param name="aEnable"></param>
		/// <returns></returns>
		private string EnableScrollWheelZoom(bool aEnable = true)
		{
			if (aEnable)
			{
				return "	MapPanel.enableScrollWheelZoom();\r\n";
			}
			else
			{
				return "	MapPanel.disableScrollWheelZoom();\r\n";
			}
		}

		/// <summary>
		/// 启用键盘上下左右键移动地图
		/// </summary>
		/// <param name="aEnable"></param>
		/// <returns></returns>
		private string IsEnableKeyboard(bool aEnable = true)
		{
			if (aEnable)
			{
				return "	MapPanel.enableKeyboard();\r\n";
			}
			else
			{
				return "	MapPanel.disableKeyboard();\r\n";
			}
		}

		/// <summary>
		/// 获取配置字符串
		/// </summary>
		/// <returns></returns>
		private string GetConfig()
		{
			StringBuilder cfgBuilder = new StringBuilder();

			if (this.EnableScale)
			{
				cfgBuilder.Append(AddScaleControl());
			}
			if (this.EnableOverviewMap)
			{
				cfgBuilder.Append(AddOverviewMapControl());
			}
			if (this.EnableMapType)
			{
				cfgBuilder.Append(AddMapTypeControl());
			}
			if (this.EnableNavigation)
			{
				cfgBuilder.Append(AddNavigationControl());
			}
			cfgBuilder.Append(EnableScrollWheelZoom(this.EnableScrollWheel));
			cfgBuilder.Append(IsEnableKeyboard(this.EnableKeyboard));

			cfgBuilder.AppendLine("	MapPanel.addEventListener('mousemove', onMouseMove);");
			return cfgBuilder.ToString();
		}

		/// <summary>
		/// 返回创建地图方法字符串
		/// </summary>
		/// <returns></returns>
		private string GenMapCreate()
		{
			StringBuilder htmlBuilder = new StringBuilder();

			htmlBuilder.AppendLine("function INST_CreateMap(aLng, aLat) {");
			htmlBuilder.AppendLine($"	MapPanel = new BMap.Map(\"{this.Name}\");");
			htmlBuilder.AppendLine("	if (aLng == 0 || aLat == 0) {");
			htmlBuilder.AppendLine($"		MapPanel.centerAndZoom(new BMap.Point({DEFAULT}), 17);");
			htmlBuilder.AppendLine("		var my_city = new BMap.LocalCity();");
			htmlBuilder.AppendLine("		my_city.get(function (evt) {");
			htmlBuilder.AppendLine("		MapPanel.setCenter(evt.name);");
			htmlBuilder.AppendLine("		});");
			htmlBuilder.AppendLine("	}");
			htmlBuilder.AppendLine("	else{");
			htmlBuilder.AppendLine("		MapPanel.centerAndZoom(new BMap.Point(aLng, aLat), 17);");
			htmlBuilder.AppendLine("	}");

			htmlBuilder.Append(GetConfig());
			htmlBuilder.AppendLine("	HideLoading();");
			htmlBuilder.AppendLine("	window.external.OnLoadFinished(aLng, aLat);");

			htmlBuilder.AppendLine("}");

			return htmlBuilder.ToString();
		}

		/// <summary>
		/// 获取API引用代码
		/// </summary>
		/// <returns></returns>
		private string GetApiUrls()
		{
			StringBuilder urlBuilder = new StringBuilder();
			// 添加API引用
			urlBuilder.Append(this.mJsApiBuilder);
			if (this.ApiURLs != null && this.ApiURLs.Length > 0)
			{
				foreach (string tmp_url in this.ApiURLs)
				{
					urlBuilder.AppendFormat(HTML_API, tmp_url);
				}
			}

			return urlBuilder.ToString();
		}

		/// <summary>
		/// 生成HTML代码
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			StringBuilder strBuilder = new StringBuilder();

			// 添加HTML头
			strBuilder.Append(HTML_HEAD);
			// 添加META头
			strBuilder.Append(this.mMetaBuilder);
			// 添加标题
			strBuilder.AppendLine($"<title>{this.Name}</title>");
			// 添加Style
			strBuilder.Append(HTML_STYLE);
			// 添加API引用
			strBuilder.Append(GetApiUrls());
			// JS代码开始
			strBuilder.Append(HTML_JSHEAD);
			strBuilder.Append(Properties.Resources.BdPublic);
			strBuilder.AppendLine();
			strBuilder.Append(GenMapCreate());
			strBuilder.AppendLine();
			if (this.EnableHashtable)
			{
				strBuilder.Append(Properties.Resources.Hashtable);
				strBuilder.AppendLine();
			}
			strBuilder.Append(this.JsCode);
			strBuilder.Append("\r\n</script>\r\n");

			// BODY代码
			strBuilder.AppendFormat(HTML_BODY, this.Name);

			return strBuilder.ToString();
		}
	}
}
