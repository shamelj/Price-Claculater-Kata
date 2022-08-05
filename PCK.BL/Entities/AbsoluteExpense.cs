using PCK.Utility;

namespace PCK.BL.Entities
{
    public class AbsoluteExpense : Expense
    {

        public Price Amount { get; set; }

        public AbsoluteExpense(string description, Price amount) : base(description)
        {
            Amount = amount;
        }
    }

}
