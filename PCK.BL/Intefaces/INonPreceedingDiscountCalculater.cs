using PCK.BL.Entities;
using PCK.Utility;

namespace PCK.BL.Intefaces
{
    public interface INonPreceedingDiscountCalculater
    {
        public Price CalculateNonPreceedingDiscount(Product product);
    }
}