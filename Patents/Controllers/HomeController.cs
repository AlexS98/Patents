using Patents.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Patents.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var roles = new RolesRepository().Roles;
            var states = new StateRepository().States;
            return View(states.Select(x => (x.StateId.ToString() + ". " + x.Info)));
        }
    }
}