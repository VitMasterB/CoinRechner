using System;

namespace CoinRechner.Calculator
{
    public class Output
    {
        public void calculatorToConsole(double price, string tradingSide, double buySellDistance, double profit, double stoplossDistance, double fee)
        {
            var priceOutput = new PriceList();

            priceOutput.calculatePriceList(price, tradingSide, buySellDistance, profit, stoplossDistance, fee);

            if (tradingSide == "v" || tradingSide == "V")
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(i + 1 + ". Bot:");
                    Console.WriteLine("Buyprice: " + Math.Round(priceOutput.ListSecond[i], 6));
                    Console.WriteLine("Sellprice: " + Math.Round(priceOutput.ListFirst[i], 6));
                    Console.WriteLine("");
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(i + 1 + ". Bot:");
                    Console.WriteLine("Buyprice: " + Math.Round(priceOutput.ListFirst[i], 6));
                    Console.WriteLine("Sellprice: " + Math.Round(priceOutput.ListSecond[i], 6));
                    Console.WriteLine("");
                }
            }
        }
    }
}