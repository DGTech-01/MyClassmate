using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Domain.Model;
using MVC.Repository;
using System.Data;
using QRCoder;
using System.Drawing;
using System.IO;


namespace MVC.Web.Controllers
{
    public class CheckInController : Controller
    {

        VisitorRepository visitorRepository = new VisitorRepository();

        public ActionResult StepTwo()
        {
            return View();
        }
        public ActionResult ShowCheckIn(string token)
        {
            VisitorModel model = visitorRepository.FetchVisitorByTokenNO(token);
            ViewBag.VisitorName = model.FirstName + " " + model.LastName;
            ViewBag.Phone = model.Phone;

            ViewBag.Officer = model.OfficerName;
            ViewBag.VisitorPic = model.VisitorPic;
            ViewBag.Email = model.Email;
            

            string SignedQRcode = "";

            SignedQRcode = token;

            if (SignedQRcode != "")
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();

                QRCodeData qrCodeData = qrGenerator.CreateQrCode(SignedQRcode, QRCodeGenerator.ECCLevel.Q);

                QRCode qrCode = new QRCode(qrCodeData);

                // I am getting error in above line, or I am using below line of code but getting error. Unable to access QRCode withQRCodeGenerator.

                //QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(ViewBag.SignedQRcode, QRCodeGenerator.ECCLevel.Q);

                using (Bitmap bitMap = qrCode.GetGraphic(20))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        byte[] byteImage = ms.ToArray();
                        ViewBag.path = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                    }
                }
            }


            return View();
        }
        public ActionResult ScanQr()
        {
            //VisitorModel viewvisitorpassdetail = new  VisitorModel();
            //ViewBag.VisitorName = viewvisitorpassdetail.FirstName + " " + viewvisitorpassdetail.LastName;
            //ViewBag.Token = viewvisitorpassdetail.TokenNo;
            //ViewBag.Officer = viewvisitorpassdetail.OfficerName;
            //ViewBag.Department = viewvisitorpassdetail.DepartmentName;
            return View();
        }
        public ActionResult ViewVisitor(string token)
        {
            VisitorModel model = visitorRepository.FetchVisitorByTokenNO(token);
            ViewBag.VisitorName = model.FirstName + " " + model.LastName;
            ViewBag.Phone = model.Phone;
            ViewBag.VisitorPic = model.VisitorPic;
            ViewBag.Officer = model.OfficerName;
     
            ViewBag.Email = model.Email;

            return View();
        }
        public JsonResult ValidateVisitor(string Token)
        {
            ValidateVisitor response = new ValidateVisitor();
            int ID = visitorRepository.ValidateVisitor(Token);

            if (ID > 0)
 
            {
                string message = "SUCCESS";
                response.Message = message;
                response.VisitorID = ID;
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            else
            {

                string message = "FAILED";
                response.Message = message;
                response.VisitorID = ID;
                return Json(response, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult AddVisitorCheckIn(string Token)
        {
            {

                DataTable result = visitorRepository.CheckInVisitorByTokenNo(Token);
                if (result != null)
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

        public JsonResult VisitorLogEntry(string Token)
        {
            ValidateVisitor response = new ValidateVisitor();
            DataTable result = visitorRepository.CheckInVisitorByTokenNo(Token);
            if (result != null)
            {
                string message = "SUCCESS";
                response.Message = message;
               
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            else
            {

                string message = "SUCCESS";
                response.Message = message;
               
                return Json(message, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult ViewVisitorPassDetails(string token)
        {
            string TokenNo = Convert.ToString(token);
            VisitorModel viewvisitorpassdetail = visitorRepository.ViewVisitorPassDetails(TokenNo);

            var jsonResult = Json(viewvisitorpassdetail, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

    }
}




