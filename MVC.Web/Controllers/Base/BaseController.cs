using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Routing;
using MVC.Domain.Model;



namespace MVC.Web.Controllers
{
    public class BaseController : Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            try
            {
               
            }
            catch (Exception)
            {
            }

        }



        private void UnAuthoRedirect(ActionExecutingContext context)
        {
            //context.HttpContext.Response.Redirect(Url.Action("unauthorized", "Account"));
            context.HttpContext.Response.Redirect("~/Account/unauthorized");
        }

        private class MenuOfRole
        {
            public string MenuURL { get; set; }
            public int RoleId { get; set; }
            public Nullable<int> UserId { get; set; }
            public bool IsCreate { get; set; }
            public bool IsRead { get; set; }
            public bool IsUpdate { get; set; }
            public bool IsDelete { get; set; }
        }


        private bool IsThisAjaxRequest()
        {
            bool result = false;
            var currentContext = new HttpContextWrapper(System.Web.HttpContext.Current);
            if (currentContext.Request.Headers["X-Requested-With"] != null
                && currentContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                result = true;
            }

            return result;
        }

    }
}
