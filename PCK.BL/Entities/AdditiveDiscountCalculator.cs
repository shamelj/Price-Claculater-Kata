using PCK.BL.Intefaces;
using PCK.Utility;

namespace PCK.BL.Entities
{
    public class AdditiveDiscountCalculator : DiscountCalculator
    {
        public AdditiveDiscountCalculator(IDiscountsRepository discountsRepository) : base(discountsRepository)
        {
        }

        public override Price CalculateNonPreceedingDiscount(Product product)
        {
            var discounts = DiscountsRepository.ReadAll(product.UPC);
            var nonPreceedingDiscounts = discounts.Where((discount) => discount.Type == DiscountType.NonPreceeding);
            var totalDiscountsRate = nonPreceedingDiscounts.Sum((discount) => discount.Rate);
            var totalNonPreceedingDiscountAmount = new Price(totalDiscountsRate * product.BasePrice.Value);
            var relativeDiscount = CalculateRelativeDiscount(product.BasePrice);
            return totalNonPreceedingDiscountAmount + relativeDiscount;
        }
        public override Price CalculatePreceedingDiscount(Product product)
        {
            var allDiscounts = DiscountsRepository.ReadAll(product.UPC);
            var preceedingDiscounts = allDiscounts.Where((discount) => discount.Type == DiscountType.Preceeding);
            var totalDiscountsRate = preceedingDiscounts.Sum((discount) => discount.Rate);
            var totalPreceedingDiscountAmount = new Price(totalDiscountsRate * product.BasePrice.Value);
            return totalPreceedingDiscountAmount;
        }
        public override Price CalculateRelativeDiscount(Price price)
        {
            var relativeDiscount = new Price(price.Value * RelativeDiscountRate.Rate);
            return relativeDiscount;
        }
    }
}
