using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FeliveryAPI.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        //public string? description { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryID { get; set; }
        public virtual Category? Category { get; set; }

        [ForeignKey(nameof(Restaurant))]
        public int RestaurantID { get; set; }
        public virtual Restaurant? Restaurant { get; set; }
        public string MenuItemImg { get; set; }
        [NotMapped]
        public virtual List<Order?> Orders { get; set; }

    }
}
