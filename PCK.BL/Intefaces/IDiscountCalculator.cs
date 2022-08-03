namespace PCK.BL.Intefaces
{
    public interface IDiscountCalculator :
        INonPreceedingDiscountCalculater,
        IPreceedingDiscountCalculater,
        IRelativeDiscountCalculater
    {
    }
}