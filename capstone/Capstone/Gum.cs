using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Gum : Snack
    {
        public Gum(string slot, string snackName, decimal price, string type) : base(slot, snackName, price, type)
        {

        }
        public override void DispenseMessage()
        {
            Console.WriteLine("Chew Chew, Yum!");
        }
    }
}
