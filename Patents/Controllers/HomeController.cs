using Microsoft.Owin.Security;
using Patents.Models.Repositories;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Patents.Controllers
{
    public class HomeController : Controller
    {
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        // GET: Home
        public ActionResult Index()
        {
            //var roles = new RolesRepository().Roles;
            //var states = new StatesRepository().States;
            //var registers = new RegistersRepository().Registers;
            var inventors = new InventorsRepository().Inventors;
            ViewBag.UserName = AuthenticationManager.User.Identity.Name.ToString();
            return View(inventors.Select(x => x.FullName + " | " + x.Password));
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Test()
        {
            ViewBag.UserName = AuthenticationManager.User.Identity.Name;
            return View();
        }
    }
}