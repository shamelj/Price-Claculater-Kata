using PCK.Utility;

namespace PCK.BL.Intefaces
{
    public interface IReporter
    {
        void Discounted(Price amount);
        void NetPrice(Price amount);
        void Summary(Price basePrice, Price flatTax, Price totalDiscount, IEnumerable<KeyValuePair<string, Price>> allExpenses, Price netPrice);
    }
}