 using GymManagment.DataAccess.Entity;
using GymManagement.AppDpContext;
using Microsoft.EntityFrameworkCore;

namespace GymManagment.DataAccess.SeedData
{
    public static class CategorySeeder
    {
        public static async Task SeedCategoriesAsync(AppDpContext dbContext)
        {
            if (!await dbContext.Categores.AnyAsync())
            {
                var categories = new List<Category>
                {
                    new Category
                    {
                         Name = "Cardio",
                         CreatedAt = DateTime.UtcNow,
                        Description = "Cardiovascular and endurance exercises"
                    },

                    new Category    
                    {
                         Name = "Strength Training",
                         CreatedAt = DateTime.UtcNow,
                        Description = "Bodybuilding and weight training"
                    },

                    new Category        
                    {
                         Name = "CrossFit",
                         CreatedAt = DateTime.UtcNow,
                        Description = "High-intensity functional movements"
                    },

                    new Category
                    {
                         Name = "Yoga & Pilates",
                        Description = "Flexibility, balance, and core stability",
                        CreatedAt = DateTime.UtcNow
                    }
                };

                await dbContext.Categores.AddRangeAsync(categories);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
 