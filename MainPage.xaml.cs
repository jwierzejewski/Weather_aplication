using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pogoda2
{

    public partial class MainPage : ContentPage
    {
        RestService restService;
        public MainPage()
        {
            InitializeComponent();
            restService = new RestService();
        }

        private async void bPogoda_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(miasto.Text))
            {
                
                WeatherData weatherData = await restService.GetWeatherData(GnerateRequestUri(Constants.OpenWeatherMapEndPoint));
                ListWeatherDayData lweatherdayData = await restService.GetWeatherDayData(GnerateRequestUri(Constants.OpenWeatherMapEndPoint2));
                
                if (weatherData == null)
                    weatherData = new WeatherData();
                BindingContext = weatherData;
                
                if (lweatherdayData!=null)
                {

                    data1.Text = lweatherdayData.list[5].Data.Split(' ')[0];
                    temp1.Text = MaxDayTemperature(lweatherdayData,0,7)+ "°C";
                    data2.Text = lweatherdayData.list[13].Data.Split(' ')[0];
                    temp2.Text = MaxDayTemperature(lweatherdayData, 8, 15) + "°C";
                    data3.Text = lweatherdayData.list[21].Data.Split(' ')[0];
                    temp3.Text = MaxDayTemperature(lweatherdayData, 16, 23) + "°C";
                    data4.Text = lweatherdayData.list[29].Data.Split(' ')[0];
                    temp4.Text = MaxDayTemperature(lweatherdayData, 24, 31) + "°C";
                    data5.Text = lweatherdayData.list[37].Data.Split(' ')[0];
                    temp5.Text = MaxDayTemperature(lweatherdayData, 32, 39) + "°C";
                }
                
                
            }
        }

        string MaxDayTemperature(ListWeatherDayData list, int min, int max)
        {
            double maxT=-273;
            for(int i=min;i<=max;i++)
            {
                if (maxT < list.list[i].Main.Temperature)
                    maxT = list.list[i].Main.Temperature;
            }
            return maxT.ToString();

        }
        string GnerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"?q={miasto.Text}";
            requestUri += "&units=metric";
            requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
            return requestUri;
        }
    }
        
}
