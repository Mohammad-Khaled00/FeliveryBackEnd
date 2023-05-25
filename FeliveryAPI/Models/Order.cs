using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeliveryAPI.Models
{
    public class Order
    {
        public Order()
        {
            List<MenuItem>? ListOfMenuItems = new List<MenuItem>();
            List<Offer>? ListOfOffers = new List<Offer>();
        }

        [Key]
        public int Id { get; set; }      
        [Required]
        public int totalPrice { get; set; } //derived attribute for each item : totalPrice+= item.price
        public string Address { get; set; } 
        [ForeignKey(nameof(Restaurant))]
        public int RestaurantID { get; set; }
        public virtual Restaurant? Restaurant { get; set; }
         [NotMapped]
        public virtual List<MenuItem?> cartItems { get; set; } //create a fn restricted to the restaurant
/*        [NotMapped]
        public virtual List<Offer?> Offers { get; set; }*/
        [ForeignKey(nameof(Customer))]
        public int CustomerID { get; set; }
        public virtual Customer? Customer { get; set; }


    }
}
