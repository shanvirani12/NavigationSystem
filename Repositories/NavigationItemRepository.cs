using Microsoft.EntityFrameworkCore;
using NavigationSystem.Models;

namespace NavigationSystem.Repositories
{
    public class NavigationItemRepository : INavigationItemRepository
    {
        private readonly AppDbContext _context;

        public NavigationItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<NavigationItem>> GetAllAsync()
        {
            return await _context.NavigationItems.ToListAsync();
        }

        public async Task<NavigationItem> GetByIdAsync(int id)
        {
            return await _context.NavigationItems.FindAsync(id);
        }

        public async Task CreateAsync(NavigationItem navigationItem)
        {
            navigationItem = new()
            {
                Name = navigationItem.Name,
                ParentId = navigationItem.ParentId,
            };
            _context.NavigationItems.Add(navigationItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(NavigationItem navigationItem)
        {
            _context.Entry(navigationItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var navigationItem = await _context.NavigationItems.FindAsync(id);
            if (navigationItem != null)
            {
                _context.NavigationItems.Remove(navigationItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}
