using Patents.Models;
using Patents.Models.Repositories;
using Patents.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Patents.Controllers
{
    public class PatentsController : Controller
    {


        PatentsRepository patent;
        IEnumerable<Patent> s = null;

        public PatentsController()
        {
            patent = new PatentsRepository();
            s = patent.Patents;
        }
        // GET: Inventors
        public ActionResult ShowAllData()
        {
            s = patent.Patents;
            return View("PatentsTable", s);
        }

        public ViewResult PatentsTable()
        {
            return View(s);
        }

        public PartialViewResult SearchingForm()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult FindByParams(PatentsView param)
        {
            s = patent.Patents;
            string id = param.PatentId;
            if (param.PatentId != null)
                s = s.Where(x => x.PatentId.ToString() == id).Select(x => x);
            //string inventorId = param.InventorId;
            //if (param.InventorId != null)
            //    s = s.Where(x => x.InventorId.ToString() == inventorId).Select(x => x);
            //string registerId = param.RegisterId;
            //if (param.RegisterId != null)
            //    s = s.Where(x => x.RegisterId.ToString() == inventorId).Select(x => x);
            string state = param.StatementState;
            if (param.StatementState != null)
                s = s.Where(x => x.Statement.State.Info == state).Select(x => x);
            string inventorName = param.InventorName;
            if (param.InventorName != null)
                s = s.Where(x => x.Inventor.Name == inventorName).Select(x => x);
            string registerName = param.RegisterName;
            if (param.RegisterName != null)
                s = s.Where(x => x.Register.Name == registerName).Select(x => x);
            string sum = param.Sum;
            if (param.Sum != null)
                s = s.Where(x => x.Sum.ToString() == sum).Select(x => x);
            return View("PatentsTable", s);
        }
    }
}
