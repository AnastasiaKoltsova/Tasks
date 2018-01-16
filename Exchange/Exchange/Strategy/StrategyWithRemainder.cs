using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange
{
    class StrategyWithRemainder: IStrategy
    {
       public OptimalResult Optimal(int x,  ExchangeResult er)
        {
            OptimalResult result = new OptimalResult();
            double differ_x_module = x;
            double differ_x = x;
            int i_optimal_row = 0;
            double An = 0;
            double Bn = 0;

            for (int i = 0; i < er.Ways.GetLength(0); i++)
            {
                double countA_in_row = 0;
                double count_all_money_in_row = 0;

                for (int j = 0; j < er.Ways.GetLength(1); j++)
                {
                    if (er.Ways[i, j] == er.a)
                        countA_in_row++;
                    if (er.Ways[i, j] != 0)
                        count_all_money_in_row++;
                }

                if (countA_in_row != 0 && count_all_money_in_row != 0 && (Math.Abs(x - (countA_in_row / count_all_money_in_row) * 100) <= differ_x_module))
                {
                    differ_x_module = Math.Abs(x - (countA_in_row / count_all_money_in_row) * 100);
                    differ_x = x - (countA_in_row / count_all_money_in_row) * 100;
                    i_optimal_row = i;
                    An = countA_in_row;
                    Bn = count_all_money_in_row - countA_in_row;
                }
            }
            result.number_of_coins_A = An;
            result.number_of_coins_B = Bn;
            result.percent_An = Math.Round((x - differ_x), 2);
            return result;
        }
    }
}
