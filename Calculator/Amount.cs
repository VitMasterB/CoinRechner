using System.Collections.Generic;

namespace CoinRechner.Calculator
{
    public class Amount
    {
        double startQuantity;
        double availableQuantity = 5.7;
        double increaseAmount = 0.01;
        double currentProfit = 0.0;
        int numberInBuySellList = 0;
        int numberStartStopLoss = -1;

        List<double> quantityList = new List<double>();
        List<double> profitlist = new List<double>();
        List<double> stopLosslist = new List<double>();

        public void calculateProfit(double price, string tradingSide, double buySellDistance, double profit, double stoplossDistance, double fee, double startQuantity, double availableQuantity, double increaseAmount)
        {
            //Die Mindestmenge wird zur Mengenliste hinzugefügt
            quantityList.Add(startQuantity);
            //Es wird direkt die Mindestmenge von der Verfügbaren Menge abgezogen
            double restQuantity = availableQuantity - startQuantity;
            //Startmenge für jede Berechnung
            var initialQuantity = startQuantity;

            var priceLists = new PriceList();
            priceLists.calculatePriceList(price, tradingSide, buySellDistance, profit, stoplossDistance, fee);
            //Der Minimale Profit wird berechnet. Alle darauf folgenden Trades müssen mindestens diesen Gewinn machen, abzüglich der
            //Verluste aus einem vorherigen StopLoss
            var minProfit = ((priceLists.ListFirst[0] * startQuantity) * (1 - fee) - (priceLists.ListSecond[0] * startQuantity) * (1 - fee));

            while (restQuantity > 0)
            {
                numberInBuySellList += 1;
                numberStartStopLoss += 1;

                while (currentProfit < minProfit)
                {
                    initialQuantity += increaseAmount;

                    currentProfit = (priceLists.ListFirst[numberInBuySellList] * startQuantity - priceLists.ListSecond[numberInBuySellList] * startQuantity) - (quantityList[numberStartStopLoss] * stopLosslist[numberStartStopLoss]);

                }

                quantityList.Add(initialQuantity);
                restQuantity-=initialQuantity;
                initialQuantity = startQuantity;
            }
        }
    }
}