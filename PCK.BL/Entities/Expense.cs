namespace PCK.BL.Entities
{
    public abstract class Expense
    {
        public string Description { get; init; }
        protected Expense(string description)
        {
            this.Description = description;
        }
    }

}
