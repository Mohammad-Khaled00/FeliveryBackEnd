using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeliveryAPI.Models
{
    public class Offer
    {
        public Offer()
        {
            MenuItem? menuItem= new MenuItem();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int offerPrice { get; set; }
        public string offerImg { get; set; }
        [NotMapped]
        public virtual List<MenuItem>? MenuitemOffers { get; set; }
    }
}
