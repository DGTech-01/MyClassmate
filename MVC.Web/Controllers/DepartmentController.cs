using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Domain.Model;
using MVC.Repository;
using System.Data;


namespace MVC.Web.Controllers
{


    public class DepartmentController : Controller
    {

        private DepartmentRepository departmentRepository = new DepartmentRepository();

        public JsonResult AddDepartment(DepartmentModel DepartmentModel)
        {

            DataTable result = departmentRepository.AddDepartment(DepartmentModel);
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

        public JsonResult DeleteEnquiry(int ID)
        {
            DataTable result = departmentRepository.DeleteEnquiry(ID);

            string message = "SUCCESS";
            return Json(message, JsonRequestBehavior.AllowGet);
        }


    }
}