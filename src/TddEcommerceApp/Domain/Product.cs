namespace TddEcommerceApp.Domain
{
    public class Product
    {
        private int cents;

        private Product()
        {
            
        }

        public Product(long id, string name, Money price)
        {
            ID = id;
            Name = name;
            Price = price;
        }

        public Money Price
        {
            get { return new Money(cents/100, cents%100); }
            private set { this.cents = value.ToCents(); }
        }

        public string Name { get; private set; }

        public long ID { get; private set; }
    }
}