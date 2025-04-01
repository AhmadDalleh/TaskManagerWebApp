namespace TaskManagerWebApp.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public DateTime CreatedAt{ get; set; }
        public List<Task>? Tasks{ get; set; }
        public List<Category>? Categories { get; set; }

    }
}
