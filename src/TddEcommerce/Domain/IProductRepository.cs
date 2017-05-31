namespace TddEcommerce.Domain
{
    public interface IProductRepository
    {
        void Save(Product product);
        Product findOne(long id);
    }
}