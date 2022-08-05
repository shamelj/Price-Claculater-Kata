using PCK.BL.Intefaces;

namespace PCK.BL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
    {
        protected static List<T> Discounts { get; } = new List<T>();
        public IEnumerable<T> ReadAll()
        {
            return Discounts;
        }
        public void Save(T discount)
        {
            Discounts.Add(discount);
        }

    }
}
