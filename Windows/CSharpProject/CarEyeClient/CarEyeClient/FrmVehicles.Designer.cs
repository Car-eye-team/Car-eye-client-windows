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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dgvVechiles = new System.Windows.Forms.DataGridView();
			this.LicensePlate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TerminalId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.StatusDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TypeDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Speed = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Direction = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Altitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Longitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Latitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Mileage = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.LocationTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.mnuRight = new System.Windows.Forms.ContextMenuStrip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.dgvVechiles)).BeginInit();
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
            this.Direction,
            this.Altitude,
            this.Longitude,
            this.Latitude,
            this.Address,
            this.Mileage,
            this.LocationTime});
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvVechiles.DefaultCellStyle = dataGridViewCellStyle3;
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
			// 
			// TypeDescription
			// 
			this.TypeDescription.DataPropertyName = "TypeDescription";
			this.TypeDescription.HeaderText = "终端类型";
			this.TypeDescription.Name = "TypeDescription";
			this.TypeDescription.ReadOnly = true;
			// 
			// Speed
			// 
			this.Speed.DataPropertyName = "Speed";
			this.Speed.HeaderText = "速度(Km/h)";
			this.Speed.Name = "Speed";
			this.Speed.ReadOnly = true;
			// 
			// Direction
			// 
			this.Direction.DataPropertyName = "Direction";
			this.Direction.HeaderText = "方向";
			this.Direction.Name = "Direction";
			this.Direction.ReadOnly = true;
			// 
			// Altitude
			// 
			this.Altitude.DataPropertyName = "Altitude";
			this.Altitude.HeaderText = "海拔(m)";
			this.Altitude.Name = "Altitude";
			this.Altitude.ReadOnly = true;
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
			this.Address.Width = 200;
			// 
			// Mileage
			// 
			this.Mileage.DataPropertyName = "Mileage";
			this.Mileage.HeaderText = "行驶里程(Km)";
			this.Mileage.Name = "Mileage";
			this.Mileage.ReadOnly = true;
			// 
			// LocationTime
			// 
			this.LocationTime.DataPropertyName = "LocationTime";
			dataGridViewCellStyle2.Format = "G";
			dataGridViewCellStyle2.NullValue = null;
			this.LocationTime.DefaultCellStyle = dataGridViewCellStyle2;
			this.LocationTime.HeaderText = "定位时间";
			this.LocationTime.Name = "LocationTime";
			this.LocationTime.ReadOnly = true;
			this.LocationTime.Width = 140;
			// 
			// mnuRight
			// 
			this.mnuRight.Name = "mnuRight";
			this.mnuRight.Size = new System.Drawing.Size(153, 26);
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
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvVechiles;
		private System.Windows.Forms.DataGridViewTextBoxColumn LicensePlate;
		private System.Windows.Forms.DataGridViewTextBoxColumn TerminalId;
		private System.Windows.Forms.DataGridViewTextBoxColumn StatusDescription;
		private System.Windows.Forms.DataGridViewTextBoxColumn TypeDescription;
		private System.Windows.Forms.DataGridViewTextBoxColumn Speed;
		private System.Windows.Forms.DataGridViewTextBoxColumn Direction;
		private System.Windows.Forms.DataGridViewTextBoxColumn Altitude;
		private System.Windows.Forms.DataGridViewTextBoxColumn Longitude;
		private System.Windows.Forms.DataGridViewTextBoxColumn Latitude;
		private System.Windows.Forms.DataGridViewTextBoxColumn Address;
		private System.Windows.Forms.DataGridViewTextBoxColumn Mileage;
		private System.Windows.Forms.DataGridViewTextBoxColumn LocationTime;
		private System.Windows.Forms.ContextMenuStrip mnuRight;
	}
}
