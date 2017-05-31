using TddEcommerce.Domain;

namespace TddEcommerce
{
    public static class DbInitializer
    {
        public static void Initialize(CommerceContext commerceContext)
        {
            commerceContext.Products.Add(new Product(1,"Cup", new Money(4,50)));
            commerceContext.Products.Add(new Product(2,"Pen", new Money(1,30)));
            commerceContext.Products.Add(new Product(3,"Plate", new Money(4,70)));
        }
    }
}