using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Vue.Controllers
{
    public class ActorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int id)
        {
            return View(id);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(int id)
        {
            return RedirectToAction(nameof(ActorsController.Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(id);
        }
        [HttpPost]
        public IActionResult PostEdit(int id)
        {
            return RedirectToAction(nameof(ActorsController.Detail), new { id });
        }
    }
}
