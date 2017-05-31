using System.Collections.Generic;

namespace TddEcommerce.Domain
{
    public class Cart
    {
        public long Id { get; set; }
        public List<CartItem> Items { get; set; }
    }
}