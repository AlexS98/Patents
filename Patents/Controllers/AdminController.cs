using Microsoft.Owin.Security;
using System.Web;
using System.Web.Mvc;

namespace Patents.Controllers
{
    [Authorize(Roles = "Administrator,Moderator")]
    public class AdminController : Controller
    {
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.UserName = AuthenticationManager.User.Identity.Name.ToString();
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult AdminIndex()
        {
            ViewBag.UserName = AuthenticationManager.User.Identity.Name.ToString();
            return View();
        }
    }
}