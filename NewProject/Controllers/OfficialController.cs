using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewProject.viewModels;
using NewProject.Models;

namespace NewProject.Controllers
{
    public class OfficialController : Controller
    {
        public Database1Entities dbContext = new Database1Entities();
        // GET: Official
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetUser(UserVM user)
        {
            UserVM userConnected = dbContext.Users.Where(u => u.FullName == user.FullName)
                                         .Select(u => new UserVM
                                         {
                                             UserID = u.UserID,
                                             FullName = u.FullName,
                                             ProfilImage = u.ProfilImage,

                                         }).FirstOrDefault();

            if (userConnected != null)
            {
                Session["UserConnected"] = userConnected;
                return RedirectToAction("SelectQuizz");
            }
            else
            {
                ViewBag.Msg = "Sorry : user is not found !!";
                return View();
            }

        }
    }
}