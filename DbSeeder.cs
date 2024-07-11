using Microsoft.EntityFrameworkCore;
using NavigationSystem.Models;

namespace NavigationSystem
{
    public static class DbSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
      
                if (context.NavigationItems.Any())
                {
                    return; 
                }

        
                var navigationItems = new List<NavigationItem>
                {
                    new NavigationItem { Name = "Products", Children = new List<NavigationItem>
                        {
                            new NavigationItem { Name = "Male", Children = new List<NavigationItem>
                                {
                                    new NavigationItem { Name = "Paints", Children = new List<NavigationItem>
                                        {
                                            new NavigationItem { Name = "Jeans", Children = new List<NavigationItem>
                                                {
                                                    new NavigationItem { Name = "Slim Fit", Children = new List<NavigationItem>
                                                        {
                                                            new NavigationItem { Name = "Blue" }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                };

               
                context.NavigationItems.AddRange(navigationItems);
                context.SaveChanges();
            }
        }
    }
}
