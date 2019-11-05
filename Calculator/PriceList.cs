using System.Collections.Generic;
using System;

namespace CoinRechner.Calculator
{
    class PriceList
    {
        //Initalisierung der Listen für die Preise
        List<double> priceFirst = new List<double>();
        List<double> priceSecond = new List<double>();
        //Initalisierung der StopLoss Preise
        List<double> priceStopLoss = new List<double>();

        public void priceCalculatorFirst(double price, string tradingSide, double buySellDistance, double fee)
        {
            if (tradingSide == "V" || tradingSide == "v")
            {
                for (int i = 0; i < 10; i++)
                {
                    priceFirst.Add(price * (1 + (buySellDistance / 100)));
                    buySellDistance += buySellDistance;
                }

                for (int i = 0; i < 10; i++)
                {
                    priceFirst[i] += fee;
                }
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    priceFirst.Add(price * (1 - (buySellDistance / 100)));
                    buySellDistance -= buySellDistance;
                }
                for (int i = 0; i < 10; i++)
                {
                    priceFirst[i] -= fee;
                }
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

                for (int i = 0; i < 10; i++)
                {
                    priceSecond[i] += fee;
                }
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    priceSecond.Add(priceFirst[i] * (1 + (profit / 100)));
                    profit += 0.25;
                }
                for (int i = 0; i < 10; i++)
                {
                    priceSecond[i] -= fee;
                }
            }
        }

        public void priceCalculatorStopLoss(string tradingSide, double stoplossDistance, double fee)
        {
            if (tradingSide == "v" || tradingSide == "V")
            {
                for (int i = 0; i < 10; i++)
                {
                    priceStopLoss.Add(priceFirst[i] * (1 + (stoplossDistance / 100)));
                }

                for (int i = 0; i < 10; i++)
                {
                    priceStopLoss[i] += fee;
                }
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    priceStopLoss.Add(priceFirst[i] * (1 - (stoplossDistance / 100)));
                }


                for (int i = 0; i < 10; i++)
                {
                    priceStopLoss[i] -= fee;
                }
            }
        }

        public void AddFee (double price, double fee)
        {
            
        }

        public void calculatePriceList(double price, string tradingSide, double buySellDistance, double profit, double stoplossDistance, double fee)
        {
            priceCalculatorFirst(price, tradingSide, buySellDistance, fee);
            priceCalculatorSecond(tradingSide, profit, fee);
            priceCalculatorStopLoss(tradingSide, stoplossDistance, fee);
        }

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
