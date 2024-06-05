using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Mvc;
using Adwity.Repositories;

namespace Adwity.Controllers
{
    public class APIsController : Controller
    {
        public string UploadImage(HttpPostedFileBase file)
        {
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    // Specify the path where you want to save the uploaded image
                    string uploadPath = Server.MapPath("~/Uploads/");
                    string fileName = Path.GetFileName(file.FileName);
                    string filePath = Path.Combine(uploadPath, fileName);

                    // Save the uploaded image to the server
                    file.SaveAs(filePath);

                    // You can do further processing with the file if needed
                    // For example, you can store the file path in the database

                    // Return the full path to the uploaded image
                    return "/uploads/" + fileName; ;
                }
                else
                {
                    return "0";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        [HttpGet]
        public ActionResult Login(string username, string password)
        {
            int result = Fetch.login(username, password);
            if (result != 0)
            {
                Session["id"] = result;
                Session["first"] = true;
                return Json(new { code = HttpStatusCode.OK, id = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { code = HttpStatusCode.Unauthorized }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult NewUser(string fname, string lname, string password, string repassword, string username)
        {
            username = fname + lname;
            username = username.Trim();
            if (password != repassword)
            {
                return Json(new { code = HttpStatusCode.BadRequest });
            }
            else if (Fetch.CheckUsernameExist(username))
            {
                return Json(new { code = HttpStatusCode.Conflict });
            }
            else if(Insert.AddUser(fname, lname, password, username))
            {

                return Login(username, password);
            }
            else
            {
                return Json(new { code = HttpStatusCode.ExpectationFailed });
            }
        }
        [HttpPost]
        public ActionResult NewPharmacy(string fname, string pname, string password, string repassword, string username, string[] branches, HttpPostedFileBase img)
        {
            username = fname + pname;
            username = username.Trim();
            string image = UploadImage(img);
            if (password != repassword) 
            {
                return Json(new { code = HttpStatusCode.BadRequest });
            }
            else if(image == "0")
            {
                return Json(new { code = HttpStatusCode.BadRequest });
            }
            else if (branches.Length <= 0)
            {
                return Json(new { code = HttpStatusCode.BadRequest });
            }
            else if (Fetch.CheckUsernameExist(username))
            {
                return Json(new { code = HttpStatusCode.Conflict });
            }
            else if (Insert.AddPharmacy(fname, pname, password, username, image, branches))
            {
                return Login(username, password);
            }
            else
            {
                return Json(new { code = HttpStatusCode.ExpectationFailed });
            }
        }
        [HttpGet]
        public ActionResult ServiceOne(string medicine, string branches)
        {
            if(Fetch.MedicineAvaliable(medicine, branches))
                return Json(new { code = HttpStatusCode.OK }, JsonRequestBehavior.AllowGet);
            else
                return Json(new {code = HttpStatusCode.NoContent}, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult ServiceTwo(string medicine, string alt, string branches)
        {
            if (Fetch.MedicineAvaliableRep(medicine, alt, branches))
                return Json(new { code = HttpStatusCode.OK }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { code = HttpStatusCode.NoContent }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult ServiceThree(string name)
        {
            if (Fetch.MedicineExist(name))
                return Json(new { code = HttpStatusCode.OK }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { code = HttpStatusCode.NoContent }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult NewMedicine(string name, string material, int quantity, string production, string expiration, string price, HttpPostedFileBase img)
        {
            string image = UploadImage(img);
            int id = (int)Session["id"];
            if(Insert.AddMedicine(name, material, quantity, production, expiration, price, image, id))
            {
                return Json(new { code = HttpStatusCode.OK });
            }
            else
            {
                return Json(new { code = HttpStatusCode.BadRequest });
            }
        }
        [HttpPost]
        public ActionResult ChangePassword(string password, string repassword)
        {
            int id = 3;
            if (password != repassword)
                return Json(new { code = HttpStatusCode.Conflict });
            if (Update.Password(password, id))
                return Json(new { code = HttpStatusCode.OK });
            else
                return Json(new { code = HttpStatusCode.BadRequest });
        }
        [HttpGet]
        public ActionResult RemoveMedicine(int medicine) 
        {
            if (Delete.Medicine(medicine))
                return Json(new { code = HttpStatusCode.OK },JsonRequestBehavior.AllowGet);
            else
                return Json(new { code = HttpStatusCode.BadRequest }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult EditMedicine(int id, string name, string material, int quantity, string price, HttpPostedFileBase img, string production = "", string expiration = "")
        {
            string image = "";
            if(img != null)
                image = UploadImage(img);
            if (Update.Medicine(name, material, quantity, production, expiration, price, image, id))
            {
                return Json(new { code = HttpStatusCode.OK });
            }
            else
            {
                return Json(new { code = HttpStatusCode.BadRequest });
            }
        }
    }
};