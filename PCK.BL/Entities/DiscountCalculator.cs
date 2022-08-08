using PCK.BL.Intefaces;
using PCK.Utility;

namespace PCK.BL.Entities
{
    public abstract class DiscountCalculator : IDiscountCalculator
    {
        public static Discount RelativeDiscountRate { get; set; } = new Discount(0, 0, DiscountType.NonPreceeding);
        protected IDiscountsRepository DiscountsRepository { get; init; }
        public DiscountCalculator(IDiscountsRepository discountsRepository)
        {
            DiscountsRepository = discountsRepository;
        }
        public abstract Price CalculateNonPreceedingDiscount(Product product);
        public abstract Price CalculatePreceedingDiscount(Product product);
        public abstract Price CalculateRelativeDiscount(Price product);
    }
}
