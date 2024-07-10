using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NavigationSystem;
using NavigationSystem.Models;

namespace NavigationSystem.Controllers
{
    public class NavigationItemsController : Controller
    {
        private readonly AppDbContext _context;

        public NavigationItemsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var navigationItems = _context.NavigationItems.ToList();
            return View(navigationItems);
        }
    }

}
