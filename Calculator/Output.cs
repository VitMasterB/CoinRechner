using System;

namespace CoinRechner.Calculator
{
    public class Output
    {
        private double price;
        
        public void calculatorToConsole(double price, string tradingSide)
        {
            var priceOutput = new Price();

            this.price = price;
            priceOutput.calculatePriceList(price, tradingSide);

            if (tradingSide == "v" || tradingSide == "V")
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(i + 1 + ". Bot:");
                    Console.WriteLine("Buyprice: " + Math.Round(priceOutput.ListFirst[i], 6));
                    Console.WriteLine("Sellprice: " + Math.Round(priceOutput.ListSecond[i], 6));
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