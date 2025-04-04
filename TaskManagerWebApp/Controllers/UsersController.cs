using Microsoft.AspNetCore.Mvc;
using TaskManagerWebApp.Data;
using TaskManagerWebApp.Models;

namespace TaskManagerWebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;
        public UsersController(AppDbContext context) 
        {
            _context = context;   
        }

        public IActionResult Index()
        {

            IEnumerable<User> usersList = _context.Users.ToList();
            return View(usersList);
        }
    }
}
