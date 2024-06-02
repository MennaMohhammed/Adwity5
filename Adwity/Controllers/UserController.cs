using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Adwity.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            if (Session["id"] == null)
                return Redirect("/");
            return View();
        }
        public ActionResult ChangePassword() 
        {
            if (Session["id"] == null)
                return Redirect("/");
            return View();
        }
    }
}