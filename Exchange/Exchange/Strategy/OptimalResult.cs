using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange
{
    class OptimalResult
    {
        public double number_of_coins_A { get; set; }
        public double number_of_coins_B { get; set; }
        public double percent_An{ get; set; }


        public override string ToString()
        {
            string a = "\nNumber_of_coins_A = " + number_of_coins_A + "\nNumber_of_coins_B = " + number_of_coins_B
                + "\nPercent An = " + percent_An + "%";
            return a;
        }
    }
}
