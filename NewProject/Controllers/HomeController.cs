using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewProject.Models;

namespace NewProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

       

        public ActionResult Contact()
        {
            Database1Entities db = new Database1Entities();

            return View(from Test in db.Tests.Take(5) select Test);
        }



        [HttpGet]
        public ActionResult Logins()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logins(Test obj)
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


        public ActionResult News()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult News(Test objUser)
        {
            if (ModelState.IsValid)
            {
                using (Database1Entities db = new Database1Entities())
                {

                    var obj = db.Tests.Where(a => a.Accountname.Equals(objUser.Accountname) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["Id"] = obj.Id.ToString();
                        Session["Accountname"] = obj.Accountname.ToString();
                        Session["password"] = obj.Password.ToString();
                        Session["Name"] = obj.Name.ToString();
                        Session["Phoneno"] = obj.Phoneno.ToString();
                        return RedirectToAction("Exits");
                    }
                }
            }
            return View(objUser);
        }
        public ActionResult Exits()
        {
            if (Session["Id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("News");
            }
        }


     
      
        public ActionResult Tables()
        {
            Database1Entities td = new Database1Entities();
            var data = td.Tests.ToList();
            ViewBag.Accountname = data;
            return View();
        }


        public ActionResult Trys(int Id, String Name)
        {
            
            var data = Id.ToString();
            var test = Name.ToString();
            var testAcc = Name.ToString();
            ViewBag.tests = testAcc;

          
            ViewBag.Accountname = data;
            ViewBag.Account = test;
            return View();
        }

        public ActionResult Mydetails()
        {
            Database1Entities td = new Database1Entities();
            var data = td.Mydatas.ToList();
            ViewBag.Accountname = data;
            return View();
        }

        public ActionResult Search(String Source,String Destination)
        {
            //var first = Source.ToString();
            //var second = Destination.ToString();


            return View();
        }
        }
}