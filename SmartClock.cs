using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Net;
using System.Runtime.InteropServices;

using Earth.Weather;
using Earth.Classes;

//####################################################################################
//
//Author : Ravi Ganesan
//Copyright : Ravi Ganesan - March 21, 2009.
//Purpose: World Clock, A clock that can be customized to any time zone in the world.
//
//####################################################################################
namespace Earth.Clock
{
    public partial class SmartClock : Form
    {
        public SmartClock()
        {
            InitializeComponent();
            refreshTimer.Interval = 900000; //Fifteen Minutes Interval
            refreshTimer.Enabled = true;
            refreshTimer.Tick += new EventHandler(refreshTimer_Tick);

          

        }

        #region Private Variables

        private Timer _time = new Timer();
        Timer _adjustPositions = new Timer();
        DateTime _dtSetClock1 = new DateTime();
        DateTime _dtSetClock2 = new DateTime();
        DateTime _dtSetClock3 = new DateTime();
        Dictionary<String,String> _getCountryNameFromCity = new Dictionary<string,string>();
        private int _xAxis;
        private int _yAxis;
        
        private Double _hoursAheadorBeforeFromUTC1;
        private Double _hoursAheadorBeforeFromUTC2;
        private Double _hoursAheadorBeforeFromUTC3;

        private String _firstClockCountryName;
        private String _secondClockCountryName;
        private String _thirdClockCountryName;

        private Boolean _isDayActivated1 = false;
        private Boolean _isNightActivated1 = false;
        private Boolean _isDayActivated2 = false;
        private Boolean _isNightActivated2 = false;
        private Boolean _isDayActivated3 = false;
        private Boolean _isNightActivated3 = false;

        private String _sunrise = String.Empty;
        private String _sunset = String.Empty;



        private Boolean _allowClocktoRun = true;
        public Boolean _setAlarm;
        DateTime _setAlarmTime = DateTime.Parse("00:00:00");        
        Dictionary<String, System.Drawing.Bitmap> _backGroundImageCollection = new Dictionary<string, Bitmap>();
        String _backGroundImageName;
        Int32 _screenPosWidth;
        Int32 _screenPosHeight;
        RegistryKey _appStartUp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        String _weatherCondition1 = string.Empty;
        String _weatherCondition2 = string.Empty;
        String _weatherCondition3 = string.Empty;

        private const String FIRSTCLOCK = "FirstClock";
        private const String SECONDCLOCK = "SecondClock";
        private const String THIRDCLOCK = "ThirdClock";


        Timer refreshTimer = new Timer();

        delegate WeatherData GetWeatherDataFromWeb(WeatherData obj);
        delegate void UpdateWeatherHandler(Object weatherDataObj, Label weatherLabel);

        #endregion

        #region DllImport 

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, Int32 Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        static extern bool ReleaseCapture();


         private const int WM_SYSCOMMAND = 0x112;
         private IntPtr WM_MOUSEMOVE = (IntPtr)0xF012;

        #endregion


         protected override void WndProc(ref Message m)
        {
            //the link below gives ID's for various windows messages.
            //http://pinvoke.net/default.aspx/Constants.WM

            base.WndProc(ref m);

            const Int32 WM_NCLBUTTONCLK = 161; //Single Click
            const Int32 WM_NCLBUTTONDBLCLK = 163; //Double Click


            //The value of the Wparam is 2 only when title bar is clicked. Any other non client area is not considered
            if (m.Msg == WM_NCLBUTTONCLK && m.WParam == (IntPtr)2)
            {
                //TitleBarClicked();
            }
            else if (m.Msg == WM_NCLBUTTONDBLCLK)
            {
                TitleBarDoubleClicked();
            }

            if (m.Msg == 132)
            {
                m.Result = (IntPtr)2;
            }
        }

        private void TitleBarClicked()
        {
            //MessageBox.Show("Single Click!");
        }

        private void TitleBarDoubleClicked()
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            _time.Enabled = true;
            _time.Interval = 100;
            _adjustPositions.Enabled = true;
            _adjustPositions.Interval = 100;            

            this.TopMost = true;
            this.MaximizeBox = false;
            //this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width; //taking the full screen width and Subtracting the form's width,gives the starting position of the form to set the form at the right side and fully visible.
            //this.Top = Screen.PrimaryScreen.Bounds.Bottom - this.Height;
            this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            this.Top = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
         
            initializeDelegates();
            if(_appStartUp.GetValue("World Clock") == null) // to check if startup enabled
            {
                makeAppAsStartup(true, false);
            }
            else
            {
                enableDisableStartupToolStripMenuItem.Text = "Disable Startup";
            }
            _xAxis = this.Width;
            _yAxis = this.Height;
            _screenPosWidth = Screen.PrimaryScreen.WorkingArea.Width;
            _screenPosHeight = Screen.PrimaryScreen.WorkingArea.Height;
            initiateBackGroundImageCollection();
            GetSetTimeRegistry();   
         


        }

        private void initiateBackGroundImageCollection()
        {
            _backGroundImageCollection.Add("Blue_Design",Earth.Properties.Resources.Blue_Design);            //_backGroundImageCollection.Add(WorldClock.Properties.Resources.Fresh_Lime, "Fresh_Lime");
            _backGroundImageCollection.Add("Fresh_Lime", Earth.Properties.Resources.Fresh_Lime);
            _backGroundImageCollection.Add("Gruenes_Blatt",Earth.Properties.Resources.Gruenes_Blatt);
            _backGroundImageCollection.Add("Natural_Green_Windows_Vista_Wallpaper",Earth.Properties.Resources.Natural_Green_Windows_Vista_Wallpaper);
            _backGroundImageCollection.Add("Natural_Water_Droplet",Earth.Properties.Resources.Natural_Water_Droplet);
            _backGroundImageCollection.Add("Natural_Wood_Wallpaper",Earth.Properties.Resources.Natural_Wood_Wallpaper);
            //_backGroundImageCollection.Add("Nature_Red_Flower",WorldClock.Properties.Resources.Nature_Red_Flower);
            _backGroundImageCollection.Add("Nice_Tree",Earth.Properties.Resources.Nice_Tree);
            _backGroundImageCollection.Add("Orange_Apple",Earth.Properties.Resources.Orange_Apple);
            //_backGroundImageCollection.Add("Rose_Daffodils",WorldClock.Properties.Resources.Rose_Daffodils);
            _backGroundImageCollection.Add("Sapphire",Earth.Properties.Resources.Sapphire);
            
            WallPaperComboBox.Items.Add("Blue_Design");
            WallPaperComboBox.Items.Add("Fresh_Lime");
            WallPaperComboBox.Items.Add("Gruenes_Blatt");
            WallPaperComboBox.Items.Add("Natural_Green_Windows_Vista_Wallpaper");
            WallPaperComboBox.Items.Add("Natural_Water_Droplet");
            WallPaperComboBox.Items.Add("Natural_Wood_Wallpaper");
            //WallPaperComboBox.Items.Add("Nature_Red_Flower");
            WallPaperComboBox.Items.Add("Nice_Tree");
            WallPaperComboBox.Items.Add("Orange_Apple");
            //WallPaperComboBox.Items.Add("Rose_Daffodils");
            WallPaperComboBox.Items.Add("Sapphire");
        }

