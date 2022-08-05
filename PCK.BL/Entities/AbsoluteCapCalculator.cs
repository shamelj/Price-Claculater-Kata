using PCK.BL.Intefaces;
using PCK.Utility;

namespace PCK.BL.Entities
{
    public class AbsoluteCapCalculator : ICapCalculator
    {
        private readonly Price absoluteCap;

        public AbsoluteCapCalculator(Price absoluteCap)
        {
            this.absoluteCap = absoluteCap;
        }

        public Price CalculateCAP(Product product)
        {
            return absoluteCap;
        }
    }
}
