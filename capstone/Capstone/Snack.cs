using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Snack
    {
        public string Slot { get; set; }
        public string SnackName { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; } = 5;
        public int TotalSold { get; set; } = 0;

        public Snack (string slot, string snackName, decimal price, string type)
        {
            this.Slot = slot;
            this.SnackName = snackName;
            this.Price = price;
            this.Type = type;
        }
        public virtual void DispenseMessage()
        {

        }
    }
}
