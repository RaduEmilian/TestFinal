using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestFinal.Controllers
{
    public class ImagesController : Controller
    {   
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}
