using ConsoleTestAppWeather.Data;
using ConsoleTestAppWeather.Service;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleTestApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("ConsoleTestAppWeather");

            //получаем данные
            string url = "https://api.openweathermap.org/data/2.5/find?q=Sukhum&units=metric&appid=f5fe011467ae500e6f54951b409d5221";
            var service = new WebWeatherApiService(url);
            var cars = await service.GetWeatherAsync();

            Console.WriteLine($"Получено {cars.Count()} авто");

            //сохраняем данные в БД
            var repository = new WeathersRepository();
            int result = await repository.SaveWeathersAsync(cars);

            Console.WriteLine($"Сохранено {result.ToString()} авто в БД");

            Console.ReadLine();
        }
    }
}
