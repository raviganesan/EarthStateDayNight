using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Earth.Clock
{
    public partial class AlarmInputDialog : Form
    {
        public AlarmInputDialog(String hour, String minutes, String ampm, Color backColor, Color foreColor, Image image)
        {
            InitializeComponent();
            this.BackColor = backColor;            
            this.labelHr.ForeColor = foreColor;
            this.labelMin.ForeColor = foreColor;
            this.labelAMPM.ForeColor = foreColor;
            this.BackgroundImage = image;

            hoursUpDown.Text = hour;
            minutesUpDown.Text = minutes;
            ampmUpDown.Text = ampm;
            this.TopMost = true;
        }
        private DateTime setAlarmTime;

        public DateTime SetAlarmTime
        {
            get { return setAlarmTime; }
            set { setAlarmTime = value; }
        }
        private void alarmBtn_Click(object sender, EventArgs e)
        {
            setAlarmTime = DateTime.Parse(alarmDateTimePicker.Value.ToShortDateString() + " " + hoursUpDown.Text + ":" + minutesUpDown.Text + ":" + "00 " + ampmUpDown.Text);
            DialogResult = DialogResult.OK;
        }

        private void hoursUpDown_Click(object sender, EventArgs e)
        {
            hoursUpDown.SelectedIndex = hoursUpDown.Items.IndexOf(hoursUpDown.Text);
            //hoursUpDown.Wrap = true;
            // by setting the wrap property, when the item in collection reaches end or first, it resets.
        }

        private void minutesUpDown_Click(object sender, EventArgs e)
        {
            minutesUpDown.SelectedIndex = minutesUpDown.Items.IndexOf(minutesUpDown.Text);
        }

        private void ampmUpDown_Click(object sender, EventArgs e)
        {
            ampmUpDown.SelectedIndex = ampmUpDown.Items.IndexOf(ampmUpDown.Text);
        }
    }
}
