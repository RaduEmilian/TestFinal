using TestFinal.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFinal.Models.Repositores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using TestFinal.ViewModels;
using TestFinal.Models.Repositories;
using TestFinal.Data;
using System.IO;

namespace TestFinal.Controllers
{
    public class GroupClassController : Controller
    {
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IGroupClassService groupClassService;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IReviewServices reviewServices;
        private readonly MyDbContext context;
        public UserManager<ApplicationUser> UserManager { get; }

        public GroupClassController(IWebHostEnvironment _hostingEnvironment, IGroupClassService _groupClassService,
            RoleManager<IdentityRole> _roleManager,
               UserManager<ApplicationUser> _userManager,MyDbContext _context , IReviewServices _reviewServices)
        {
            hostingEnvironment = _hostingEnvironment;
            groupClassService = _groupClassService;
            roleManager = _roleManager;
            userManager = _userManager;
            context = _context;
            reviewServices = _reviewServices;
        }

        [AllowAnonymous]
        [HttpGet]

        public IActionResult Index()
        {
            var clasa = groupClassService.ListAllGroupClassWith();
            return View("Index", clasa);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateGroupClass()
        {
            CreateGroupClassViewModel model = new CreateGroupClassViewModel { };

            return View("add", model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateGroupClass(CreateGroupClassViewModel model)
        {
            if (ModelState.IsValid)
            {

                GroupClass groupClass = new GroupClass
                {
                    Title = model.Title,
                    Id = model.Id,
                    Description = model.Description,
                    RoomNumber = model.RoomNumber
                };

                await groupClassService.AddGroupClassAsync(groupClass);

                return RedirectToAction("Index", "groupClass");
            }

            return View("add", model);
        }
        [HttpGet]
        public ViewResult List(string category)
        {
            IEnumerable<GroupClass> clasa;

            clasa = groupClassService.ListAllGroupClass();

            return View(new GroupClassListViewModel
            {
                GroupClasses = clasa.ToList(),
            });
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteGroupClass(int id)
        {
            var clasa = await groupClassService.GetGroupClassByIdAsync(id);

            await groupClassService.DeleteGroupClassAsync(clasa);

            return RedirectToAction("Index", "groupClass");
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditGroupClass(EditGroupClassViewModel model)
        {
            var clasa = await groupClassService.GetGroupClassByIdAsync(model.Id);

            if (clasa == null)
            {
                ViewBag.ErrorMessage = $"GroupClass with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                clasa.Title = model.Title;
                clasa.Description = model.Description;
                clasa.RoomNumber = model.RoomNumber;

                await groupClassService.UpdateGroupClassAsync(clasa);

                return RedirectToAction("Index", "groupClass");


            }
            return View("Index", model);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditGroupClass(int id)
        {
            var clasa = await groupClassService.GetGroupClassByIdAsync(id);

            if (clasa == null)
            {
                ViewBag.ErrorMessage = $"Car option with Id = {id} cannot be found";
                return View("NotFound");
            }

            var model = new EditGroupClassViewModel

            {
                Id = clasa.Id,
                Title = clasa.Title,
                Description = clasa.Description,
                RoomNumber = clasa.RoomNumber

            };

            return View("edit", model);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
                return NotFound();



            var groupClass = await groupClassService.GetGroupClassByIdAsync(id);

            if (groupClass == null)
                return NotFound();
            

            var review = reviewServices.GetAllGroupClass().Where(r => r.GroupClass.Id == id).ToList();

            var user = await userManager.GetUserAsync(HttpContext.User);

            var groupclassmodel = new GroupClassViewModel()
            {
                Id = groupClass.Id,
                Title = groupClass.Title,
                Description = groupClass.Description,
                RoomNumber = groupClass.RoomNumber,
                Reviews = review,        
                User = user,
            };

            return View(groupclassmodel);
        }


    }
}
