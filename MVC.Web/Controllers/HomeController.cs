using MVC.Domain.Model;
using MVC.Repository;
using MVC.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Web.Controllers
{
    public class HomeController : Controller
    {
        private AccountService accountService = new AccountService();
        private ChaRegisterService chaRegisterService = new ChaRegisterService();
        private VisitorRepository visitorRepository = new VisitorRepository();
        private ChaRegisterRepository chaRegisterRepository = new ChaRegisterRepository();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PreRegister()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Register()
        {
            List<SelectListModel> usertypeId = visitorRepository.GetUSerType();
            ViewBag.UserTypeID = new SelectList(usertypeId, "ID", "Name");
            List<SelectListModel> documentType = visitorRepository.GetDocument();
            ViewBag.documentType = new SelectList(documentType, "ID", "Name");
            return View();
        }

        public ActionResult ReturnVisitor()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Checkout()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //public JsonResult ChaRegister(ChaRegisterEntity Registercha)
        //{
           
        //    var date = DateTime.Now;
           
        //    int result = chaRegisterService.AddChaRegister(Registercha);
        //    if (result > 0)
        //    {
        //        string message = "SUCCESS";
        //        return Json(message, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {

        //        string message = "Failed";
        //        return Json(message, JsonRequestBehavior.AllowGet);
        //    }
        //}
        public JsonResult ChaRegister(FormCollection form)
        {
            ChaRegisterEntity cha = new ChaRegisterEntity();

            if (Request.Files.Count > 0)
            {
                string path = Server.MapPath("~/Images/ChaRegister");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);

                }

                HttpFileCollectionBase files = Request.Files;
                HttpPostedFileBase postedFile = Request.Files[0];
                string filePath = Path.Combine(path, postedFile.FileName);
                postedFile.SaveAs(filePath);
                cha.Document = postedFile.FileName;

            }

            var date = DateTime.Now;

            cha.PhotoForedit = form["PhotoForedit"];
            string PhotoForEdit = cha.PhotoForedit;
            if (PhotoForEdit != null)
            {
                cha.Document = form["PhotoForedit"];
            }

            cha.ID = Convert.ToInt32(form["ID"]);
            cha.FirstName = form["FirstName"];
            cha.LastName = form["LastName"];
            cha.Gender = form["Gender"];
            cha.IsActive = Convert.ToInt32(form["IsActive"]);
            cha.Password = form["Password"];
            cha.EmailID = form["EmailID"];
            cha.MobileNumber = form["MobileNumber"];
            cha.CHACode = form["CHACode"];
            cha.UserTypeID = Convert.ToInt32(form["UserTypeID"]);
            cha.RegistrationDate = form["registrationDate"];
            int result = chaRegisterService.AddChaRegister(cha);

            if (result >= 0)
            {

                string message = "SUCCESS";

                return Json(message, JsonRequestBehavior.AllowGet);
            }
            else
            {

                string message = "FAILED";


                return Json(message, JsonRequestBehavior.AllowGet);
            }



        }


        public JsonResult AddChaDetails(FormCollection form)
        {
            ChaRegisterEntity Cha = new ChaRegisterEntity();
            string photo= form["image"];

            if (photo != "")
            {
                var t = photo.Substring(22);  // remove data:image/png;base64,

                byte[] bytes = Convert.FromBase64String(t);

                var randomFileName = Guid.NewGuid().ToString().Substring(0, 4) + ".png";
                var fullPath = Path.Combine(Server.MapPath("~/Images/Cha_liveImage/"), randomFileName);
                System.IO.File.WriteAllBytes(fullPath, bytes);
                Cha.LivePhoto = randomFileName;
            }
  


            if (Request.Files.Count > 0)
            {
                string path = Server.MapPath("~/Images/Cha_liveImage");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);

                }

                HttpFileCollectionBase files = Request.Files;
                HttpPostedFileBase postedFile = Request.Files[0];
                string filePath = Path.Combine(path, postedFile.FileName);
                postedFile.SaveAs(filePath);
                Cha.Document = postedFile.FileName;

            }

            var date = DateTime.Now;

            //int id = employee.ID;
            //if (id > 0)
            //{

            Cha.ID = Convert.ToInt32(form["Id"]);

            //}

            Cha.DocumentType =Convert.ToInt32(form["DocumentType"]);
            Cha.FirstName = form["FirstName"];
            Cha.LastName = form["LastName"];
            Cha.EmailID = form["EmailID"];
            Cha.CHACode = form["CHACode"];
            Cha.MobileNumber = form["MobileNumber"];
            Cha.Gender = form["Gender"];
            Cha.UserTypeID = Convert.ToInt32(form["UserTypeID"]);
            Cha.RegistrationDate = form["RegistrationDate"];
            Cha.Password = form["Password"];
            Cha.otherGovernmentOfficer = form["otherGovernmentOfficer"];
            Cha.IsActive = Convert.ToInt32(form["IsActive"]);

            int result = chaRegisterService.AddChaDetails(Cha);

            if (result >= 0)
            {

                string message = "SUCCESS";



                return Json(message, JsonRequestBehavior.AllowGet);
            }
            else
            {

                string message = "FAILED";


                return Json(message, JsonRequestBehavior.AllowGet);
            }



        }
        public JsonResult EmailValidation(string Email)
        {
            string message = " ";
            ChaRegisterEntity response = new ChaRegisterEntity();
            string EmailID = chaRegisterRepository.EmailValidation(Email);

            if (EmailID == "0")
            {
                 message = "SUCCESS";

                response.EmailID = EmailID;
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            else
            {

                 message = "FAILED";

                response.EmailID = EmailID;
                return Json(message, JsonRequestBehavior.AllowGet);
            }
        }

    }
}