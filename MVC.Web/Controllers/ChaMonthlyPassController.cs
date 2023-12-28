using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Domain.Model;
using MVC.Repository;
using System.Data;
using MVC.Services;

namespace MVC.Web.Controllers
{


    public class ChaMonthlyPassController : Controller
    {

        private ChaPassRepository chaPassRepository = new ChaPassRepository();
        private string _userId; private string _roleId;

        public string userId
        {
            get { return Request.Cookies["UserID"] != null ? Request.Cookies["UserID"].Value : ""; }
            set { _userId = Request.Cookies["UserID"] != null ? Request.Cookies["UserID"].Value : ""; }
        }

        public string roleId
        {
            get { return Request.Cookies["UserRoleID"] != null ? Request.Cookies["UserRoleID"].Value : ""; }
            set { _roleId = Request.Cookies["UserRoleID"] != null ? Request.Cookies["UserRoleID"].Value : ""; }
        }
        public ActionResult AddChaMonthlyPassDetail(MonthlyPassModel MonthlyPassModel)
        {
            MonthlyPassModel.AddedBy = Convert.ToInt32(userId);
            //monthlyPass.CHAID  = Convert.ToInt32(userId);
            DataTable result = chaPassRepository.AddChaPassDetail(MonthlyPassModel);
            if (result !=null )
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

        public JsonResult ChaMonthPassRejected(int ID,int userid)
        {
            DataTable result = chaPassRepository.DeleteEnquiry(ID,userid);

            string message = "SUCCESS";
            return Json(message, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ChaMonthPassApproved(int ID)
        {
            ChaMonthPassService chaMonthPassService = new ChaMonthPassService();
            DataTable result = chaPassRepository.ChaMonthPassApproved(ID);
            string message = "SUCCESS";
            return Json(message, JsonRequestBehavior.AllowGet);
        }
      
    }
}