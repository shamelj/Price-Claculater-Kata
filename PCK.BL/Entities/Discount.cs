namespace PCK.BL.Entities
{
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
        public uint UPC { get; set; }
        public Discount(double rate, uint upc)
        {
            Rate = rate;
            UPC = upc;
        }
    }
}
