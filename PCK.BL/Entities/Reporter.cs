using PCK.BL.Intefaces;
using PCK.Utility;

namespace PCK.BL.Entities
{
    public class Reporter : IReporter
    {
        public void Discounted(Price amount)
        {
            if (amount.Value != 0.00)
                Console.WriteLine($"Discount {amount}");
        }
        public void NetPrice(Price amount)
        {
            Console.WriteLine($"Price {amount}");
        }

        public void Summary(Price basePrice, Price flatTax, Price totalDiscount, IEnumerable<KeyValuePair<string, Price>> allExpenses, Price netPrice)
        {
            Console.WriteLine($"Cost = {basePrice}");
            Console.WriteLine($"Tax = {flatTax}");
            Console.WriteLine($"Discounts = {totalDiscount}");
            foreach (var expense in allExpenses)
            {
                Console.WriteLine($"{expense.Key} = {expense.Value}");
            }
            Console.WriteLine($"TOTAL = {netPrice}");


        }
    }
}
