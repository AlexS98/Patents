using Patents.Models.Repositories;
using System.Linq;
using System.Web.Mvc;

namespace Patents.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var roles = new RolesRepository().Roles;
            var states = new StateRepository().States;
            return View(states.Select(x => x.StateId.ToString() + ". " + x.Info));
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Test()
        {
            return View();
        }
    }
}