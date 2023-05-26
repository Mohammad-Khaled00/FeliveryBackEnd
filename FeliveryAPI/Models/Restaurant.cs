using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
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
            Offers = new List<Offer>();
            Orders = new List<Order>();
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
        public string StoreImg { get; set; }
        public StoreType Type { get; set; }
        public virtual IdentityUser? IdentityUser { get; set; }
        public virtual ICollection<MenuItem?> MenuItems { get; set; }
        public virtual ICollection<Order?> Orders { get; set; }
        public virtual ICollection<Offer?> Offers { get; set; }


        /// <summary>
        /// To Do Feature
        /// public int Rate { get; set; } 
        /// (1 -> 5)
        /// </summary>
    }
}
