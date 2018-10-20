using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace CarEyeClient.Utils
{
	/// <summary>
	/// IE版本设置工具类
	/// </summary>
	internal static class IEUtils
	{
		const int WM_SETTINGCHANGE = 0x001A;
		const int HWND_BROADCAST = 0xFFFF;

		public enum SendMessageTimeoutFlags : uint
		{
			SMTO_NORMAL = 0x0000,
			SMTO_BLOCK = 0x0001,
			SMTO_ABORTIFHUNG = 0x0002,
			SMTO_NOTIMEOUTIFNOTHUNG = 0x0008
		}

		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		public static extern IntPtr SendMessageTimeout(
		IntPtr windowHandle,
		uint Msg,
		IntPtr wParam,
		IntPtr lParam,
		SendMessageTimeoutFlags flags,
		uint timeout,
		out IntPtr result
		);

		/// <summary>  
		/// 设置浏览器版本为系统的浏览器版本
		/// </summary>  
		public static void SetWebBrowserFeatures()
		{
			if (LicenseManager.UsageMode != LicenseUsageMode.Runtime)
			{
				return;
			}

			// 获取程序及名称  
			var appName = System.IO.Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
			int ieVersion = 7;

			try
			{
				// 获取本系统的浏览器版本
				ieVersion = GetBrowserVersion();
			}
			catch
			{

			}
			// 得到浏览器的模式的值
			UInt32 ieMode = (uint)ieVersion * 1000;

			var featureControlRegKey = @"HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\";
			var regValue = Registry.GetValue(featureControlRegKey + "FEATURE_BROWSER_EMULATION", appName, 0);
			if (regValue != null && Convert.ToUInt32(regValue) == ieMode)
			{
				// 已经注册过, 则不再修改
				return;
			}
			// 设置浏览器对应用程序（appName）以什么模式（ieMode）运行
			Registry.SetValue(featureControlRegKey + "FEATURE_BROWSER_EMULATION",
								appName, ieMode, RegistryValueKind.DWord);
			// 使能全局特性
			Registry.SetValue(featureControlRegKey + "FEATURE_ENABLE_CLIPCHILDREN_OPTIMIZATION",
								appName, 1, RegistryValueKind.DWord);

			// 通知所有打开的程序注册表以修改
			SendMessageTimeout(new IntPtr(HWND_BROADCAST), WM_SETTINGCHANGE, IntPtr.Zero, IntPtr.Zero, SendMessageTimeoutFlags.SMTO_NORMAL, 1000, out IntPtr result);
		}

		/// <summary>  
		/// 获取浏览器的版本  
		/// </summary>  
		/// <returns></returns>
		private static int GetBrowserVersion()
		{
			int browserVersion = 0;

			using (var ieKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer",
				RegistryKeyPermissionCheck.ReadSubTree,
				System.Security.AccessControl.RegistryRights.QueryValues))
			{
				var version = ieKey.GetValue("svcVersion");
				if (null == version)
				{
					version = ieKey.GetValue("Version");
					if (null == version)
					{
						throw new ApplicationException("Microsoft Internet Explorer is required!");
					}
				}
				int.TryParse(version.ToString().Split('.')[0], out browserVersion);
			}

			//如果小于7  
			if (browserVersion < 7)
			{
				throw new ApplicationException("不支持的浏览器版本!");
			}

			return browserVersion;
		}
	}
}
