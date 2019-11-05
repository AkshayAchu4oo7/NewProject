using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
    using NewProject.Models;

namespace NewProject.Controllers
{
    public class ModelsController : Controller
    {
        // GET: Models
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index1()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Index1(Test obj)
        {
            if (ModelState.IsValid)
            {
                Database1Entities db = new Database1Entities();
                db.Tests.Add(obj);
                db.SaveChanges();
            }
            else
            {
                return View();
            }

            return View(obj);
        }

        public ActionResult Index2()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index2(Test objUser)
        {
            if (ModelState.IsValid)
            {
                using (Database1Entities db = new Database1Entities())
                {

                    var obj = db.Tests.Where(a => a.Accountname.Equals(objUser.Accountname) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["Accountname"] = obj.Accountname.ToString();

                        return RedirectToAction("Index");
                    }
                }
            }
            return View(objUser);
        }


    }
}