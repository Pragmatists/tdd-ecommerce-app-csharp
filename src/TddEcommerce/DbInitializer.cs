using TddEcommerce.Domain;

namespace TddEcommerce
{
    public static class DbInitializer
    {
        public static void Initialize(CommerceContext commerceContext)
        {
            commerceContext.Database.EnsureCreated();
            commerceContext.Products.Add(new Product("Cup", new Money(4,50)));
            commerceContext.Products.Add(new Product("Pen", new Money(1,30)));
            commerceContext.Products.Add(new Product("Plate", new Money(4,70)));
            commerceContext.SaveChanges(true);
        }
    }
}