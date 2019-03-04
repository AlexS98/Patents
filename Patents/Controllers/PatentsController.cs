using Microsoft.Owin.Security;
using Patents.Models.Repositories;
using Patents.Models.ViewModels;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Patents.Models.Entities;

namespace Patents.Controllers
{
    public class PatentsController : Controller
    {
        private readonly GenericRepository<Patent> _patents;
        private IEnumerable<Patent> _s;
        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        public PatentsController()
        {
            _patents = new GenericRepository<Patent>();
            _s = _patents.GetWithInclude(x => x.Inventor, x => x.Payment,x => x.Request.State, x => x.Idea, x => x.Register);
        }

        [Authorize(Roles = "Registred user")]
        public ActionResult UserPatents()
        {
            if (string.IsNullOrEmpty(AuthenticationManager.User.Identity.Name))
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                string userName = AuthenticationManager.User.Identity.Name;
                ViewBag.UserName = userName;
                _s = _patents.GetWithInclude(x => x.Inventor, x => x.Payment, x => x.Request, x => x.Request.State, 
                    x => x.Idea, x => x.Register).Where(x => x.Inventor.FullName == userName).Select(x => x);
                return View("PatentsTable", _s);
            }
        }

        // GET: Inventors
        public ActionResult ShowAllData(bool test = false)
        {
            ViewBag.UserName = AuthenticationManager.User.Identity.Name;
            if (!test) { _s = _patents.GetWithInclude(x => x.Inventor, x => x.Payment, x => x.Request, x => x.Request.State, x => x.Idea, x => x.Register); }
            return View("PatentsTable", _s);
        }

        public ViewResult PatentsTable()
        {
            ViewBag.UserName = AuthenticationManager.User.Identity.Name;
            return View(_s);
        }

        public PartialViewResult SearchingForm()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult FindByParams(PatentsView param, bool test = false)
        {
            ViewBag.UserName = AuthenticationManager.User.Identity.Name;
            if (!test) { _s = _patents.GetWithInclude(x => x.Inventor, x => x.Payment, x => x.Request, x => x.Request.State, x => x.Idea, x => x.Register); }
            if (param.PatentId != null)
            { _s = _s.Where(x => x.PatentId.ToString() == param.PatentId).Select(x => x); }
            if (param.StatementState != null)
            { _s = _s.Where(x => x.Request.State.Info == param.StatementState).Select(x => x); }
            if (param.InventorName != null)
            { _s = _s.Where(x => x.Inventor.FullName == param.InventorName).Select(x => x); }
            if (param.RegisterName != null)
            { _s = _s.Where(x => x.Register.FullName == param.RegisterName).Select(x => x); }
            if (param.Sum != null)
            { _s = _s.Where(x => x.Payment.Sum.ToString(CultureInfo.InvariantCulture) == param.Sum).Select(x => x); }
            return View("PatentsTable", _s);
        }
    }
}
