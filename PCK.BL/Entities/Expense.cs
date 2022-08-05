namespace PCK.BL.Entities
{
    public abstract class Expense
    {
        public string Description { get; set; }
        protected Expense(string description)
        {
            this.Description = description;
        }
    }

}
