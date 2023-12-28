using MVC.Domain.Model;
using MVC.Services;
using MVC.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Repository;
using System.Data;

namespace MVC.Web.Controllers
{
    public class AdminController : Controller
    {
        private AccountService accountService = new AccountService();
        private DepartmentRepository departmentRepository = new DepartmentRepository();
        private DesignationRepository designationRepository = new DesignationRepository();
        private EmployeeRepository employeeRepository = new EmployeeRepository();
        private ChaRegisterService chaService = new ChaRegisterService();
        private VisitorRepository visitorRepository = new VisitorRepository();

        private ChaPassRepository chaPassRepository = new ChaPassRepository();

        private AccountRepository accountRepository = new AccountRepository();

      
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
        public ActionResult Dashboard()
        {
            int roleid = Convert.ToInt32(roleId);
            int userid = Convert.ToInt32(userId);

            List<VisitorModel> visitors = visitorRepository.FetchAllVisitor(roleid, userid);
            ViewBag.VisitorCount = visitors.Count;

            DataTable UserDetail = visitorRepository.GetUserDetails(Convert.ToInt32(userId), Convert.ToInt32(roleId));

            ViewBag.FullName = UserDetail.Rows[0][0].ToString();
      

            DataTable AllCounts = visitorRepository.GetCountForDashboard();

            ViewBag.ChaRegister = AllCounts.Rows[0][1].ToString();
            ViewBag.Employee = AllCounts.Rows[1][1].ToString();
            ViewBag.Visitor = AllCounts.Rows[2][1].ToString();
            ViewBag.roleid = roleid;
            return View(visitors);  
        }

        public ActionResult Department()
        {
            List<DepartmentModel> department = departmentRepository.FetchDepartmentType();
            return View(department);
        }
        public ActionResult ChaMonthPass()
        {
            int roleid = Convert.ToInt32(roleId);
            int userid = Convert.ToInt32(userId);
            List<MonthlyPass> monthlyPasses = chaPassRepository.FetchChaMonthPassList(roleid, userid);
            return View(monthlyPasses);
        }
       

        public ActionResult AddDepartment()
        {
            return View();
        }

        public ActionResult Designation()
        {
            List<DesignationModel> designations = designationRepository.FetchDesignationType();
            return View(designations);
        }


        public ActionResult Employee()
        {
            List<EmployeeModel> employee = employeeRepository.FetchEmployeeType();

            List<SelectListModel> department = visitorRepository.GetDepartment();
            ViewBag.department = new SelectList(department, "ID", "Name");

            List<SelectListModel> designation = employeeRepository.GetDesignation();
            ViewBag.designation = new SelectList(designation, "ID", "Name");
            return View(employee);
        }

        public ActionResult AddDesignation()
        {
            return View();
        }

       

        public ActionResult AddEmployee()
        {

            List<SelectListModel> department = visitorRepository.GetDepartment();
            ViewBag.department = new SelectList(department, "ID", "Name");

            //List<SelectListModel> designation = visitorRepoitory.GetDesignation();
            //ViewBag.designation = new SelectList(designation, "ID", "Name");

            return View();
        }

        public ActionResult ViewEmployee()
        {
            return View();
        }

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

            int roleid =Convert.ToInt32(roleId);
            int userid = Convert.ToInt32(userId);
            ViewBag.roleid = roleid;
            List<VisitorModel> visitors = visitorRepository.FetchAllVisitor(roleid, userid);



            return View(visitors);
        }

        public ActionResult AddVisitor()
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

        public ActionResult ViewVisitor()
        {
            return View();
        }

        public ActionResult PreRegistor()
        {
            return View();
        }

        public ActionResult AddPreRegistor()
        {
            return View();
        }

        public ActionResult ViewPreRegistor()
        {
            return View();
        }



        public ActionResult Cha()
        {
            ChaRegisterService chaService = new ChaRegisterService();
            List<ChaRegisterEntity> allcha = chaService.GetChaSummaryList();
            //return View(allUnits);
            return View(allcha);
        }



        public JsonResult CHaReject(int ID)
        {
            ChaRegisterService chaService = new ChaRegisterService();
            int userid = Convert.ToInt32(userId);
            DataTable result = chaService.Rejectcha(ID, userid);
            string message = "SUCCESS";
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CHaAccept(int ID)
        {
            ChaRegisterService chaService = new ChaRegisterService();
            int userid =Convert.ToInt32(userId);
            DataTable result = chaService.Acceptcha(ID, userid);
            string message = "SUCCESS";
            return Json(message, JsonRequestBehavior.AllowGet);
        }



        public JsonResult GetCHaAnalysisDetails(int ID)
        {

            ChaRegisterEntity result = chaService.getChadetail(ID);

            var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;

        }


        public JsonResult VisitorCheckOutByID(string TokenNo)
        {
            DataTable result = accountRepository.CheckInVisitorByTokenNo(TokenNo);
            string msg = result.Rows[0][0].ToString();
            if (msg != "")
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

        public ActionResult UserDetail()
        {
            int RoleID = Convert.ToInt32(roleId);
            int UserID = Convert.ToInt32(userId);
            DataTable UserData = accountService.GetUserData(UserID, RoleID);
            ViewBag.UserName = UserData.Rows[0][2];
            ViewBag.UserEmail = UserData.Rows[0][1];
            return PartialView("_UserDetail");


            //return PartialView("SideMenu", MenuList);
        }

        public ActionResult LogOut()
        {
            
            Session.Abandon();

            return RedirectToAction("Login", "Account");
        }

    }
}