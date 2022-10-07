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
            Inventory inv = new Inventory();
            inv.Populate();

            bool isRunning = true;
            bool transaction = false;


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
                        Console.WriteLine($"Current Money Provided {userMoney}");
                        Console.WriteLine(" ");

                        Console.WriteLine("(1) Feed Money");
                        Console.WriteLine("(2) Select Product");
                        Console.WriteLine("(3) Finish Transaction");

                        userInput = Console.ReadLine();

                        if (userInput.Equals("1"))
                        {
                            
                            // feed money method
                            userMoney = inv.FeedMoney(userMoney); 
                        }
                        else if (userInput.Equals("2"))
                        {
                            // select product
                            // Dispense method
                        }
                        else if (userInput.Equals("3"))
                        {
                            //transaction = false
                        }
                        else
                        {
                            //cw enter number 1-3
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
