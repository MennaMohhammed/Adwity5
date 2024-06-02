using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Adwity.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult user()
        {
            return View();
        }
        public ActionResult pharmacy()
        {
            return View();
        }
    }
}