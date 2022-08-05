using PCK.BL.Intefaces;
using PCK.Utility;

namespace PCK.BL.Entities
{
    public class NetPriceCalculator
    {
        private IDiscountCalculator DiscountCalculator { get; init; }
        private IFlatTaxCalculator TaxCalculator { get; init; }
        private IReporter Reporter { get; init; }
        private IExpensesCalculator ExpensesCalculator { get; init; }
        private ICapCalculator CapCalculator { get; init; }


        public NetPriceCalculator(IDiscountCalculator discountCalculater,
                                  IFlatTaxCalculator taxCalculator,
                                  IReporter reporter,
                                  IExpensesCalculator expensesCalculator,
                                  ICapCalculator capCalculator)
        {
            DiscountCalculator = discountCalculater;
            TaxCalculator = taxCalculator;
            Reporter = reporter;
            ExpensesCalculator = expensesCalculator;
            CapCalculator = capCalculator;
        }

        public Price CalculateNetPrice(Product product)
        {
            var cap = CapCalculator.CalculateCAP(product);
            var preceedingDiscount = DiscountCalculator.CalculatePreceedingDiscount(product);
            preceedingDiscount = preceedingDiscount > cap ? cap : preceedingDiscount;
            var basePriceWithPreceedingDiscount = product.BasePrice - preceedingDiscount;
            var productWithNewPrice = new Product(product) { BasePrice = basePriceWithPreceedingDiscount };
            var nonPreceedingDiscount = DiscountCalculator.CalculateNonPreceedingDiscount(productWithNewPrice);
            var relativeDiscount = DiscountCalculator.CalculateRelativeDiscount(productWithNewPrice);
            var totalDiscount = preceedingDiscount + nonPreceedingDiscount + relativeDiscount;
            totalDiscount = totalDiscount > cap ? cap : totalDiscount;
            var flatTax = TaxCalculator.CalculateFlatTax(productWithNewPrice);
            var absoluteExpenses = ExpensesCalculator.CalculateAbsoluteExpenses();
            var relativeExpenses = ExpensesCalculator.CalculateRelativeExpenses(productWithNewPrice);
            var totalExpenses = absoluteExpenses + relativeExpenses;
            var netPrice = product.BasePrice - totalDiscount + flatTax + totalExpenses;
            var allExpensesData = ExpensesCalculator.AllExpensesData(productWithNewPrice);
            Reporter.Summary(product.BasePrice, flatTax, totalDiscount, allExpensesData, netPrice);
            Reporter.Discounted(totalDiscount);
            return netPrice;
        }


    }
}
