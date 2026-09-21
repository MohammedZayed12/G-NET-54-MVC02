using GymManagement.AppDpContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Presentation.Reposatiry;

namespace WebApplication.Controllers
{
    public class PlanController : Controller
    {
        #region Fields
        private readonly IplanRepository _planRepository;
        #endregion

        #region Constructors
        public PlanController(IplanRepository planRepository)
        {
            _planRepository = planRepository;
        }
        #endregion

        #region Public Methods
        public async Task<IActionResult> Index()
        {
            var plans = await _planRepository.GetAllPlans();
            return View(plans);
        }

        public async Task<IActionResult> details(int id)
        {
            var plan = await _planRepository.GetPlanById(id);
            if (plan == null)
            {
                //if the plan is not found,go back to the index page
                return RedirectToAction(nameof(Index));
            }
            return View(plan);
        }
        #endregion
    }
}
