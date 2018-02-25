using Microsoft.Owin.Security;
using Patents.Models;
using Patents.Models.Repositories;
using Patents.Models.ViewModels;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Patents.Models.Entities;
using Patents.Models.TestInterfaces;

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
        public PatentsController(IPatentsRepository rep = null, bool test = false)
        {
            if (test)
            {
                _s = rep.Patents;
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
            string id = param.PatentId;
            if (param.PatentId != null)
            {
                _s = _s.Where(x => x.PatentId.ToString() == id).Select(x => x);
            }
            //string inventorId = param.InventorId;
            //if (param.InventorId != null)
            //    s = s.Where(x => x.InventorId.ToString() == inventorId).Select(x => x);
            //string registerId = param.RegisterId;
            //if (param.RegisterId != null)
            //    s = s.Where(x => x.RegisterId.ToString() == inventorId).Select(x => x);
            string state = param.StatementState;
            if (param.StatementState != null)
            { _s = _s.Where(x => x.Request.State.Info == state).Select(x => x); }
            string inventorName = param.InventorName;
            if (param.InventorName != null)
            { _s = _s.Where(x => x.Inventor.FullName == inventorName).Select(x => x); }
            string registerName = param.RegisterName;
            if (param.RegisterName != null)
            { _s = _s.Where(x => x.Register.FullName == registerName).Select(x => x); }
            string sum = param.Sum;
            if (param.Sum != null)
            { _s = _s.Where(x => x.Payment.Sum.ToString(CultureInfo.InvariantCulture) == sum).Select(x => x); }
            return View("PatentsTable", _s);
        }
    }
}
