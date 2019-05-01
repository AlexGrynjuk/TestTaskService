using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestService.BLL
{
    public class BllTest
    {
        #region const of coins
        private const int c1 = 1;
        private const int c2 = 5;
        private const int c3 = 10;
        private const int c4 = 25;
        private const int c5 = 50;
        private const int c6 = 100;
        private static readonly int[] coins = new int[6] { c1, c2, c3, c4, c5, c6 };
        #endregion
        public int[] getChange(double money, double amount)
        {
            decimal diff = (decimal)money - (decimal)amount;

            if (diff < 0)
                throw new Exception("There is not enought money!");
            if (diff == 0)
                return new int[6] { 0, 0, 0, 0, 0, 0 };

            int[] change = new int[6] { 0, 0, 0, 0, 0, 0 };

            int diffincoins = (int)Math.Truncate(diff * 100);
            
            for (int i = coins.Length - 1; i >= 0; i--)
            {
                int numberofcoins;
                numberofcoins = diffincoins / coins[i];
                if (numberofcoins != 0)
                    change[i] = numberofcoins;
                diffincoins = diffincoins % coins[i];
            }
            
            return change;
        }

        #region const full desc
        private static readonly string[] desc = new string[52]
        {
            "2S","3S","4S","5S","6S","7S","8S","9S","TS","JS","QS","KS","AS",
            "2C","3C","4C","5C","6C","7C","8C","9C","TC","JC","QC","KC","AC",
            "2H","3H","4H","5H","6H","7H","8H","9H","TH","JH","QH","KH","AH",
            "2D","3D","4D","5D","6D","7D","8D","9D","TD","JD","QD","KD","AD"
        };
        #endregion
        public int getNumberOfFullDesc(string[] cards)
        {
            int[] numberOfEachCard = new int[52];
            for (int i = 0; i < numberOfEachCard.Length; i++)
                numberOfEachCard[i] = 0;

            Array.ForEach(cards, c => numberOfEachCard[Array.IndexOf(desc, c)] += 1);

            int countOfDesc = numberOfEachCard[0];

            for (int i = 1; i < numberOfEachCard.Length; i++)
            {
                if (numberOfEachCard[i] < countOfDesc)
                    countOfDesc = numberOfEachCard[i];
            }

            return countOfDesc;
        }
    }
}