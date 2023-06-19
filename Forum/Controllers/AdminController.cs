using Forum.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Forum.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ApplicationDbContext context;

        public AdminController(UserManager<IdentityUser> userManager, ApplicationDbContext context) 
        {
            this.userManager = userManager;
            this.context = context;
        }
        public async Task<IActionResult> ListUsers()
        {
            var users = await userManager.Users.ToListAsync();
            return View(users);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null) 
            {
                return NotFound();
            }

            await userManager.DeleteAsync(user);

            return RedirectToAction("ListUsers");
        }

        public async Task<IActionResult> ListQuestions()
        {
            var questions = await context.Questions.ToListAsync();
            return View(questions);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            
            var question = await context.Questions.FindAsync(id);
            if (question != null)
            {
                context.Questions.Remove(question);
            }

            await context.SaveChangesAsync();
            return RedirectToAction("ListQuestions");
        }
    }
}
