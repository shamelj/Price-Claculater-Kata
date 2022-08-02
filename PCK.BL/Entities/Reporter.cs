using PCK.BL.Intefaces;
using PCK.Utility;

namespace PCK.BL.Entities
{
    public class Reporter : IReporter
    {
        public void Discounted(Price amount)
        {
            if (amount.Value != 0.00)
                Console.WriteLine($"Discount {amount.Value}");
        }
        public void NetPrice(Price amount)
        {
            Console.WriteLine($"Price {amount.Value}");
        }
    }
}
