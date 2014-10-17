using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Earth.Weather
{
    public class WeatherData
    {
        public WeatherData()
        {
            retrieveLocationIDMappingData();
            RetrieveConditionCodes();            
        }

        Dictionary<String, String> locationIDNameMapping = new Dictionary<string, string>();
        public Dictionary<String, String> LocationIDNameMapping
        {
            get { return locationIDNameMapping; }
        }

        String tempCode;
        public String TempCode
        {
            get { return tempCode; }
            set { tempCode = value; }
        }

        String temperature;
        public String Temperature
        {
            get { return temperature; }
            set { temperature = value; }
        }
        Char unit;

        public Char Unit
        {
            get { return unit; }
            set { unit = value; }
        }
        String imagePath;
        public String ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; }
        }

        String geoLatitude;
        public String GeoLatitude
        {
            get { return geoLatitude; }
            set { geoLatitude = value; }
        }

        String geoLongtitude;
        public String GeoLongtitude
        {
            get { return geoLongtitude; }
            set { geoLongtitude = value; }
        }

        String condition;
        public String Condition
        {
            get { return condition; }
            set { condition = value; }
        }

        String forecastday1;
        public String Forecastday1
        {
            get { return forecastday1; }
            set { forecastday1 = value; }
        }

        String forecastday2;
        public String Forecastday2
        {
            get { return forecastday2; }
            set { forecastday2 = value; }
        }

        private void retrieveLocationIDMappingData()
        {
            //retrieve the locationID/WOEID from web than the local, in the future
            locationIDNameMapping.Add("pondicherry", "2295300");
            locationIDNameMapping.Add("chicago", "2379574");
        }

        String locationID;
        public String LocationID
        {
            get { return locationID; }
            set { locationID = value; }
        }

        String cityName;

        public String CityName
        {
            get { return cityName; }
            set { cityName = value; }
        }

        String region;

        public String Region
        {
            get { return region; }
            set { region = value; }
        }
        String sunset;

        public String Sunset
        {
            get { return sunset; }
            set { sunset = value; }
        }
        String sunrise;

        public String Sunrise
        {
            get { return sunrise; }
            set { sunrise = value; }
        }

        Dictionary<string, string> _conditionCodes = new Dictionary<string, string>();

        public Dictionary<string, string> ConditionCodes
        {
            get { return _conditionCodes; }
            
        }
        private void RetrieveConditionCodes()
        {
            Dictionary<string,string> conditionCodes = new Dictionary<string,string>();
            conditionCodes.Add("0", "Tornado");            
            conditionCodes.Add("1", "Humid Storm");
            conditionCodes.Add("2", "Hurricane ");          
            conditionCodes.Add("3", "Severe Storms");//severe thunderstorms
            conditionCodes.Add("4", "Thunderstorms");
            conditionCodes.Add("5", "Rain & Snow");
            conditionCodes.Add("6", "Rain & Sleet");
            conditionCodes.Add("7", "Snow & Sleet");          
            conditionCodes.Add("8", "Chill Drizzle ");
            conditionCodes.Add("9", "Drizzle");          
            conditionCodes.Add("10", "Freezing Rain");
            conditionCodes.Add("11", "Light Rain");
            conditionCodes.Add("12", "Showers");          
            conditionCodes.Add("13", "Snow Flurries");          
            conditionCodes.Add("14", "Snow Showers");
            conditionCodes.Add("15", "Blowing Snow");
            conditionCodes.Add("16", "Snow");
            conditionCodes.Add("17", "Hail");
            conditionCodes.Add("18", "Sleet");
            conditionCodes.Add("19", "Dust");
            conditionCodes.Add("20", "Foggy");
            conditionCodes.Add("21", "Haze");
            conditionCodes.Add("22", "Smoke");
            conditionCodes.Add("23", "Blustery");
            conditionCodes.Add("24", "Windy");
            conditionCodes.Add("25", "Cold");
            conditionCodes.Add("26", "Cloudy");
            conditionCodes.Add("27", "Mostly Cloudy");
            conditionCodes.Add("28", "Mostly Cloudy");
            conditionCodes.Add("29", "Partly Cloudy");
            conditionCodes.Add("30", "Partly Cloudy");
            conditionCodes.Add("31", "Clear");
            conditionCodes.Add("32", "Sunny");
            conditionCodes.Add("33", "Fair");
            conditionCodes.Add("34", "Fair (day)");
            conditionCodes.Add("35", "Rain and Hail");
            conditionCodes.Add("36", "Hot");
            conditionCodes.Add("37", "Isolated Storm");
            conditionCodes.Add("38", "Scatterd Storm");
            conditionCodes.Add("39", "Scatterd Storm");
            conditionCodes.Add("40", "Scattrd Shower");
            conditionCodes.Add("41", "Heavy Snow");
            conditionCodes.Add("42", "Scattered Snow");
            conditionCodes.Add("43", "Heavy Snow");
            conditionCodes.Add("44", "Partly Cloudy");
            conditionCodes.Add("45", "Thundershowers");
            conditionCodes.Add("46", "Snow Showers");
            conditionCodes.Add("47", "Isolatd Shower");
            conditionCodes.Add("3200", "No Info");

            _conditionCodes = conditionCodes;
        }

    }
}
