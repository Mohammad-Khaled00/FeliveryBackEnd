using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FeliveryAPI.Models
{
    public class Offer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TotalPrice { get; set; }
    
        public string? Description { get; set; }
        [Required]
        public virtual ICollection<OrderDetails> Details { get; set; }
        [ForeignKey(nameof(Restaurant))]
        public int RestaurantID { get; set; }
        public virtual Restaurant? Restaurant { get; set; }
        [ForeignKey(nameof(Customer))]
        public int CustomerID { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
