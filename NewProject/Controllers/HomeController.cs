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
        Database1Entities db = new Database1Entities();
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


     
      [HttpGet]
        public ActionResult Tables()
        {
           

            List<Test> StudentList = db.Tests.ToList();
            //pass the StudentList list object to the view.  
            return View(StudentList);
        }
        [HttpPost]
        public ActionResult Tables(String search)
        {
         return View(db.Tests.Where(x => x.Accountname.StartsWith(search) || search == null).ToList());
        }
        [HttpGet]
        public ActionResult Example()
        {


            List<Test> StudentList = db.Tests.ToList();
            //pass the StudentList list object to the view.  
            return View(StudentList);
        }
        [HttpPost]
        public ActionResult Example(String search)
        {
            return View();
        }
        public ActionResult Trys(int Id, String Name,String name1,String name2, String name3)
        {
            
            var data = Id.ToString();
            var test = Name.ToString();
            var testAcc = name1.ToString();
            var testAcc1 = name2.ToString();
            var testAcc2 = name3.ToString();

            ViewBag.Id = data;
            ViewBag.Account = test;
            ViewBag.nickname = testAcc;
            ViewBag.phoneno = testAcc1;
            ViewBag.password = testAcc2;

          
            
            return View();
        }

        public ActionResult Mydetails()
        {
            Database1Entities td = new Database1Entities();
            var data = td.Mydatas.ToList();
            ViewBag.Accountname = data;
            return View();
        }
        [HttpGet]
        public ActionResult Search()
        {
            List<Test> StudentList = db.Tests.ToList();
            //pass the StudentList list object to the view.  
            return View(StudentList);
        }
        [HttpPost]
        public ActionResult Search(string option, string search)
        {
            if (option == "Password")
            {
                //Index action method will return a view with a student records based on what a user specify the value in textbox  
                return View(db.Tests.Where( x => x.Password == search || search == null).ToList());
            }
            else if (option == "Accountname")
            {
                return View(db.Tests.Where(x => x.Password == search || search == null).ToList());
            }
            else
            {
                return View(db.Tests.Where(x => x.Accountname.StartsWith(search) || search == null).ToList());
            }
        }
    }
        }
