namespace PCK.BL.Entities
{
    public class RelativeExpense : Expense
    {
        private double rate;

        public double Rate
        {
            get => rate;
            set
            {
                if (rate < 0)
                    throw new ArgumentException("Rate must be a positive value");
                rate = value;
            }
        }
        public RelativeExpense(string description, double rate) : base(description)
        {
            Rate = rate;
        }
    }

}
