using System.ComponentModel.DataAnnotations;

namespace FeliveryAPI.Models
{
    public class Customer

    { 
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        //public List<Order>? customerOrders { get; set; }

    }
}
