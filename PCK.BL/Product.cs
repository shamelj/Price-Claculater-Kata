﻿using PCK.Utility;

namespace PCK.BL
{
    public class Product
    {
        public string Name { get; set; }
        public uint UPC { get; set; }
        public Price BasePrice { get; set; }
        public Product(string name, uint UPC, Price basePrice)
        {
            this.Name = name;
            this.UPC = UPC;
            this.BasePrice = basePrice;
        }
    }
}
