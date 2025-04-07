using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query.Internal;
using TaskManagerWebApp.Data;
using TaskManagerWebApp.Models;

namespace TaskManagerWebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly PasswordHasher<User> _passwordHasher = new PasswordHasher<User>();
        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            IEnumerable<User> usersList = _context.Users.ToList();
            return View(usersList);
        }

        public IActionResult New()
        {
            return View();
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
       public IActionResult New(User user) 
        {
            if (string.IsNullOrWhiteSpace(user.PasswordHash))
            {
                ModelState.AddModelError("PasswordHash", "Password is required.");
            }
            if (ModelState.IsValid) 
            {
                if (user.PasswordHash != null)
                    user.PasswordHash = _passwordHasher.HashPassword(user, user.PasswordHash);
                _context.Users.Add(user);
                _context.SaveChanges();
                TempData["successData"] = "User has been added successfully";
                return RedirectToAction("Index");
            }
            else
                return View(user);
        }
        public void CreateSelectList(int selectId = 1)
        {
            List<Category> categories = _context.Categories.ToList();
            SelectList listItems = new SelectList(categories, "CategoryId", "Name");
            ViewBag.CategoryList = listItems;
        }
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
                return NotFound();

            var user = _context.Users.FirstOrDefault(u => u.UserId == Id);
            if (user == null)
                return NotFound();

            // Clear the password field before sending it to the view
            user.PasswordHash = null;

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var userInDb = _context.Users.FirstOrDefault(u => u.UserId == user.UserId);
                if (userInDb == null)
                    return NotFound();

                userInDb.UserName = user.UserName;
                userInDb.Email = user.Email;
                userInDb.CreatedAt = DateTime.Now;

                if (!string.IsNullOrEmpty(user.PasswordHash)) // Plain password entered
                {
                    userInDb.PasswordHash = _passwordHasher.HashPassword(userInDb, user.PasswordHash);
                }

                _context.SaveChanges();
                TempData["successData"] = "User has been edited successfully";
                return RedirectToAction("Index");
            }

            return View(user);
        }

        public IActionResult Delete(int? Id)
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }
            var user = _context.Users.FirstOrDefault(u=>u.UserId == Id);
            if(user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteUser(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var user = _context.Users.FirstOrDefault(u=>u.UserId == Id);
            if(user == null)
            {
                return BadRequest();
            }
            _context.Remove(user);
            _context.SaveChanges();
            TempData["successData"] = "User has been Deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
