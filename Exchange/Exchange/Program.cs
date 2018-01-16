using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter coin A");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter coin B");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Summ");
            double summ = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter percent A");
            int x = Convert.ToInt32(Console.ReadLine());

            ExchangeResult exchange = CoinsExchange.Calculation(a, b, summ);
            OptimalResult optimal = exchange.Optimal(x, exchange);
            Console.Write(optimal);
            Console.ReadKey();
        }
    }
}
