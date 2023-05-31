using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeliveryAPI.Models
{
/*    public enum Status
    {
        Pending,
        Done
    }*/
    public class Order
    {
        [Key]
        public int Id { get; set; }      
        [Required]
        public int TotalPrice { get; set; }
        [Required]
        public string Address { get; set; }
        //public Status? Status { get; set; }
        public bool? Status { get; set; }
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
