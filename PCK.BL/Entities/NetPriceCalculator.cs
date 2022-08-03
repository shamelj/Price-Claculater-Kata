using PCK.BL.Intefaces;
using PCK.Utility;

namespace PCK.BL.Entities
{
    public class NetPriceCalculator
    {
        private IDiscountCalculator DiscountCalculator { get; init; }
        private IFlatTaxCalculator TaxCalculator { get; init; }
        private IReporter Reporter { get; init; }
        public NetPriceCalculator(IDiscountCalculator discountCalculater, IFlatTaxCalculator taxCalculator, IReporter reporter)
        {
            DiscountCalculator = discountCalculater;
            TaxCalculator = taxCalculator;
            Reporter = reporter;
        }

        public Price CalculateNetPrice(Product product)
        {
            var preceedingDiscount = DiscountCalculator.CalculatePreceedingDiscount(product);
            var basePriceWithPreceedingDiscount = product.BasePrice - preceedingDiscount;
            var productWithNewPrice = new Product(product) { BasePrice = basePriceWithPreceedingDiscount };
            var nonPreceedingDiscount = DiscountCalculator.CalculateNonPreceedingDiscount(productWithNewPrice);
            var relativeDiscount = DiscountCalculator.CalculateRelativeDiscount(productWithNewPrice);
            var totalDiscount = preceedingDiscount + nonPreceedingDiscount + relativeDiscount;
            var flatTax = TaxCalculator.CalculateFlatTax(productWithNewPrice);
            var netPrice = product.BasePrice - totalDiscount + flatTax;
            Reporter.NetPrice(netPrice);
            Reporter.Discounted(totalDiscount);
            return netPrice;
        }


    }
}
