namespace PCK.BL.Intefaces
{
    public interface IGenericRepository<T>
    {

        IEnumerable<T> ReadAll();
        void Save(T item);


    }
}
