using NavigationSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NavigationSystem.Repositories
{
    public interface INavigationItemRepository
    {
        Task<List<NavigationItem>> GetAllAsync();
        Task<NavigationItem> GetByIdAsync(int id);
        Task CreateAsync(NavigationItem navigationItem);
        Task UpdateAsync(NavigationItem navigationItem);
        Task DeleteAsync(int id);
    }
}
