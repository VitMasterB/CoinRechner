using System.Collections.Generic;

namespace CoinRechner.Calculator
{
    public class Amount
    {
        double startQuantity = 0.12;
        double availableQuantity = 5.7;
        double increaseAmount = 0.01;
        List<double> quantityList = new List<double>();
        List<double> profitlist = new List<double>();
        List<double> stopLosslist = new List<double>();

        public void calculateProfitX(double price, string tradingSide, double buySellDistance, double profit, double stoplossDistance, double fee, double startQuantity, double availableQuantity, double increaseAmount)
        {
            double currentProfit = 0.0;
            int number = 0;
            int numberStartStopLoss=-1;
            double restQuantity=availableQuantity-startQuantity;
            quantityList.Add(startQuantity);

            var priceLists = new PriceList(); 
            priceLists.calculatePriceList( price, tradingSide, buySellDistance, profit, stoplossDistance, fee);

            var minProfit = ((priceLists.ListFirst[0]*startQuantity)*(1-fee)-(priceLists.ListSecond[0]*startQuantity)*(1-fee));

            while (availableQuantity > restQuantity)
            {
                while (currentProfit < minProfit)
                {
                    startQuantity+=increaseAmount;
                    number+=1;
                    numberStartStopLoss+=1;
                    currentProfit = (priceLists.ListFirst[number]*startQuantity-priceLists.ListSecond[number]*startQuantity)-(quantityList[numberStartStopLoss]*stopLosslist[numberStartStopLoss]);

                }
            }

        }
    }
}