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


    public class DesignationController : Controller
    {

        private DesignationRepository designationRepository = new DesignationRepository();


        public JsonResult AddDesignation(DesignationModel designationModel)
        {

            DataTable result = designationRepository.AddDesignation(designationModel);
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

        public JsonResult DeleteDesignation(int ID)
        {
            DataTable result = designationRepository.DeleteDesignation(ID);

            string message = "SUCCESS";
            return Json(message, JsonRequestBehavior.AllowGet);
        }


    }
}