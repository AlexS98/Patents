using Microsoft.Owin.Security;
using Patents.Models.Repositories;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Patents.Models.Entities;

namespace Patents.Controllers
{
    public class HomeController : Controller
    {
        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        // GET: Home
        public ActionResult Index()
        {
            var inventors = new GenericRepository<Inventor>().Get();
            ViewBag.UserName = AuthenticationManager.User.Identity.Name;
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