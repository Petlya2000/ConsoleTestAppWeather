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

            //�������� ������
            string url = "https://api.openweathermap.org/data/2.5/find?q=Sukhum&units=metric&appid=f5fe011467ae500e6f54951b409d5221";
            var service = new WebWeatherApiService(url);
            var cars = await service.GetWeatherAsync();

            Console.WriteLine($"�������� {cars.Count()} ����");

            //��������� ������ � ��
            var repository = new WeathersRepository();
            int result = await repository.SaveWeathersAsync(cars);

            Console.WriteLine($"��������� {result.ToString()} ���� � ��");

            Console.ReadLine();
        }
    }
}
