using PCK.BL.Intefaces;
using PCK.Utility;

namespace PCK.BL.Entities
{
    public class NetPriceCalculator
    {
        private IDiscountCalculator DiscountCalculator { get; init; }
        private IFlatTaxCalculator TaxCalculator { get; init; }
        private IReporter Reporter { get; init; }
        public IExpensesCalculator ExpensesCalculator { get; private set; }

        public NetPriceCalculator(IDiscountCalculator discountCalculater,
                                  IFlatTaxCalculator taxCalculator,
                                  IReporter reporter,
                                  IExpensesCalculator expensesCalculator)
        {
            DiscountCalculator = discountCalculater;
            TaxCalculator = taxCalculator;
            Reporter = reporter;
            ExpensesCalculator = expensesCalculator;
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
            var absoluteExpenses = ExpensesCalculator.CalculateAbsoluteExpenses();
            var relativeExpenses = ExpensesCalculator.CalculateRelativeExpenses(productWithNewPrice);
            var totalExpenses = absoluteExpenses + relativeExpenses;
            var netPrice = product.BasePrice - totalDiscount + flatTax + totalExpenses;
            var allExpenses = ExpensesCalculator.AllExpenses(productWithNewPrice);
            Reporter.Summary(product.BasePrice, flatTax, totalDiscount, allExpenses, netPrice);
            Reporter.Discounted(totalDiscount);
            return netPrice;
        }


    }
}
