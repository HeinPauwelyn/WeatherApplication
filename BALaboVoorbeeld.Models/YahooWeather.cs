using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BALaboVoorbeeld.Models
{
    public class Location
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
    }

    public class Units
    {
        public string Distance { get; set; }
        public string Pressure { get; set; }
        public string Speed { get; set; }
        public string Temperature { get; set; }
    }

    public class Wind
    {
        public string Chill { get; set; }
        public string Direction { get; set; }
        public string Speed { get; set; }
    }

    public class Atmosphere
    {
        public string Humidity { get; set; }
        public string Pressure { get; set; }
        public string Rising { get; set; }
        public string Visibility { get; set; }
    }

    public class Astronomy
    {
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
    }

    public class Image
    {
        public string Title { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Link { get; set; }
        public string Url { get; set; }
    }

    public class Condition
    {
        public string Code { get; set; }
        public string Date { get; set; }
        public string Temp { get; set; }
        public string Text { get; set; }

        public string ImgURL
        {
            get
            {
                return $"http://l.yimg.com/a/i/us/we/52/{Code}.gif";
            }
        }
    }

    public class Forecast
    {
        public string Code { get; set; }
        public string Date { get; set; }
        public string Day { get; set; }
        public string High { get; set; }
        public string Low { get; set; }
        public string Text { get; set; }
    }


    public class Item
    {
        public string Title { get; set; }
        public string Lat { get; set; }
        public string @long { get; set; }
        public string Link { get; set; }
        public string PubDate { get; set; }
        public Condition Condition { get; set; }
        public string Description { get; set; }
        public IEnumerable<Forecast> Forecast { get; set; }

        public Forecast Forecast0
        {
            get
            {
                return Forecast.ToList<Forecast>()[0];
            }
        }
    }

    public class Channel
    {
        public Item Item { get; set; }
    }

    public class WeatherResults
    {
        public Channel Channel { get; set; }
    }

    public class WeatherQuery
    {
        //public int count { get; set; }
        //public string created { get; set; }
        //public string lang { get; set; }
        public WeatherResults Results { get; set; }
    }

    public class YahooWeather
    {
        public WeatherQuery Query { get; set; }
    }
}
