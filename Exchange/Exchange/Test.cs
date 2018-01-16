using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Exchange;

namespace UnitTests
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void coin_inversion()
        {
            var exchange = CoinsExchange.Calculation(2, 6, 10);
            Assert.AreEqual(exchange.a, 6);
            Assert.AreEqual(exchange.b, 2);
        }

        [Test]
        public void no_coin_inversion()
        {
            var exchange = CoinsExchange.Calculation(8, 3, 10);
            Assert.AreEqual(exchange.a, 8);
            Assert.AreEqual(exchange.b, 3);
        }

        [Test]
        public void count_max_number_of_combs()
        {
            var exchange = CoinsExchange.Calculation(5, 2, 10);
            Assert.AreEqual(exchange.MaxCountCombs, 3);
        }

        [Test]
        public void count_max_number_of_coins()
        {
            var exchange = CoinsExchange.Calculation(5, 2, 10);
            Assert.AreEqual(exchange.MaxCountMoney, 5);
        }

        [Test]
        public void all_combinations_of_coins()
        {
            int[,] array = new int[,] { { 2, 2, 2, 2, 2 }, { 2, 2, 5, 0, 0 }, { 5, 5, 0, 0, 0 } };
            var exchange = CoinsExchange.Calculation(5, 2, 10);
            Assert.AreEqual(exchange.Ways, array);
        }

        [Test]
        public void all_remainder_of_coins()
        {
            int[] array = new int[] { 0, 1, 0 };
            var exchange = CoinsExchange.Calculation(5, 2, 10);
            Assert.AreEqual(exchange.Remainder, array);
        }

        [Test]
        public void count_number_of_zero_remainder()
        {
            var exchange = CoinsExchange.Calculation(5, 2, 10);
            Assert.AreEqual(exchange.count_zero_R, 2);
        }

        [Test]
        public void choice_of_strategy_1()
        {
            var exchange = CoinsExchange.Calculation(5, 2, 10);
            Assert.That(exchange.strategy, Is.TypeOf(typeof(StrategyWithoutRemainder)));
        }

        [Test]
        public void choice_of_strategy_2()
        {
            var exchange = CoinsExchange.Calculation(6, 3, 10);
            Assert.That(exchange.strategy, Is.TypeOf(typeof(StrategyWithRemainder)));
        }

        [Test]
        public void number_of_coins_A_for_Strategy_1()
        {
            var exchange = CoinsExchange.Calculation(4, 3, 8);
            OptimalResult optimal = exchange.Optimal(50, exchange);

            Assert.AreEqual(optimal.number_of_coins_A, 2);
        }

        [Test]
        public void number_of_coins_B_for_Strategy_1()
        {
            var exchange = CoinsExchange.Calculation(4, 3, 8);
            OptimalResult optimal = exchange.Optimal(50, exchange);

            Assert.AreEqual(optimal.number_of_coins_B, 0);
        }

        [Test]
        public void calculation_of_зуксуте_for_optimal_combination_for_Strategy_1()
        {
            var exchange = CoinsExchange.Calculation(4, 3, 8);
            OptimalResult optimal = exchange.Optimal(50, exchange);

            Assert.AreEqual(optimal.percent_An, 100);
        }

        [Test]
        public void number_of_coins_A_for_Strategy_2()
        {
            var exchange = CoinsExchange.Calculation(6, 3, 10);
            OptimalResult optimal = exchange.Optimal(50, exchange);

            Assert.AreEqual(optimal.number_of_coins_A, 1);
        }

        [Test]
        public void number_of_coins_B_for_Strategy_2()
        {
            var exchange = CoinsExchange.Calculation(6, 3, 10);
            OptimalResult optimal = exchange.Optimal(50, exchange);

            Assert.AreEqual(optimal.number_of_coins_B, 1);
        }

        [Test]
        public void calculation_of_зуксуте_for_optimal_combination_for_Strategy_2()
        {
            var exchange = CoinsExchange.Calculation(6, 3, 10);
            OptimalResult optimal = exchange.Optimal(50, exchange);

            Assert.AreEqual(optimal.percent_An, 50);
        }
    }
}