        void main_setAlarm(object sender, EventArgs e)
        {
            localTimeLbl.ForeColor = Color.Red;
            localTimeLbl.Font = new Font(FontFamily.GenericSansSerif, 7.05F, FontStyle.Bold);
            System.Threading.Thread.Sleep(500);
            localTimeLbl.Text = "";
            System.Threading.Thread.Sleep(500);
            localTimeLbl.Text = DateTime.Now.ToLongTimeString() + " " + DateTime.Now.DayOfWeek + " " + DateTime.Now.Date.ToString().Remove(9);
        }

        #region Delegates Initialization

        private void initializeDelegates()
        {
            _time.Tick += new EventHandler(_time_Tick);
            this.Resize += new EventHandler(Main_Resize);
            WallPaperComboBox.SelectedIndexChanged += new EventHandler(WallPaperComboBox_SelectedIndexChanged);
            this.clockGroupBox1.MouseLeave += new EventHandler(clockGroupBox1_MouseLeave);
            this.clockGroupBox2.MouseLeave += new EventHandler(clockGroupBox2_MouseLeave);
            this.clockGroupBox3.MouseLeave += new EventHandler(clockGroupBox3_MouseLeave);

            this.setClock1Label.MouseDoubleClick += new MouseEventHandler(setClock1Label_MouseDoubleClick);
            this.setClock2Label.MouseDoubleClick += new MouseEventHandler(setClock2Label_MouseDoubleClick);
            this.setClock3Label.MouseDoubleClick += new MouseEventHandler(setClock3Label_MouseDoubleClick);

            this.clockGroupBox1.MouseDown += new MouseEventHandler(clockGroupBox1_MouseDown);
            this.clockGroupBox2.MouseDown += new MouseEventHandler(clockGroupBox2_MouseDown);
            this.clockGroupBox3.MouseDown += new MouseEventHandler(clockGroupBox3_MouseDown);

            _adjustPositions.Tick += new EventHandler(_adjustPositions_Tick);            
        }

