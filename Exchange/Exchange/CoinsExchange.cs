using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange
{
    class CoinsExchange
    {
        public static ExchangeResult Calculation(int a, int b, double summ)
        {
            ExchangeResult er = new ExchangeResult();
            er.a = a;
            er.b = b;
            er.inversion_flag = Inversion(a, b);
            if (er.inversion_flag)
            {
                int c = er.a;
                er.a = er.b;
                er.b = c;
            }
            er.MaxCountMoney = CountMoney(summ, er.b);
            er.MaxCountCombs = CountCombs(summ, er.a);
            er.Ways = AllCombs(er.MaxCountCombs, er.MaxCountMoney, summ, er.a, er.b);
            er.Remainder = Remainder(er.Ways, summ);
            er.count_zero_R = CountZero(er.Remainder);
            er.strategy = Strategy(er.count_zero_R);

            return er;
        }

        public static int CountCombs(double summ, int a)
        {
            int MaxCountCombs = Convert.ToInt32(summ / a) + 1;
            return MaxCountCombs;
        }

        private static int CountMoney(double summ, int b)
        {
            int MaxCountMoney = Convert.ToInt32(summ / b);
            return MaxCountMoney;
        }

        private static bool Inversion(int a, int b)
        {
            bool inversion_flag = false;
            if (b > a)
            {
               int c = a;
                a = b;
                b = c;
                inversion_flag = true;
            }
            return inversion_flag;
        }

        private static int[,] AllCombs(int MaxCountCombs,int MaxCountMoney, double summ, int a, int b)
        {
            int[,] Ways = new int[MaxCountCombs, MaxCountMoney];
            int summ_for_a = Convert.ToInt32(summ);
            int countAdd_A = 0;
            bool add_A = false;

            for (int i = 0; i < MaxCountCombs; i++)
            {
                int summ_for_b = Convert.ToInt32(summ);
                int count_A = countAdd_A;

                for (int j = 0; j < MaxCountMoney; j++)
                {
                    if ((summ_for_b - a * countAdd_A) >= b)
                    {
                        Ways[i, j] = b;
                        summ_for_b -= b;
                    }
                    else if (add_A)
                    {
                        if (count_A != 0)
                        {
                            Ways[i, j] = a;
                            count_A--;
                        }
                        else
                        {
                            Ways[i, j] = 0;
                            add_A = false;
                        }
                    }
                    else Ways[i, j] = 0;
                }
                if (summ_for_a >= a)
                {
                    summ_for_a -= a;
                    add_A = true;
                    countAdd_A++;
                }
            }
            return Ways;
        }

        private static int[] Remainder(int[,] Ways, double summ)
        {
            int[] Remainder = new int[Ways.GetLength(0)];
            int summInt = Convert.ToInt32(summ);

            for (int i = 0; i < Ways.GetLength(0); i++)
            {
                int summ_in_combs = 0;
                for (int j = 0; j < Ways.GetLength(1); j++)
                {
                    summ_in_combs += Ways[i, j];
                }
                Remainder[i] = summInt - summ_in_combs;
            }
            return Remainder;
        }

        private static int CountZero(int[] Remainder)
        {
            int count_zero_R = 0;
            for (int i = 0; i < Remainder.Length; i++)
            {
                if (Remainder[i] == 0)
                    count_zero_R++;
            }
            return count_zero_R;
        }

        private static IStrategy Strategy(int count_zero_R)
        {
            IStrategy getStrategy;
            if (count_zero_R == 0)
                getStrategy = new StrategyWithRemainder();
            else
                getStrategy = new StrategyWithoutRemainder();

            return getStrategy;
        }
    }
}
