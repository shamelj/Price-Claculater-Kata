namespace PCK.BL.Entities
{
    public class RelativeExpense : Expense
    {

        public double Rate { get; init; }
        public RelativeExpense(string description, double rate) : base(description)
        {
            if (rate < 0)
                throw new ArgumentException("Rate must be a positive value");
            Rate = rate;
            Rate = rate;
        }
    }

}
