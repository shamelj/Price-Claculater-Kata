using PCK.BL.Entities;

namespace PCK.BL.Intefaces
{
    public interface IDiscountsRepository : IGenericRepository<Discount>
    {
        IEnumerable<Discount> ReadAll(uint upc);
    }
}