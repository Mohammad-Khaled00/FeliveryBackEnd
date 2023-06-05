using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeliveryAPI.Models
{
    public class Restaurant
    {
        public enum StoreType
        {
            Restaurant
        }
        public Restaurant()
        {
            MenuItems = new List<MenuItem>();
            Orders = new List<Order>();
            Categories = new List<Category>();
        }

        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(IdentityUser))]
        public string? SecurityID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Required]
        public int MobileNumber { get; set; }
        public string Description { get; set; }
        public string? StoreImg { get; set; }
        public StoreType Type { get; set; }
        public string? Status { get; set; }
        public int TotalRatings { get; set; }
        public int NumOfRaters { get; set; }
        public virtual IdentityUser? IdentityUser { get; set; }
        public virtual ICollection<MenuItem?> MenuItems { get; set; }
        public virtual ICollection<Order?> Orders { get; set; }
        public virtual ICollection<Category?> Categories { get; set; }
    }
}
