namespace PCK.BL.Entities
{
    public enum DiscountType
    {
        Preceeding,
        NonPreceeding
    }
    public class Discount
    {
        private double _rate;

        public double Rate
        {
            get => _rate;
            set
            {
                if (value < 0 || value > 1)
                    throw new ArgumentOutOfRangeException("Rate must be in range [0,1]");
                _rate = value;
            }
        }
        public DiscountType Type { get; set; }
        public uint UPC { get; set; }
        public Discount(double rate, uint upc, DiscountType type )
        {
            Rate = rate;
            UPC = upc;
            Type = type;
        }
    }
}
