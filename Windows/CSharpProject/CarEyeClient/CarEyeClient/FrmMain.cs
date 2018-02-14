using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using CarEyeClient.Utils;

namespace CarEyeClient
{
	public partial class FrmMain : CarEyeClient.FrmBase
	{
		public FrmMain()
		{
			InitializeComponent();
			this.Text = $"{GlobalCfg.Title}[{GlobalCfg.Version}]";
//			Debug.WriteLine(UrlApiHelper.GetLastPosition(GlobalCfg.TerminalId));
		}
	}
}
