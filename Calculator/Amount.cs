using System.Collections.Generic;
using System;
using System.Linq;

namespace CoinRechner.Calculator
{
    public class Amount
    {
        int numberStartStopLoss = -1;
        double currentProfit;
        int numberInBuySellList;
        double sumLoss;

        List<double> quantityList = new List<double>();
        List<double> profitlist = new List<double>();
        List<double> stopLosslist = new List<double>();
        List<double> lossList = new List<double>();

        public void calculateProfit(double price, string tradingSide, double buySellDistance, double profit, double stoplossDistance, double fee, double startQuantity, double availableQuantity, double increaseAmount)
        {   
            //Startmenge für jede Berechnung       
            var initialQuantity = 0.0;
            //Preislisten werden generiert
            var priceLists = new PriceList();
            priceLists.calculatePriceList(price, tradingSide, buySellDistance, profit, stoplossDistance, fee);

            //Der Minimale Gewinn, der mindestens erwirtschaftet werden muss für einen Verkaufsstart
            var minProfit = ((priceLists.ListFirst[0] * startQuantity) * (1 - fee) - (priceLists.ListSecond[0] * startQuantity) * (1 - fee));
            
            //Die Mindestmenge wird zur Mengenliste hinzugefügt
            quantityList.Add(startQuantity);
            //Den möglichen Verlust für den ersten Trade wird in die Liste hinzugefügt
            lossList.Add(addLoss(priceLists.ListFirst[0],priceLists.ListStopLoss[0],tradingSide,startQuantity));
            //----------------------------------------------------------------------------
            var restQuantity = availableQuantity - startQuantity;



            while (restQuantity > initialQuantity)
            {
                numberInBuySellList += 1;
                sumLoss=lossList.AsQueryable().Sum();

                while (currentProfit < minProfit)
                {
                
                    initialQuantity += increaseAmount;

                    currentProfit = (priceLists.ListFirst[numberInBuySellList] * startQuantity - priceLists.ListSecond[numberInBuySellList] * startQuantity)-sumLoss;

                }

                quantityList.Add(startQuantity);
                lossList.Add(addLoss(priceLists.ListFirst[numberInBuySellList],priceLists.ListStopLoss[numberInBuySellList],tradingSide,startQuantity));

                restQuantity -= initialQuantity;
                initialQuantity = startQuantity;
            }

            foreach (var quantity in quantityList)
            {
                Console.WriteLine(quantity);
            }

        }

        private double addLoss(double buySellPrice,double stopLossprice,string tradingSide, double quantity)
        {
            double loss;

            if (tradingSide == "v"|| tradingSide =="V")
            {
                loss = (buySellPrice*quantity)-(stopLossprice*quantity);
            }
            else 
            {
                loss = (stopLossprice*quantity)-(buySellPrice*quantity);
            }
            return loss;
        }
    }
}