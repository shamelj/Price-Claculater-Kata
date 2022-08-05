using PCK.BL.Intefaces;
using PCK.Utility;

namespace PCK.BL.Entities
{
    public class ExpensesCalculator : IExpensesCalculator
    {
        private IAbsoluteExpensesRepository AbsoluteExpensesRepository { get; }
        private IRelativeExpensesRepository RelativeExpensesRepository { get; }

        public ExpensesCalculator(IAbsoluteExpensesRepository absoluteExpensesRepository,
                                  IRelativeExpensesRepository relativeExpensesRepository)
        {
            AbsoluteExpensesRepository = absoluteExpensesRepository;
            RelativeExpensesRepository = relativeExpensesRepository;
        }

        public Price CalculateAbsoluteExpenses()
        {
            var absoluteExpenses = AbsoluteExpensesRepository.ReadAll();
            var sum = absoluteExpenses.Sum((expense) => expense.Amount.Value);
            return new(sum);
        }

        public Price CalculateRelativeExpenses(Product product)
        {
            var allRelativeExpenses = RelativeExpensesRepository.ReadAll();
            var ratesSum = allRelativeExpenses.Sum((expense) => expense.Rate);
            var totalRelativeExpenses = ratesSum * product.BasePrice.Value;
            return new(totalRelativeExpenses);
        }
        public IEnumerable<KeyValuePair<string,Price>> AllExpenses(Product product){
            var absoluteExpenses = AbsoluteExpensesRepository
                .ReadAll()
                .Select((expense) => KeyValuePair.Create(expense.Description, expense.Amount));
            var RelativeExpenses = RelativeExpensesRepository
                .ReadAll()
                .Select((expense) => KeyValuePair.Create(expense.Description, new Price(expense.Rate * product.BasePrice.Value)));

            var result = RelativeExpenses.Concat(absoluteExpenses);
            return result;
        }
    }
}
