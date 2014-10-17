namespace Earth.Weather
{
    partial class WeatherForm
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
            this.backgroundProcessor = new System.ComponentModel.BackgroundWorker();
            this.groupBoxTimeZoneSelection = new System.Windows.Forms.GroupBox();
            this.checkBoxClock3 = new System.Windows.Forms.CheckBox();
            this.checkBoxClock2 = new System.Windows.Forms.CheckBox();
            this.checkBoxClock1 = new System.Windows.Forms.CheckBox();
            this.comboBoxTimeZoneSelection = new System.Windows.Forms.ComboBox();
            this.countryLabel = new System.Windows.Forms.Label();
            this.groupBoxWeatherSelection = new System.Windows.Forms.GroupBox();
            this.checkBoxFahrenheit = new System.Windows.Forms.CheckBox();
            this.checkBoxCelcius = new System.Windows.Forms.CheckBox();
            this.conditionTempLabel = new System.Windows.Forms.Label();
            this.cityRegionLabel = new System.Windows.Forms.Label();
            this.pictureBoxWeather = new System.Windows.Forms.PictureBox();
            this.fetchLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.formLabel = new System.Windows.Forms.Label();
            this.getWeatherBtn = new System.Windows.Forms.Button();
            this.cityComboBx = new System.Windows.Forms.ComboBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.submitBtn = new System.Windows.Forms.Button();
            this.groupBoxTimeZoneSelection.SuspendLayout();
            this.groupBoxWeatherSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWeather)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundProcessor
            // 
            this.backgroundProcessor.WorkerSupportsCancellation = true;
            this.backgroundProcessor.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundProcessor_DoWork);
            this.backgroundProcessor.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundProcessor_RunWorkerCompleted);
            // 
            // groupBoxTimeZoneSelection
            // 
            this.groupBoxTimeZoneSelection.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxTimeZoneSelection.Controls.Add(this.checkBoxClock3);
            this.groupBoxTimeZoneSelection.Controls.Add(this.checkBoxClock2);
            this.groupBoxTimeZoneSelection.Controls.Add(this.checkBoxClock1);
            this.groupBoxTimeZoneSelection.Controls.Add(this.comboBoxTimeZoneSelection);
            this.groupBoxTimeZoneSelection.Controls.Add(this.countryLabel);
            this.groupBoxTimeZoneSelection.Location = new System.Drawing.Point(4, -2);
            this.groupBoxTimeZoneSelection.Name = "groupBoxTimeZoneSelection";
            this.groupBoxTimeZoneSelection.Size = new System.Drawing.Size(243, 95);
            this.groupBoxTimeZoneSelection.TabIndex = 17;
            this.groupBoxTimeZoneSelection.TabStop = false;
            // 
            // checkBoxClock3
            // 
            this.checkBoxClock3.AutoSize = true;
            this.checkBoxClock3.Location = new System.Drawing.Point(177, 41);
            this.checkBoxClock3.Name = "checkBoxClock3";
            this.checkBoxClock3.Size = new System.Drawing.Size(62, 17);
            this.checkBoxClock3.TabIndex = 26;
            this.checkBoxClock3.Text = "Clock-3";
            this.checkBoxClock3.UseVisualStyleBackColor = true;
            this.checkBoxClock3.Click += new System.EventHandler(this.checkBoxClock3_Click);
            // 
            // checkBoxClock2
            // 
            this.checkBoxClock2.AutoSize = true;
            this.checkBoxClock2.Location = new System.Drawing.Point(91, 41);
            this.checkBoxClock2.Name = "checkBoxClock2";
            this.checkBoxClock2.Size = new System.Drawing.Size(62, 17);
            this.checkBoxClock2.TabIndex = 25;
            this.checkBoxClock2.Text = "Clock-2";
            this.checkBoxClock2.UseVisualStyleBackColor = true;
            this.checkBoxClock2.Click += new System.EventHandler(this.checkBoxClock2_Click);
            // 
            // checkBoxClock1
            // 
            this.checkBoxClock1.AutoSize = true;
            this.checkBoxClock1.Location = new System.Drawing.Point(8, 41);
            this.checkBoxClock1.Name = "checkBoxClock1";
            this.checkBoxClock1.Size = new System.Drawing.Size(62, 17);
            this.checkBoxClock1.TabIndex = 24;
            this.checkBoxClock1.Text = "Clock-1";
            this.checkBoxClock1.UseVisualStyleBackColor = true;
            this.checkBoxClock1.Click += new System.EventHandler(this.checkBoxClock1_Click);
            // 
            // comboBoxTimeZoneSelection
            // 
            this.comboBoxTimeZoneSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTimeZoneSelection.FormattingEnabled = true;
            this.comboBoxTimeZoneSelection.Location = new System.Drawing.Point(6, 64);
            this.comboBoxTimeZoneSelection.Name = "comboBoxTimeZoneSelection";
            this.comboBoxTimeZoneSelection.Size = new System.Drawing.Size(233, 21);
            this.comboBoxTimeZoneSelection.TabIndex = 23;
            this.comboBoxTimeZoneSelection.SelectedIndexChanged += new System.EventHandler(this.comboBoxTimeZoneSelection_SelectedIndexChanged);
            this.comboBoxTimeZoneSelection.MouseMove += new System.Windows.Forms.MouseEventHandler(this.comboBoxTimeZoneSelection_MouseMove);
            this.comboBoxTimeZoneSelection.Click += new System.EventHandler(this.comboBoxTimeZoneSelection_Click);
            // 
            // countryLabel
            // 
            this.countryLabel.BackColor = System.Drawing.Color.Transparent;
            this.countryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countryLabel.Location = new System.Drawing.Point(15, 11);
            this.countryLabel.Name = "countryLabel";
            this.countryLabel.Size = new System.Drawing.Size(209, 20);
            this.countryLabel.TabIndex = 22;
            this.countryLabel.Text = "label1";
            // 
            // groupBoxWeatherSelection
            // 
            this.groupBoxWeatherSelection.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxWeatherSelection.Controls.Add(this.checkBoxFahrenheit);
            this.groupBoxWeatherSelection.Controls.Add(this.checkBoxCelcius);
            this.groupBoxWeatherSelection.Controls.Add(this.conditionTempLabel);
            this.groupBoxWeatherSelection.Controls.Add(this.cityRegionLabel);
            this.groupBoxWeatherSelection.Controls.Add(this.pictureBoxWeather);
            this.groupBoxWeatherSelection.Controls.Add(this.fetchLabel);
            this.groupBoxWeatherSelection.Controls.Add(this.progressBar1);
            this.groupBoxWeatherSelection.Controls.Add(this.formLabel);
            this.groupBoxWeatherSelection.Controls.Add(this.getWeatherBtn);
            this.groupBoxWeatherSelection.Controls.Add(this.cityComboBx);
            this.groupBoxWeatherSelection.Location = new System.Drawing.Point(4, 93);
            this.groupBoxWeatherSelection.Name = "groupBoxWeatherSelection";
            this.groupBoxWeatherSelection.Size = new System.Drawing.Size(243, 150);
            this.groupBoxWeatherSelection.TabIndex = 0;
            this.groupBoxWeatherSelection.TabStop = false;
            // 
            // checkBoxFahrenheit
            // 
            this.checkBoxFahrenheit.AutoSize = true;
            this.checkBoxFahrenheit.Location = new System.Drawing.Point(170, 29);
            this.checkBoxFahrenheit.Name = "checkBoxFahrenheit";
            this.checkBoxFahrenheit.Size = new System.Drawing.Size(76, 17);
            this.checkBoxFahrenheit.TabIndex = 29;
            this.checkBoxFahrenheit.Text = "Fahrenheit";
            this.checkBoxFahrenheit.UseVisualStyleBackColor = true;
            this.checkBoxFahrenheit.Click += new System.EventHandler(this.checkBoxFahrenheit_Click);
            // 
            // checkBoxCelcius
            // 
            this.checkBoxCelcius.AutoSize = true;
            this.checkBoxCelcius.Checked = true;
            this.checkBoxCelcius.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCelcius.Location = new System.Drawing.Point(170, 11);
            this.checkBoxCelcius.Name = "checkBoxCelcius";
            this.checkBoxCelcius.Size = new System.Drawing.Size(60, 17);
            this.checkBoxCelcius.TabIndex = 28;
            this.checkBoxCelcius.Text = "Celcius";
            this.checkBoxCelcius.UseVisualStyleBackColor = true;
            this.checkBoxCelcius.Click += new System.EventHandler(this.checkBoxCelcius_Click);
            // 
            // conditionTempLabel
            // 
            this.conditionTempLabel.AutoSize = true;
            this.conditionTempLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conditionTempLabel.Location = new System.Drawing.Point(97, 103);
            this.conditionTempLabel.Name = "conditionTempLabel";
            this.conditionTempLabel.Size = new System.Drawing.Size(73, 16);
            this.conditionTempLabel.TabIndex = 27;
            this.conditionTempLabel.Text = "Condition";
            // 
            // cityRegionLabel
            // 
            this.cityRegionLabel.AutoSize = true;
            this.cityRegionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cityRegionLabel.Location = new System.Drawing.Point(97, 85);
            this.cityRegionLabel.Name = "cityRegionLabel";
            this.cityRegionLabel.Size = new System.Drawing.Size(102, 16);
            this.cityRegionLabel.TabIndex = 24;
            this.cityRegionLabel.Text = "City && Region";
            // 
            // pictureBoxWeather
            // 
            this.pictureBoxWeather.Location = new System.Drawing.Point(19, 74);
            this.pictureBoxWeather.Name = "pictureBoxWeather";
            this.pictureBoxWeather.Size = new System.Drawing.Size(59, 50);
            this.pictureBoxWeather.TabIndex = 18;
            this.pictureBoxWeather.TabStop = false;
            // 
            // fetchLabel
            // 
            this.fetchLabel.AutoSize = true;
            this.fetchLabel.BackColor = System.Drawing.Color.Transparent;
            this.fetchLabel.Location = new System.Drawing.Point(2, 128);
            this.fetchLabel.Name = "fetchLabel";
            this.fetchLabel.Size = new System.Drawing.Size(48, 13);
            this.fetchLabel.TabIndex = 21;
            this.fetchLabel.Text = "Fetching";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(81, 128);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(159, 16);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 20;
            this.progressBar1.Visible = false;
            // 
            // formLabel
            // 
            this.formLabel.BackColor = System.Drawing.Color.Transparent;
            this.formLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formLabel.Location = new System.Drawing.Point(3, 14);
            this.formLabel.Name = "formLabel";
            this.formLabel.Size = new System.Drawing.Size(160, 28);
            this.formLabel.TabIndex = 19;
            this.formLabel.Text = "Enter the City Name to get Weather:";
            // 
            // getWeatherBtn
            // 
            this.getWeatherBtn.Location = new System.Drawing.Point(139, 47);
            this.getWeatherBtn.Name = "getWeatherBtn";
            this.getWeatherBtn.Size = new System.Drawing.Size(101, 23);
            this.getWeatherBtn.TabIndex = 18;
            this.getWeatherBtn.Text = "Get Weather";
            this.getWeatherBtn.UseVisualStyleBackColor = true;
            this.getWeatherBtn.Click += new System.EventHandler(this.getWeatherBtn_Click);
            // 
            // cityComboBx
            // 
            this.cityComboBx.FormattingEnabled = true;
            this.cityComboBx.Location = new System.Drawing.Point(4, 47);
            this.cityComboBx.Name = "cityComboBx";
            this.cityComboBx.Size = new System.Drawing.Size(121, 21);
            this.cityComboBx.TabIndex = 17;
            this.cityComboBx.SelectionChangeCommitted += new System.EventHandler(this.cityComboBx_SelectionChangeCommitted);
            this.cityComboBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cityComboBx_KeyPress);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(142, 252);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(101, 23);
            this.cancelBtn.TabIndex = 22;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // submitBtn
            // 
            this.submitBtn.BackColor = System.Drawing.Color.Transparent;
            this.submitBtn.Location = new System.Drawing.Point(8, 254);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(101, 23);
            this.submitBtn.TabIndex = 23;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = false;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // WeatherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(251, 283);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.groupBoxWeatherSelection);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.groupBoxTimeZoneSelection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WeatherForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TimeZone & Weather";
            this.groupBoxTimeZoneSelection.ResumeLayout(false);
            this.groupBoxTimeZoneSelection.PerformLayout();
            this.groupBoxWeatherSelection.ResumeLayout(false);
            this.groupBoxWeatherSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWeather)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundProcessor;
        private System.Windows.Forms.GroupBox groupBoxTimeZoneSelection;
        private System.Windows.Forms.CheckBox checkBoxClock3;
        private System.Windows.Forms.CheckBox checkBoxClock2;
        private System.Windows.Forms.CheckBox checkBoxClock1;
        private System.Windows.Forms.ComboBox comboBoxTimeZoneSelection;
        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.GroupBox groupBoxWeatherSelection;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label fetchLabel;
        public System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label formLabel;
        private System.Windows.Forms.Button getWeatherBtn;
        private System.Windows.Forms.ComboBox cityComboBx;
        private System.Windows.Forms.PictureBox pictureBoxWeather;
        private System.Windows.Forms.Label cityRegionLabel;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Label conditionTempLabel;
        private System.Windows.Forms.CheckBox checkBoxFahrenheit;
        private System.Windows.Forms.CheckBox checkBoxCelcius;
    }
}