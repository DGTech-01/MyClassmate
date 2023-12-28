using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Domain.Model;
using MVC.Repository;
using System.Data;
using MVC.Services;
using System.IO;

namespace MVC.Web.Controllers
{


    public class EmployeeController : Controller
    {

        private EmployeeRepository employeeRepository = new EmployeeRepository();
        private EmployeeService employeeService = new EmployeeService();

      

        public JsonResult AddEmployee(FormCollection form)
        {
            EmployeeModel employee = new EmployeeModel();

            if (Request.Files.Count > 0)
            {
                string path = Server.MapPath("~/Images/OfficersImgs");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);

                }

                HttpFileCollectionBase files = Request.Files;
                HttpPostedFileBase postedFile = Request.Files[0];
                string filePath = Path.Combine(path, postedFile.FileName);
                postedFile.SaveAs(filePath);
                employee.Image = postedFile.FileName;

            }
            else if (Request.Files.Count == 0)
            {
                employee.PhotoForedit = form["PhotoForedit"];
                string PhotoForEdit = employee.PhotoForedit;
                if (PhotoForEdit != "")
                {
                    employee.Image = form["PhotoForedit"];
                }
            }
            
            var date = DateTime.Now;

            
            employee.ID = Convert.ToInt32(form["ID"]);

            employee.AddedOn = Convert.ToDateTime(date);
            employee.FirstName = form["FirstName"];
            employee.LastName = form["LastName"];
            employee.Email = form["Email"];
            employee.Phone = Convert.ToString(form["Phone"]);
            employee.JoiningDate = Convert.ToString(form["JoiningDate"]);
            employee.Gender = Convert.ToInt32(form["Gender"]);
            employee.Department = Convert.ToInt32(form["Department"]);
            employee.Designation = Convert.ToInt32(form["Designation"]);
            employee.Password1 = Convert.ToString(form["Password1"]);
            employee.Password2 = Convert.ToString(form["Password2"]);
            employee.About = Convert.ToString(form["About"]);
            employee.IsActive = Convert.ToInt32(form["IsActive"]);
            int result = employeeService.AddEmployeeDetails(employee);

            if(result>=0)
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
        public ActionResult Employee()
        {
            List<SelectListModel> department = employeeRepository.GetDepartment();
            ViewBag.department = new SelectList(department, "ID", "Name");

            List<SelectListModel> designation = employeeRepository.GetDesignation();
            ViewBag.designation = new SelectList(designation, "ID", "Name");

         

            List<EmployeeModel> employees = employeeRepository.FetchEmployeeType();
            return View(employees);

        }

     
        public JsonResult GetEmployeeByID(int ID)
        {
            int id = Convert.ToInt32(ID);
            EmployeeModel employeeDetails = employeeService.FetchEmployeeByID(ID);

            var jsonResult = Json(employeeDetails, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }


        public JsonResult InActiveEmployee(int ID)
        {
            DataTable result = employeeRepository.DeleteEnquiry(ID);

            string message = "SUCCESS";
            return Json(message, JsonRequestBehavior.AllowGet);
        }

    }
}