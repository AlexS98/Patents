﻿using Patents.Models;
using Patents.Models.Repositories;
using Patents.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Patents.Controllers
{
    public class InventorsController : Controller
    {
        InventorsRepository inventor;
        IEnumerable<Inventor> s = null;

        public InventorsController(IInventorsRepository rep, bool test = false)
        {
            if (!test)
            {
                inventor = new InventorsRepository();
                s = inventor.Inventors;
            }
            else {
                s = rep.Inventors;
            }
        }
        // GET: Inventors
        public ActionResult ShowAllData(bool test = false)
        {
            if(!test) s = inventor.Inventors;
            return View("InventorsTable", s);
        }

        public ViewResult InventorsTable()
        {
            return View(s);
        }

        public PartialViewResult SearchingForm()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult FindByParams(InventorsView param, bool test = false)
        {
            if(!test) s = inventor.Inventors;
            string id = param.Id;
            if (param.Id != null)
                s = s.Where(x => x.InventorId.ToString() == id).Select(x => x);
            string inventorName = param.Name;
            if (param.Name != null)
                s = s.Where(x => x.Name == inventorName).Select(x => x);
            string email = param.Email;
            if (param.Email != null)
                s = s.Where(x => x.Email == email).Select(x => x);
            string adress = param.Adress;
            if (param.Adress != null)
                s = s.Where(x => x.Adress == adress).Select(x => x);
            return View("InventorsTable", s);
        }
    }
}