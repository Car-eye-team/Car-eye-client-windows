namespace CarEyeClient
{
	partial class FrmVehicles
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dgvVechiles = new System.Windows.Forms.DataGridView();
			this.LicensePlate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TerminalId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.StatusDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TypeDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Speed = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Mileage = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Direction = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Altitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Longitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Latitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.LocationTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.UpdateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.mnuRight = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnuTrack = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuDVR = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuRequest = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.dgvVechiles)).BeginInit();
			this.mnuRight.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgvVechiles
			// 
			this.dgvVechiles.AllowUserToAddRows = false;
			this.dgvVechiles.AllowUserToDeleteRows = false;
			this.dgvVechiles.AllowUserToOrderColumns = true;
			this.dgvVechiles.AllowUserToResizeRows = false;
			this.dgvVechiles.BackgroundColor = System.Drawing.Color.White;
			this.dgvVechiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvVechiles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvVechiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvVechiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LicensePlate,
            this.TerminalId,
            this.StatusDescription,
            this.TypeDescription,
            this.Speed,
            this.Mileage,
            this.Direction,
            this.Altitude,
            this.Longitude,
            this.Latitude,
            this.Address,
            this.LocationTime,
            this.UpdateTime});
			this.dgvVechiles.ContextMenuStrip = this.mnuRight;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvVechiles.DefaultCellStyle = dataGridViewCellStyle5;
			this.dgvVechiles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvVechiles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dgvVechiles.Location = new System.Drawing.Point(0, 0);
			this.dgvVechiles.MultiSelect = false;
			this.dgvVechiles.Name = "dgvVechiles";
			this.dgvVechiles.ReadOnly = true;
			this.dgvVechiles.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.dgvVechiles.RowHeadersVisible = false;
			this.dgvVechiles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			this.dgvVechiles.RowTemplate.Height = 23;
			this.dgvVechiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvVechiles.Size = new System.Drawing.Size(899, 336);
			this.dgvVechiles.TabIndex = 0;
			this.dgvVechiles.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVechiles_CellDoubleClick);
			// 
			// LicensePlate
			// 
			this.LicensePlate.DataPropertyName = "LicensePlate";
			this.LicensePlate.HeaderText = "车牌号码";
			this.LicensePlate.Name = "LicensePlate";
			this.LicensePlate.ReadOnly = true;
			this.LicensePlate.Width = 80;
			// 
			// TerminalId
			// 
			this.TerminalId.DataPropertyName = "TerminalId";
			this.TerminalId.HeaderText = "终端编号";
			this.TerminalId.Name = "TerminalId";
			this.TerminalId.ReadOnly = true;
			// 
			// StatusDescription
			// 
			this.StatusDescription.DataPropertyName = "StatusDescription";
			this.StatusDescription.HeaderText = "状态";
			this.StatusDescription.Name = "StatusDescription";
			this.StatusDescription.ReadOnly = true;
			this.StatusDescription.Width = 80;
			// 
			// TypeDescription
			// 
			this.TypeDescription.DataPropertyName = "TypeDescription";
			this.TypeDescription.HeaderText = "终端类型";
			this.TypeDescription.Name = "TypeDescription";
			this.TypeDescription.ReadOnly = true;
			this.TypeDescription.Width = 80;
			// 
			// Speed
			// 
			this.Speed.DataPropertyName = "Speed";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.Speed.DefaultCellStyle = dataGridViewCellStyle2;
			this.Speed.HeaderText = "速度(Km/h)";
			this.Speed.Name = "Speed";
			this.Speed.ReadOnly = true;
			this.Speed.Width = 90;
			// 
			// Mileage
			// 
			this.Mileage.DataPropertyName = "Mileage";
			this.Mileage.HeaderText = "行驶里程(Km)";
			this.Mileage.Name = "Mileage";
			this.Mileage.ReadOnly = true;
			// 
			// Direction
			// 
			this.Direction.DataPropertyName = "Direction";
			this.Direction.HeaderText = "方向";
			this.Direction.Name = "Direction";
			this.Direction.ReadOnly = true;
			this.Direction.Width = 60;
			// 
			// Altitude
			// 
			this.Altitude.DataPropertyName = "Altitude";
			this.Altitude.HeaderText = "海拔(m)";
			this.Altitude.Name = "Altitude";
			this.Altitude.ReadOnly = true;
			this.Altitude.Width = 70;
			// 
			// Longitude
			// 
			this.Longitude.DataPropertyName = "Longitude";
			this.Longitude.HeaderText = "经度";
			this.Longitude.Name = "Longitude";
			this.Longitude.ReadOnly = true;
			// 
			// Latitude
			// 
			this.Latitude.DataPropertyName = "Latitude";
			this.Latitude.HeaderText = "纬度";
			this.Latitude.Name = "Latitude";
			this.Latitude.ReadOnly = true;
			// 
			// Address
			// 
			this.Address.DataPropertyName = "Address";
			this.Address.HeaderText = "详细位置";
			this.Address.Name = "Address";
			this.Address.ReadOnly = true;
			this.Address.Width = 220;
			// 
			// LocationTime
			// 
			this.LocationTime.DataPropertyName = "LocationTime";
			dataGridViewCellStyle3.Format = "G";
			dataGridViewCellStyle3.NullValue = null;
			this.LocationTime.DefaultCellStyle = dataGridViewCellStyle3;
			this.LocationTime.HeaderText = "定位时间";
			this.LocationTime.Name = "LocationTime";
			this.LocationTime.ReadOnly = true;
			this.LocationTime.Width = 140;
			// 
			// UpdateTime
			// 
			this.UpdateTime.DataPropertyName = "UpdateTime";
			dataGridViewCellStyle4.Format = "G";
			dataGridViewCellStyle4.NullValue = null;
			this.UpdateTime.DefaultCellStyle = dataGridViewCellStyle4;
			this.UpdateTime.HeaderText = "信息更新时间";
			this.UpdateTime.Name = "UpdateTime";
			this.UpdateTime.ReadOnly = true;
			this.UpdateTime.Width = 140;
			// 
			// mnuRight
			// 
			this.mnuRight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTrack,
            this.mnuDVR,
            this.mnuRequest});
			this.mnuRight.Name = "mnuRight";
			this.mnuRight.Size = new System.Drawing.Size(153, 92);
			// 
			// mnuTrack
			// 
			this.mnuTrack.Name = "mnuTrack";
			this.mnuTrack.Size = new System.Drawing.Size(152, 22);
			this.mnuTrack.Text = "轨迹回放";
			this.mnuTrack.Click += new System.EventHandler(this.mnuTrack_Click);
			// 
			// mnuDVR
			// 
			this.mnuDVR.Name = "mnuDVR";
			this.mnuDVR.Size = new System.Drawing.Size(152, 22);
			this.mnuDVR.Text = "视频预览";
			this.mnuDVR.Click += new System.EventHandler(this.mnuDVR_Click);
			// 
			// mnuRequest
			// 
			this.mnuRequest.Name = "mnuRequest";
			this.mnuRequest.Size = new System.Drawing.Size(152, 22);
			this.mnuRequest.Text = "点 名";
			this.mnuRequest.Click += new System.EventHandler(this.mnuRequest_Click);
			// 
			// FrmVehicles
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.ClientSize = new System.Drawing.Size(899, 336);
			this.CloseButton = false;
			this.CloseButtonVisible = false;
			this.Controls.Add(this.dgvVechiles);
			this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
			this.HideOnClose = true;
			this.Name = "FrmVehicles";
			this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockBottom;
			this.TabText = "车辆详情";
			this.Text = "车辆详情";
			((System.ComponentModel.ISupportInitialize)(this.dgvVechiles)).EndInit();
			this.mnuRight.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvVechiles;
		private System.Windows.Forms.ContextMenuStrip mnuRight;
		private System.Windows.Forms.ToolStripMenuItem mnuTrack;
		private System.Windows.Forms.ToolStripMenuItem mnuDVR;
		private System.Windows.Forms.ToolStripMenuItem mnuRequest;
		private System.Windows.Forms.DataGridViewTextBoxColumn LicensePlate;
		private System.Windows.Forms.DataGridViewTextBoxColumn TerminalId;
		private System.Windows.Forms.DataGridViewTextBoxColumn StatusDescription;
		private System.Windows.Forms.DataGridViewTextBoxColumn TypeDescription;
		private System.Windows.Forms.DataGridViewTextBoxColumn Speed;
		private System.Windows.Forms.DataGridViewTextBoxColumn Mileage;
		private System.Windows.Forms.DataGridViewTextBoxColumn Direction;
		private System.Windows.Forms.DataGridViewTextBoxColumn Altitude;
		private System.Windows.Forms.DataGridViewTextBoxColumn Longitude;
		private System.Windows.Forms.DataGridViewTextBoxColumn Latitude;
		private System.Windows.Forms.DataGridViewTextBoxColumn Address;
		private System.Windows.Forms.DataGridViewTextBoxColumn LocationTime;
		private System.Windows.Forms.DataGridViewTextBoxColumn UpdateTime;
	}
}
