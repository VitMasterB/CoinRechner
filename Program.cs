using System;
using CoinRechner.Calculator;

namespace CoinRechner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kauf [K] oder Verkauf[V]?");
            string tradingSide = Console.ReadLine();

            Console.WriteLine("Bitte geben Sie den Startpreis an");
            var startPrice = Convert.ToDouble(Console.ReadLine());

            var priceOut = new Output();

            priceOut.calculatorToConsole(startPrice,tradingSide);
        }
    }
}