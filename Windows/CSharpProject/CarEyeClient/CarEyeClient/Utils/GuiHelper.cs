using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CarEyeClient.Model;

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
			where T : Control
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
			where T : Control
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

		/// <summary>
		/// 将枚举集合加载到ComboBox列表中
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="aCtrl"></param>
		/// <param name="aDefault"></param>
		public static void LoadEnumLst<T>(ComboBox aCtrl, T aDefault) where T : IComparable
		{
			aCtrl.Items.Clear();
			List<ValueString<T>> enumLst = ModelUtils.ToList<T>();
			if (enumLst == null || enumLst.Count <= 0)
			{
				return;
			}

			foreach (ValueString<T> tmpItem in enumLst)
			{
				aCtrl.Items.Add(tmpItem);
				if (aDefault.CompareTo(tmpItem.Value) == 0)
				{
					aCtrl.SelectedItem = tmpItem;
				}
			}

			if (aCtrl.Items.Count > 0 && aCtrl.SelectedIndex < 0)
			{
				aCtrl.SelectedIndex = 0;
			}
			aCtrl.Refresh();
		}

		/// <summary>
		/// 将枚举集合加载到ComboBox列表中
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="aCtrl"></param>
		/// <param name="aSelect"></param>
		/// <param name="aItems"></param>
		public static void LoadEnumLst<T>(ComboBox aCtrl, T aSelect, params T[] aItems) where T : IComparable
		{
			if (aItems == null || aItems.Length <= 0)
			{
				LoadEnumLst<T>(aCtrl, aSelect);
				return;
			}

			aCtrl.Items.Clear();
			List<ValueString<T>> enumLst = ModelUtils.ToList<T>();
			if (enumLst == null || enumLst.Count <= 0)
			{
				return;
			}

			foreach (ValueString<T> tmpItem in enumLst)
			{
				if (aItems.Contains(tmpItem.Value))
				{
					aCtrl.Items.Add(tmpItem);
					if (aSelect.CompareTo(tmpItem.Value) == 0)
					{
						aCtrl.SelectedItem = tmpItem;
					}
				}
			}

			if (aCtrl.Items.Count > 0 && aCtrl.SelectedIndex < 0)
			{
				aCtrl.SelectedIndex = 0;
			}
			aCtrl.Refresh();
		}
	}
}
