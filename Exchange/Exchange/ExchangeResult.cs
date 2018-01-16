using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange
{
    class ExchangeResult
    {
        public int a { get; set; }
        public int b { get; set; }
        public int MaxCountMoney { get; set; }
        public int MaxCountCombs { get; set; }
        public int[,] Ways { get; set; }
        public int[] Remainder { get; set; }
        public int count_zero_R { get; set; }
        public bool inversion_flag { get; set; }
        public IStrategy strategy { get; set; }

        public OptimalResult Optimal(int x, ExchangeResult er)
        {
            OptimalResult or = er.strategy.Optimal(x, er);
            return or;
        }
    }
}
