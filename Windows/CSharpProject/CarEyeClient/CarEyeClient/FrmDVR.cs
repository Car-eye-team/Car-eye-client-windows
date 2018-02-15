using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace CarEyeClient
{
	/// <summary>
	/// 视频实时预览子窗体
	/// </summary>
	public partial class FrmDVR : FrmChild
	{
		/// <summary>
		/// 主窗体
		/// </summary>
		private FrmMain mParent;

		public FrmDVR(FrmMain aParent)
		{
			InitializeComponent();
			mParent = aParent;
		}
	}
}
