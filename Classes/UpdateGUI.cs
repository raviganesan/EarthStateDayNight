using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Earth.Classes
{
    class UpdateGUI
    {

        IAsyncResult weatherResult1;

        public IAsyncResult WeatherResult1
        {
            get { return weatherResult1; }
            set { weatherResult1 = value; }
        }
        IAsyncResult weatherResult2;

        public IAsyncResult WeatherResult2
        {
            get { return weatherResult2; }
            set { weatherResult2 = value; }
        }
        IAsyncResult weatherResult3;

        public IAsyncResult WeatherResult3
        {
            get { return weatherResult3; }
            set { weatherResult3 = value; }
        }
  
    }
}
