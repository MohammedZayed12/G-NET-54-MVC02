using GymManagement.AppDpContext;
using GymManagment.DataAccess.SeedData;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.DataAccess.DatabaseSeeder
{
    public static class DatabaseSeeder
    {
        public static async Task SeedAllAsync(AppDpContext dbContext)
        {
            await PlanSeeder.SeedPlansAsync(dbContext);
            await CategorySeeder.SeedCategoriesAsync(dbContext);
        }
    }
}
