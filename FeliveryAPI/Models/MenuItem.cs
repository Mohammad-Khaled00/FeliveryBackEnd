using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FeliveryAPI.Models
{
    //[Index(nameof(Name), IsUnique = true)]
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        public string? Description { get; set; }
        public string? MenuItemImg { get; set; }
        public bool IsOffer { get; set; } = false;
        [ForeignKey(nameof(Category))]
        public int CategoryID { get; set; }
        public virtual Category? Category { get; set; }
        [ForeignKey(nameof(Restaurant))]
        public int RestaurantID { get; set; }
        public virtual Restaurant? Restaurant { get; set; }
    }
}
