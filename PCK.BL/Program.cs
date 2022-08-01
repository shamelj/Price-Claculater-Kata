using PCK.BL;
var book = new Product("The Little Prince", 12345, new(20.25));
var priceCalculater = new ProductPriceCalculater(book);
ProductPriceCalculater.RelativeDiscountRate = 0.15;
priceCalculater.CalculateNetPrice();

static void Log(ProductPriceCalculater priceCalculater)
{
    var flatRateTax = ProductPriceCalculater.FlatRateTax * 100;
    var relativeDiscountRate = ProductPriceCalculater.RelativeDiscountRate * 100;
    var tax = priceCalculater.CalculateFlatTax();
    var discount = priceCalculater.CalculateRelativeDiscount();
    var basePrice = priceCalculater.BasePrice();
    var netPrice = priceCalculater.CalculateNetPrice();
    Console.WriteLine($"Tax={flatRateTax}%, discount={relativeDiscountRate}% Tax amount = {tax}; Discount amount = {discount} Price before = {basePrice}, price after = {netPrice}");
}