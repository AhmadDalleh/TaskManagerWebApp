﻿using Microsoft.EntityFrameworkCore;
using TaskManagerWebApp.Models;

namespace TaskManagerWebApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        
    }
}
