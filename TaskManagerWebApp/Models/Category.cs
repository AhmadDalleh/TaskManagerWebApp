using System.ComponentModel.DataAnnotations;

namespace TaskManagerWebApp.Models
{
    public class Category
    {
        [Key]
        public int CategoryId{ get; set; }
        [Required]
        public string? Name{ get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public  ICollection<Tasks> Tasks { get; set; }
    }
}
