using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeliveryAPI.Models
{
    public class OrderDetails
    {
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Order? Order { get; set; }
        [ForeignKey("MenuItem")]
        public int MenuItemID { get; set; }
        public virtual MenuItem? MenuItem { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}