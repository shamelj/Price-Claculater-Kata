using PCK.BL.Intefaces;
using PCK.Utility;

namespace PCK.BL.Entities
{
    public class TaxCalculator : ITaxCalculator
    {
        public static double FlatRateTax { get; set; } = 0.2;

        public Price CalculateTax(Product product)
        {
            var flatTax = CalculateFlatTax(product);
            return flatTax;
        }

        public Price CalculateFlatTax(Product product)
        {
            var flatTax = new Price(FlatRateTax * product.BasePrice.Value);
            return flatTax;
        }
    }
}
