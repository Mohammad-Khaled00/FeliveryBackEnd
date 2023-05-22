using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FeliveryAPI.Models
{
    public class Category
    {
        [Key]
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
