using System.ComponentModel.DataAnnotations.Schema;

namespace TddEcommerce.Domain
{
    public class Product
    {


        private Product()
        {
            
        }

        public Product(string name, Money price)
        {
            Name = name;
            Price = price;
        }

        public Money Price
        {
            get { return new Money(Cents/100, Cents%100); }
            private set { this.Cents = value.ToCents(); }
        }

        public string Name { get; private set; }

        public long ID { get; private set; }

        public int Cents
        {
            get;
            set;
        }
    }
}