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
                        if (snackTemp[3] == "Chip")
                        {
                            Chips snack = new Chips(snackTemp[0], snackTemp[1], pr, snackTemp[3]);
                            VendingInventory.Add(snackTemp[0], snack);
                        }
                        if (snackTemp[3] == "Candy")
                        {
                            Candy snack = new Candy(snackTemp[0], snackTemp[1], pr, snackTemp[3]);
                            VendingInventory.Add(snackTemp[0], snack);
                        }
                        if (snackTemp[3] == "Drink")
                        {
                            Drinks snack = new Drinks(snackTemp[0], snackTemp[1], pr, snackTemp[3]);
                            VendingInventory.Add(snackTemp[0], snack);
                        }
                        if (snackTemp[3] == "Gum")
                        {
                            Gum snack = new Gum(snackTemp[0], snackTemp[1], pr, snackTemp[3]);
                            VendingInventory.Add(snackTemp[0], snack);
                        }
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
            decimal totalSales = 0;

            foreach(Snack sn in VendingInventory.Values)
            {
                Console.WriteLine(sn.SnackName + "|" + sn.TotalSold);
                totalSales += (sn.TotalSold * sn.Price);  
            }
            Console.WriteLine($"**TOTAL SALES** {totalSales:C2}");
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
        public decimal Dispense(string input, decimal money)
        {
            VendingInventory[input].Quantity--;
            VendingInventory[input].TotalSold++;
            money = money - VendingInventory[input].Price;
            VendingInventory[input].DispenseMessage();
            return money;
        }
        public void GetChange(decimal customerMoney)
        {
            decimal expanded = (customerMoney * 100);
            decimal quarters = Math.Floor(expanded / 25);
            decimal remaining = expanded % 25;
            decimal dimes = Math.Floor(remaining / 10);
            remaining = remaining % 10;
            decimal nickels = Math.Floor(remaining / 5);
            Console.WriteLine($"CHANGE RETURNED \nQuarters: {quarters}\nDimes: {dimes}\nNickels: {nickels}");
        }
    }
}
