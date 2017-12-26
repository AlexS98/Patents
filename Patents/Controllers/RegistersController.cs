using Patents.Models;
using Patents.Models.Repositories;
using Patents.Models.TestInterfaces;
using Patents.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Patents.Controllers
{
    public class RegistersController : Controller
    {
        RegistersRepository register;
        IEnumerable<Register> s;

        public RegistersController()
        {
            register = new RegistersRepository();
            s = register.Registers;
        }
        public RegistersController(IRegistersRepository rep = null, bool test = false)
        {
            if (test)
            {
                s = rep.Registers;
            }
        }
        // GET: Inventors
        public ActionResult ShowAllData(bool test = false)
        {
            if (!test) { s = register.Registers; }
            return View("RegistersTable", s);
        }

        public ViewResult RegistersTable()
        {
            return View(s);
        }

        public PartialViewResult SearchingForm()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult FindByParams(RegistersView param, bool test = false)
        {
            if (!test) { s = register.Registers; }
            string id = param.Id;
            if (param.Id != null)
            {
                s = s.Where(x => x.RegisterId.ToString() == id).Select(x => x); }

            string inventorName = param.Name;
            if (param.Name != null)
            {
                s = s.Where(x => x.Name == inventorName).Select(x => x);
            }
            string email = param.Email;
            if (param.Email != null)
            {
                s = s.Where(x => x.Email == email).Select(x => x);
            }
            string role = param.Role;
            if (param.Role != null)
            {
                s = s.Where(x => x.Role.UserRole == role).Select(x => x);
            }
            return View("RegistersTable", s);
        }
    }
}