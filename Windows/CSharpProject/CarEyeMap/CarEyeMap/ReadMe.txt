CarEye地图控件使用说明：
功能：
	刷新地图：Refresh
	执行地图页面中的动态脚本函数：InvokeScript
	漫游，鼠标拖动地图：CloseTool
	拉框放大：ZoomIn
	拉框缩小：ZoomOut
	标注功能（标注上限为15个）：OpenMarkTool
	在指定位置添加一个标注（标注上限为15个）：AddMarker
	在地图中显示圆形区域：ShowRound
	在地图中显示矩形区域：ShowRect
	在地图中显示多边形区域：ShowPoly
	在地图中显示路线：ShowRoute
	在地图中显示路段：ShowLine
	设置地图的中心显示坐标：SetCenter
	获取当前地图的中心坐标：GetCenter
	地图本地查询功能：LocalSearch
	开启距离测量工具：OpenDistanceTool
	开启面积测量工具：OpenAreaTool
	开启圆形区域绘制工具：OpenRoundTool
	开启矩形区域绘制工具：OpenRectTool
	开启多边形区域绘制工具：OpenPolyTool
	开启路线绘制工具：OpenRouteTool

事件：
	地图执行窗口方法触发事件：ExternalChanged
	光标移动触发事件，可获取当前光标所在位置的地图经纬度：CursorMoved
	绘制完圆形区域触发事件：DrawedRound
	绘制完矩形区域触发事件：DrawedRect
	绘制完多边形区域触发事件：DrawedPoly
	绘制完路线触发事件：DrawedRoute

JS代码全局变量：
	// 主地图容器
	var MapPanel = null;
	// 当前正在使用的工具
	var CurTool = null;
	// 区域/路线图层
	var AreaLayer = null;
	// 路段图层
	var LineLayer = null;
	// 本地查询工具
	var LocalSearchTool = null;
	// 用户标注集合
	var UserMarkers = [];
	// 默认的LABEL显示样式 蓝底白字
	var LABEL_STYLE
	// 区域显示样式
	var AREA_STYLE
	// 路线显示样式
	var ROUTE_STYLE
	// 路段显示样式
	var LINE_STYLE

JS代码提供方法：
	检测的结尾字符串：String.prototype.endWith
	弹出对话框：MsgBox(aMsg)
	获取当前程序运行的路径, 以'\'结尾：GetCurrentPath
	调用C#外部方法,最多可传入7个参数：function External(aName, ...)
	清空地图所有图层：function ClearMap()
	删除当前存在的区域图层：RemoveAreaLayer
	删除当前存在的路段图层：RemoveLineLayer
	显示一个Loading框：ShowLoading(aMsg)
	隐藏Loading框：HideLoading
	通知应用地图创建载入完成 OnLoadFinished(x, y)

已经引用的百度API：	
	RectangleZoom/1.2/src/RectangleZoom_min.js
	DistanceTool/1.2/src/DistanceTool_min.js
	MarkerTool/1.2/src/MarkerTool.js
	GeoUtils/1.2/src/GeoUtils_min.js
	DrawingManager/1.4/src/DrawingManager_min.js

注意：
	在公用方法中有ClearMap()方法，但是其中只是清理并重置控件中定义的图层及变量，
	为了让此方法能清理用户定义的图层及变量，用户需要定义一个ClearGloble()方法，
	在ClearMap中会被调用，如果不存在则不进行调用。

	在使用本控件之前需将BdMapHtml.BaiduKey修改成自己的百度AK, 否则会因为次数超限而不能正常使用

