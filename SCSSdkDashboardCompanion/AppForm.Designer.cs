namespace SCSSdkDashboardCompanion
{
    partial class AppForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.devicesList = new System.Windows.Forms.ListBox();
            this.refreshDevicesBttn = new System.Windows.Forms.Button();
            this.useDeviceBtn = new System.Windows.Forms.Button();
            this.appLabel = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.Button();
            this.minimizeBtn = new System.Windows.Forms.Button();
            this.baudRateLabel = new System.Windows.Forms.Label();
            this.baud115200 = new System.Windows.Forms.RadioButton();
            this.baud9600 = new System.Windows.Forms.RadioButton();
            this.messageLabel = new System.Windows.Forms.Label();
            this.disconnectBtn = new System.Windows.Forms.Button();
            this.devicesManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.devicesManagerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // devicesList
            // 
            this.devicesList.Font = new System.Drawing.Font("Corbel", 11F);
            this.devicesList.FormattingEnabled = true;
            this.devicesList.ItemHeight = 18;
            this.devicesList.Location = new System.Drawing.Point(18, 61);
            this.devicesList.Name = "devicesList";
            this.devicesList.Size = new System.Drawing.Size(368, 94);
            this.devicesList.TabIndex = 0;
            this.devicesList.SelectedIndexChanged += new System.EventHandler(this.devicesList_SelectedIndexChanged);
            // 
            // refreshDevicesBttn
            // 
            this.refreshDevicesBttn.AutoSize = true;
            this.refreshDevicesBttn.Font = new System.Drawing.Font("Corbel", 11F);
            this.refreshDevicesBttn.Location = new System.Drawing.Point(18, 161);
            this.refreshDevicesBttn.Name = "refreshDevicesBttn";
            this.refreshDevicesBttn.Size = new System.Drawing.Size(133, 28);
            this.refreshDevicesBttn.TabIndex = 1;
            this.refreshDevicesBttn.Text = "Refresh devices list";
            this.refreshDevicesBttn.UseVisualStyleBackColor = true;
            this.refreshDevicesBttn.Click += new System.EventHandler(this.refreshDevicesBttn_Click);
            // 
            // useDeviceBtn
            // 
            this.useDeviceBtn.AutoSize = true;
            this.useDeviceBtn.BackColor = System.Drawing.Color.White;
            this.useDeviceBtn.Font = new System.Drawing.Font("Corbel", 11F);
            this.useDeviceBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.useDeviceBtn.Location = new System.Drawing.Point(157, 161);
            this.useDeviceBtn.Name = "useDeviceBtn";
            this.useDeviceBtn.Size = new System.Drawing.Size(136, 28);
            this.useDeviceBtn.TabIndex = 2;
            this.useDeviceBtn.Text = "Use selected device";
            this.useDeviceBtn.UseVisualStyleBackColor = false;
            this.useDeviceBtn.Click += new System.EventHandler(this.useDeviceBtn_Click);
            // 
            // appLabel
            // 
            this.appLabel.AutoSize = true;
            this.appLabel.Font = new System.Drawing.Font("Corbel", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.appLabel.Location = new System.Drawing.Point(12, 9);
            this.appLabel.Name = "appLabel";
            this.appLabel.Size = new System.Drawing.Size(300, 36);
            this.appLabel.TabIndex = 3;
            this.appLabel.Text = "Dashboard Companion";
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.FlatAppearance.BorderSize = 0;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.closeBtn.Location = new System.Drawing.Point(371, 9);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(25, 25);
            this.closeBtn.TabIndex = 4;
            this.closeBtn.Text = "X";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.BackColor = System.Drawing.Color.Transparent;
            this.minimizeBtn.FlatAppearance.BorderSize = 0;
            this.minimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeBtn.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizeBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.minimizeBtn.Location = new System.Drawing.Point(340, 9);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(25, 25);
            this.minimizeBtn.TabIndex = 5;
            this.minimizeBtn.Text = "—";
            this.minimizeBtn.UseVisualStyleBackColor = false;
            this.minimizeBtn.Click += new System.EventHandler(this.minimizeBtn_Click);
            // 
            // baudRateLabel
            // 
            this.baudRateLabel.AutoSize = true;
            this.baudRateLabel.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baudRateLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.baudRateLabel.Location = new System.Drawing.Point(222, 202);
            this.baudRateLabel.Name = "baudRateLabel";
            this.baudRateLabel.Size = new System.Drawing.Size(71, 18);
            this.baudRateLabel.TabIndex = 6;
            this.baudRateLabel.Text = "Baud rate:";
            // 
            // baud115200
            // 
            this.baud115200.AutoSize = true;
            this.baud115200.Checked = true;
            this.baud115200.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baud115200.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.baud115200.Location = new System.Drawing.Point(306, 200);
            this.baud115200.Name = "baud115200";
            this.baud115200.Size = new System.Drawing.Size(71, 22);
            this.baud115200.TabIndex = 8;
            this.baud115200.TabStop = true;
            this.baud115200.Text = "115200";
            this.baud115200.UseVisualStyleBackColor = true;
            this.baud115200.CheckedChanged += new System.EventHandler(this.baud115200_CheckedChanged);
            // 
            // baud9600
            // 
            this.baud9600.AutoSize = true;
            this.baud9600.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baud9600.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.baud9600.Location = new System.Drawing.Point(307, 223);
            this.baud9600.Name = "baud9600";
            this.baud9600.Size = new System.Drawing.Size(58, 22);
            this.baud9600.TabIndex = 9;
            this.baud9600.Text = "9600";
            this.baud9600.UseVisualStyleBackColor = true;
            this.baud9600.CheckedChanged += new System.EventHandler(this.baud9600_CheckedChanged);
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageLabel.ForeColor = System.Drawing.Color.Gray;
            this.messageLabel.Location = new System.Drawing.Point(15, 213);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(92, 18);
            this.messageLabel.TabIndex = 10;
            this.messageLabel.Text = "Disconnected";
            // 
            // disconnectBtn
            // 
            this.disconnectBtn.AutoSize = true;
            this.disconnectBtn.BackColor = System.Drawing.Color.White;
            this.disconnectBtn.Font = new System.Drawing.Font("Corbel", 11F);
            this.disconnectBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.disconnectBtn.Location = new System.Drawing.Point(299, 161);
            this.disconnectBtn.Name = "disconnectBtn";
            this.disconnectBtn.Size = new System.Drawing.Size(87, 28);
            this.disconnectBtn.TabIndex = 11;
            this.disconnectBtn.Text = "Disconnect";
            this.disconnectBtn.UseVisualStyleBackColor = false;
            this.disconnectBtn.Click += new System.EventHandler(this.disconnectBtn_Click);
            // 
            // devicesManagerBindingSource
            // 
            this.devicesManagerBindingSource.DataSource = typeof(SCSSdkDashboardCompanion.DevicesController);
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(406, 259);
            this.Controls.Add(this.disconnectBtn);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.baud9600);
            this.Controls.Add(this.baud115200);
            this.Controls.Add(this.baudRateLabel);
            this.Controls.Add(this.minimizeBtn);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.appLabel);
            this.Controls.Add(this.useDeviceBtn);
            this.Controls.Add(this.refreshDevicesBttn);
            this.Controls.Add(this.devicesList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AppForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard Companion";
            this.Shown += new System.EventHandler(this.AppForm_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AppForm_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.devicesManagerBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox devicesList;
        private System.Windows.Forms.Button refreshDevicesBttn;
        private System.Windows.Forms.Button useDeviceBtn;
        private System.Windows.Forms.Label appLabel;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button minimizeBtn;
        private System.Windows.Forms.Label baudRateLabel;
        private System.Windows.Forms.RadioButton baud115200;
        private System.Windows.Forms.RadioButton baud9600;
        private System.Windows.Forms.BindingSource devicesManagerBindingSource;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Button disconnectBtn;
    }
}

