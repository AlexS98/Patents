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
            //var roles = new RolesRepository().Roles;
            //var states = new StatesRepository().States;
            //var registers = new RegistersRepository().Registers;
            var inventors = new InventorsRepository().Inventors;
            return View(inventors.Select(x => x.Name + " | " + x.Password));
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Test()
        {
            return View();
        }
    }
}