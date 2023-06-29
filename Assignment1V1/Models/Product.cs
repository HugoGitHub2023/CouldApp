using Assignment1V1.Areas.Identity.Data;
using Assignment1V1.Models;
using System.ComponentModel.DataAnnotations;

namespace Assignment1V1.Models
{
    public class Product
    {


        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public int Price { get; set; }

        public List<ApplicationUser>? Users { get; set; }
    }
}

