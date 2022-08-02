using PCK.BL.Intefaces;
using PCK.Utility;

namespace PCK.BL.Entities
{
    public class NetPriceCalculater
    {
        public IDiscountCalculater DiscountCalculater { get; set; }
        public ITaxCalculator TaxCalculator { get; set; }
        public IReporter Reporter { get; set; }
        public NetPriceCalculater(IDiscountCalculater discountCalculater, ITaxCalculator taxCalculator, IReporter reporter)
        {
            DiscountCalculater = discountCalculater;
            TaxCalculator = taxCalculator;
            Reporter = reporter;
        }
        public Price CalculateNetPrice(Product product)
        {
            Price tax = TaxCalculator.CalculateTax(product);
            Price discount = DiscountCalculater.CalculateDiscount(product);
            var netPrice = product.BasePrice + tax - discount;
            Reporter.NetPrice(netPrice);
            Reporter.Discounted(discount);
            return netPrice;
        }


    }
}
