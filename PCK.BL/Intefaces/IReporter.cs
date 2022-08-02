using PCK.Utility;

namespace PCK.BL.Intefaces
{
    public interface IReporter
    {
        void Discounted(Price amount);
        void NetPrice(Price amount);
    }
}