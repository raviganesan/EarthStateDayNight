using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Xml;
using System.Collections.ObjectModel;

namespace Earth.Weather
{
    public partial class WeatherForm : Form
    {
        public WeatherForm(Color backColor, Color foreColor, Image image)
        {
            InitializeComponent();
            GetTimeZoneFromRegistry();
            //GetSortedTimeZones();
            //this.countryName = countryName;
            //countryLabel.Text = selectedCountryName;
            this.TopMost = true;
            this.BackColor = backColor;
            this.BackgroundImage = image;
            this.formLabel.ForeColor = foreColor;
            this.countryLabel.ForeColor = foreColor;

           #region Label ForeColor Settings 

            checkBoxClock1.ForeColor = foreColor;
            checkBoxClock2.ForeColor = foreColor;
            checkBoxClock3.ForeColor = foreColor;
            checkBoxCelcius.ForeColor = foreColor;
            checkBoxFahrenheit.ForeColor = foreColor;
            fetchLabel.ForeColor = foreColor;
            cityRegionLabel.ForeColor = foreColor;
            conditionTempLabel.ForeColor = foreColor;

           #endregion

            #region Label Text Settings

            countryLabel.Text = "";
            cityRegionLabel.Text = "";
            conditionTempLabel.Text = "";
            fetchLabel.Text = "";

            #endregion
        }
        
        public WeatherForm(String selectedCountryName, Color backColor, Color foreColor, Image image)
        {
            InitializeComponent();
            //this.countryName = countryName;
            countryLabel.Text = selectedCountryName;
            this.BackColor = backColor;
            this.formLabel.ForeColor = foreColor;
            this.countryLabel.ForeColor = foreColor;
            this.BackgroundImage = image;

            fetchLabel.Text = "";
        }

        #region Properties

        private WeatherData _localWeatherData;
        public WeatherData LocalWeatherData
        {
            get { return _localWeatherData; }
        }

        String _selectedCountryName = string.Empty;

        public String SelectedCountryName
        {
            get { return _selectedCountryName; }           
        }
        String _selectedTimeZone = string.Empty;

        public String SelectedTimeZone
        {
            get { return _selectedTimeZone; }
            
        }

        Boolean _isClockSet1 = false;

        public Boolean IsClockSet1
        {
            get { return _isClockSet1; }            
        }
        Boolean _isClockSet2 = false;

        public Boolean IsClockSet2
        {
            get { return _isClockSet2; }            
        }
        Boolean _isClockSet3 = false;

        public Boolean IsClockSet3
        {
            get { return _isClockSet3; }
        }

        #endregion

        WebBrowser _wb;
        String _cityWOEID1 = string.Empty;
        String _cityWOEID2 = string.Empty;
        Timer refreshTimer = new Timer();
        WeatherForecast WeatherFC = new WeatherForecast();
        Dictionary<String, String> _getCountryNameFromCity = new Dictionary<string, string>();

        void refreshTimer_Tick(object sender, EventArgs e)
        {
            refreshBtn_Click(null, null);
        }

