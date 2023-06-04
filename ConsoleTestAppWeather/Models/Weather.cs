using System;

namespace ConsoleTestAppWeather.Models
{
    public class Weather
    {
        public int id { get; set; }
        public string name { get; set; }
    	 	public double temp { get; set; }
    public double pressure { get; set; }
    public double humidity { get; set; }
        public double wind_speed { get; set; }
       
    }
}
