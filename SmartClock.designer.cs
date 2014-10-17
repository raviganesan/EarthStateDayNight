namespace Earth.Clock
{
    partial class SmartClock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmartClock));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.settingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.timeZoneWeatherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alarmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.skinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphicalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WallPaperComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.transparentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendToBackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableDisableStartupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localLabel = new System.Windows.Forms.Label();
            this.localTimeLbl = new System.Windows.Forms.Label();
            this.setClock3Time = new System.Windows.Forms.Label();
            this.setClock3Label = new System.Windows.Forms.Label();
            this.setClock2Time = new System.Windows.Forms.Label();
            this.setClock2Label = new System.Windows.Forms.Label();
            this.setClock1Time = new System.Windows.Forms.Label();
            this.setClock1Label = new System.Windows.Forms.Label();
            this.clockGroupBox1 = new System.Windows.Forms.GroupBox();
            this.setWeatherLabel1 = new System.Windows.Forms.Label();
            this.setDateLabel1 = new System.Windows.Forms.Label();
            this.alarmIndicator = new System.Windows.Forms.PictureBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.clockGroupBox2 = new System.Windows.Forms.GroupBox();
            this.setWeatherLabel2 = new System.Windows.Forms.Label();
            this.setDateLabel2 = new System.Windows.Forms.Label();
            this.clockGroupBox3 = new System.Windows.Forms.GroupBox();
            this.setWeatherLabel3 = new System.Windows.Forms.Label();
            this.setDateLabel3 = new System.Windows.Forms.Label();
            this.backgroundProcessor = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip.SuspendLayout();
            this.clockGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alarmIndicator)).BeginInit();
            this.clockGroupBox2.SuspendLayout();
            this.clockGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem1,
            this.toolStripSeparator1,
            this.skinToolStripMenuItem,
            this.sendToBackToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.enableDisableStartupToolStripMenuItem,
            this.toolStripSeparator2,
            this.quitToolStripMenuItem});
            this.contextMenuStrip.Margin = new System.Windows.Forms.Padding(250, 200, 250, 500);
            this.contextMenuStrip.Name = "contextMenu";
            this.contextMenuStrip.Size = new System.Drawing.Size(151, 148);
            // 
            // settingsToolStripMenuItem1
            // 
            this.settingsToolStripMenuItem1.BackColor = System.Drawing.SystemColors.Control;
            this.settingsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timeZoneWeatherToolStripMenuItem,
            this.alarmToolStripMenuItem});
            this.settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
            this.settingsToolStripMenuItem1.Size = new System.Drawing.Size(150, 22);
            this.settingsToolStripMenuItem1.Text = "Settings";
            // 
            // timeZoneWeatherToolStripMenuItem
            // 
            this.timeZoneWeatherToolStripMenuItem.Name = "timeZoneWeatherToolStripMenuItem";
            this.timeZoneWeatherToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.timeZoneWeatherToolStripMenuItem.Text = "Time Zone && Weather";
            this.timeZoneWeatherToolStripMenuItem.Click += new System.EventHandler(this.timeZoneWeatherToolStripMenuItem_Click);
            // 
            // alarmToolStripMenuItem
            // 
            this.alarmToolStripMenuItem.Name = "alarmToolStripMenuItem";
            this.alarmToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.alarmToolStripMenuItem.Text = "Alarm";
            this.alarmToolStripMenuItem.Click += new System.EventHandler(this.alarmToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(147, 6);
            // 
            // skinToolStripMenuItem
            // 
            this.skinToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalToolStripMenuItem,
            this.graphicalToolStripMenuItem,
            this.transparentToolStripMenuItem});
            this.skinToolStripMenuItem.Name = "skinToolStripMenuItem";
            this.skinToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.skinToolStripMenuItem.Text = "Skin";
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.normalToolStripMenuItem.Text = "Normal";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.normalToolStripMenuItem_Click);
            // 
            // graphicalToolStripMenuItem
            // 
            this.graphicalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WallPaperComboBox});
            this.graphicalToolStripMenuItem.Name = "graphicalToolStripMenuItem";
            this.graphicalToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.graphicalToolStripMenuItem.Text = "Graphical";
            // 
            // WallPaperComboBox
            // 
            this.WallPaperComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WallPaperComboBox.Name = "WallPaperComboBox";
            this.WallPaperComboBox.Size = new System.Drawing.Size(121, 23);
            // 
            // transparentToolStripMenuItem
            // 
            this.transparentToolStripMenuItem.Name = "transparentToolStripMenuItem";
            this.transparentToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.transparentToolStripMenuItem.Text = "Transparent";
            this.transparentToolStripMenuItem.Click += new System.EventHandler(this.transparentToolStripMenuItem_Click);
            // 
            // sendToBackToolStripMenuItem
            // 
            this.sendToBackToolStripMenuItem.Name = "sendToBackToolStripMenuItem";
            this.sendToBackToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.sendToBackToolStripMenuItem.Text = "Send To Back";
            this.sendToBackToolStripMenuItem.Click += new System.EventHandler(this.sendToBackToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // enableDisableStartupToolStripMenuItem
            // 
            this.enableDisableStartupToolStripMenuItem.Name = "enableDisableStartupToolStripMenuItem";
            this.enableDisableStartupToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.enableDisableStartupToolStripMenuItem.Text = "Enable Startup";
            this.enableDisableStartupToolStripMenuItem.Click += new System.EventHandler(this.enableDisableStartupToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(147, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.quitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minimizeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // minimizeToolStripMenuItem
            // 
            this.minimizeToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
            this.minimizeToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.minimizeToolStripMenuItem.Text = "Minimize";
            this.minimizeToolStripMenuItem.Click += new System.EventHandler(this.minimizeToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // localLabel
            // 
            this.localLabel.AutoSize = true;
            this.localLabel.BackColor = System.Drawing.Color.Transparent;
            this.localLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.localLabel.Location = new System.Drawing.Point(29, 93);
            this.localLabel.Name = "localLabel";
            this.localLabel.Size = new System.Drawing.Size(65, 13);
            this.localLabel.TabIndex = 7;
            this.localLabel.Text = "Local Time :";
            // 
            // localTimeLbl
            // 
            this.localTimeLbl.AutoSize = true;
            this.localTimeLbl.BackColor = System.Drawing.Color.Transparent;
            this.localTimeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localTimeLbl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.localTimeLbl.Location = new System.Drawing.Point(94, 93);
            this.localTimeLbl.Name = "localTimeLbl";
            this.localTimeLbl.Size = new System.Drawing.Size(35, 13);
            this.localTimeLbl.TabIndex = 8;
            this.localTimeLbl.Text = "label4";
            this.localTimeLbl.Click += new System.EventHandler(this.localTimeLbl_Click);
            // 
            // setClock3Time
            // 
            this.setClock3Time.AutoSize = true;
            this.setClock3Time.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setClock3Time.ForeColor = System.Drawing.SystemColors.ControlText;
            this.setClock3Time.Location = new System.Drawing.Point(1, 30);
            this.setClock3Time.Name = "setClock3Time";
            this.setClock3Time.Size = new System.Drawing.Size(39, 17);
            this.setClock3Time.TabIndex = 6;
            this.setClock3Time.Text = "time";
            // 
            // setClock3Label
            // 
            this.setClock3Label.AutoSize = true;
            this.setClock3Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.setClock3Label.ForeColor = System.Drawing.SystemColors.ControlText;
            this.setClock3Label.Location = new System.Drawing.Point(3, 12);
            this.setClock3Label.Name = "setClock3Label";
            this.setClock3Label.Size = new System.Drawing.Size(102, 13);
            this.setClock3Label.TabIndex = 5;
            this.setClock3Label.Text = "P O R T U G A L";
            // 
            // setClock2Time
            // 
            this.setClock2Time.AutoSize = true;
            this.setClock2Time.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setClock2Time.ForeColor = System.Drawing.SystemColors.ControlText;
            this.setClock2Time.Location = new System.Drawing.Point(1, 30);
            this.setClock2Time.Name = "setClock2Time";
            this.setClock2Time.Size = new System.Drawing.Size(39, 17);
            this.setClock2Time.TabIndex = 4;
            this.setClock2Time.Text = "time";
            // 
            // setClock2Label
            // 
            this.setClock2Label.AutoSize = true;
            this.setClock2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.setClock2Label.ForeColor = System.Drawing.SystemColors.ControlText;
            this.setClock2Label.Location = new System.Drawing.Point(3, 12);
            this.setClock2Label.Name = "setClock2Label";
            this.setClock2Label.Size = new System.Drawing.Size(73, 13);
            this.setClock2Label.TabIndex = 3;
            this.setClock2Label.Text = "R U S S I A";
            // 
            // setClock1Time
            // 
            this.setClock1Time.AutoSize = true;
            this.setClock1Time.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setClock1Time.ForeColor = System.Drawing.SystemColors.ControlText;
            this.setClock1Time.Location = new System.Drawing.Point(1, 30);
            this.setClock1Time.Name = "setClock1Time";
            this.setClock1Time.Size = new System.Drawing.Size(39, 17);
            this.setClock1Time.TabIndex = 2;
            this.setClock1Time.Text = "time";
            // 
            // setClock1Label
            // 
            this.setClock1Label.AutoSize = true;
            this.setClock1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.setClock1Label.ForeColor = System.Drawing.SystemColors.ControlText;
            this.setClock1Label.Location = new System.Drawing.Point(3, 12);
            this.setClock1Label.Name = "setClock1Label";
            this.setClock1Label.Size = new System.Drawing.Size(57, 13);
            this.setClock1Label.TabIndex = 1;
            this.setClock1Label.Text = "I N D I A";
            // 
            // clockGroupBox1
            // 
            this.clockGroupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.clockGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.clockGroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.clockGroupBox1.Controls.Add(this.setWeatherLabel1);
            this.clockGroupBox1.Controls.Add(this.setDateLabel1);
            this.clockGroupBox1.Controls.Add(this.setClock1Label);
            this.clockGroupBox1.Controls.Add(this.setClock1Time);
            this.clockGroupBox1.Location = new System.Drawing.Point(3, -6);
            this.clockGroupBox1.Name = "clockGroupBox1";
            this.clockGroupBox1.Size = new System.Drawing.Size(101, 92);
            this.clockGroupBox1.TabIndex = 0;
            this.clockGroupBox1.TabStop = false;
            this.clockGroupBox1.MouseHover += new System.EventHandler(this.clockGroupBox1_MouseHover);
            // 
            // setWeatherLabel1
            // 
            this.setWeatherLabel1.AutoSize = true;
            this.setWeatherLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setWeatherLabel1.ForeColor = System.Drawing.Color.Maroon;
            this.setWeatherLabel1.Location = new System.Drawing.Point(0, 73);
            this.setWeatherLabel1.Name = "setWeatherLabel1";
            this.setWeatherLabel1.Size = new System.Drawing.Size(61, 13);
            this.setWeatherLabel1.TabIndex = 10;
            this.setWeatherLabel1.Text = "Checking...";
            // 
            // setDateLabel1
            // 
            this.setDateLabel1.AutoSize = true;
            this.setDateLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setDateLabel1.Location = new System.Drawing.Point(2, 51);
            this.setDateLabel1.Name = "setDateLabel1";
            this.setDateLabel1.Size = new System.Drawing.Size(31, 15);
            this.setDateLabel1.TabIndex = 10;
            this.setDateLabel1.Text = "date";
            // 
            // alarmIndicator
            // 
            this.alarmIndicator.BackColor = System.Drawing.Color.Transparent;
            this.alarmIndicator.ErrorImage = null;
            this.alarmIndicator.Image = global::Earth.Properties.Resources._3DGreenButton;
            this.alarmIndicator.Location = new System.Drawing.Point(5, 87);
            this.alarmIndicator.Name = "alarmIndicator";
            this.alarmIndicator.Size = new System.Drawing.Size(25, 23);
            this.alarmIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.alarmIndicator.TabIndex = 9;
            this.alarmIndicator.TabStop = false;
            this.alarmIndicator.Tag = "";
            this.alarmIndicator.Click += new System.EventHandler(this.alarmIndicator_Click);
            this.alarmIndicator.MouseHover += new System.EventHandler(this.alarmIndicator_MouseHover);
            // 
            // toolTip
            // 
            this.toolTip.IsBalloon = true;
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // clockGroupBox2
            // 
            this.clockGroupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.clockGroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.clockGroupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.clockGroupBox2.Controls.Add(this.setWeatherLabel2);
            this.clockGroupBox2.Controls.Add(this.setDateLabel2);
            this.clockGroupBox2.Controls.Add(this.setClock2Label);
            this.clockGroupBox2.Controls.Add(this.setClock2Time);
            this.clockGroupBox2.Location = new System.Drawing.Point(107, -6);
            this.clockGroupBox2.Name = "clockGroupBox2";
            this.clockGroupBox2.Size = new System.Drawing.Size(101, 92);
            this.clockGroupBox2.TabIndex = 3;
            this.clockGroupBox2.TabStop = false;
            this.clockGroupBox2.MouseHover += new System.EventHandler(this.clockGroupBox2_MouseHover);
            // 
            // setWeatherLabel2
            // 
            this.setWeatherLabel2.AutoSize = true;
            this.setWeatherLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.setWeatherLabel2.ForeColor = System.Drawing.Color.Maroon;
            this.setWeatherLabel2.Location = new System.Drawing.Point(0, 73);
            this.setWeatherLabel2.Name = "setWeatherLabel2";
            this.setWeatherLabel2.Size = new System.Drawing.Size(61, 13);
            this.setWeatherLabel2.TabIndex = 11;
            this.setWeatherLabel2.Text = "Checking...";
            // 
            // setDateLabel2
            // 
            this.setDateLabel2.AutoSize = true;
            this.setDateLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setDateLabel2.Location = new System.Drawing.Point(2, 51);
            this.setDateLabel2.Name = "setDateLabel2";
            this.setDateLabel2.Size = new System.Drawing.Size(31, 15);
            this.setDateLabel2.TabIndex = 11;
            this.setDateLabel2.Text = "date";
            // 
            // clockGroupBox3
            // 
            this.clockGroupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.clockGroupBox3.BackColor = System.Drawing.Color.Transparent;
            this.clockGroupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.clockGroupBox3.Controls.Add(this.setWeatherLabel3);
            this.clockGroupBox3.Controls.Add(this.setDateLabel3);
            this.clockGroupBox3.Controls.Add(this.setClock3Label);
            this.clockGroupBox3.Controls.Add(this.setClock3Time);
            this.clockGroupBox3.Location = new System.Drawing.Point(211, -6);
            this.clockGroupBox3.Name = "clockGroupBox3";
            this.clockGroupBox3.Size = new System.Drawing.Size(101, 92);
            this.clockGroupBox3.TabIndex = 4;
            this.clockGroupBox3.TabStop = false;
            this.clockGroupBox3.MouseHover += new System.EventHandler(this.clockGroupBox3_MouseHover);
            // 
            // setWeatherLabel3
            // 
            this.setWeatherLabel3.AutoSize = true;
            this.setWeatherLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.setWeatherLabel3.ForeColor = System.Drawing.Color.Maroon;
            this.setWeatherLabel3.Location = new System.Drawing.Point(0, 73);
            this.setWeatherLabel3.Name = "setWeatherLabel3";
            this.setWeatherLabel3.Size = new System.Drawing.Size(61, 13);
            this.setWeatherLabel3.TabIndex = 12;
            this.setWeatherLabel3.Text = "Checking...";
            // 
            // setDateLabel3
            // 
            this.setDateLabel3.AutoSize = true;
            this.setDateLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setDateLabel3.Location = new System.Drawing.Point(2, 51);
            this.setDateLabel3.Name = "setDateLabel3";
            this.setDateLabel3.Size = new System.Drawing.Size(31, 15);
            this.setDateLabel3.TabIndex = 12;
            this.setDateLabel3.Text = "date";
            // 
            // backgroundProcessor
            // 
            this.backgroundProcessor.WorkerSupportsCancellation = true;
            this.backgroundProcessor.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundProcessor_DoWork);
            this.backgroundProcessor.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundProcessor_RunWorkerCompleted);
            // 
            // SmartClock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(315, 112);
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.clockGroupBox3);
            this.Controls.Add(this.clockGroupBox2);
            this.Controls.Add(this.alarmIndicator);
            this.Controls.Add(this.localLabel);
            this.Controls.Add(this.localTimeLbl);
            this.Controls.Add(this.clockGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SmartClock";
            this.Opacity = 0.96;
            this.ShowInTaskbar = false;
            this.Text = "Smart Clock";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.Load += new System.EventHandler(this.Main_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SmartClock_FormClosing);
            this.contextMenuStrip.ResumeLayout(false);
            this.clockGroupBox1.ResumeLayout(false);
            this.clockGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alarmIndicator)).EndInit();
            this.clockGroupBox2.ResumeLayout(false);
            this.clockGroupBox2.PerformLayout();
            this.clockGroupBox3.ResumeLayout(false);
            this.clockGroupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem1;
        private System.Windows.Forms.Label localLabel;
        private System.Windows.Forms.Label localTimeLbl;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label setClock3Time;
        private System.Windows.Forms.Label setClock3Label;
        private System.Windows.Forms.Label setClock2Time;
        private System.Windows.Forms.Label setClock2Label;
        private System.Windows.Forms.Label setClock1Time;
        private System.Windows.Forms.Label setClock1Label;
        private System.Windows.Forms.GroupBox clockGroupBox1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem sendToBackToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem alarmToolStripMenuItem;
        private System.Windows.Forms.PictureBox alarmIndicator;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem skinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphicalToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox WallPaperComboBox;
        private System.Windows.Forms.ToolStripMenuItem transparentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableDisableStartupToolStripMenuItem;
        private System.Windows.Forms.GroupBox clockGroupBox2;
        private System.Windows.Forms.GroupBox clockGroupBox3;
        private System.Windows.Forms.Label setDateLabel1;
        private System.Windows.Forms.Label setDateLabel2;
        private System.Windows.Forms.Label setDateLabel3;
        private System.Windows.Forms.Label setWeatherLabel1;
        private System.Windows.Forms.Label setWeatherLabel2;
        private System.Windows.Forms.Label setWeatherLabel3;
        private System.ComponentModel.BackgroundWorker backgroundProcessor;
        private System.Windows.Forms.ToolStripMenuItem timeZoneWeatherToolStripMenuItem;
    }
}

