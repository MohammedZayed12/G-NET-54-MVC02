using GymManagement.AppDpContext;
using GymManagment.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using MVC.Presentation.Reposatiry;

namespace MVC.Presentation.Repository
{
    public class PlanRepository : IplanRepository
    {
        private readonly AppDpContext db;

        public PlanRepository(AppDpContext context)
        {
            db = context;
        }

        public async Task<IEnumerable<Plan>> GetAllPlans()
        {
            return await db.Plans.ToListAsync();
        }

       public async Task<Plan> GetPlanById(int id)
        {
            return await db.Plans.FindAsync(id);
        }

       public void AddPlan(Plan plan)
        {
            db.Plans.Add(plan);
        }

        public void UpdatePlan(Plan plan)
        {
            db.Plans.Update(plan);
        }

        public void DeletePlan(int id)
        {
            var plan = db.Plans.Find(id);
            if (plan != null)
            {
                db.Plans.Remove(plan);
            }
        }

        public async Task savechanges()
        {
            await db.SaveChangesAsync();
        }
    }
}
