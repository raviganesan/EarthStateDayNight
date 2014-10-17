using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Earth.Weather;

namespace Earth.Classes
{
    class WeatherDataPool
    {

        WeatherData weatherData1 = new WeatherData();

        public WeatherData WeatherData1
        {
            get { return weatherData1; }
            set { weatherData1 = value; }
        }

        WeatherData weatherData2 = new WeatherData();

        public WeatherData WeatherData2
        {
            get { return weatherData2; }
            set { weatherData2 = value; }
        }

        WeatherData weatherData3 = new WeatherData();

        public WeatherData WeatherData3
        {
            get { return weatherData3; }
            set { weatherData3 = value; }
        }


    }
}
