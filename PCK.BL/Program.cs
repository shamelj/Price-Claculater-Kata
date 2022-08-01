using PCK.BL;
var book = new Product("The Little Prince", 12345, new(20.25));
var priceCalculater = new ProductPriceCalculater(book);
Log(book, priceCalculater);
ProductPriceCalculater.FlatRateTax = 0.21;
Log(book, priceCalculater);

static void Log(Product book, ProductPriceCalculater priceCalculater)
{
    Console.WriteLine($"Product price reported as {book.BasePrice} before tax and {priceCalculater.PriceAfterTax()} after {ProductPriceCalculater.FlatRateTax * 100}% tax.");
}