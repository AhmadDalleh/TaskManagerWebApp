using Microsoft.EntityFrameworkCore;

namespace TaskManagerWebApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> optoins) : base(optoins)
        {

        }
    }
}
