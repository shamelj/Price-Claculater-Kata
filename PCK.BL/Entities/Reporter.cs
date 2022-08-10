using PCK.BL.Intefaces;
using PCK.Utility;

namespace PCK.BL.Entities
{
    public enum Currencies
    {
        USD,
        GBP, JPY
    }
    public class Reporter : IReporter
    {
        private readonly string currency;
        public Reporter(Currencies currency)
        {
            switch (currency)
            {
                case Currencies.USD: this.currency = "USD"; break;
                case Currencies.GBP: this.currency = "GBP"; break;
                case Currencies.JPY: this.currency = "JPY"; break;
                default: this.currency = ""; break;
            }
        }
        public void Discounted(Price amount)
        {
            if (amount.Value != 0.00)
                Console.WriteLine($"Discount {amount} {currency}");
        }
        public void NetPrice(Price amount)
        {
            Console.WriteLine($"Price {amount} {currency}");
        }

        public void Summary(Price basePrice, Price flatTax, Price totalDiscount, IEnumerable<KeyValuePair<string, Price>> allExpenses, Price netPrice)
        {
            Console.WriteLine($"Cost = {basePrice} {currency}");
            Console.WriteLine($"Tax = {flatTax} {currency}");
            Console.WriteLine($"Discounts = {totalDiscount} {currency}");
            foreach (var expense in allExpenses)
            {
                Console.WriteLine($"{expense.Key} = {expense.Value} {currency}");
            }
            Console.WriteLine($"TOTAL = {netPrice} {currency}");


        }
    }
}
