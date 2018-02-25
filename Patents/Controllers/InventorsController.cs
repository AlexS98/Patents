using Microsoft.Owin.Security;
using Patents.Models;
using Patents.Models.Repositories;
using Patents.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Patents.Models.Entities;
using Patents.Models.TestInterfaces;

namespace Patents.Controllers
{
    public class InventorsController : Controller
    {
        private readonly GenericRepository<Inventor> _inventor;
        private IEnumerable<Inventor> _s;
        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        public InventorsController()
        {
            _inventor = new GenericRepository<Inventor>();
            _s = _inventor.Get();
        }
        public InventorsController(IInventorsRepository rep = null, bool test = false)
        {
            if (test) _s = rep?.Inventors;
        }

        // GET: Inventors
        public ActionResult ShowAllData(bool test = false)
        {
            ViewBag.UserName = AuthenticationManager.User.Identity.Name;
            if (!test) _s = _inventor.Get();
            return View("InventorsTable", _s);
        }

        public ViewResult InventorsTable()
        {
            ViewBag.UserName = AuthenticationManager.User.Identity.Name;
            return View(_s);
        }

        public PartialViewResult SearchingForm()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult FindByParams(InventorsView param, bool test = false)
        {
            ViewBag.UserName = AuthenticationManager.User.Identity.Name;
            if (!test) _s = _inventor.Get();
            string id = param.Id;
            if (param.Id != null)
                _s = _s.Where(x => x.InventorId.ToString() == id).Select(x => x);
            string inventorName = param.Name;
            if (param.Name != null)
                _s = _s.Where(x => x.FullName == inventorName).Select(x => x);
            string email = param.Email;
            if (param.Email != null)
                _s = _s.Where(x => x.Email == email).Select(x => x);
            string adress = param.Adress;
            if (param.Adress != null)
                _s = _s.Where(x => x.Adress == adress).Select(x => x);
            return View("InventorsTable", _s);
        }
    }
}