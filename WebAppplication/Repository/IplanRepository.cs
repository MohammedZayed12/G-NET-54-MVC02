using GymManagment.DataAccess.Entity;
using GymManagmentPresentation;

namespace MVC.Presentation.Reposatiry
{
    public interface IplanRepository
    {
        Task<IEnumerable<Plan>> GetAllPlans();

        Task<Plan> GetPlanById(int id);

        void AddPlan(Plan plan);

        void UpdatePlan(Plan plan);

        void DeletePlan(int id);

        Task savechanges();
    }
}
