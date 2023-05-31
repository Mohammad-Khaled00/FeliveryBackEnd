using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeliveryAPI.Models
{
    public class Customer

    {
        public Customer()
        {
            Orders = new List<Order?>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string CustomerName { get; set; }
        [Required]
        public string Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required]
        public int MobileNumber { get; set; }
        [ForeignKey(nameof(IdentityUser))]
        public string? SecurityID { get; set; }
        public virtual IdentityUser? IdentityUser { get; set; }
        public virtual ICollection<Order?> Orders { get; set; }

    }
}
