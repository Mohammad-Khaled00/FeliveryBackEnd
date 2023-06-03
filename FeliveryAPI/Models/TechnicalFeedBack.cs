using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeliveryAPI.Models
{
    public class TechnicalFeedBack
    {
        [Key]
        public int Id { get; set; }
        public string Comment { get; set; }
        [ForeignKey(nameof(Restaurant))]
        public int RestaurantID { get; set; }
        public virtual Restaurant? Restaurant { get; set; }
        [ForeignKey(nameof(Customer))]
        public int CustomerID { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
