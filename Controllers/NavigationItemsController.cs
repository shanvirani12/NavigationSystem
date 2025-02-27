﻿// NavigationItemsController.cs
using Microsoft.AspNetCore.Mvc;
using NavigationSystem.Models;
using NavigationSystem.Repositories;
using System.Threading.Tasks;

namespace NavigationSystem.Controllers
{
    public class NavigationItemsController : Controller
    {
        private readonly INavigationItemRepository _repository;

        public NavigationItemsController(INavigationItemRepository repository)
        {
            _repository = repository;
        }

        
        public async Task<IActionResult> Index()
        {
            var navigationItems = await _repository.GetAllAsync();
            return View(navigationItems);
        }

      
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var navigationItem = await _repository.GetByIdAsync(id.Value);
            if (navigationItem == null)
            {
                return NotFound();
            }

            return View(navigationItem);
        }

       
        public IActionResult Create()
        {

            return View();
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ParentId")] NavigationItem navigationItem)
        {
            
            await _repository.CreateAsync(navigationItem);
                
            
            return View(navigationItem);
        }

        // GET: NavigationItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var navigationItem = await _repository.GetByIdAsync(id.Value);
            if (navigationItem == null)
            {
                return NotFound();
            }
            return View(navigationItem);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ParentId")] NavigationItem navigationItem)
        {
            if (id != navigationItem.Id)
            {
                return NotFound();
            }

            
            await _repository.UpdateAsync(navigationItem);
               
          
            return View(navigationItem);
        }

        // GET: NavigationItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var navigationItem = await _repository.GetByIdAsync(id.Value);
            if (navigationItem == null)
            {
                return NotFound();
            }

            return View(navigationItem);
        }

 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
