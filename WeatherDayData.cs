using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pogoda2
{
    
    public class ListWeatherDayData
    {
        [JsonProperty("list")]
        public List<WeatherDayData> list { get; set; }

    }
    public class WeatherDayData:WeatherData
    {
        [JsonProperty("dt_txt")]
        public string Data { get; set; }

        
    }
}

