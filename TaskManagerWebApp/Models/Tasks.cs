using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerWebApp.Models
{
    public class Tasks
    {
        [Key]
        public int TaskId{ get; set; }

        [Required]
        [MaxLength(255)]
        public string? Title{ get; set; }

        [MaxLength(255)]
        public string? Description { get; set; }

        [Required]
        [DisplayName("Due Date")]
        public DateTime DueDate { get; set; }

        public List<String>? Status { get; set; }

        [DisplayName("Created At")]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public int? UserId { get; set; }
        public User? User{ get; set; }

        [Required]
        public int CategoryID { get; set; }
        public Category? Category { get; set; }

    }
}
