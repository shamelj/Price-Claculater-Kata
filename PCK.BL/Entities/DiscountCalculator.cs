using PCK.BL.Intefaces;
using PCK.Utility;

namespace PCK.BL.Entities
{
    public class DiscountCalculator : IDiscountCalculator
    {
        public static double RelativeDiscountRate { get; set; } = 0;
        private IDiscountsRepository DiscountsRepository { get; }
        public DiscountCalculator(IDiscountsRepository discountsRepository)
        {
            DiscountsRepository = discountsRepository;
        }
        
        public Price CalculateNonPreceedingDiscount(Product product)
        {
            var discounts = DiscountsRepository.ReadAll(product.UPC);
            var nonPreceedingDiscounts = discounts.Where((discount) => discount.Type == DiscountType.NonPreceeding);
            var totalDiscountsRate = nonPreceedingDiscounts.Sum((discount) => discount.Rate);
            var totalNonPreceedingDiscountAmount = new Price(totalDiscountsRate * product.BasePrice.Value);
            return totalNonPreceedingDiscountAmount;
        }
        public Price CalculatePreceedingDiscount(Product product)
        {
            var allDiscounts = DiscountsRepository.ReadAll(product.UPC);
            var preceedingDiscounts = allDiscounts.Where((discount) => discount.Type == DiscountType.Preceeding);
            var totalDiscountsRate = preceedingDiscounts.Sum((discount) => discount.Rate);
            var totalPreceedingDiscountAmount = new Price(totalDiscountsRate * product.BasePrice.Value);
            return totalPreceedingDiscountAmount;
        }
        public Price CalculateRelativeDiscount(Product product)
        {
            var relativeDiscount = new Price(product.BasePrice.Value * RelativeDiscountRate);
            return relativeDiscount;
        }
    }
}
