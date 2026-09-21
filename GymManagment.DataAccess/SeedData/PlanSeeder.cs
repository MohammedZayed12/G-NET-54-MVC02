using GymManagment.DataAccess.Entity;
using GymManagement.AppDpContext;
using Microsoft.EntityFrameworkCore;

namespace GymManagment.DataAccess.SeedData
{
    public static class PlanSeeder
    {
        public static async Task SeedPlansAsync(AppDpContext dbContext)
        {
            if (!await dbContext.Plans.AnyAsync())
            {
                var plans = new List<Plan>
                {
                    new Plan
                    {
                        Name = "Basic Plan",
                        Description = "Basic gym membership",
                        Price = 50,
                        DurationDays = 30,
                        CreatedAt = DateTime.UtcNow,
                        IsActive = false
                    },

                    new Plan
                    {
                        Name = "Premium Plan",
                        Description = "Premium gym membership",
                        Price = 100,
                        DurationDays = 60,
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true

                    },

                    new Plan
                    {
                        Name = "VIP Plan",
                        Description = "VIP gym membership",
                        Price = 150,
                        DurationDays = 90,
                        CreatedAt = DateTime.UtcNow,
                        IsActive = false
                    }
                };

                await dbContext.Plans.AddRangeAsync(plans);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}