using PCK.BL.Entities;
using PCK.BL.Intefaces;
using PCK.Utility;
using PCK.BL;
using PCK.BL.Repositories;

var book = new Product("The Little Prince", 12345, new(20.25));

// repos
var discountsRepository = new CacheDiscountsRepository();
var absoluteExpensesRepository = new CacheAbsoluteExpensesRepository();
var relativeExpensesRepository = new CacheRelativeExpensesRepository();


// calculaters
var taxCalculator = new TaxCalculator(); TaxCalculator.FlatRateTax = .21;
var discountCalculator = new DiscountCalculator(discountsRepository);
var expensesCalculater = new ExpensesCalculator(absoluteExpensesRepository, relativeExpensesRepository);
DiscountCalculator.RelativeDiscountRate = 0.15;
// adding data
discountsRepository.Save(new(0.07, 12345, DiscountType.NonPreceeding));
absoluteExpensesRepository.Save(new("Transport Cost", new(2.2)));
relativeExpensesRepository.Save(new("Packaging Cost", .01));

// Reporter
var reporter = new Reporter();
var netPriceCalculator = new NetPriceCalculator(discountCalculator, taxCalculator, reporter, expensesCalculater);
netPriceCalculator.CalculateNetPrice(book);
