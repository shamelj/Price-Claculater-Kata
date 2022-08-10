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

        public double Rate { get; init; }
        public DiscountType Type { get; init; }
        public uint UPC { get; init; }
        public Discount(double rate, uint upc, DiscountType type)
        {
            if (rate < 0 || rate > 1)
                throw new ArgumentOutOfRangeException("Rate must be in range [0,1]");
            _rate = rate;
            UPC = upc;
            Type = type;
        }
    }
}
