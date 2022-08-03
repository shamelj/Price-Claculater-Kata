using PCK.BL.Entities;
using PCK.Utility;

namespace PCK.BL.Intefaces
{
    public interface IRelativeDiscountCalculater
    {
        Price CalculateRelativeDiscount(Product product);
    }
}