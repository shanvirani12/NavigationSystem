using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NavigationSystem.Models;

namespace NavigationSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var navigationItems = _context.NavigationItems
                .Include(n => n.Children)
                .ToList();

            ViewData["NavigationItems"] = navigationItems;

            return View();
        }
    }
}
