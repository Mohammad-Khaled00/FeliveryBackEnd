using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeliveryAPI.Models
{
    public class OrderDetails
    {

        //public int OrderId { get; set; }
        //public int MenuItemId { get; set; }
        //public Order Order { get; set; }
        //public MenuItem MenuItem { get; set; }


        //[PrimaryKey(nameof(OrderId),nameof(MeniItemID))]

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Order? order { get; set; }


        [ForeignKey("MenuItem")]
        public int MenuItemID { get; set; }
        public virtual MenuItem? menuItem { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }


        #region Another solu

        //[Key, Column(Order = 1)]
        //public virtual Order? order { get; set; }
        //public int KeyId { get; set; }
        //[Key, Column(Order = 2)]
        //public virtual MenuItem? menuItem { get; set; }
        //public int Key1Id { get; set; }
        #endregion
        #region Data Annotation approach
        //public virtual Order? order { get; set; }
        //public virtual MenuItem? menuItem { get; set; }


        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Key]
        //public int orderID { get; set; }
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Key]
        //public int menuItemID { get; set; }
        #endregion
    }



}
