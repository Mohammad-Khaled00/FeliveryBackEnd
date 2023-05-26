using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeliveryAPI.Models
{
    public class Order
    {
        public Order()
        {
            //List<Offer>? ListOfOffers = new();
            Customer = new Customer();
            Restaurant = new Restaurant();
        }

        [Key]
        public int Id { get; set; }      
        [Required]
        public int TotalPrice { get; set; } //derived attribute for each item : totalPrice+= item.price
        public string Address { get; set; } 
        [ForeignKey(nameof(Restaurant))]
        public int RestaurantID { get; set; }
        public virtual Restaurant? Restaurant { get; set; }
         [NotMapped]
        public virtual List<MenuItem?> CartItems { get; set; } //create a fn restricted to the restaurant
/*        [NotMapped]
        public virtual List<Offer?> Offers { get; set; }*/
        [ForeignKey(nameof(Customer))]
        public int CustomerID { get; set; }
        public virtual Customer? Customer { get; set; }


    }
}
