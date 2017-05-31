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

        public void Save(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public Product findOne(long id)
        {
            return db.Products.SingleOrDefault(m=>m.ID == id);
        }
    }
}