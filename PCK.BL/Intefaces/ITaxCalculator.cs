using PCK.Utility;
using PCK.BL.Entities;
namespace PCK.BL.Intefaces
{
    public interface ITaxCalculator
    {
        Price CalculateTax(Product product);
    }
}