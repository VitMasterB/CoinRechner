using System.Collections.Generic;
using System;

namespace CoinRechner.Calculator
{
    class Price
    {
        private double price;
        //Tradinggebühren
        private double fees = 0.002;

        //Prozentualer Preisabstand bei einem Sell start 
        private List<double> priceDistanceFirstSell = new List<double>() { 1.015, 1.035, 1.055, 1.075, 1.095 };
        private List<double> priceDistanceSecondSell = new List<double>() { 0.995, 0.988, 0.98, 0.97, 0.955 };

        //Prozentualer Preisabstand bei einem buy start 
        private List<double> priceDistanceFirstBuy = new List<double>() { 0.985, 0.965, 0.945, 0.925, 0.905 };
        private List<double> priceDistanceSecondBuy = new List<double>() { 1.005, 1.012, 1.02, 1.03, 1.045 };

        //Initalisierung der Listen für die Preise
        List<double> priceFirst = new List<double>();
        List<double> priceSecond = new List<double>();

        //Methode zur Berechnung der Verkaufspreise
        private void priceCalculatorFirst(double price, string tradingSide)
        {
            if (tradingSide == "V" || tradingSide == "v")
            {
                foreach (var newPrice in priceDistanceFirstSell)
                {
                    priceFirst.Add(price * newPrice);
                }
            }
            else
            {
                foreach (var newPrice in priceDistanceFirstBuy)
                {
                    priceFirst.Add(price * newPrice);
                }
            }
        }

        //Methode zur Berechnung des Kaufpreises
        private void priceCalculatorSecond(double price, string tradingSide)
        {
            if (tradingSide == "v" || tradingSide == "V")
            {
                for (int i = 0; i < 5; i++)
                {
                    priceSecond.Add(priceFirst[i] * (priceDistanceSecondSell[i] - fees));
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    priceSecond.Add(priceFirst[i] * (priceDistanceSecondBuy[i] - fees));
                }
            }
        }

        public void calculatePriceList(double price, string tradingSide)
        {
            this.price = price;
            priceCalculatorFirst(price, tradingSide);
            priceCalculatorSecond(price, tradingSide);
        }


        //Preise werden ausgegeben
        public void calculatorToConsole(double price, string tradingSide)
        {
            this.price = price;
            priceCalculatorFirst(price, tradingSide);
            priceCalculatorSecond(price, tradingSide);

            if (tradingSide == "v" || tradingSide == "V")
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(i + 1 + ". Bot:");
                    Console.WriteLine("Buyprice: " + Math.Round(priceSecond[i], 6));
                    Console.WriteLine("Sellprice: " + Math.Round(priceFirst[i], 6));
                    Console.WriteLine("");
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(i + 1 + ". Bot:");
                    Console.WriteLine("Buyprice: " + Math.Round(priceFirst[i], 6));
                    Console.WriteLine("Sellprice: " + Math.Round(priceSecond[i], 6));
                    Console.WriteLine("");
                }
            }
        }
    }
}
