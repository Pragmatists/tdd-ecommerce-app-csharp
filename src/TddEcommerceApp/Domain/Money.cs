namespace TddEcommerceApp.Domain
{
    public class Money
    {
        private int dollars;
        private int cents;

        public Money(int dollars, int cents)
        {
            this.cents = cents;
            this.dollars = dollars;
        }

        public int ToCents()
        {
            return dollars*100 + cents;
        }

        public Money Add(Money other)
        {
            var newValue = ToCents() + other.ToCents();
            return new Money(newValue / 100, newValue % 100);
        }

        protected bool Equals(Money other)
        {
            return dollars == other.dollars && cents == other.cents;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Money) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (dollars*397) ^ cents;
            }
        }
    }
}