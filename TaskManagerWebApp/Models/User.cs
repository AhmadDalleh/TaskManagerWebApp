using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace TaskManagerWebApp.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [DisplayName("User Name")]
        public string? UserName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(500,ErrorMessage ="Bad email format")]
        public string? Email { get; set; }
        [Required]
        [PasswordPropertyText]
        [DisplayName("Password")]
        public string? PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<Task>? Tasks{ get; set; }
        public List<Category>? Categories { get; set; }

    }
}
