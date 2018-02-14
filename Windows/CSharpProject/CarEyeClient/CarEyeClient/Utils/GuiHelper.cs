using System;
using System.Windows.Forms;

namespace CarEyeClient.Utils
{
	/// <summary>
	/// 界面操作帮助类
	/// </summary>
	internal static class GuiHelper
	{
		/// <summary>
		/// 包装好的世新科技提示对话框
		/// </summary>
		/// <param name="aMsg">要显示的内容</param>
		/// <param name="aArgs">输入的参数</param>
		/// <returns></returns>
		public static DialogResult MsgBox(string aMsg, params object[] aArgs)
		{
			return MessageBox.Show(string.Format(aMsg, aArgs),
								$"{GlobalCfg.Company}提醒",
								MessageBoxButtons.OKCancel,
								MessageBoxIcon.Information);
		}

		/// <summary>
		/// 对控件进行委托操作如果有必要的话
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="aControl">控件</param>
		/// <param name="aAction">要执行的动作方法</param>
		/// <returns></returns>
		public static void InvokeIfRequired<T>(this T aControl, Action<T> aAction)
			where T : System.Windows.Forms.Control
		{
			try
			{
				if (aControl.InvokeRequired)
				{
					aControl.Invoke(new Action(() => aAction(aControl)));
				}
				else
				{
					aAction(aControl);
				}
			}
			catch (Exception)
			{
			}
		}

		/// <summary>
		/// 对控件进行异步委托操作如果有必要的话
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="aControl">控件</param>
		/// <param name="aAction">要执行的动作方法</param>
		/// <returns></returns>
		public static void BeginInvokeIfRequired<T>(this T aControl, Action<T> aAction)
			where T : System.Windows.Forms.Control
		{
			try
			{
				if (aControl.InvokeRequired)
				{
					aControl.BeginInvoke(new Action(() => aAction(aControl)));
				}
				else
				{
					aAction(aControl);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