        void clockGroupBox3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            IntPtr lResult = SendMessage(this.Handle, WM_SYSCOMMAND, WM_MOUSEMOVE, (IntPtr)0);
        }

        void clockGroupBox2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            IntPtr lResult = SendMessage(this.Handle, WM_SYSCOMMAND, WM_MOUSEMOVE, (IntPtr)0);
        }

        void clockGroupBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            IntPtr lResult = SendMessage(this.Handle, WM_SYSCOMMAND, WM_MOUSEMOVE, (IntPtr)0);
        }

        void setClock3Label_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_weatherCondition3.Length > 0)
            {
                int getIndex = _weatherCondition3.IndexOf('\n');
                MessageBox.Show(_weatherCondition3.Substring(getIndex).Trim(), setClock3Label.Text);
            }
        }

        void setClock2Label_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_weatherCondition2.Length > 0)
            {
                int getIndex = _weatherCondition2.IndexOf('\n');
                MessageBox.Show(_weatherCondition2.Substring(getIndex).Trim(), setClock2Label.Text);
            }
        }

        void setClock1Label_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_weatherCondition1.Length > 0)
            {
                int getIndex = _weatherCondition1.IndexOf('\n');
                MessageBox.Show(_weatherCondition1.Substring(getIndex).Trim(), setClock1Label.Text);
            }
        }

        void _adjustPositions_Tick(object sender, EventArgs e)
        {
            if (Screen.PrimaryScreen.WorkingArea.Width != _screenPosWidth || Screen.PrimaryScreen.WorkingArea.Height != _screenPosHeight)
            {
                Main_Resize(this, null);
                _screenPosWidth = Screen.PrimaryScreen.WorkingArea.Width;
                _screenPosHeight = Screen.PrimaryScreen.WorkingArea.Height;
            }
        }        

        #endregion

        private void makeAppAsStartup(Boolean startUp, Boolean NotifyUser)
        {   
            if(startUp)
            {
                _appStartUp.SetValue("World Clock", Application.ExecutablePath.ToString());
                if(NotifyUser)MessageBox.Show("Startup Enabled!", "Starup", MessageBoxButtons.OK,MessageBoxIcon.Information);
               //rkApp.DeleteValue("World Clock", false);// to disable
               //if(rkApp.GetValue("World Clock") == null) // to verify if the app is set as startup or not
            }
            else
            {
                _appStartUp.DeleteValue("World Clock", false);// to disable
                if (NotifyUser)MessageBox.Show("Startup Disabled!", "Starup", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

        }
        private void enableDisableStartupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (enableDisableStartupToolStripMenuItem.Text == "Enable Startup")
            {
                makeAppAsStartup(true,true);
                enableDisableStartupToolStripMenuItem.Text = "Disable Startup";
            }
            else
            {
                makeAppAsStartup(false, true);
                enableDisableStartupToolStripMenuItem.Text = "Enable Startup";
            }
        }
        private void GetSetTimeRegistry()
        {
            RegistryKey rkGetClock = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Ravi Ganesan\\World Clock", true);
            if (rkGetClock != null)
            {

                _firstClockCountryName = rkGetClock.GetValue(FIRSTCLOCK + "Label").ToString().Contains("I N D I A") ? "INDIA Standard Time" : rkGetClock.GetValue(FIRSTCLOCK + "Label").ToString() + " Standard Time";
                TimeZoneInfo firstClock = TimeZoneInfo.FindSystemTimeZoneById(_firstClockCountryName);
                _dtSetClock1 = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, firstClock.Id);
                _hoursAheadorBeforeFromUTC1 = Convert.ToDouble(rkGetClock.GetValue(FIRSTCLOCK + "TimeZone"));
                                              


                _secondClockCountryName = rkGetClock.GetValue(SECONDCLOCK + "Label").ToString().Contains("I N D I A") ? "INDIA Standard Time" : rkGetClock.GetValue(SECONDCLOCK + "Label").ToString() + " Standard Time";
                TimeZoneInfo secondClock = TimeZoneInfo.FindSystemTimeZoneById(_secondClockCountryName);
                _dtSetClock2 = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, secondClock.Id);
                _hoursAheadorBeforeFromUTC2 = Convert.ToDouble(rkGetClock.GetValue(SECONDCLOCK + "TimeZone"));

                
                _thirdClockCountryName = rkGetClock.GetValue(THIRDCLOCK + "Label").ToString().Contains("I N D I A") ? "INDIA Standard Time" : rkGetClock.GetValue(THIRDCLOCK + "Label").ToString() + " Standard Time";
                TimeZoneInfo thirdClock = TimeZoneInfo.FindSystemTimeZoneById(_thirdClockCountryName);
                _dtSetClock3 = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, thirdClock.Id);
                _hoursAheadorBeforeFromUTC3 = Convert.ToDouble(rkGetClock.GetValue(THIRDCLOCK + "TimeZone"));

                if (rkGetClock.GetValue("backGroundImageName") != null)
                {  
                    _backGroundImageName = rkGetClock.GetValue("backGroundImageName").ToString();
                    SetLocalLabelForeColor(_backGroundImageName);

                    switch (_backGroundImageName)
                    {
                        case "TransparentColor":
                            transparentToolStripMenuItem_Click(this,null);
                            break;

                        case "NormalColor":
                            //normalToolStripMenuItem_Click(this,null);
                            this.BackColor = Color.WhiteSmoke;
                            break;

                        default:
                            this.BackgroundImage = _backGroundImageCollection[rkGetClock.GetValue("backGroundImageName").ToString()];                            
                            break;
                    }
                    //setLabelForeColorOnChange(_backGroundImageName);
                }
                //return the city, if not return the country name
                setClock1Label.Text = (rkGetClock.GetValue(FIRSTCLOCK + "CityName") != null) ? rkGetClock.GetValue(FIRSTCLOCK + "CityName").ToString() : rkGetClock.GetValue(FIRSTCLOCK + "Label").ToString();
                setClock2Label.Text = (rkGetClock.GetValue(SECONDCLOCK + "CityName") != null) ? rkGetClock.GetValue(SECONDCLOCK + "CityName").ToString() : rkGetClock.GetValue(SECONDCLOCK + "Label").ToString();
                setClock3Label.Text = (rkGetClock.GetValue(THIRDCLOCK + "CityName") != null) ? rkGetClock.GetValue(THIRDCLOCK + "CityName").ToString() : rkGetClock.GetValue(THIRDCLOCK + "Label").ToString();
            }
            else
            {
                //Default Settings
                setClock1Label.Text = "I N D I A";
                setClock2Label.Text = "RUSSIAN";
                setClock3Label.Text = "GMT";
                _firstClockCountryName = "INDIA Standard Time";
                _secondClockCountryName = "RUSSIAN Standard Time";
                _thirdClockCountryName = "GMT Standard Time";
                _hoursAheadorBeforeFromUTC1 = 5.5;
                _hoursAheadorBeforeFromUTC2 = 3;
                _hoursAheadorBeforeFromUTC3 = 0;
                setClock1Time.Text = "5.5";
                setClock2Time.Text = "3";
                setClock3Time.Text  = "0";
                setCountrySpecificSettings(setClock1Label, setClock1Time.Text, FIRSTCLOCK);
                setCountrySpecificSettings(setClock2Label, setClock2Time.Text, SECONDCLOCK);
                setCountrySpecificSettings(setClock3Label, setClock3Time.Text, THIRDCLOCK);
                setBackGroundinRegistry("NormalColor");
                //setLabelForeColorOnChange(_backGroundImageName);

            }
            
            #region Refresh Weather

            backgroundProcessor.RunWorkerAsync();

            #endregion

        }

        private void SetLocalLabelForeColor(String selectedWallPaper)
        {
            Color color = setLabelForeColorOnChange(selectedWallPaper, "");
            localTimeLbl.ForeColor = color;
            localLabel.ForeColor = color;
        }        

        void refreshTimer_Tick(object sender, EventArgs e)
        {
            setWeatherLabel1.Text = "Updating...";
            setWeatherLabel2.Text = "Updating...";
            setWeatherLabel3.Text = "Updating...";
            System.Threading.Thread.Sleep(2000); // just to show user, weather is getting updated.
            backgroundProcessor.RunWorkerAsync();
        }

        private WeatherData GetLatestWeather(Label weatherLabel, String whichClock)
        {
            WeatherData weatherData = new WeatherData();
            try
            {
                RegistryKey rkGetClock = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Ravi Ganesan\\World Clock", true);

                weatherData.LocationID = rkGetClock.GetValue(whichClock + "WOEID").ToString();
                weatherData.Unit = Convert.ToChar(rkGetClock.GetValue(whichClock + "Unit"));
                WeatherForecast weatherForecast = new WeatherForecast();
                weatherData = weatherForecast.GetWeatherDataFromWeb(weatherData);
            }
            catch (Exception)
            {
                return weatherData = null;
            }
            return weatherData;
        }

        private void backgroundProcessor_DoWork(object sender, DoWorkEventArgs e)
        {
            WeatherDataPool weatherDataPool = new WeatherDataPool();
            weatherDataPool.WeatherData1 = GetLatestWeather(setWeatherLabel1, FIRSTCLOCK);
            weatherDataPool.WeatherData2 = GetLatestWeather(setWeatherLabel2, SECONDCLOCK);
            weatherDataPool.WeatherData3 = GetLatestWeather(setWeatherLabel3, THIRDCLOCK);

            e.Result = weatherDataPool;
        }

        private void backgroundProcessor_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    MessageBox.Show(e.Error.Message, "Error");
                }
                else if (e.Cancelled) //when the application cancels the process
                {

                }
                else //successful
                {   
                    WeatherData weatherData1 = ((WeatherDataPool)e.Result).WeatherData1;
                    WeatherData weatherData2 = ((WeatherDataPool)e.Result).WeatherData2;
                    WeatherData weatherData3 = ((WeatherDataPool)e.Result).WeatherData3;

                    _weatherCondition1 = UpdateWeather(weatherData1, setWeatherLabel1);
                    _weatherCondition2 = UpdateWeather(weatherData2, setWeatherLabel2);
                    _weatherCondition3 = UpdateWeather(weatherData3, setWeatherLabel3);

                }
            }
            catch (WebException exp)
            {
                MessageBox.Show(exp.Message, "Error in Internet Connecction!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private String UpdateWeather(WeatherData weatherData, Label weatherLabel, GroupBox groupBox)
        {
            String weatherCondition = String.Empty; //it will be empty when error is found, hence the showtool will show accordingly.
            try
            {
                //Actual value from web 
                //weatherLabel.Text = weatherData.Condition + " " + weatherData.Temperature + " C";
                weatherLabel.Text = weatherData.ConditionCodes[weatherData.TempCode] + " " + weatherData.Temperature + " " + weatherData.Unit.ToString().ToUpper();
                setSpecificWeatherLabelForeColor(_backGroundImageName, weatherLabel);
                //weatherCondition = weatherData.Condition + " " + weatherData.Temperature + " " + weatherData.Unit.ToString().ToUpper();
                weatherCondition = SetToolTipInfo(weatherData);
                ReturnImageFromURL(weatherData.ImagePath, groupBox);

            }
            catch (Exception)
            {
                weatherLabel.ForeColor = Color.Maroon;
                weatherLabel.Text = "Update Weather!";
            }

            return weatherCondition;
        }

        private String UpdateWeather(WeatherData weatherData, Label weatherLabel)
        {
            String weatherCondition = String.Empty; //it will be empty when error is found, hence the showtool will show accordingly.
            try
            {   
                //Actual value from web 
                //weatherLabel.Text = weatherData.Condition + " " + weatherData.Temperature + " C";
                weatherLabel.Text = weatherData.ConditionCodes[weatherData.TempCode] + " " + weatherData.Temperature + " " + weatherData.Unit.ToString().ToUpper();
                setSpecificWeatherLabelForeColor(_backGroundImageName, weatherLabel);
                //weatherCondition = weatherData.Condition + " " + weatherData.Temperature + " " + weatherData.Unit.ToString().ToUpper();
                weatherCondition = SetToolTipInfo(weatherData);
            }
            catch (Exception)
            {
                weatherLabel.ForeColor = Color.Maroon;
                //weatherLabel.Text = "Update Weather!";
                weatherLabel.Text = "  Internet Error!";
            }

            return weatherCondition;
        }

        void clockGroupBox1_MouseLeave(object sender, EventArgs e)
        {
            this.Text = "Smart Clock";
        }       

        void clockGroupBox2_MouseLeave(object sender, EventArgs e)
        {
            this.Text = "Smart Clock";
        }

        void clockGroupBox3_MouseLeave(object sender, EventArgs e)
        {
            this.Text = "Smart Clock";
        }

        private void clockGroupBox3_MouseHover(object sender, EventArgs e)
        {
            ToolTipShow(_weatherCondition3, setClock3Label, clockGroupBox3);
        }

        private void clockGroupBox2_MouseHover(object sender, EventArgs e)
        {
            ToolTipShow(_weatherCondition2, setClock2Label, clockGroupBox2);
        }

        private void clockGroupBox1_MouseHover(object sender, EventArgs e)
        {
            ToolTipShow(_weatherCondition1, setClock1Label, clockGroupBox1);
        }
       

        private void ToolTipShow(String weatherCondition, Label clockLabel, GroupBox groupBox)
        {
            try
            {
                this.Text = ("Smart Clock  - For More Options, Right Click.");
                this.toolTip.ToolTipTitle = clockLabel.Text;
                this.toolTip.ReshowDelay = 500;
                //Didn't like to show sunrise and sunset information
                //int getIndex = weatherCondition.Contains("C") ? weatherCondition.IndexOf('C') : weatherCondition.IndexOf('F');
                int getIndex = weatherCondition.IndexOf('\n');
                this.toolTip.Show(weatherCondition.Remove(getIndex), groupBox, 15, 50, 2000);
                //this.toolTip.Show(weatherCondition, groupBox, 15, 50, 2500);

                //how to draw image in tool tip.
                //http://msdn.microsoft.com/en-us/library/system.windows.forms.tooltip.ownerdraw(VS.80).aspx
            }
            catch (Exception)
            {
                backgroundProcessor.RunWorkerAsync();//Re-Checks the weather data,instead of waiting for 15 Min Interval while resuming from Standby.
                //MessageBox.Show("Data Not Found!", "No Data");
            }
        }

        private void timeZoneWeatherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _allowClocktoRun = false;
            WeatherData weatherData = null;
            WeatherForm weatherForm = new WeatherForm(this.BackColor, this.localTimeLbl.ForeColor, this.BackgroundImage);
            if (weatherForm.ShowDialog() == DialogResult.OK)
            {
                weatherData = weatherForm.LocalWeatherData;
                TimeZoneInfo setClockTimeZone = TimeZoneInfo.FindSystemTimeZoneById(weatherForm.SelectedCountryName + " Standard Time");
                UpdateClockTimeZone(setClockTimeZone, weatherForm);
                
            }
            _allowClocktoRun = true;
        }

        private void setCountrySpecificSettings(WeatherForm weatherForm, String whichClockToUpdate)
        {
            RegistryKey rkSetClock = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Ravi Ganesan\\World Clock");

            rkSetClock.SetValue(whichClockToUpdate + "Label", weatherForm.SelectedCountryName);
            rkSetClock.SetValue(whichClockToUpdate + "TimeZone", weatherForm.SelectedTimeZone);
            rkSetClock.SetValue(whichClockToUpdate + "CityName", weatherForm.LocalWeatherData.CityName.ToUpper());
            rkSetClock.SetValue(whichClockToUpdate + "WOEID", weatherForm.LocalWeatherData.LocationID);
            rkSetClock.SetValue(whichClockToUpdate + "Unit", weatherForm.LocalWeatherData.Unit);
        }

        private void UpdateClockTimeZone(TimeZoneInfo setClockTimeZone, WeatherForm weatherForm)
        {
            WeatherData weatherData = weatherForm.LocalWeatherData;
            String weatherCondition = String.Empty;

            switch (DetermineWhoisUpdated(weatherForm))
            {
                case FIRSTCLOCK:
                    _firstClockCountryName = setClockTimeZone.Id; //(the Value of weatherForm.SelectedCountryName + " Standard Time")
                    _hoursAheadorBeforeFromUTC1 = Convert.ToDouble(weatherForm.SelectedTimeZone);
                    if (weatherData != null)
                    {
                        setClock1Label.Text = weatherData.CityName.ToUpper();
                        setWeatherLabel1.Text = weatherData.ConditionCodes[weatherData.TempCode] + " " + weatherData.Temperature + " " + weatherData.Unit.ToString().ToUpper();
                        //_weatherCondition1 = weatherData.Condition + " " + weatherData.Temperature + " " + weatherData.Unit.ToString().ToUpper(); //updating global variable, for changes happened from weather form
                        _weatherCondition1 = SetToolTipInfo(weatherData);
                        setSpecificWeatherLabelForeColor(_backGroundImageName, setWeatherLabel1);
                        setCountrySpecificSettings(weatherForm, FIRSTCLOCK);
                    }
                    else
                    {
                        _weatherCondition1 = String.Empty;
                        DeleteWeatherSettings(setClock1Label, setWeatherLabel1, weatherForm, FIRSTCLOCK);
                    }
                    _isDayActivated1 = false;
                    _isNightActivated1 = false;
                    break;
                    //return weatherCondition; //updating global variable, for changes happened from weather form

                case SECONDCLOCK:
                    _secondClockCountryName = setClockTimeZone.Id;
                    _hoursAheadorBeforeFromUTC2 = Convert.ToDouble(weatherForm.SelectedTimeZone);
                    if (weatherData != null)
                    {
                        setClock2Label.Text = weatherData.CityName.ToUpper();
                        setWeatherLabel2.Text = weatherData.ConditionCodes[weatherData.TempCode] + " " + weatherData.Temperature + " " + weatherData.Unit.ToString().ToUpper();
                        //_weatherCondition2 = weatherData.Condition + " " + weatherData.Temperature + " " + weatherData.Unit.ToString().ToUpper();
                        _weatherCondition2 = SetToolTipInfo(weatherData);
                        setSpecificWeatherLabelForeColor(_backGroundImageName, setWeatherLabel2);
                        setCountrySpecificSettings(weatherForm, SECONDCLOCK);
                        //ReturnImageFromURL(weatherForm.LocalWeatherData.ImagePath, clockGroupBox2);
                    }
                    else
                    {
                        _weatherCondition2 = String.Empty;
                        DeleteWeatherSettings(setClock2Label, setWeatherLabel2, weatherForm, SECONDCLOCK);
                    }
                    _isDayActivated2 = false;
                    _isNightActivated2 = false;
                    break;

                case THIRDCLOCK:
                    _thirdClockCountryName = setClockTimeZone.Id;
                    _hoursAheadorBeforeFromUTC3 = Convert.ToDouble(weatherForm.SelectedTimeZone);
                    if (weatherData != null)
                    {
                        setClock3Label.Text = weatherData.CityName.ToUpper();
                        setWeatherLabel3.Text = weatherData.ConditionCodes[weatherData.TempCode] + " " + weatherData.Temperature + " " + weatherData.Unit.ToString().ToUpper();
                        //_weatherCondition3 = weatherData.Condition + " " + weatherData.Temperature + " " + weatherData.Unit.ToString().ToUpper();
                        _weatherCondition3 = SetToolTipInfo(weatherData);
                        setSpecificWeatherLabelForeColor(_backGroundImageName, setWeatherLabel3);
                        setCountrySpecificSettings(weatherForm, THIRDCLOCK);
                        //ReturnImageFromURL(weatherForm.LocalWeatherData.ImagePath, clockGroupBox3);

                    }
                    else
                    {
                        _weatherCondition3 = String.Empty;
                        DeleteWeatherSettings(setClock3Label, setWeatherLabel3, weatherForm, THIRDCLOCK);
                    }
                    _isDayActivated3 = false;
                    _isNightActivated3 = false;
                    break;
            }
        
        }

        private String SetToolTipInfo(WeatherData weatherData)
        {
            //String weatherCondition = String.Empty; //it will be empty when error is found, hence the showtool will show accordingly.            
            StringBuilder weatherCondition = new StringBuilder();

            weatherCondition.Append(weatherData.Condition + " " + weatherData.Temperature + " " + weatherData.Unit.ToString().ToUpper());
            weatherCondition.Append("\n");
            weatherCondition.Append("\n");
            weatherCondition.Append("Sunrise: "+ weatherData.Sunrise.ToUpper());
            weatherCondition.Append("\n");
            weatherCondition.Append("Sunset: " + weatherData.Sunset.ToUpper());
            
            //weatherCondition  = weatherData.Condition + " " + weatherData.Temperature + " " + weatherData.Unit.ToString().ToUpper()+ "\n"+ weatherData.Sunrise + "\n" + weatherData.Sunset;

            return weatherCondition.ToString();
        }

        private void ReturnImageFromURL(String urlPath, GroupBox grpBox)
        {
            PictureBox picBox = new PictureBox();
            picBox.Load(urlPath);

            grpBox.BackgroundImage = picBox.Image;
            
        }

        private string DetermineWhoisUpdated(WeatherForm weatherform)
        {
            String whichClock = String.Empty;

            if (weatherform.IsClockSet1) whichClock = FIRSTCLOCK;
            if (weatherform.IsClockSet2) whichClock = SECONDCLOCK;
            if (weatherform.IsClockSet3) whichClock = THIRDCLOCK;

            return whichClock;
        }

        private void DeleteWeatherSettings(Label clockLabel, Label weatherLabel, WeatherForm weatherForm, String whichClock)
        {
            weatherLabel.ForeColor = Color.Maroon;
            weatherLabel.Text = "Update Weather!";
            clockLabel.Text = weatherForm.SelectedCountryName;
            //TimeZone.Text = weatherForm.SelectedTimeZone;
            setCountrySpecificSettings(clockLabel,weatherForm.SelectedTimeZone,whichClock);

            RegistryKey rkSetClock = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Ravi Ganesan\\World Clock");
            rkSetClock.DeleteValue(whichClock + "CityName",false);
            rkSetClock.DeleteValue(whichClock + "WOEID",false);

        }

        private void setCountrySpecificSettings(Label clockLabel, String timeZone, String whichClock)
        {
            clockLabel.Text = clockLabel.Text.Contains("INDIA") ? "I N D I A" : clockLabel.Text;
            RegistryKey rkSetClock = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Ravi Ganesan\\World Clock");
            rkSetClock.SetValue(whichClock + "Label", clockLabel.Text);
            rkSetClock.SetValue(whichClock + "TimeZone", timeZone);            
        }

        private void setCountrySpecificSettings(Label clockLabel, Label clockTime)
        {
            clockLabel.Text = clockLabel.Text.Contains("INDIA") ? "I N D I A" : clockLabel.Text;
            RegistryKey rkSetClock = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Ravi Ganesan\\World Clock");
            rkSetClock.SetValue(clockTime.Name, clockTime.Text);
            rkSetClock.SetValue(clockLabel.Name, clockLabel.Text);
        }       
       

        private void setCountrySpecificSettings(Label clockLabel, Label clockTime, Label weatherLabel, String cityName, String locationID)
        {
            RegistryKey rkSetClock = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Ravi Ganesan\\World Clock");

            rkSetClock.SetValue(clockLabel.Name, clockLabel.Text);
            rkSetClock.SetValue(clockTime.Name, clockTime.Text);
            rkSetClock.SetValue("CityName" + weatherLabel.Name, cityName.ToUpper());
            rkSetClock.SetValue("WOEID" + weatherLabel.Name, locationID);

            //clockLabel.Text = cityName;
            clockGroupBox1.Invalidate(); //Redraws the entire Surface of the control
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

        private void _time_Tick(object sender, EventArgs e)
        {
            if (_allowClocktoRun)
            {
                //Below code for Computers with/without Windows XP OS Patch for DST (KB931836)
                //**Start**
                //DateTime UTC = DateTime.UtcNow;
                //_dtSetClock1 = UTC.AddHours(VerifyDayLightSavings(_firstClockCountryName, _hoursAheadorBeforeFromUTC1));
                //_dtSetClock2 = UTC.AddHours(VerifyDayLightSavings(_secondClockCountryName, _hoursAheadorBeforeFromUTC2));
                //_dtSetClock3 = UTC.AddHours(VerifyDayLightSavings(_thirdClockCountryName, _hoursAheadorBeforeFromUTC3));
                //**End**

                //Below code for Computers with Windows XP OS Patch for DST (KB931836)
                //**Start**
                _dtSetClock1 = VerifyDayLightSavings(_dtSetClock1, _firstClockCountryName);
                _dtSetClock2 = VerifyDayLightSavings(_dtSetClock2, _secondClockCountryName);
                _dtSetClock3 = VerifyDayLightSavings(_dtSetClock3, _thirdClockCountryName);
                //**End**

                setClock1Time.Text = String.Format("{0: hh:mm:ss tt}",_dtSetClock1);
                setDateLabel1.Text = String.Format("{0: ddd MMM-dd-yy}", _dtSetClock1);
                setClock2Time.Text = String.Format("{0: hh:mm:ss tt}", _dtSetClock2);
                setDateLabel2.Text = String.Format("{0: ddd MMM-dd-yy}", _dtSetClock2);
                setClock3Time.Text = String.Format("{0: hh:mm:ss tt}", _dtSetClock3);
                setDateLabel3.Text = String.Format("{0: ddd MMM-dd-yy}", _dtSetClock3);
                localTimeLbl.Text = String.Format("{0: hh:mm:ss tt dddd MMM-dd-yyyy}", DateTime.Now);

                DetectDayNight();
            }
        }

        private void DetectDayNightAsPerAstronomy()
        {
            //First Clock
            if (_dtSetClock1 > DateTime.Parse(_dtSetClock1.ToShortDateString() + " 6:00:00 AM") && _dtSetClock1 < DateTime.Parse(_dtSetClock1.ToShortDateString() + " 6:00:00 PM"))
            {
                _isDayActivated1 = SetDay(_isDayActivated1, clockGroupBox1);
                _isNightActivated1 = false;
            }
            else
            {
                _isNightActivated1 = SetNight(_isNightActivated1, clockGroupBox1);
                _isDayActivated1 = false;
            }
            //Second Clock
            if (_dtSetClock2 > DateTime.Parse(_dtSetClock2.ToShortDateString() + " 6:00:00 AM") && _dtSetClock2 < DateTime.Parse(_dtSetClock2.ToShortDateString() + " 6:00:00 PM"))
            {
                _isDayActivated2 = SetDay(_isDayActivated2, clockGroupBox2);
                _isNightActivated2 = false;
            }
            else
            {
                _isNightActivated2 = SetNight(_isNightActivated2, clockGroupBox2);
                _isDayActivated2 = false;
            }
            //Third Clock
            if (_dtSetClock3 > DateTime.Parse(_dtSetClock3.ToShortDateString() + " 6:00:00 AM") && _dtSetClock3 < DateTime.Parse(_dtSetClock3.ToShortDateString() + " 6:00:00 PM"))
            {
                _isDayActivated3 = SetDay(_isDayActivated3, clockGroupBox3);
                _isNightActivated3 = false;
            }
            else
            {
                _isNightActivated3 = SetNight(_isNightActivated3, clockGroupBox3);
                _isDayActivated3 = false;
            }

        }

        private void DetectDayNight()
        {
            //First Clock 
            
            //if (_dtSetClock1 > DateTime.Parse(_dtSetClock1.ToShortDateString() + " 6:00:00 AM") && _dtSetClock1 < DateTime.Parse(_dtSetClock1.ToShortDateString() + " 6:00:00 PM"))
            if (checkAstronomicalOrStatic(_dtSetClock1,_weatherCondition1))
            {
                _isDayActivated1 = SetDay(_isDayActivated1, clockGroupBox1);
                _isNightActivated1 = false;
            }
            else
            {
                _isNightActivated1 = SetNight(_isNightActivated1,clockGroupBox1);
                _isDayActivated1 = false;
            }
            //Second Clock
           // if (_dtSetClock2 > DateTime.Parse(_dtSetClock2.ToShortDateString() + " 6:00:00 AM") && _dtSetClock2 < DateTime.Parse(_dtSetClock2.ToShortDateString() + " 6:00:00 PM"))
            if (checkAstronomicalOrStatic(_dtSetClock2, _weatherCondition2))
            {
                _isDayActivated2 = SetDay(_isDayActivated2, clockGroupBox2);
                _isNightActivated2 = false;
            }
            else
            {
                _isNightActivated2 = SetNight(_isNightActivated2, clockGroupBox2);
                _isDayActivated2 = false;
            }
            //Third Clock
            //if (_dtSetClock3 > DateTime.Parse(_dtSetClock3.ToShortDateString() + " 6:00:00 AM") && _dtSetClock3 < DateTime.Parse(_dtSetClock3.ToShortDateString() + " 6:00:00 PM"))
            if (checkAstronomicalOrStatic(_dtSetClock3, _weatherCondition3))
            {
                _isDayActivated3 = SetDay(_isDayActivated3, clockGroupBox3);
                _isNightActivated3 = false;
            }
            else
            {
                _isNightActivated3 = SetNight(_isNightActivated3, clockGroupBox3);
                _isDayActivated3 = false;
            }

        }

        private Boolean checkAstronomicalOrStatic(DateTime dtClock, String weatherCondition)
        {
            Boolean isDay = false;
            if (!String.IsNullOrEmpty(weatherCondition))
            {
                String[] astronomyArray = new String[] {"\n"};
                String[] astronomy = weatherCondition.Split(astronomyArray, StringSplitOptions.None);
                isDay = dtClock > DateTime.Parse(dtClock.ToShortDateString() + astronomy[2].Replace("Sunrise:", "").ToString()) && dtClock < DateTime.Parse(dtClock.ToShortDateString() + astronomy[3].Replace("Sunset:", "").ToString());
            }
            else
            {
                isDay = dtClock > DateTime.Parse(dtClock.ToShortDateString() + " 6:00:00 AM") && dtClock < DateTime.Parse(dtClock.ToShortDateString() + " 6:00:00 PM");
            }

            return isDay;
        }


        private Boolean SetNight(Boolean isNightActivated, GroupBox clockGroupBox)
        {
            if (!isNightActivated)
            {
                clockGroupBox.BackgroundImage = Earth.Properties.Resources.NightSky;
                isNightActivated = true;

            }
            setLabelsForeColor(Color.White, Color.LightPink, clockGroupBox.Name);
            return isNightActivated;
        }

        private Boolean SetDay(Boolean isDayActivated, GroupBox clockGroupBox)
        {   
            if (!isDayActivated)
            {
                clockGroupBox.BackgroundImage = null;
                clockGroupBox.BackColor = Color.Transparent;
                isDayActivated = true;
            }
            setLabelForeColorOnChange(_backGroundImageName, clockGroupBox.Name);
            return isDayActivated;
        }

        private Double VerifyDayLightSavings(String clockCountryName, Double hoursAheadorBeforeFromUTC)
        {
            //Computers without Windows XP OS Patch for DST (KB931836)
            TimeZoneInfo Zone = TimeZoneInfo.FindSystemTimeZoneById(clockCountryName);
            DateTime clock = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, Zone.Id);
            hoursAheadorBeforeFromUTC = Zone.IsDaylightSavingTime(clock) ? hoursAheadorBeforeFromUTC + 1 : hoursAheadorBeforeFromUTC;
            return hoursAheadorBeforeFromUTC;

        }

        private DateTime VerifyDayLightSavings(DateTime clock, String clockCountryName)
        {
            //Computers with Windows XP OS Patch for DST (KB931836)
            //Installing this update enables your computer to automatically adjust the computer clock on the correct date in 2007 
            //due to revised Daylight Saving Time laws in many countries.

            //refresh time zone (since windows os takes care of daylightsavings, making timezone class to follow Windows by refreshing)
            TimeZoneInfo Zone = TimeZoneInfo.FindSystemTimeZoneById(clockCountryName);
            clock = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, Zone.Id);
            return clock;

        }

        private void checkAlarm() //runs in a Async Thread
        {
            Boolean isAlarmTriggered = false;            
            //System.Threading.Thread runAlarmThread = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(Beep));

            while (DateTime.Now <= _setAlarmTime.AddMinutes(2))
            {
                System.Threading.Thread.Sleep(100);//wait for some time, so that the user can see the blinking text
                if (DateTime.Now >= _setAlarmTime && DateTime.Now <= _setAlarmTime.AddMinutes(2))//for two minutes it will flash
                {
                    if (!isAlarmTriggered)
                    {
                        isAlarmTriggered = true;
                        Beep(true);


                        //Beep(true); //Synchronous call
                        //runAlarmThread.Start(true); //Asynchronous alarm call, it doesn't disturb the blinking text                   
                    }
                    accessCrossThreadOperation(true);                    
                }
            }
            accessCrossThreadOperation(false);
            _setAlarmTime = DateTime.Parse("00:00:00"); //once the alarm check loop exits, the alarm is reset to 0

            isAlarmTriggered = false;
            //runAlarmThread.Abort();            
            //runAlarmThread.Abort();
            Beep(false);
            this.Text = "Smart Clock";
        }
       
        //private void Beep(object enabled)
        private void Beep(Boolean activate)
        {
            //since PlayLooping/Play itself offers Asynchrounous operation, 
            //not required to call beep through Threads

           //System.Media.SystemSounds.Beep.Play();
            //System.Threading.Thread.Sleep(500);
            try
            {
                System.Media.SoundPlayer sdPlayer = new System.Media.SoundPlayer(Application.StartupPath + "\\cuckooclock.wav");
                //System.Media.SoundPlayer sdPlayer = new System.Media.SoundPlayer(Earth.Properties.Resources.cuckooclock);

                //Boolean activate = Convert.ToBoolean(enabled);
                //while (activate)
                //{
                //    System.Threading.Thread.Sleep(2000);
                    //System.Media.SoundPlayer sdPlayer = new System.Media.SoundPlayer(Earth.Properties.Resources.cuckooclock);
                if (activate)
                {
                    sdPlayer.PlayLooping();
                }
                else
                {
                    sdPlayer.Stop();
                }
                //}
                //sdPlayer.Stop();
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("Please make sure you copied the wav file \"cuckooclock.wav\"", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void accessCrossThreadOperation(Boolean alarm)
        {
            //To Handle Cross Thread Operation (For resolving the issue: When a thread that wants to access a thread which was not created by it.)
            if (InvokeRequired)
            {
                switch (alarm)
                {
                    case true:
                        this.Invoke(new MethodInvoker(blinkText));
                        break;
                    case false:
                        this.Invoke(new MethodInvoker(applyNormalFontToLocalTime));
                        break;
                }
            }
        }

        private void applyNormalFontToLocalTime()
        {
            localTimeLbl.Font = new Font(FontFamily.GenericSansSerif, 8.25F, FontStyle.Regular);
            SetLocalLabelForeColor(_backGroundImageName);
        }   
        
        private void blinkText()
        {
            System.Threading.Thread.Sleep(500);
            localTimeLbl.Text = "";
            System.Threading.Thread.Sleep(500);
            localTimeLbl.ForeColor = Color.Red;
            localTimeLbl.Font = new Font(FontFamily.GenericSansSerif, 6.95F, FontStyle.Bold);  
            localTimeLbl.Text = DateTime.Now.ToLongTimeString() + " " + DateTime.Now.DayOfWeek + " " + DateTime.Now.Date.ToString().Remove(9);
            this.Text = "Click on Blinking Text, to turn OFF Alarm";
        }

        private void runningTextOnTitleBar()
        {
            String titleText = "World Clock - Click on Blinking Text to Stop Blinking...";
            String[] textArray = titleText.Split(' ');         
        }
       
        void Main_Resize(object sender, EventArgs e)
        {
            //this.Height = 136;
            //this.Width = 298;
            //this.Left = Screen.PrimaryScreen.Bounds.Width - 148; //taking the full screen width and Subtracting the form's width,gives the starting position of the form to set the form at the right side and fully visible.
            this.Refresh();
            this.Left = Screen.PrimaryScreen.WorkingArea.Width - _xAxis; //taking the full screen width and Subtracting the form's width,gives the starting position of the form to set the form at the right side and fully visible.
            this.Top = Screen.PrimaryScreen.WorkingArea.Height - _yAxis;
            if ((this.WindowState == FormWindowState.Normal) || (this.WindowState == FormWindowState.Maximized))
            {
                this.ShowInTaskbar = false;
            }

        }
      
        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            //this.ShowInTaskbar = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About abt = new About();
            abt.Show();
        }
        private void transparentToolStripMenuItem_Click(object sender, EventArgs e)
        {   //Detects the OS Installed and applies transparency            
            //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmartClock));
            //this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("")));
            this.BackgroundImage = null;
            RegistryKey rkGetOSInfo = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", true);
            if (rkGetOSInfo != null && rkGetOSInfo.GetValue("ProductName").ToString().Contains("Vista"))
            {
                this.BackColor = Color.FromArgb(255, 235, 234, 219);//WinVista 
            }
            else
            {
                MessageBox.Show("Right Click only on the Texts for Options", "Options", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.BackColor = Color.FromArgb(255, 236, 233, 216);//winXP 
            }
            //setLabelsForeColor(Color.Black);            
            //setLabelForeColorOnChange("TransparentColor");
            setBackGroundinRegistry("TransparentColor");
            SetLocalLabelForeColor("TransparentColor");
        }
        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            this.BackgroundImage = null;
            this.BackColor = Color.WhiteSmoke;
            setBackGroundinRegistry("NormalColor");
            SetLocalLabelForeColor("NormalColor");
        }
        private void setBackGroundinRegistry(String backGroundImageColor)
        {
            _backGroundImageName = backGroundImageColor;
            RegistryKey rkSetClock = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Ravi Ganesan\\World Clock");
            rkSetClock.SetValue("backGroundImageName", _backGroundImageName);
        }
        void WallPaperComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {            
            this.BackgroundImage = _backGroundImageCollection[WallPaperComboBox.SelectedItem.ToString()];            
            setBackGroundinRegistry(WallPaperComboBox.SelectedItem.ToString());
            SetLocalLabelForeColor(WallPaperComboBox.SelectedItem.ToString());
        }

        private Color setLabelForeColorOnChange(String selectedWallPaper, String groupBoxName)
        { //It returns the color for the localLabel Forecolor.
            switch (selectedWallPaper)
            {
                //case "Blue_Design":
                //    setLabelsForeColor(Color.Black, Color.Snow, groupBoxName);
                //    this.toolTip.BackColor = Color.LightYellow;
                //    return Color.Black;
                case "Natural_Water_Droplet":
                    setLabelsForeColor(Color.Black, Color.Black, groupBoxName);
                    this.toolTip.BackColor = Color.LightYellow;
                    return Color.Black;
                case "Fresh_Lime":
                    setLabelsForeColor(Color.Black, Color.Navy, groupBoxName);
                    this.toolTip.BackColor = Color.LightYellow;
                    return Color.Black;
                case "Sapphire":
                    setLabelsForeColor(Color.Black, Color.DarkOrange, groupBoxName);
                    this.toolTip.BackColor = Color.LightYellow;
                    return Color.Black;
                case "NormalColor":
                case "TransparentColor":
                    setLabelsForeColor(Color.Black, Color.Blue, groupBoxName);
                    this.toolTip.BackColor = Color.LightYellow;
                    return Color.Black;
                case "Nice_Tree":                    
                    setLabelsForeColor(Color.DarkRed, Color.Black, groupBoxName);
                    this.toolTip.BackColor = Color.Orange;
                    return Color.DarkRed;
                case "Natural_Wood_Wallpaper":                    
                    setLabelsForeColor(Color.WhiteSmoke, Color.White, groupBoxName);
                    this.toolTip.BackColor = Color.Khaki;
                    return Color.WhiteSmoke;
                default:                    
                    setLabelsForeColor(Color.WhiteSmoke, Color.White, groupBoxName);
                    this.toolTip.BackColor = Color.LightSkyBlue;
                    return Color.WhiteSmoke;
            }
        }
        private void setSpecificWeatherLabelForeColor(String selectedWallPaper, Label weatherLabel)
        { //Only the specific Label color changes, because the other label may have Maroon colors based on data 
          //availability.
            switch (selectedWallPaper)
            {
                case "Natural_Water_Droplet":
                    weatherLabel.ForeColor = Color.Snow;
                    this.toolTip.BackColor = Color.LightYellow;
                    break;
                case "Fresh_Lime":
                    weatherLabel.ForeColor = Color.Navy;
                    this.toolTip.BackColor = Color.LightYellow;
                    break;
                case "Sapphire":
                    weatherLabel.ForeColor = Color.DarkOrange;
                    this.toolTip.BackColor = Color.LightYellow;
                    break;
                case "NormalColor":
                case "TransparentColor":
                    weatherLabel.ForeColor = Color.Blue;
                    this.toolTip.BackColor = Color.LightYellow;
                    break;
                case "Nice_Tree":
                    weatherLabel.ForeColor = Color.Black;
                    this.toolTip.BackColor = Color.Orange;
                    break;
                case "Natural_Wood_Wallpaper":
                    weatherLabel.ForeColor = Color.White;
                    this.toolTip.BackColor = Color.Khaki;
                    break;
                default:
                    weatherLabel.ForeColor = Color.White;
                    this.toolTip.BackColor = Color.LightSkyBlue;
                    break;
            }
            clockGroupBox1.Invalidate(); // redraws
            clockGroupBox2.Invalidate();
            clockGroupBox3.Invalidate();
        }
        private void setLabelsForeColor(Color color)
        {
            setClock1Label.ForeColor = color;
            setClock2Label.ForeColor = color;
            setClock3Label.ForeColor = color;
            setClock1Time.ForeColor = color;
            setClock2Time.ForeColor = color;
            setClock3Time.ForeColor = color;
            setDateLabel1.ForeColor = color;
            setDateLabel2.ForeColor = color;
            setDateLabel3.ForeColor = color;

            localTimeLbl.ForeColor = color;
            localLabel.ForeColor = color;
        }

        private void setLabelsForeColor(Color labelsForeColor, Color weatherColor, String groupBoxName)
        {
            switch (groupBoxName)
            {
                case "clockGroupBox1":
                    setClock1Label.ForeColor = labelsForeColor;
                    setClock1Time.ForeColor = labelsForeColor;
                    setDateLabel1.ForeColor = labelsForeColor;
                    setWeatherLabel1.ForeColor = (setWeatherLabel1.ForeColor != Color.Maroon) ? weatherColor : Color.Maroon;
                    break;

                case "clockGroupBox2":
                    setClock2Label.ForeColor = labelsForeColor;
                    setClock2Time.ForeColor = labelsForeColor;
                    setDateLabel2.ForeColor = labelsForeColor;
                    setWeatherLabel2.ForeColor = (setWeatherLabel2.ForeColor != Color.Maroon) ? weatherColor : Color.Maroon;
                    break;

                case "clockGroupBox3":
                    setClock3Label.ForeColor = labelsForeColor;
                    setClock3Time.ForeColor = labelsForeColor;
                    setDateLabel3.ForeColor = labelsForeColor;
                    setWeatherLabel3.ForeColor = (setWeatherLabel3.ForeColor != Color.Maroon) ? weatherColor : Color.Maroon;
                    break;
            }
        }

        private void SetWeatherLabelForeColor(Color color)
        {
            //changes color only when its called from UpdateWeather method ((i.e)only when data available)
            setWeatherLabel1.ForeColor = (setWeatherLabel1.ForeColor != Color.Maroon) ? color : Color.Maroon;
            setWeatherLabel2.ForeColor = (setWeatherLabel2.ForeColor != Color.Maroon) ? color : Color.Maroon;
            setWeatherLabel3.ForeColor = (setWeatherLabel3.ForeColor != Color.Maroon) ? color : Color.Maroon;
        }

      
        private void sendToBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sendToBackToolStripMenuItem.Text == "Send To Back")
            {
                this.TopMost = false;
                this.SendToBack();
                sendToBackToolStripMenuItem.Text = "Bring To Top Most";
            }
            else
            {                
                this.TopMost = true;
                sendToBackToolStripMenuItem.Text = "Send To Back";
            }
        }       

        private void alarmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            callAlarmDialog();
        }

        private void alarmIndicator_Click(object sender, EventArgs e)
        {
            callAlarmDialog();
        }

        private void callAlarmDialog()
        {
            String[] timeSplit = DateTime.Now.ToLongTimeString().Split(':');
            AlarmInputDialog alarmInputDialog;

            if (_setAlarmTime == DateTime.Parse("00:00:00"))
            {
                alarmInputDialog = new AlarmInputDialog(timeSplit[0], timeSplit[1], timeSplit[2].Substring(3, 2), this.BackColor, this.localTimeLbl.ForeColor, this.BackgroundImage);
                alarmInputDialog.Text = "Set Alarm";
            }
            else
            {
                String[] alarmSplit = _setAlarmTime.ToLongTimeString().Split(':');

                alarmInputDialog = new AlarmInputDialog(alarmSplit[0], alarmSplit[1], alarmSplit[2].Substring(3, 2), this.BackColor, this.localTimeLbl.ForeColor, this.BackgroundImage);
                alarmInputDialog.Text = "Alarm - Already Set";
            }
                if (alarmInputDialog.ShowDialog() == DialogResult.OK)
                {
                    _setAlarmTime = alarmInputDialog.SetAlarmTime;
                    
                    System.Threading.Thread blinkthread = new System.Threading.Thread(new System.Threading.ThreadStart(checkAlarm));
                    blinkthread.Start();
                }            
        }     

        private void localTimeLbl_Click(object sender, EventArgs e)
        {
            _setAlarmTime = DateTime.Parse("00:00:00");
            this.Text = "Smart Clock";
        }

        private void alarmIndicator_MouseHover(object sender, EventArgs e)
        {
            toolTip.ToolTipTitle = "Alarm";
            toolTip.Show("Click for Alarm",alarmIndicator,1000);
        }

        private void SmartClock_FormClosing(object sender, FormClosingEventArgs e)
        {
            localTimeLbl_Click(null, null); //In case the form is closed while alarm
        }        
             
    }
}