        private void getWeatherBtn_Click(object sender, EventArgs e)
        {
            try
            {
                cityComboBx.DroppedDown = false;//to avoid calling the event, when combobox is closed.
                ProgressStart();
                if (cityComboBx.Text.Length > 0)
                {
                    if (CitySelectionCheck(cityComboBx.Text))
                    {
                        QueryWOEIDforCity(cityComboBx.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Enter the City Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    progressComplete();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK);
                cityComboBx.Text = "";
                progressComplete();
            }
        }

        private void ProgressStart()
        {
            progressBar1.Visible = true;
            fetchLabel.Text = "Fetching Data";
        }

        private void QueryWOEIDforCity(String cityName)
        {
            _wb = new WebBrowser();
            //show recent = false, hence information from cache will not be loaded
            _wb.Navigate("http://locdrop.query.yahoo.com/v1/public/yql?q=select%20line1,%20line2,%20line3,%20line4,%20city,%20uzip,%20statecode,%20countrycode,%20latitude,%20longitude,%20country,%20woeid,%20quality,%20house,%20street,%20state%20from%20locdrop.placefinder%20where%20text=%22"+ cityName +"%22%20and%20locale=%22en-US%22%20and%20gflags=%22f%22");//&format=json&callback=YUI.Env.JSONP.yui_3_5_1_53_1344013094282_2");

            //_wb.Navigate("http://weather.yahoo.com/locationWidget/widget/htdocs/locationWidget.php?appId=us_weather&useFallback=false&filter_country=US&filter_name=USA&filter_status=FALSE&locale=en-US&language=ENG&showRecent=false&showSaved=false&showForm=false&showCheckbox=false&showDefault=true&rnd=1265845298704&default=&location=" + cityName);
            _wb.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(wb_DocumentCompleted);
        }

        void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                //Since DocumentTitle is not set, by default any internet error will contain "Cannot find server" or "Navigation cancelled"
                if (_wb.DocumentTitle == string.Empty)
                {
                    Dictionary<String, String> retrievedLocationList = new Dictionary<string, string>();
                    HtmlDocument htmlDocument = _wb.Document;
                    HtmlElementCollection htmlElementCollection = htmlDocument.GetElementsByTagName("Result");
//                    HtmlElementCollection htmlElementCollection = htmlDocument.GetElementsByTagName("li");
                    if (htmlElementCollection.Count == 0)
                    {
                        String[] idSearch = _wb.Document.All[0].InnerText.Split('"');
                        retrievedLocationList.Add(idSearch[9], idSearch[13]);
                    }
                    else
                    {
                        foreach (HtmlElement location in htmlElementCollection)
                        {
                            if (location.InnerHtml.Contains("<A href"))
                            {
                                String[] pickUpWOEID = location.InnerHtml.Split('"');
                                String pick = pickUpWOEID[1].Replace("#", "");
                                pick = pick.Replace("\\", "");
                                retrievedLocationList.Add(pick, location.InnerText);
                            }
                            else  // Country name
                            {
                                retrievedLocationList.Add("* " + location.InnerText + " *", "* " + location.InnerText + " *");
                            }
                        }
                    }
                    AddItemsToComboBox(retrievedLocationList);
                }
                else
                {
                    throw new Exception("Error in Internet Connection!");
                }

            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Please check your city Name!", "Enter City Name ?", MessageBoxButtons.OK, MessageBoxIcon.Question);
                progressComplete();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressComplete();
            }
        }

        private void AddItemsToComboBox(Dictionary<String, String> retrievedLocationList)
        {
            cityComboBx.DataSource = new BindingSource(retrievedLocationList, null);
            cityComboBx.DisplayMember = "Value";
            cityComboBx.ValueMember = "Key";
            if (cityComboBx.Items.Count == 1)
            {
                cityComboBx_SelectionChangeCommitted(null, null);
                return;
            }
            cityComboBx.DroppedDown = true;
            progressComplete();
        }

