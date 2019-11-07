using System.Collections.Generic;
using System;

namespace CoinRechner.Calculator
{
    class PriceList
    {
        //Initalisierung der Listen für die Kauf- und Verkaufspreise
        List<double> priceFirst = new List<double>();
        List<double> priceSecond = new List<double>();
        //Initalisierung der StopLoss Preise
        List<double> priceStopLoss = new List<double>();

        public void priceCalculatorFirst(double price, string tradingSide, double buySellDistance, double fee)
        {
            double startbuySellDistance=buySellDistance;
            if (tradingSide == "V" || tradingSide == "v")
            {
                for (int i = 0; i < 10; i++)
                {
                    priceFirst.Add(price * (1 + (buySellDistance / 100)));
                    buySellDistance += startbuySellDistance;
                }

                AddFee(tradingSide, fee, priceFirst);
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    priceFirst.Add(price * (1 - (buySellDistance / 100)));
                    buySellDistance -= startbuySellDistance;
                }
                AddFee(tradingSide, fee, priceFirst);
            }
        }

        public void priceCalculatorSecond(string tradingSide, double profit, double fee)
        {
            if (tradingSide == "v" || tradingSide == "V")
            {
                for (int i = 0; i < 10; i++)
                {
                    priceSecond.Add(priceFirst[i] * (1 - (profit / 100)));
                    profit += 0.25;
                }
                AddFee(tradingSide, fee, priceSecond);
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    priceSecond.Add(priceFirst[i] * (1 + (profit / 100)));
                    profit += 0.25;
                }
                AddFee(tradingSide, fee, priceSecond);
            }
        }
        //Es wird eine Liste mit den Stoploss Preisen erzeugt
        public void priceCalculatorStopLoss(string tradingSide, double stoplossDistance, double fee)
        {
            if (tradingSide == "v" || tradingSide == "V")
            {
                for (int i = 0; i < 10; i++)
                {
                    priceStopLoss.Add(priceFirst[i] * (1 + (stoplossDistance / 100)));
                }

                AddFee(tradingSide, fee, priceStopLoss);
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    priceStopLoss.Add(priceFirst[i] * (1 - (stoplossDistance / 100)));
                }


                AddFee(tradingSide, fee, priceStopLoss);
            }
        }
        //Hier werden die Handelsgebühren "Fees" zum Preis dazugerechnet
        public void AddFee(string tradingSide, double fee, List<double> list)
        {
            if (tradingSide == "V" || tradingSide == "v")
            {
                for (int i = 0; i < 10; i++)
                {
                    list[i] *= (1+fee/100);
                }
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    list[i] *= (1-fee/100);
                }
            }
        }
        //Methoden zur Erzeugung der Preislisten, für Buy- und Sellside und Stoploss
        public void calculatePriceList(double price, string tradingSide, double buySellDistance, double profit, double stoplossDistance, double fee)
        {
            priceCalculatorFirst(price, tradingSide, buySellDistance, fee);
            priceCalculatorSecond(tradingSide, profit, fee);
            priceCalculatorStopLoss(tradingSide, stoplossDistance, fee);
        }

        //Zugriff auf die jeweilige Liste
        public List<double> ListFirst
        {
            get { return priceFirst; }
        }

        public List<double> ListSecond
        {
            get { return priceSecond; }
        }

        public List<double> ListStopLoss
        {
            get { return priceStopLoss; }
        }
    }
}
