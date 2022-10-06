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
            foreach(Snack sn in inv.VendingInventory.Values)
            {
                Console.WriteLine(sn.SnackName);
            }
        }
    }
}
