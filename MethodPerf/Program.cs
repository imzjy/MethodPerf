using MethodTimer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MethodPerf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var rnd = new Random().Next(1, 1000);
                GetOrders(rnd);
            }
        }

        public static class MethodTimeLogger
        {
            public static void Log(MethodBase methodBase, TimeSpan elapsed, string message)
            {
                Console.WriteLine($"{ methodBase.DeclaringType?.Name }.{ methodBase.Name } { elapsed }ms with parameter { message }");
            }
        }

        [Time("max:{max}")]
        public static void GetOrders(int max)
        {
            // Get orders from database
            var rnd = new Random().Next(1000, 2000);
            Thread.Sleep(rnd);
        }
    }
}
