using PCK.BL.Entities;
using PCK.BL.Intefaces;

namespace PCK.BL.Repositories
{
    public class CacheDiscountsRepository : GenericRepository<Discount>, IDiscountsRepository
    {
        public IEnumerable<Discount> ReadAll(uint upc)
        {
            return Discounts.Where((discount) => discount.UPC == upc);
        }
    }
}
