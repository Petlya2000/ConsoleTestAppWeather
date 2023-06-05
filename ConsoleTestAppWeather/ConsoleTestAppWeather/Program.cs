using ConsoleTestAppWeather.Data;
using ConsoleTestAppWeather.Service;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleTestApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("ConsoleTestAppWeather");

            //ïîëó÷àåì äàííûå
            string url = "https://api.openweathermap.org/data/2.5/find?q=Gagra&units=metric&appid=f5fe011467ae500e6f54951b409d5221";
            var service = new WebWeatherApiService(url);
            var cars = await service.GetWeatherAsync();

            Console.WriteLine($"Найдена {cars.Count()} данныъ");

            //ñîõðàíÿåì äàííûå â ÁÄ
            var repository = new WeathersRepository();
            int result = await repository.SaveWeathersAsync(cars);

            Console.WriteLine($"Добавлено {result.ToString()} данныъ в БД");
            string sqlExpression = "SELECT * FROM weathers";
            using (var connection = new SqliteConnection("Data Source=weathers.db"))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            var id = reader.GetValue(0);
                            var country = reader.GetValue(1);
                            var name = reader.GetValue(2);
                            var temp = reader.GetValue(3);
                            var pressure = reader.GetValue(4);
                            var humidity = reader.GetValue(5);
                            var wind_speed = reader.GetValue(6);

                            Console.WriteLine($"{id} \t {country} \t {name} \t {temp} \t {pressure} \t ");
                            Console.WriteLine($"");
                        }
                    }
                }
            }
            Console.ReadLine();

        }
    }
}
