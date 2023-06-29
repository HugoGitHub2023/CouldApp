using Assignment1V1.Areas.Identity.Data;

namespace Assignment1V1.Models
{
    public class UserProducts
    {
        public ApplicationUser? User { get; set; }

        public string? UserId { get; set; }

        public Product? Course { get; set; }

        public int? CourseId { get; set; }
    }
}
