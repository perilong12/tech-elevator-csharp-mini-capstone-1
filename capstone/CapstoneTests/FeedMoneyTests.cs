using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass()]
    public class FeedMoneyTests
    {
        [TestMethod]

        public void FeedMoneyTest()
        {
            //arrange
            Capstone.Inventory inv = new Capstone.Inventory();

            string legit = "2";
            string other = "2.50";
            string word = "word";

            //act


            //assert
            inv.FeedMoney(2)
            {

            }
        }
    }
}
