namespace Earth.Clock
{
    partial class AlarmInputDialog
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
            this.hoursUpDown = new System.Windows.Forms.DomainUpDown();
            this.minutesUpDown = new System.Windows.Forms.DomainUpDown();
            this.ampmUpDown = new System.Windows.Forms.DomainUpDown();
            this.alarmBtn = new System.Windows.Forms.Button();
            this.alarmDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.labelHr = new System.Windows.Forms.Label();
            this.labelMin = new System.Windows.Forms.Label();
            this.labelAMPM = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // hoursUpDown
            // 
            this.hoursUpDown.Items.Add("12");
            this.hoursUpDown.Items.Add("11");
            this.hoursUpDown.Items.Add("10");
            this.hoursUpDown.Items.Add("9");
            this.hoursUpDown.Items.Add("8");
            this.hoursUpDown.Items.Add("7");
            this.hoursUpDown.Items.Add("6");
            this.hoursUpDown.Items.Add("5");
            this.hoursUpDown.Items.Add("4");
            this.hoursUpDown.Items.Add("3");
            this.hoursUpDown.Items.Add("2");
            this.hoursUpDown.Items.Add("1");
            this.hoursUpDown.Location = new System.Drawing.Point(19, 23);
            this.hoursUpDown.Name = "hoursUpDown";
            this.hoursUpDown.Size = new System.Drawing.Size(42, 20);
            this.hoursUpDown.TabIndex = 0;
            this.hoursUpDown.Wrap = true;
            this.hoursUpDown.Click += new System.EventHandler(this.hoursUpDown_Click);
            // 
            // minutesUpDown
            // 
            this.minutesUpDown.Items.Add("59");
            this.minutesUpDown.Items.Add("58");
            this.minutesUpDown.Items.Add("57");
            this.minutesUpDown.Items.Add("56");
            this.minutesUpDown.Items.Add("55");
            this.minutesUpDown.Items.Add("54");
            this.minutesUpDown.Items.Add("53");
            this.minutesUpDown.Items.Add("52");
            this.minutesUpDown.Items.Add("51");
            this.minutesUpDown.Items.Add("50");
            this.minutesUpDown.Items.Add("49");
            this.minutesUpDown.Items.Add("48");
            this.minutesUpDown.Items.Add("47");
            this.minutesUpDown.Items.Add("46");
            this.minutesUpDown.Items.Add("45");
            this.minutesUpDown.Items.Add("44");
            this.minutesUpDown.Items.Add("43");
            this.minutesUpDown.Items.Add("42");
            this.minutesUpDown.Items.Add("41");
            this.minutesUpDown.Items.Add("40");
            this.minutesUpDown.Items.Add("39");
            this.minutesUpDown.Items.Add("38");
            this.minutesUpDown.Items.Add("37");
            this.minutesUpDown.Items.Add("36");
            this.minutesUpDown.Items.Add("35");
            this.minutesUpDown.Items.Add("34");
            this.minutesUpDown.Items.Add("33");
            this.minutesUpDown.Items.Add("32");
            this.minutesUpDown.Items.Add("31");
            this.minutesUpDown.Items.Add("30");
            this.minutesUpDown.Items.Add("29");
            this.minutesUpDown.Items.Add("28");
            this.minutesUpDown.Items.Add("27");
            this.minutesUpDown.Items.Add("26");
            this.minutesUpDown.Items.Add("25");
            this.minutesUpDown.Items.Add("24");
            this.minutesUpDown.Items.Add("23");
            this.minutesUpDown.Items.Add("22");
            this.minutesUpDown.Items.Add("21");
            this.minutesUpDown.Items.Add("20");
            this.minutesUpDown.Items.Add("19");
            this.minutesUpDown.Items.Add("18");
            this.minutesUpDown.Items.Add("17");
            this.minutesUpDown.Items.Add("16");
            this.minutesUpDown.Items.Add("15");
            this.minutesUpDown.Items.Add("14");
            this.minutesUpDown.Items.Add("13");
            this.minutesUpDown.Items.Add("12");
            this.minutesUpDown.Items.Add("11");
            this.minutesUpDown.Items.Add("10");
            this.minutesUpDown.Items.Add("09");
            this.minutesUpDown.Items.Add("08");
            this.minutesUpDown.Items.Add("07");
            this.minutesUpDown.Items.Add("06");
            this.minutesUpDown.Items.Add("05");
            this.minutesUpDown.Items.Add("04");
            this.minutesUpDown.Items.Add("03");
            this.minutesUpDown.Items.Add("02");
            this.minutesUpDown.Items.Add("01");
            this.minutesUpDown.Items.Add("00");
            this.minutesUpDown.Location = new System.Drawing.Point(89, 23);
            this.minutesUpDown.Name = "minutesUpDown";
            this.minutesUpDown.Size = new System.Drawing.Size(42, 20);
            this.minutesUpDown.TabIndex = 1;
            this.minutesUpDown.Wrap = true;
            this.minutesUpDown.Click += new System.EventHandler(this.minutesUpDown_Click);
            // 
            // ampmUpDown
            // 
            this.ampmUpDown.Items.Add("AM");
            this.ampmUpDown.Items.Add("PM");
            this.ampmUpDown.Location = new System.Drawing.Point(157, 23);
            this.ampmUpDown.Name = "ampmUpDown";
            this.ampmUpDown.Size = new System.Drawing.Size(42, 20);
            this.ampmUpDown.TabIndex = 2;
            this.ampmUpDown.Wrap = true;
            this.ampmUpDown.Click += new System.EventHandler(this.ampmUpDown_Click);
            // 
            // alarmBtn
            // 
            this.alarmBtn.Location = new System.Drawing.Point(56, 78);
            this.alarmBtn.Name = "alarmBtn";
            this.alarmBtn.Size = new System.Drawing.Size(87, 23);
            this.alarmBtn.TabIndex = 3;
            this.alarmBtn.Text = "Set Alarm";
            this.alarmBtn.UseVisualStyleBackColor = true;
            this.alarmBtn.Click += new System.EventHandler(this.alarmBtn_Click);
            // 
            // alarmDateTimePicker
            // 
            this.alarmDateTimePicker.Location = new System.Drawing.Point(15, 52);
            this.alarmDateTimePicker.Name = "alarmDateTimePicker";
            this.alarmDateTimePicker.Size = new System.Drawing.Size(187, 20);
            this.alarmDateTimePicker.TabIndex = 4;
            // 
            // labelHr
            // 
            this.labelHr.AutoSize = true;
            this.labelHr.BackColor = System.Drawing.Color.Transparent;
            this.labelHr.Location = new System.Drawing.Point(16, 7);
            this.labelHr.Name = "labelHr";
            this.labelHr.Size = new System.Drawing.Size(35, 13);
            this.labelHr.TabIndex = 5;
            this.labelHr.Text = "Hours";
            // 
            // labelMin
            // 
            this.labelMin.AutoSize = true;
            this.labelMin.BackColor = System.Drawing.Color.Transparent;
            this.labelMin.Location = new System.Drawing.Point(86, 8);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(44, 13);
            this.labelMin.TabIndex = 6;
            this.labelMin.Text = "Minutes";
            // 
            // labelAMPM
            // 
            this.labelAMPM.AutoSize = true;
            this.labelAMPM.BackColor = System.Drawing.Color.Transparent;
            this.labelAMPM.Location = new System.Drawing.Point(154, 7);
            this.labelAMPM.Name = "labelAMPM";
            this.labelAMPM.Size = new System.Drawing.Size(44, 13);
            this.labelAMPM.TabIndex = 7;
            this.labelAMPM.Text = "AM/PM";
            // 
            // AlarmInputDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(223, 106);
            this.Controls.Add(this.labelAMPM);
            this.Controls.Add(this.labelMin);
            this.Controls.Add(this.labelHr);
            this.Controls.Add(this.alarmDateTimePicker);
            this.Controls.Add(this.alarmBtn);
            this.Controls.Add(this.ampmUpDown);
            this.Controls.Add(this.minutesUpDown);
            this.Controls.Add(this.hoursUpDown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AlarmInputDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alarm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DomainUpDown hoursUpDown;
        private System.Windows.Forms.DomainUpDown minutesUpDown;
        private System.Windows.Forms.DomainUpDown ampmUpDown;
        private System.Windows.Forms.Button alarmBtn;
        private System.Windows.Forms.DateTimePicker alarmDateTimePicker;
        private System.Windows.Forms.Label labelHr;
        private System.Windows.Forms.Label labelMin;
        private System.Windows.Forms.Label labelAMPM;
    }
}