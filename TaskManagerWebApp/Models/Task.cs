﻿namespace TaskManagerWebApp.Models
{
    public class Task
    {
        public int TaskId{ get; set; }
        public string? Title{ get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public List<String>? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UserId { get; set; }
        public User? User{ get; set; }
        
    }
}
