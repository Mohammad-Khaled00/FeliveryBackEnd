using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeliveryAPI.Models
{
    public class Category
    {
        public Category()
        {
            Restaurant? Restaurant = new Restaurant();
        }
        [Key]
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey(nameof(Restaurant))]
        public int RestaurantID { get; set; }
        public virtual Restaurant? Restaurant { get; set; }
    }
}
