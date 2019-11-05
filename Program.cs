using System;
using CoinRechner.Calculator;

namespace CoinRechner
{
    class Program
    {
        static void Main(string[] args)
        {
            //StopLoss
            double stoplossDistance = 3.0;
            //Abstand vom aktuellen Preis
            double buySellDistance = 1.5;
            //Tradinggebühren
            double fee = 0.1;
            //Start minimaler Gewinn
            double profit = 0.5;

            Console.WriteLine("Kauf [K] oder Verkauf[V]?");
            string tradingSide = Console.ReadLine();

            Console.WriteLine("Bitte geben Sie den Startpreis an");
            var startPrice = Convert.ToDouble(Console.ReadLine());

            var priceOut = new Output();
            //double price, string tradingSide, double buySellDistance, double profit, double stoplossDistance, double fee
            priceOut.calculatorToConsole(startPrice, tradingSide, buySellDistance, profit, stoplossDistance, fee);
        }
    }
}