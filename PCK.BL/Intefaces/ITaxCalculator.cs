using PCK.BL.Entities;
using PCK.Utility;
namespace PCK.BL.Intefaces
{
    public interface IFlatTaxCalculator
    {
        Price CalculateFlatTax(Product product);
    }
}