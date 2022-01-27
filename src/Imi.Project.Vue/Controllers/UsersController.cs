using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Vue.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string id)
        {
            return RedirectToAction(nameof(MoviesController.Index));
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            return View(id);
        }
        [HttpPost]
        public IActionResult PostEdit(string id)
        {
            return RedirectToAction(nameof(MoviesController.Detail), new { id });
        }
    }
}
