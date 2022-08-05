using PCK.BL.Entities;
using PCK.Utility;

namespace PCK.BL.Intefaces
{
    public interface IExpensesCalculator
    {
        Price CalculateAbsoluteExpenses();
        Price CalculateRelativeExpenses(Product product);
        IEnumerable<KeyValuePair<string, Price>> AllExpensesData(Product product);

    }
}
