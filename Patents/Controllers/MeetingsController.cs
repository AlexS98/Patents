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
    public class MeetingsController : Controller
    {
        private readonly GenericRepository<Meeting> _meeting;
        private IEnumerable<Meeting> _s;
        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        public MeetingsController() {
            _meeting = new GenericRepository<Meeting>();
            _s = _meeting.Get();
        }

        public MeetingsController(IMeetingsRepository rep, bool test)
        {
            if (test)
            {
                _s = rep.Meetings;
            }
        }

        public ActionResult ShowAllData(bool test = false)
        {
            ViewBag.UserName = AuthenticationManager.User.Identity.Name;
            if (!test) { _s = _meeting.Get(); }
            return View("MeetingsTable", _s);
        }

        public ViewResult MeetingsTable()
        {
            ViewBag.UserName = AuthenticationManager.User.Identity.Name;
            return View(_s);
        }

        public PartialViewResult ShowAll()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult FindByParams(MeetingsView param, bool test = false)
        {
            ViewBag.UserName = AuthenticationManager.User.Identity.Name;
            if (!test) _s = _meeting.Get();
            string state = param.State;
            if(param.State != null )
                _s = _s.Where(x => x.State.Info == state).Select(x => x);
            string inventorName = param.InventorName;
            if (param.InventorName != null)
                _s = _s.Where(x => x.Inventor.FullName == inventorName).Select(x => x);
            string registerName = param.RegisterName;
            if (param.RegisterName != null)
                _s = _s.Where(x => x.Register.FullName == registerName).Select(x => x);
            string date = param.Date;
            if (param.Date != null)
                _s = _s.Where(x => x.Date.ToString() == date).Select(x => x);
            return View("MeetingsTable", _s);
        }
    }
}