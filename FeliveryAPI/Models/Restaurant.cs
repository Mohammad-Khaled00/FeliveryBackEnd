using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeliveryAPI.Models
{
    public class Restaurant
    {
       public enum status
        {
            Pending,Approved
        }
        public enum StoreType
        {
            Restaurant
        }
        public Restaurant()
        {
            MenuItems = new List<MenuItem>();
        }


        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Required]
        public int MobileNumber { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Description { get; set; }   
        public string StoreImg { get; set; }
        public status Status { get; set; }
        public StoreType Type { get; set; }
        public virtual ICollection<MenuItem?> MenuItems { get; set; }
        public virtual ICollection<Order?> Orders { get; set; }
        public virtual ICollection<Offer?> Offers { get; set; }

        /// <summary>
        /// To Do Feature
        /// public StoreType Type { get; set; } 
        /// Restaurant- Grocery - Pastery
        /// </summary>

        /// <summary>
        /// To Do Feature
        /// public int Rate { get; set; } 
        /// (1 -> 5)
        /// </summary>
    }
}
