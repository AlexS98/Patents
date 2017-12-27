using Microsoft.Owin.Security;
using Patents.Models;
using Patents.Models.Repositories;
using Patents.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Patents.Controllers
{
    public class MeetingsController : Controller
    {
        MeetingsRepository meeting;
        IEnumerable<Meeting> s;
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        public MeetingsController() {
            meeting = new MeetingsRepository();
            s = meeting.Meetings;
        }

        public MeetingsController(IMeetingsRepository rep, bool test)
        {
            if (test)
            {
                s = rep.Meetings;
            }
        }

        public ActionResult ShowAllData(bool test = false)
        {
            ViewBag.UserName = AuthenticationManager.User.Identity.Name.ToString();
            if (!test) { s = meeting.Meetings; }
            return View("MeetingsTable", s);
        }

        public ViewResult MeetingsTable()
        {
            ViewBag.UserName = AuthenticationManager.User.Identity.Name.ToString();
            return View(s);
        }

        public PartialViewResult ShowAll()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult FindByParams(MeetingsView param, bool test = false)
        {
            ViewBag.UserName = AuthenticationManager.User.Identity.Name.ToString();
            if (!test) s = meeting.Meetings;
            string state = param.State;
            if(param.State != null )
                s = s.Where(x => x.State.Info == state).Select(x => x);
            string inventorName = param.InventorName;
            if (param.InventorName != null)
                s = s.Where(x => x.Inventor.Name == inventorName).Select(x => x);
            string registerName = param.RegisterName;
            if (param.RegisterName != null)
                s = s.Where(x => x.Register.Name == registerName).Select(x => x);
            string date = param.Date;
            if (param.Date != null)
                s = s.Where(x => x.Date.ToString() == date).Select(x => x);
            return View("MeetingsTable", s);
        }
    }
}