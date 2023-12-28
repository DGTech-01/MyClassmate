using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC.Domain.Model;
using MVC.Domain;
using MVC.Services;
using MVC.Services.Interface;
using System.Net;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Http;
using MoneyTransfer.Domain.ViewModel;
using System.Xml.Linq;
using System.Web.Routing;

namespace MVC.Web.Controllers
{
    public class AccountController : Controller
    {

       // private readonly AccountService accountService;

         AccountService accountService = new AccountService();
        //public AccountController(AccountService accountService)
        //{
        //    this.accountService = accountService;
        //}

        //public ActionResult UserRights()
        //{
        //    List<UserRights> model = accountService.GetUserRigths();
        //    return View(model);
        //}

        public ActionResult UserLogin()
        {  
            return View();
        }

        public ActionResult Login()
        {

            return View();
        }


        public ActionResult UserProfile()
        {
            int id = 22;
            VisitorModel visitorDetails = accountService.FetchProfileDetails(id);

            ViewBag.FirstName = visitorDetails.FirstName;
            ViewBag.LastName = visitorDetails.LastName;
            ViewBag.Email = visitorDetails.Email;
            ViewBag.Phone = visitorDetails.Phone;
            ViewBag.UserName = visitorDetails.UserName;
            ViewBag.Image = visitorDetails.VisitorPic;
            ViewBag.Address = visitorDetails.VisitorAddress;
          

            //var jsonResult = Json(visitorDetails, JsonRequestBehavior.AllowGet);
            //jsonResult.MaxJsonLength = int.MaxValue;



            return View();
        }
        public JsonResult ValidLogin(string User, string Password)
        {
            ResponseMessage message = new ResponseMessage();
            //  element.AddedBy = Convert.ToInt32(Session["userID"]);
            message = accountService.Login(User, Password);


            return Json(message);
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        //public JsonResult ResetPassword(string userID)
        //{
        //    Random generator = new Random();
        //    string randomOTP = generator.Next(0, 999999).ToString("D6");

        //    double UserID = Convert.ToDouble(userID);

        //    int result = accountService.ResetPassword(userID, 0, randomOTP, "FGTPWD");

        //    if (result == 1)
        //    {
        //        string message = "Your pocketmoney One Time Password(OTP) is " + randomOTP + ". Do not share this OTP to anyone for security reasons.";
        //        _mailRepository.SendWhattsupMessage(userID, message);
        //        SendEmail(randomOTP, userID);
        //        return Json(new { Success = true, message = "" }, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
        //    }
        //}

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User loginEntities)
        {
            // BE.LoginEntites loginEntities = new BE.LoginEntites();
            var name = loginEntities.UserName;
            var pass = loginEntities.Password;
            Boolean rememberme = Convert.ToBoolean(loginEntities.Remember);


           // var password = EncryptionLibrary.EncryptText(loginViewModel.Password);

            var logindata = accountService.UserLogin(name, pass);

            if (logindata.UserID != 0)
            {
                //Start Validation to Authenticate User For Valid URL Access
               
                //Message = ValidateURLUserLogin(logindata.UserID, Request.Url.Host);
                //if (Message != "" && Message != "Success")
                //{
                //    logindata.LoginErrorMessage = Message;
                //    return View("index", logindata);
                //}

                //End Validation to Authenticate User For Valid URL Access

                Session["userid"] = logindata.UserID;
                Session["username"] = logindata.UserName;
                //Session["department"] = logindata.DepType;
                //Session["companycode"] = logindata.ConCode;

                //List<BE.NotificationList> displayNotificaitonList = new List<BE.NotificationList>();
                //displayNotificaitonList = objLogin.UserNotificationList(logindata.UserID.ToString());


                //Session["alertCount"] = displayNotificaitonList.Count();

                //// Session["DisplayUserList"] = newList;
                //Session["DisplayUserList"] = displayNotificaitonList;
                ////List<BE.UserList> bst = (List<BE.UserList>)Session["DisplayUserList"];

                HttpCookie usercookies = new HttpCookie("usercookies");
                usercookies["userid"] = Convert.ToString(logindata.UserID);
                usercookies["username"] = logindata.UserName; ;
                //usercookies["password"] = logindata.UserPass;
                //usercookies["department"] = logindata.DepType;
                //usercookies["companycode"] = logindata.ConCode;
                Response.Cookies.Add(usercookies);

                RememberMe(name, pass, rememberme, Convert.ToString(logindata.UserID));
                //  return RedirectToAction("Dashboard");
                if (logindata.UserType == "Admin" & logindata.UserID == 141 || logindata.UserType == "User" & logindata.UserID == 128)
                {
                    return RedirectToAction("AdminDashboard", "User");
                }
                else
                {

                    return RedirectToAction("Dashboard", "Dashboard");
                }

            }
            else
            {
                //logindata.message = "Wrong Username or Password.";
                //  return View("index");
                return View("Login", logindata);
            }
        }

        private void RememberMe(String name, String password, Boolean rememberme, String UserId)
        {

            if (rememberme)
            {
                HttpCookie usercookies = new HttpCookie("usercookies");
                usercookies["userid"] = UserId;
                usercookies["username"] = name;
                usercookies["password"] = password;
                //usercookies["department"] = DepType;
                //usercookies["companycode"] = ConCode;
                Response.Cookies.Add(usercookies);

                //HttpCookie userinfo = new HttpCookie("userinfo");
                //userinfo["username"] = name;
                //userinfo["password"] = password;
                usercookies.Expires = DateTime.Now.AddDays(30);
                //Response.Cookies.Add(userinfo);
            }
            else
            {
                HttpCookie vms_userInfo = new HttpCookie("usercookies");
                vms_userInfo.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(vms_userInfo);

            }
        }

