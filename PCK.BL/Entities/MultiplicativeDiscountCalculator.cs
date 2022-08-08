using PCK.BL.Intefaces;
using PCK.Utility;

namespace PCK.BL.Entities
{
    public class MultiplicativeDiscountCalculator : DiscountCalculator
    {
        public MultiplicativeDiscountCalculator(IDiscountsRepository discountsRepository) : base(discountsRepository)
        {
        }

        public override Price CalculateNonPreceedingDiscount(Product product)
        {
            var discounts = DiscountsRepository.ReadAll(product.UPC);
            var nonPreceedingDiscounts = discounts.Where((discount) => discount.Type == DiscountType.NonPreceeding);
            var priceAfterApplyingDiscounts = nonPreceedingDiscounts
                .Aggregate(new Price(product.BasePrice),
                           (accumulatedPrice, discount) => new(accumulatedPrice.Value - accumulatedPrice.Value * discount.Rate));
            var discountAmount = product.BasePrice - priceAfterApplyingDiscounts;
            return discountAmount;
        }
        public override Price CalculatePreceedingDiscount(Product product)
        {

            var allDiscounts = DiscountsRepository.ReadAll(product.UPC);
            var preceedingDiscounts = allDiscounts.Where((discount) => discount.Type == DiscountType.Preceeding);
            var priceAfterApplyingDiscounts = preceedingDiscounts
                .Aggregate(new Price(product.BasePrice),
                           (accumulatedPrice, discount) => new(accumulatedPrice.Value - accumulatedPrice.Value * discount.Rate));
            var relativeDiscount = CalculateRelativeDiscount(priceAfterApplyingDiscounts);
            var discountAmount = (product.BasePrice - priceAfterApplyingDiscounts) + relativeDiscount;
            return discountAmount;
        }
        public override Price CalculateRelativeDiscount(Price price)
        {
            var relativeDiscount = new Price(price.Value * RelativeDiscountRate.Rate);
            return relativeDiscount;
        }
    }
}
