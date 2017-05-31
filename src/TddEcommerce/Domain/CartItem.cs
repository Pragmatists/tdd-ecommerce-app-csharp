using System.ComponentModel.DataAnnotations;

namespace TddEcommerce.Domain
{
    public class CartItem
    {
        [Key]
        public long ProductId { get; set; }
    }
}