        private void cityComboBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                getWeatherBtn_Click(null, null);
            }
        }

        private void backgroundProcessor_DoWork(object sender, DoWorkEventArgs e)
        {
            WeatherForecast weatherForecast = new WeatherForecast();
            weatherForecast.GetWeatherDataFromWeb((WeatherData)e.Argument);
            e.Result = e.Argument; //chk result is not null before mapping            
            //backgroundProcessor.CancelAsync();
            if (backgroundProcessor.CancellationPending) //future support, incase if the application cancels the background process
            {
                e.Cancel = true;
            }
        }

        private void backgroundProcessor_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                WeatherData weatherData = (WeatherData)e.Result;
                if (e.Error != null)
                {
                    MessageBox.Show(e.Error.Message, "Error");
                }
                else if (e.Cancelled) //when the application cancels the process
                {
                    //handle when its cancelled
                    progressComplete();
                }
                else //successful
                {

                    _localWeatherData = weatherData;
                    pictureBoxWeather.Load(weatherData.ImagePath);
                    //weatherLabel.Text = weatherData.CityName + ", " + weatherData.Region + "  :" + weatherData.Condition + " " + weatherData.Temperature + " C";
                    cityRegionLabel.Text = weatherData.CityName + ", " + weatherData.Region;
                    conditionTempLabel.Text = weatherData.Condition + ", " + weatherData.Temperature + " "+ weatherData.Unit.ToString().ToUpper();
                    //temperatureLabel.Text = weatherData.Temperature + " C";
                    //DialogResult = DialogResult.OK;
                }
                progressComplete();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message + ", Check your Input!", "Error");
            }
        }

        private void progressComplete()
        {
            progressBar1.Visible = false;
            fetchLabel.Text = "";
        }

        private void cityComboBx_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                ProgressStart();
                WeatherData weatherData = new WeatherData();
                String locationID = String.Empty;

                if (cityComboBx.SelectedValue != null)
                {
                    locationID = ((Object)cityComboBx.SelectedValue).ToString();
                }
                else if (cityComboBx.SelectedValue == null && cityComboBx.Text.Length < 1)
                {
                    MessageBox.Show("Please Select a Value", "Error in Selection", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    progressComplete();
                    return;
                }

                if (CitySelectionCheck(locationID))
                {
                    weatherData.LocationID = locationID;
                    weatherData.Unit = DetermineWhichUnitSelected();
                    Application.DoEvents();//making the current events in the queue to process parallely, before handing over the control to background thread
                    backgroundProcessor.RunWorkerAsync(weatherData);
                    //not required to exit, as its the last line else this function needs to exit(return).
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message + ". Check your Input!", "Error");
            }
        }

        private Boolean CitySelectionCheck(String locationID)
        {
            if (locationID.Contains("*"))
            {
                MessageBox.Show("Please select only the City!", "Select City", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressComplete();
                return false;
            }
            return true;
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(_cityWOEID1))
            {
                MessageBox.Show("Enter a Valid City and press \"Get\" before your refresh!", "What are you doing?", MessageBoxButtons.OK, MessageBoxIcon.Question);
                progressComplete();
            }
            else
            {
                GetLatestWeather(_cityWOEID1);
            }
        }

        private void GetLatestWeather(String cityWOEID)
        {
            ProgressStart();
            WeatherData weatherData = new WeatherData();
            weatherData.LocationID = cityWOEID;
            weatherData.Unit = DetermineWhichUnitSelected();
            Application.DoEvents();
            if (!backgroundProcessor.IsBusy)
            {
                backgroundProcessor.RunWorkerAsync(weatherData);
            }
            else
            {
                MessageBox.Show("I am Busy!", "Busy...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetSortedTimeZones()
        {
            ReadOnlyCollection<TimeZoneInfo> tZone = TimeZoneInfo.GetSystemTimeZones();
            List<TimeZoneInfo> sortedTZones = (from tZoneObj in tZone
                                               where tZoneObj.BaseUtcOffset.Hours < 0
                                               orderby tZoneObj.BaseUtcOffset, tZoneObj.DisplayName
                                               select tZoneObj).Concat(from tZoneObj in tZone
                                                                       where tZoneObj.BaseUtcOffset.Hours > 0
                                                                       orderby tZoneObj.BaseUtcOffset, tZoneObj.DisplayName 
                                                                       select tZoneObj).ToList<TimeZoneInfo>();


            //comboBoxTimeZoneSelection.DataSource = sortedTZones;

        }
        private void GetTimeZoneFromRegistry()
        {
            RegistryKey rkTimeZone = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Time Zones", true);
            String[] timeZoneArray = rkTimeZone.GetSubKeyNames();
            Array.Sort(timeZoneArray);

            foreach (String country in timeZoneArray)
            {
                RegistryKey rkCountry = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Time Zones" + "\\" + country, true);
                //comboBoxTimeZoneSelection.Items.Add(rkCountry.GetValue("display").ToString());
                _getCountryNameFromCity.Add(rkCountry.GetValue("display").ToString(), country.Replace(" Standard Time", "").ToUpper());

            }
            //comboBoxTimeZoneSelection.Sorted = true;
            SortTimeZonesInDescAscOrder();
        }
        private void SortTimeZonesInDescAscOrder()
        {
            List<string> descZones = new List<string>();
            List<String> ascZones = new List<string>();

            foreach (KeyValuePair<String, String> countryName in _getCountryNameFromCity.OrderBy(pair => pair.Key))
            {
                if (countryName.Key.Contains("GMT-") || countryName.Key.Contains("UTC-"))
                {
                    descZones.Add(countryName.Key);
                }
                else
                {
                    ascZones.Add(countryName.Key);
                }
            }

            descZones.Reverse();
            descZones.AddRange(ascZones);
            comboBoxTimeZoneSelection.DataSource = descZones;
        }
 

        private void comboBoxTimeZoneSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            String countryTimeAdjustment = comboBoxTimeZoneSelection.SelectedItem.ToString();
            _selectedCountryName = _getCountryNameFromCity.ContainsKey(countryTimeAdjustment) ? _getCountryNameFromCity[countryTimeAdjustment] : MessageBox.Show("Re-Select the TimeZone", "Error in Selection", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString();
            _selectedTimeZone = checkValidExpressions(countryTimeAdjustment);
            countryLabel.Text = _selectedCountryName;

        }
      

        private String checkValidExpressions(String countryTimeAdjustment)
        {
            String returnValue = String.Empty;
            Match match = Regex.Match(countryTimeAdjustment, "1|2|3|4|5|6|7|8|9|0");
            if (match.Success)
            {
                String[] trimAndAdjustTime = countryTimeAdjustment.Substring(4, 6).Replace(':', '.').Split('.');
                returnValue = Convert.ToDouble(trimAndAdjustTime[1].Contains("3") ? trimAndAdjustTime[0] + "." + trimAndAdjustTime[1].Replace('3', '5') : trimAndAdjustTime[0] + "." + trimAndAdjustTime[1]).ToString();
            }
            else
            {
                returnValue = "0";
            }
            return returnValue;
        }


        private void submitBtn_Click(object sender, EventArgs e)
        {
            //If the user enters city name but pressed submit, display warning message
            if (cityComboBx.Text != String.Empty && _localWeatherData == null)
            {
                MessageBox.Show("Please press \"Get Weather\" button to get weather!", "Press Get Weather Button!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //getWeatherBtn_Click(null,null);
            }
            else
            {
                //Logical OR Gate is applied 
                //Currently Not allowing users to proceed without (1)Selecting clock, (2)TimeZone and (3)Weather
                if ((((IsClockSet1 | IsClockSet2 | IsClockSet3) != false) && (comboBoxTimeZoneSelection.SelectedItem != null)))
                {
                    if (_localWeatherData != null)
                    {

                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        if (MessageBox.Show("Would you like to Update the Weather? \n\n Select YES to update weather! \n\n Select NO to Proceed without updating weather!", "Weather not Updated!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            _localWeatherData = null; //for safe side
                            DialogResult = DialogResult.OK;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select any \"One Clock\" to proceed", "Error in Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void checkBoxClock1_Click(object sender, EventArgs e)
        {
            //checkBoxClock1.Checked;
            checkBoxClock2.Checked = false;
            checkBoxClock3.Checked = false;
            _isClockSet1 = checkBoxClock1.Checked;
            _isClockSet2 = checkBoxClock2.Checked;
            _isClockSet3 = checkBoxClock3.Checked;
        }

        private void checkBoxClock2_Click(object sender, EventArgs e)
        {

            checkBoxClock1.Checked = false;
            checkBoxClock3.Checked = false;
            _isClockSet1 = checkBoxClock1.Checked;
            _isClockSet2 = checkBoxClock2.Checked;
            _isClockSet3 = checkBoxClock3.Checked;
        }

        private void checkBoxClock3_Click(object sender, EventArgs e)
        {
            checkBoxClock1.Checked = false;
            checkBoxClock2.Checked = false;
            _isClockSet1 = checkBoxClock1.Checked;
            _isClockSet2 = checkBoxClock2.Checked;
            _isClockSet3 = checkBoxClock3.Checked;
        }


        private void checkBoxCelcius_Click(object sender, EventArgs e)
        {
            checkBoxFahrenheit.Checked = false;
        }

        private void checkBoxFahrenheit_Click(object sender, EventArgs e)
        {
            checkBoxCelcius.Checked = false;
        }

        private Char DetermineWhichUnitSelected()
        {
            if (checkBoxCelcius.Checked) return 'c';
            if (checkBoxFahrenheit.Checked) return 'f';

            return 'c';
        }

        private void comboBoxTimeZoneSelection_Click(object sender, EventArgs e)
        {
        //    if (comboBoxTimeZoneSelection.SelectedItem != null)
        //    {
        //        comboBoxTimeZoneSelection.Text = comboBoxTimeZoneSelection.SelectedItem.ToString();
        //        comboBoxTimeZoneSelection.Text = comboBoxTimeZoneSelection.SelectedText;
        //        comboBoxTimeZoneSelection.Text = comboBoxTimeZoneSelection.SelectedValue.ToString();
        //        comboBoxTimeZoneSelection.Text = comboBoxTimeZoneSelection.SelectedIndex.ToString();
        //    }
        }

        private void comboBoxTimeZoneSelection_MouseMove(object sender, MouseEventArgs e)
        {
            //if (comboBoxTimeZoneSelection.SelectedItem != null)
            //{
            //    comboBoxTimeZoneSelection.Text = comboBoxTimeZoneSelection.SelectedItem.ToString();
            //    comboBoxTimeZoneSelection.Text = comboBoxTimeZoneSelection.SelectedText;
            //    comboBoxTimeZoneSelection.Text = comboBoxTimeZoneSelection.SelectedValue.ToString();
            //    comboBoxTimeZoneSelection.Text = comboBoxTimeZoneSelection.SelectedIndex.ToString();
            //}
        
        }

             

    }

}
