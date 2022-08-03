using PCK.BL.Entities;
using PCK.Utility;

namespace PCK.BL.Intefaces
{
    public interface IPreceedingDiscountCalculater
    {
        public Price CalculatePreceedingDiscount(Product product);
    }
}