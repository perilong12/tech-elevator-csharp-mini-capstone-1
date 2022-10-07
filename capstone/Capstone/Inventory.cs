using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{
    public class Inventory
    {

        public Dictionary<string, Snack> VendingInventory { get; set; }
        public Inventory()
        {
            VendingInventory = new Dictionary<string, Snack>();
        }

        public void Populate()
        {

            //opens try catch for stream reader

            try
            {

                // opens stream reader
                List<string[]> chunks = new List<string[]>();
                using(StreamReader sr = new StreamReader(@"C:\Users\Student\git\c-sharp-minicapstonemodule1-team4\capstone\vendingmachine.csv"))
                {   
                    //runs while not end of stream


                    while(!sr.EndOfStream)
                    {
                        string[] snackTemp = sr.ReadLine().Split("|");
                        decimal pr = Decimal.Parse(snackTemp[2]);
                        //Console.WriteLine(snackTemp[0] + " " + snackTemp[1] + " " + pr + " " + snackTemp[3]);
                        Snack snack = new Snack(snackTemp[0], snackTemp[1], pr, snackTemp[3]);
                        VendingInventory.Add(snackTemp[0], snack);
                    }
                }
            }
            catch(IOException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
        public void ListItems()
        {
            foreach (Snack sn in VendingInventory.Values)
            {
                Console.WriteLine($"{sn.Slot} | {sn.SnackName}: ${sn.Price}");
            }


        }

        public void DisplaySalesReport()
        {
            //make the sales report
        }

        public decimal FeedMoney(decimal fedMoney)
        {
            bool success = false;
            do
            {
                Console.WriteLine("Enter your money in whole dollar amounts please!");
                string entry = Console.ReadLine();

                success = Int32.TryParse(entry, out int result);

                if (success == true)
                {
                    fedMoney += decimal.Parse(entry);
                }
            }
            while (success == false);

            return fedMoney;
        }
    }
}
