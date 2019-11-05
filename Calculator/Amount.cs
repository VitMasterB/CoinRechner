using System.Collections.Generic;

namespace CoinRechner.Calculator
{
    public class Amount
    {
        List<double> quantityList = new List<double>();
        List<double> profitlist = new List<double>();

        public double calculateProfit(double buyPrice, double sellPrice, double quantity, string tradingside, double fees)
        {
            var profit = 0.0;

            if (tradingside == "V")
            {
                profit = (sellPrice * quantity - buyPrice * quantity) * (1 - fees);
            }
            else
            {
                profit = (buyPrice * quantity - sellPrice * quantity) * (1 - fees);
            }

            return profit;
        }

        public double calculateProfitFull(double buyPrice, double sellPrice, double quantity, string tradingside, double fees, int execution)
        {
            var priceLists = new PriceList();
            //priceLists.calculatePriceList (price, tradingside);

            var profitFull = 0.0;
            return profitFull;

        }
    }
}