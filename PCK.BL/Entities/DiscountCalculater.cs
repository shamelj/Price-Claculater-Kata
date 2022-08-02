using PCK.BL.Intefaces;
using PCK.Utility;

namespace PCK.BL.Entities
{
    public class DiscountCalculater : IDiscountCalculater
    {
        public static double RelativeDiscountRate { get; set; } = 0;
        private IDiscountsRepository DiscountsRepository { get; }
        public DiscountCalculater(IDiscountsRepository discountsRepository)
        {
            DiscountsRepository = discountsRepository;
        }
        public Price CalculateDiscount(Product product)
        {
            var relativeDiscount = CalculateRelativeDiscount(product);
            var specialDiscount = CalculateSpecialDiscount(product);
            var totalDiscount = relativeDiscount + specialDiscount;
            return totalDiscount;
        }
        public Price CalculateSpecialDiscount(Product product)
        {
            var discounts = DiscountsRepository.ReadAll(product.UPC);
            var totalDiscountsRate = discounts.Sum((discount) => discount.Rate);
            var specialDiscount = new Price(totalDiscountsRate * product.BasePrice.Value);
            return specialDiscount;
        }
        public Price CalculateRelativeDiscount(Product product)
        {
            var relativeDiscount = new Price(product.BasePrice.Value * RelativeDiscountRate);
            return relativeDiscount;
        }
    }
}
