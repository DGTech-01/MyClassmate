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
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MVC.Web.Controllers
{
    public class ReportController : Controller
    {
        private VisitorRepository visitorRepository = new VisitorRepository();
        // GET: Employee
        private string _userId; private string _roleId; private string _username;

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
        public string username
        {
            get { return Request.Cookies["UserName"] != null ? Request.Cookies["UserName"].Value : ""; }
            set { _username = Request.Cookies["UserName"] != null ? Request.Cookies["UserName"].Value : ""; }
        }

        public ActionResult VisitorReport()
        {
            int roleID = Convert.ToInt32(roleId);
            int userID = Convert.ToInt32(userId);
            DateTime StartDate = new DateTime(DateTime.Now.Year, 11, 1);
            DateTime EndDate = DateTime.Now;
            List<VisitorModel> VisitorReportlst = visitorRepository.GetVisitorReportDetailsLists(StartDate, EndDate, roleID, userID);
            return View(VisitorReportlst);
        }


        public PartialViewResult PreRegistorReport()
        {


            return PartialView("Myview");
        }
        public ActionResult AttendanceReport()
        {
            return View();
        }

        public ActionResult Visitor()
        {
           
            return View();
        }

        public PartialViewResult GetVisitorReportDetailsList(DateTime StartDate, DateTime EndDate)
        {
            int roleID = Convert.ToInt32(roleId);
            int userID = Convert.ToInt32(userId);
           VisitorModel VisitorReportlst = visitorRepository.GetVisitorReportDetailsList(StartDate, EndDate, roleID, userID);

            DataTable dt = visitorRepository.GetvisitorReportDetail(StartDate, EndDate, roleID, userID);
            Session["VisitorSummary"] = dt;
            return PartialView("_VisitorReport", VisitorReportlst);
            
        }
 

        public ActionResult ExportToExcelVisitors()
        {
            DataTable CompanyMaster = new DataTable();


            var CompanyName = "VMS";
            var CompanyAddress = "";
            DataTable getMovementICDNew = (DataTable)Session["VisitorSummary"];


            GridView gridview = new GridView();
            gridview.DataSource = getMovementICDNew;


            gridview.DataBind();

            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=VisitorsReport.xls");
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))

                {

                    // render the GridView to the HtmlTextWriter
                    htw.Write("<table><tr><td  style='font-weight: bold; text-align: center'; colspan ='7'><strong style='font-size: 26px'>" + CompanyName + " <strong></td></tr>");
                    htw.Write("<table><tr><td  style='font-weight: bold; text-align: center'; colspan ='7'><strong style='font-size: 15px'>" + CompanyAddress + " <strong></td></tr>");
                    htw.Write("<table><tr><td  style='font-weight: bold; text-align: center'; colspan ='7'><strong style='font-size: 15px'>Complain Report<strong></td></tr>");

                    // htw.Write("<table><tr><td colspan='7'><h6 style='text-align:left'>  </h6></td></tr>");
                    gridview.RenderControl(htw);
                    // Output the GridView content saved into StringWriter
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }

            return View();
        }

    }
}