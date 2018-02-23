using System.ComponentModel;

namespace CarEyeClient.DVR
{
	/// <summary>
	/// 显示绘制格式定义
	/// </summary>
	internal enum RENDER_FORMAT
	{
		/// <summary>
		/// DISPLAY_FORMAT_YV12 -> 842094169
		/// </summary>
		[Description("YV12")]
		DISPLAY_FORMAT_YV12 = 842094169,

		/// <summary>
		/// DISPLAY_FORMAT_YUY2 -> 844715353
		/// </summary>
		[Description("YUY2")]
		DISPLAY_FORMAT_YUY2 = 844715353,

		/// <summary>
		/// DISPLAY_FORMAT_UYVY -> 1498831189
		/// </summary>
		[Description("UYVY")]
		DISPLAY_FORMAT_UYVY = 1498831189,

		/// <summary>
		/// DISPLAY_FORMAT_A8R8G8B8 -> 21
		/// </summary>
		[Description("A8R8G8B8")]
		DISPLAY_FORMAT_A8R8G8B8 = 21,

		/// <summary>
		/// DISPLAY_FORMAT_X8R8G8B8 -> 22
		/// </summary>
		[Description("X8R8G8B8")]
		DISPLAY_FORMAT_X8R8G8B8 = 22,

		/// <summary>
		/// DISPLAY_FORMAT_RGB565 -> 23
		/// </summary>
		[Description("RGB565")]
		DISPLAY_FORMAT_RGB565 = 23,

		/// <summary>
		/// DISPLAY_FORMAT_RGB555 -> 25
		/// </summary>
		[Description("RGB555")]
		DISPLAY_FORMAT_RGB555 = 25,

		/// <summary>
		/// DISPLAY_FORMAT_RGB24_GDI -> 26
		/// </summary>
		[Description("GDI")]
		DISPLAY_FORMAT_RGB24_GDI = 26,
	}
}
