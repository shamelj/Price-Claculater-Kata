using PCK.Utility;

namespace PCK.BL
{
    public class Report
    {
        public static void ReprotDicount(Price amount)
        {
            if (amount.Value != 0.00)
                Console.WriteLine($"Discount {amount.Value}");
        }
        public static void ReportNetPrice(Price amount)
        {
            Console.WriteLine($"Price {amount.Value}");
        }
    }
}
