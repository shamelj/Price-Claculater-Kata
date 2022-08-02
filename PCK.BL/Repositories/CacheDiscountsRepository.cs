using PCK.BL.Entities;
using PCK.BL.Intefaces;

namespace PCK.BL.Repositories
{
    public class CacheDiscountsRepository : IDiscountsRepository
    {
        private static List<Discount> Discounts { get; } = new List<Discount>();
        public IEnumerable<Discount> ReadAll()
        {
            return Discounts;
        }
        public IEnumerable<Discount> ReadAll(uint upc)
        {
            return Discounts.Where((discount) => discount.UPC == upc);
        }

        public void Save(Discount discount)
        {
            Discounts.Add(discount);
        }
    }
}
