using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Domain.Model;
using MVC.Repository;
using System.Data;
using System.IO;
using MVC.Services;
namespace MVC.Web.Controllers
{


    public class VisitorController : Controller
    {
        private VisitorRepository visitorRepository = new VisitorRepository();

        private VisitorService visitorService = new VisitorService();


        public ActionResult Visitor()
        {
            List<SelectListModel> department = visitorRepository.GetDepartment();
            ViewBag.department = new SelectList(department, "ID", "Name");

            List<SelectListModel> officer = visitorRepository.GetOfficer();
            ViewBag.officer = new SelectList(officer, "ID", "Name");

            List<SelectListModel> visitorType = visitorRepository.GetVisitor();
            ViewBag.visitorType = new SelectList(visitorType, "ID", "Name");

            List<SelectListModel> documentType = visitorRepository.GetDocument();
            ViewBag.documentType = new SelectList(documentType, "ID", "Name");



            return View();
        }
        public ActionResult Count()
        {
            List<SelectListModel> department = visitorRepository.GetDepartment();
            ViewBag.department = new SelectList(department, "ID", "Name");

            return View();
        }
        public PartialViewResult GetVisitorDetailByID(int ID)
        {

            VisitorModel visitorModel = visitorRepository.FetchVisitorDetailByID(ID);

            return PartialView("_Visitor", visitorModel);
        }

        public JsonResult AddVisitorDetail(FormCollection form)
        {
            VisitorModel visitor = new VisitorModel();
            VisitorResponse response = new VisitorResponse();

            if (Request.Files.Count > 0)
            {
                string path = Server.MapPath("~/Images/VisitorsImgs");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);

                }

                HttpFileCollectionBase files = Request.Files;
                HttpPostedFileBase postedFile = Request.Files[0];
                string filePath = Path.Combine(path, postedFile.FileName);
                postedFile.SaveAs(filePath);
                visitor.DocumentName = postedFile.FileName;

            }
            var date = DateTime.Now;

            visitor.AddedOn = date;
            visitor.FirstName = form["FirstName"];
            visitor.LastName = form["LastName"];
            visitor.CompanyName = form["CompanyName"];
            visitor.Gender = Convert.ToInt32(form["Gender"]);
            visitor.VisitorType = Convert.ToInt32(form["VisitorType"]);
            visitor.Department = Convert.ToInt32(form["Department"]);
            visitor.Officer = Convert.ToInt32(form["Officer"]);
            visitor.AadharNo = Convert.ToString(form["AadharNo"]);
            visitor.DocumentType = Convert.ToInt32(form["DocumentType"]);
            visitor.VisitorAddress = form["VisitorAddress"];
            visitor.VisitPurpose = form["VisitPurpose"];
            visitor.Phone = form["Phone"];
            visitor.Email = form["Email"];


            string tokenNo = RandomDigits(10);
            visitor.TokenNo = tokenNo;
            ViewBag.tokenNo = tokenNo;
            int result = visitorService.AddVisitorDetails(visitor);


