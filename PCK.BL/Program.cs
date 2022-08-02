using PCK.BL.Entities;
using PCK.BL.Intefaces;
using PCK.Utility;
using PCK.BL;
using PCK.BL.Repositories;

var book = new Product("The Little Prince", 12345, new(20.25));

var discountsRepository = new CacheDiscountsRepository();
var taxCalculator = new TaxCalculator();
var discountCalculator = new DiscountCalculater(discountsRepository);
DiscountCalculater.RelativeDiscountRate = 0.15;
discountsRepository.Save(new(0.07, 12345));
var reporter = new Reporter();
var netPriceCalculator = new NetPriceCalculater(discountCalculator,taxCalculator,reporter);
netPriceCalculator.CalculateNetPrice(book);
