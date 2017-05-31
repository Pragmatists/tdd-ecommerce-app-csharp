using System.Collections.Generic;

namespace TddEcommerce.Domain
{
    public interface IProductRepository
    {
        void Save(Product product);
        Product FindOne(long id);
        List<Product> FindAll();
    }
}