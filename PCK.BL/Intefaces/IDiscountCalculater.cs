using PCK.BL.Entities;
using PCK.Utility;

namespace PCK.BL.Intefaces
{
    public interface IDiscountCalculater
    {
        Price CalculateDiscount(Product product);
    }
}