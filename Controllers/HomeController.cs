using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChefsDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsDishes.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.AllChefs = _context.Chefs
                .Include(chef => chef.CreatedDishes)
                .ToList();
            return View();
        }

        [HttpPost("createChef")]
        public IActionResult CreateChef(Chef newChef)
        {
            if(ModelState.IsValid)
            {
                _context.Chefs.Add(newChef);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Chef");
        }

        [HttpGet]
        [Route("new")]
        public IActionResult Chef()
        {
            return View();
        }

        [HttpGet]
        [Route("dishes/new")]
        public IActionResult DishPage()
        {
            ViewBag.AllChefs = _context.Chefs.ToList();
            return View("Dish");
        }

        [HttpPost("createDish")]
        public IActionResult CreateDish(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                _context.Dishes.Add(newDish);
                _context.SaveChanges();
                return RedirectToAction("Dish");
            }
            return View("Dish");
        }

        [HttpGet]
        [Route("dishes")]
        public IActionResult DishesPage()
        {
            ViewBag.AllChefs = _context.Chefs.ToList();

            ViewBag.AllDishes = _context.Dishes
                .Include(dish => dish.Creator)
                .ToList();
            return View("Dishes");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
