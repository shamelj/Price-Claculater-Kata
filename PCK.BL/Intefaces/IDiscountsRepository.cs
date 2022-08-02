using PCK.BL.Entities;

namespace PCK.BL.Intefaces
{
    public interface IDiscountsRepository
    {
        IEnumerable<Discount> ReadAll();
        IEnumerable<Discount> ReadAll(uint upc);
        void Save(Discount discount);
    }
}