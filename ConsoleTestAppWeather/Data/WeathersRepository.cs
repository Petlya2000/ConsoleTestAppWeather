using ConsoleTestAppWeather.Data;
using ConsoleTestAppWeather.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestAppWeather.Data
{
    public class WeathersRepository
    {
        public async Task<int> SaveWeathersAsync(IEnumerable<Weather> weathers )
        {
            int result = 0;
            using (var context = new AppDataContext())
            {
                context.weathers.AddRange(weathers);
                result = await context.SaveChangesAsync();
            }

            return result;
        }


    }
}
