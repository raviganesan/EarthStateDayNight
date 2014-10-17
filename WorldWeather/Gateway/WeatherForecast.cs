using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;

namespace Earth.Weather
{
    public class WeatherForecast
    {
        public WeatherForecast()
        {

        }
        //WeatherData WeatherData = new WeatherData();
        //public void GetWeatherDataFromWeb(WeatherData weatherData)
        //public void GetWeatherDataFromWeb(Object weatherDataObj) //passing params as object, as it is accessed by threads and background worker
        public WeatherData GetWeatherDataFromWeb(WeatherData weatherData)
        {
            //WeatherData weatherData = (WeatherData)weatherDataObj;
            
            WebRequest webRequest = WebRequest.Create("http://weather.yahooapis.com/forecastrss?w=" + weatherData.LocationID + "&u=" + weatherData.Unit);
            //webRequest.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.Reload);
            WebResponse webResponse = webRequest.GetResponse();
            //System.Net.Cache.RequestCacheLevel requestCacheLevel = System.Net.Cache.RequestCacheLevel.Reload;

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml((new StreamReader(webResponse.GetResponseStream()).ReadToEnd()));

            XmlNode imageNode = xmldoc.SelectSingleNode("//channel//item/description");
            String[] imagedataArray = new String[] { "<br />" };
            String[] imageFromCdata = imageNode.FirstChild.Value.Split(imagedataArray, StringSplitOptions.None);
            String[] imageURLArray = imageFromCdata[0].Split('\"');
            String imageURL = imageURLArray[1];

            weatherData.ImagePath = imageURL;
            if (imageNode.FirstChild is XmlCDataSection) //future use for forecast
            {
                XmlCDataSection xmlCDataSection = (XmlCDataSection)imageNode.FirstChild;
            }


            //Location Info
            weatherData.CityName = xmldoc.SelectSingleNode("//channel")["yweather:location"].Attributes["city"].Value;
            weatherData.Region = xmldoc.SelectSingleNode("//channel")["yweather:location"].Attributes["region"].Value;

            //Astronomy Info
            weatherData.Sunset = xmldoc.SelectSingleNode("//channel")["yweather:astronomy"].Attributes["sunset"].Value;
            weatherData.Sunrise = xmldoc.SelectSingleNode("//channel")["yweather:astronomy"].Attributes["sunrise"].Value;

            //Weather Condition Info
            weatherData.Condition = xmldoc.SelectSingleNode("//channel//item")["yweather:condition"].Attributes["text"].Value;
            weatherData.TempCode = xmldoc.SelectSingleNode("//channel//item")["yweather:condition"].Attributes["code"].Value;
            weatherData.Temperature = xmldoc.SelectSingleNode("//channel//item")["yweather:condition"].Attributes["temp"].Value;

            //XmlNode xmlNode = xmldoc.SelectSingleNode("//channel//item");

            //foreach (XmlNode conditionNode in xmlNode.ChildNodes)
            //{
            //    if (conditionNode.Name == "yweather:condition")
            //    {
            //        weatherData.Condition = conditionNode.Attributes["text"].Value;
            //        weatherData.TempCode = conditionNode.Attributes["code"].Value;
            //        weatherData.Temperature = conditionNode.Attributes["temp"].Value;
            //        break;
            //    }
            //}
            webResponse.Close();
            return weatherData;
        }

    }
}
