using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFinal.Data;
using TestFinal.Models;

namespace TestFinal.Controllers
{
    public class ReviewController : Controller
    {
        private readonly MyDbContext context;
        public ReviewController(MyDbContext _context)
        {
            context = _context;
        }
        public IActionResult AddReviewGroupClass(int Id, int rate, string comment)
        {
            var currenUser = this.ControllerContext.HttpContext.User.Identity.Name;
            if (context.Users.FirstOrDefault(u => u.UserName == currenUser) != null)
            {
                Review review = new Review()
                {
                    Rate = rate,
                    ReviewMessage = comment,
                    ReviewDate = DateTime.Now,
                    GroupClass = context.GroupClasses.FirstOrDefault(p => p.Id == Id),
                    User = context.Users.FirstOrDefault(u => u.UserName == currenUser)
                };
                context.Reviews.AddAsync(review);
                context.SaveChanges();
            }
            return RedirectToAction("Details", "GroupClass", new { Id = Id });
        }
    }
}
