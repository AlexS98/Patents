using Microsoft.Owin.Security;
using Patents.Models.Entities;
using Patents.Models.Repositories;
using Patents.Models.TestInterfaces;
using Patents.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Patents.Controllers
{
    public class RegistersController : Controller
    {
        private readonly GenericRepository<Register> _register;
        private IEnumerable<Register> _s;
        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        public RegistersController()
        {
            _register = new GenericRepository<Register>();
            _s = _register.Get();
        }
        public RegistersController(IRegistersRepository repository = null, bool test = false)
        {
            if (!test) return;
            if (repository != null) _s = repository.Registers;
        }
        // GET: Inventors
        public ActionResult ShowAllData(bool test = false)
        {
            ViewBag.UserName = AuthenticationManager.User.Identity.Name;
            if (!test) { _s = _register.GetWithInclude(x => x.Role); }
            return View("RegistersTable", _s);
        }

        public ViewResult RegistersTable()
        {
            ViewBag.UserName = AuthenticationManager.User.Identity.Name;
            return View(_s);
        }

        public PartialViewResult SearchingForm()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult FindByParams(RegistersView param, bool test = false)
        {
            ViewBag.UserName = AuthenticationManager.User.Identity.Name;
            if (!test) { _s = _register.GetWithInclude(x => x.Role); }
            string id = param.Id;
            if (param.Id != null)
            {
                _s = _s.Where(x => x.RegisterId.ToString() == id).Select(x => x);
            }
            string inventorName = param.Name;
            if (param.Name != null)
            {
                _s = _s.Where(x => x.FullName == inventorName).Select(x => x);
            }
            string email = param.Email;
            if (param.Email != null)
            {
                _s = _s.Where(x => x.Email == email).Select(x => x);
            }
            string role = param.Role;
            if (param.Role != null)
            {
                _s = _s.Where(x => x.Role.UserRole == role).Select(x => x);
            }
            return View("RegistersTable", _s);
        }
    }
}