        //[NonAction]
        //public void remove_Anonymous_Cookies()
        //{
        //    if (Request.Cookies["MoneyTransferChannel"] != null)
        //    {
        //        CookieOptions option = new CookieOptions();
        //        option.Expires = DateTime.Now.AddDays(-1);
        //        Response.Cookies.Append("MoneyTransferChannel", "", option);
        //    }
        //}

        public ActionResult AdminDashboard()
        {
            return View();
        }

        public ActionResult UserDashboard()
        {
            return View();
        }

        //public ActionResult AdminMenu()
        //{
        //    List<Menus> MenuList = new List<Menus>();

        //    int userid = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
        //    MenuList = accountService.GetSideMenu(userid);
        //    //HttpContext.Session.SetString["MenuList"] = MenuList;
        //    return PartialView("_AdminMenu", MenuList);

        //}


        public ActionResult Menus()
        {
            LoginUserDetail loginUserDetail = null;
            string userName = string.Empty;
            double userID = 1;
            int userRole = 1;
            List<Menus> menuData = null;

            loginUserDetail = (LoginUserDetail)Session["LoginUserDetail"];


            #region Based on login credentials, set properties
            if (loginUserDetail == null)
            {
                //  cf.LogoutUser(Session, Response);//
                RedirectToAction("Login");
                RedirectToAction("Login", "Account");
                // return RedirectToAction("Login","Account");
                new RedirectToRouteResult(new RouteValueDictionary { { "action", "Login" }, { "controller", "Account" } });
            }
            else if (loginUserDetail != null)
            {
                menuData = accountService.getUserMenus(loginUserDetail.RoleID, loginUserDetail.UserID);
            }
            #endregion
            return PartialView("_Menus", menuData);

        }





        //public ActionResult SideMenus()
        //{

        //    List<Menus> MenuList = new List<Menus>();

        //    int roleID = Convert.ToInt32(Session["roleID"]);

        //    MenuList = accountService.GetSideMenu(roleID);
        //    //HttpContext.Session.SetString["MenuList"] = MenuList;
        //    Session["MenuList"] = MenuList; 
        //    return PartialView("_SideMenu", MenuList);
        //}

        //public ActionResult SideMenu()
        //{
        //    Menus menus = null;
        //    string userName = string.Empty;
        //    double userID = 1;
        //    int userRole = 1;
        //    List<Menus> menuData = null;

        //    menus = (Menus)Session["Menus"];

        //    loginUserDetail = (LoginUserDetail)Session["LoginUserDetail"];

        //    #region Based on login credentials, set properties
        //    if (menus == null)
        //    chaService
        //        //  cf.LogoutUser(Session, Response);//
        //        RedirectToAction("Login");
        //        RedirectToAction("Login", "Auth");
        //        // return RedirectToAction("Login","Account");
        //        new RedirectToRouteResult(new RouteValueDictionary { { "action", "Login" }, { "controller", "Auth" } });
        //    }
        //    else if (menus != null)
        //    {
        //        menuData = accountService.getUserMenus(loginUserDetail.RoleID, loginUserDetail.UserID);
        //    }
        //    #endregion
        //    return PartialView("_Menus", menuData);

        //}








       

        //vivekworks

        //public JsonResult LoginSubmit(string email, string password)
        //{
        //    LoginUserDetail lLoginUserDetail = accountService.UserLogin(email, password);
        //    if (lLoginUserDetail != null && lLoginUserDetail.UserID > 0)
        //    {
        //        Session["LoginUserDetail"] = lLoginUserDetail;
        //        //Response.Redirect(CommonFunctions.DefaultPage);
        //        return Json(new { message = "SUCCESS" }, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(new { message = "FAILED" }, JsonRequestBehavior.AllowGet);
        //    }
        //}









        public JsonResult LoginSubmit(string email, string password)
        {
            // LoginUserDetail lLoginUserDetail = accountRepository.IsUserValid(uname, upwd, utype);
            LoginUserDetail lLoginUserDetail = accountService.UserLogin(email, password);
            if (lLoginUserDetail != null && lLoginUserDetail.UserID > 0)
            {
                Session["LoginUserDetail"] = lLoginUserDetail;
                //Session["UseID"] = lLoginUserDetail.UserID.ToString();
                //Session["RoleID"] = lLoginUserDetail.RoleID.ToString();
                //Session["DeptID"] = lLoginUserDetail.DeptID.ToString();
                //Session["UserName"] = lLoginUserDetail.UserName.ToString();

                Response.Cookies["UserID"].Value = lLoginUserDetail.UserID.ToString();
                Response.Cookies["UserName"].Value = lLoginUserDetail.UserName.ToString();
                Response.Cookies["UserRoleID"].Value = lLoginUserDetail.RoleID.ToString();
            
                Response.Cookies["UserID"].Expires = DateTime.Now.AddHours(2);
                Response.Cookies["UserRoleID"].Expires = DateTime.Now.AddHours(2);


                ViewBag.roleid = Response.Cookies["UserRoleID"].Value;
                int role = Convert.ToInt32(ViewBag.roleid);

                return Json(new { message = "SUCCESS", roleid=lLoginUserDetail.RoleID  }, JsonRequestBehavior.AllowGet);


            }
            else
            {
                return Json(new { message = "FAILED", roleid=0 }, JsonRequestBehavior.AllowGet);

            }
        }


    }
} 