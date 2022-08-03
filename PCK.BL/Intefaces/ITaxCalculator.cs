using PCK.Utility;
using PCK.BL.Entities;
namespace PCK.BL.Intefaces
{
    public interface IFlatTaxCalculator
    {
        Price CalculateFlatTax(Product product);
    }
}