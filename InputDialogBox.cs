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
    public partial class InputDialogBox : Form
    {
        public InputDialogBox(String countryName,Color backColor, Color foreColor, Image image)
        {
            InitializeComponent();
            this.countryName = countryName;
            this.BackColor = backColor;
            this.labelText.ForeColor = foreColor;
            this.BackgroundImage = image;
        }
        private string modifiedCountryName;

        public string ModifiedCountryName
        {
            get { return modifiedCountryName; }
        }

        private String countryName = string.Empty;
        private void okBtn_Click(object sender, EventArgs e)
        {
            modifiedCountryName = countryNameTextBox.Text;
            DialogResult = DialogResult.OK;
            
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {   
            Close();
        }

        private void InputDialogBox_Load(object sender, EventArgs e)
        {
            countryNameTextBox.Text = this.countryName;
        }

        private void countryNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                okBtn_Click(this, null);
            }
        }

    }
}
