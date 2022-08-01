using PCK.Utility;

namespace PCK.BL
{
    public class ProductPriceCalculater
    {
        public Product Product { get; set; }
        public static double FlatRateTax { get; set; } = 0.2;
        public ProductPriceCalculater(Product product)
        {
            this.Product = product;
        }
        public Price PriceAfterTax()
        {
            var basePrice = Product.BasePrice;
            var tax = new Price(FlatRateTax * basePrice.Value);
            var priceAfterTax = basePrice + tax;
            return priceAfterTax;
        }
        public Price PriceBeforeTax()
        {
            return Product.BasePrice;
        }
    }
}
