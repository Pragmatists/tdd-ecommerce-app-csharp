using System.Collections.Generic;
using System.Linq;
using TddEcommerce.Domain;

namespace TddEcommerce.Infrastructure
{
    public class EfProductRepository : IProductRepository
    {
        private CommerceContext db;

        public EfProductRepository(CommerceContext db)
        {
            this.db = db;
        }

        public long Save(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return product.ID;
        }

        public Product FindOne(long id)
        {
            return db.Products.SingleOrDefault(m=>m.ID == id);
        }

        public List<Product> FindAll()
        {
            return db.Products.ToList();
        }
    }
}