using PCK.BL.Intefaces;
using PCK.Utility;

namespace PCK.BL.Entities
{
    public class RelativeCapCalculator : ICapCalculator
    {
        private readonly double CAPRate;

        public RelativeCapCalculator(double capRate)
        {
            if (capRate < 0)
                throw new ArgumentException("CAP rate must be positive.");
            CAPRate = capRate;
        }

        public Price CalculateCAP(Product product)
        {
            return new(product.BasePrice.Value * CAPRate);
        }
    }
}
