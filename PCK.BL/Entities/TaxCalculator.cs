using PCK.BL.Intefaces;
using PCK.Utility;

namespace PCK.BL.Entities
{
    public class TaxCalculator : IFlatTaxCalculator
    {
        private static double flatRateTax = 0.2;

        public static double FlatRateTax
        {
            get => flatRateTax;
            set
            {
                if (flatRateTax < 0.0) throw new ArgumentException("Please enter a positive percentage.");
                flatRateTax = value;
            }
        }

        public Price CalculateFlatTax(Product product)
        {
            var flatTax = new Price(FlatRateTax * product.BasePrice.Value);
            return flatTax;
        }
    }
}
