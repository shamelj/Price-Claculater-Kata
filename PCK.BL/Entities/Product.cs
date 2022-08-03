using PCK.Utility;

namespace PCK.BL.Entities
{
    public class Product
    {
        public string Name { get; set; }
        public uint UPC { get; set; }
        public Price BasePrice { get; set; }
        public Product(string name, uint UPC, Price basePrice)
        {
            Name = name;
            this.UPC = UPC;
            BasePrice = basePrice;
        }
        public Product(Product inputProduct)
        {
            this.Name = new(inputProduct.Name);
            this.UPC = inputProduct.UPC;
            this.BasePrice = new(inputProduct.BasePrice);

        }
    }
}
