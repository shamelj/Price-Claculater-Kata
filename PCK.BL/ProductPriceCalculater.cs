using PCK.Utility;

namespace PCK.BL
{
    public class ProductPriceCalculater
    {
        public Product Product { get; set; }
        public static double FlatRateTax { get; set; } = 0.2;
        public static double RelativeDiscountRate { get; set; } = 0;
        public ProductPriceCalculater(Product product)
        {
            this.Product = product;
        }
        public Price CalculateNetPrice()
        {
            Price tax = CalculateFlatTax();
            Price discount = CalculateRelativeDiscount();
            var netPrice = Product.BasePrice + tax - discount;
            return netPrice;
        }

        public Price CalculateRelativeDiscount()
        {
            return new(Product.BasePrice.Value * RelativeDiscountRate);
        }

        public Price CalculateFlatTax()
        {
            return new Price(FlatRateTax * Product.BasePrice.Value);
        }

        public Price BasePrice()
        {
            return Product.BasePrice;
        }
    }
}