            if (result > 0)
            {

                string message = "SUCCESS";
                response.Message = message;
                response.TokenNo = tokenNo;

                return Json(response, JsonRequestBehavior.AllowGet);
            }
            else
            {

                string message = "FAILED";
                response.Message = message;
                response.TokenNo = tokenNo;
                return Json(response, JsonRequestBehavior.AllowGet);
            }

        }

        public string RandomDigits(int length)
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < length; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return s;
        }

        public void SaveImage(string image, string TokenNo)
        {
            List<VisitorModel> JOAttachmentList = new List<VisitorModel>();

            VisitorModel data = new VisitorModel();
            if (string.IsNullOrEmpty(image))
                return;
            //int userid = Convert.ToInt32(userId);
            var t = image.Substring(22);  // remove data:image/png;base64,

            byte[] bytes = Convert.FromBase64String(t);

            var randomFileName = Guid.NewGuid().ToString().Substring(0, 4) + ".png";
            var fullPath = Path.Combine(Server.MapPath("~/Images/Visitor_liveImage/"), randomFileName);
            if (!Directory.Exists(Server.MapPath("~/Images/Visitor_liveImage/")))
            {
                Directory.CreateDirectory(Server.MapPath("~/Images/Visitor_liveImage/"));
            }
            System.IO.File.WriteAllBytes(fullPath, bytes);

            data.VisitorPic = randomFileName;

            int liveimage = visitorRepository.UploadLiveImage( randomFileName, TokenNo);
           



        }
        public JsonResult InActiveVisitor(int ID)
        {
            DataTable result = visitorRepository.DeleteEnquiry(ID);

            string message = "SUCCESS";
            return Json(message, JsonRequestBehavior.AllowGet);
        }
        
        
        public JsonResult BlockVisitor(int ID)
        {
            DataTable result = visitorRepository.BlockVisitor(ID);

            string message = "SUCCESS";
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public VisitorModel ViewVisitorByID(int ID)
        {

            VisitorModel visitor = new VisitorModel();
            VisitorModel visitorDetails = visitorRepository.FetchVisitorDetailByID(ID);

            var jsonResult = Json(visitorDetails, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return visitor;
        }

        public JsonResult VisitorCheckOutByID(string TokenNo)
        {
            DataTable result = visitorRepository.VisitorCheckOut(TokenNo);

            string message = "SUCCESS";
            return Json(message, JsonRequestBehavior.AllowGet);
        }
        public JsonResult EditVisitorByID(int ID)
        {
            int id = Convert.ToInt32(ID);
            VisitorModel editvisitor = visitorService.EditVisitorByID(ID);

            var jsonResult = Json(editvisitor, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        public JsonResult AddVisitorByAdmin(FormCollection form)
        {
            VisitorModel visitor = new VisitorModel();

            if (Request.Files.Count > 0)
            {
                string path = Server.MapPath("~/Images/Visitor_liveImage");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);

                }

                HttpFileCollectionBase files = Request.Files;
                HttpPostedFileBase postedFile = Request.Files[0];
                string filePath = Path.Combine(path, postedFile.FileName);
                postedFile.SaveAs(filePath);
                visitor.VisitorPic = postedFile.FileName;

            }

            var date = DateTime.Now;

            visitor.PhotoForedit = form["PhotoForedit"];
            string PhotoForEdit = visitor.PhotoForedit;
            if (PhotoForEdit !="")
            {
                visitor.VisitorPic = form["PhotoForedit"];
            } 

            visitor.VisitorID = Convert.ToInt32(form["VisitorID"]);
            visitor.FirstName = form["FirstName"];
            visitor.LastName = form["LastName"];
            visitor.CompanyName = form["CompanyName"];
            visitor.Gender = Convert.ToInt32(form["Gender"]);
            visitor.VisitorType = Convert.ToInt32(form["VisitorType"]);
            visitor.Department = Convert.ToInt32(form["Department"]);
            visitor.Officer = Convert.ToInt32(form["Officer"]);
            visitor.AadharNo = Convert.ToString(form["AadharNo"]);
            visitor.DocumentType = Convert.ToInt32(form["DocumentType"]);
            visitor.VisitorAddress = form["VisitorAddress"];
            visitor.VisitPurpose = form["VisitPurpose"];
            visitor.Phone = form["Phone"];
            visitor.Email = form["Email"];


            string tokenNo = RandomDigits(10);
            visitor.TokenNo = tokenNo;

            int result = visitorService.AddVisitorByAdmin(visitor);

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
            string EmailID = visitorRepository.EmailValidation(Email);

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


        public ActionResult GetOfficersByDepartment(int departmentId)
        {
            List<EmployeeModel> bankName = visitorService.GetOfficersByDepartment(departmentId);
            var selectListItems = bankName.Select(x => new SelectListItem
            {
                Text = x.FirstName.ToString(),
                Value = x.ID.ToString()
            }).ToList();

            return Json(selectListItems);


        }

        [HttpPost]
        public ActionResult SaveFeedback(VisitorModel model)
        {

            int result = visitorService.SaveFeedback(model);

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


    }


}