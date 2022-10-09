using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace Capstone
{
    public class Program

    {       
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\Student\git\c-sharp-minicapstonemodule1-team4";
            string fileName = @"\Log.txt";
            string fullPath = filePath + fileName;

            Inventory inv = new Inventory();
            inv.Populate();

            bool isRunning = true;
            bool transaction = false;
            string log = "";


            while(isRunning)
            {
                decimal userMoney = 0;
                Console.WriteLine("(1) Display Vending Machine Items");
                Console.WriteLine("(2) Purchase");
                Console.WriteLine("(3) Exit");

                string userInput = Console.ReadLine();

                if (userInput.Equals("1"))
                {
                    inv.ListItems();
                }
                else if(userInput.Equals("2"))
                {
                    transaction = true;
                    
                    while(transaction == true)
                    {
                        Console.WriteLine($"Current Money Provided {userMoney:C2}");
                        Console.WriteLine(" ");

                        Console.WriteLine("(1) Feed Money");
                        Console.WriteLine("(2) Select Product");
                        Console.WriteLine("(3) Finish Transaction");

                        userInput = Console.ReadLine();

                        if (userInput.Equals("1"))
                        {
                            decimal temp = userMoney;
                            userMoney = inv.FeedMoney(userMoney);
                            File.AppendAllText(fullPath,$"\n{DateTime.Today.Month}/{DateTime.Today.Day}/{DateTime.Today.Year}  {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second} FEED MONEY: {temp:C2} {userMoney:C2}");
                        }
                        else if (userInput.Equals("2"))
                        {
                            Console.Write("Please Enter Slot:");
                            string userSelectionInput = Console.ReadLine().ToUpper();
                            if (inv.VendingInventory.ContainsKey(userSelectionInput))
                            {
                                if (inv.VendingInventory[userSelectionInput].Quantity>0)
                                {
                                    if(inv.VendingInventory[userSelectionInput].Price <= userMoney)
                                    {
                                        userMoney = inv.Dispense(userSelectionInput, userMoney);
                                        File.AppendAllText(fullPath, $"\n{DateTime.Today.Month}/{DateTime.Today.Day}/{DateTime.Today.Year}  {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second} {userSelectionInput} {inv.VendingInventory[userSelectionInput].SnackName} {userMoney:C2}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Insufficient Funds");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Sold Out");
                                }

                            }
                            else
                            {
                                Console.WriteLine("Invalid Slot");
                            }
                        }
                        else if (userInput.Equals("3"))
                        {
                            File.AppendAllText(fullPath, $"\n{DateTime.Today.Month}/{DateTime.Today.Day}/{DateTime.Today.Year}  {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second} GIVE CHANGE {userMoney:C2} $0.00");
                            inv.GetChange(userMoney);
                            transaction = false;
                        }
                        else
                        {
                            Console.WriteLine("Please select a number 1 through 3.");
                        }
                    }

                   
                }
                else if(userInput.Equals("3"))
                {
                    isRunning = false;
                    Console.WriteLine("Thank you for your purchase!");
                }
                else if(userInput.Equals("4"))
                {
                    inv.DisplaySalesReport();
                }
                else
                {
                    Console.WriteLine("Invalid input please enter a number 1-3");
                }
            }
        }

    }

}
