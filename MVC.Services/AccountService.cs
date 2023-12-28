using MVC.Domain.Model;
using MVC.Repository;
using MVC.Repository.Interface;
using MVC.Services.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Services
{
    public class AccountService : IAccountService
    {
        public AccountRepository accountRepostory = new AccountRepository();

 

        //public LoginUserDetail UserLogin(string name, string pass)
        //{
        //    DataTable loginData = new DataTable();
        //    loginData = accountRepostory.Login(name, pass);
        //    LoginUserDetail objLoginData = new LoginUserDetail();
        //    if (loginData.Rows.Count > 0)
        //    {

        //        foreach (DataRow row in loginData.Rows)
        //        {
        //            objLoginData.UserID = Convert.ToInt32(row["UserID"]);
        //            objLoginData.UserName = Convert.ToString(row["UserName"]);
        //            objLoginData.RoleID = Convert.ToInt32(row["RoleID"]);
             
         

        //        }
        //    }
        //    return objLoginData;
        //}

        public LoginUserDetail UserLogin(string userid, string password)
        {
            LoginUserDetail loginUserDetail = new LoginUserDetail();
            DataTable dt = accountRepostory.UserLogin(userid, password);

            foreach (DataRow dr in dt.Rows)
            {
                loginUserDetail.UserID = Convert.ToInt32(dr["UserID"]);
                loginUserDetail.RoleID = Convert.ToInt32(dr["RoleID"]);
                if (!String.IsNullOrEmpty(dr["DeptID"].ToString()))
                {
                    loginUserDetail.DeptID = Convert.ToInt32(dr["DeptID"]);
                }
                
                loginUserDetail.UserName = Convert.ToString(dr["Username"]);
            }
            return loginUserDetail;
        }

        public List<Menus> getUserMenus(int roleId, int userID)
        {
            List<Menus> menuList = new List<Menus>();
            menuList = accountRepostory.getUserMenus(roleId,userID);
            return menuList;
        }

 
        public int ResetPassword(string userid, int loginid, string otp, string action)
        {
            DataTable dt = new DataTable();
            dt = accountRepostory.ResetPassword(userid, loginid, otp, action);

            int result = 0;
            if (dt.Rows.Count > 0)
            {
                result = Convert.ToInt32(dt.Rows[0][0].ToString());
            }

            return result;
        }
        public ResponseMessage Login(string User, string Password)
        {
            ResponseMessage message = new ResponseMessage();
            try
            {
                DataTable data = new DataTable();
                data = accountRepostory.Login(User, Password);
                if (data != null)
                {
                    foreach (DataRow row in data.Rows)
                    {
                        message.Message = Convert.ToString(row["Message"]);
                        message.Status = Convert.ToInt32(row["Status"]);
                    }
                }
                return message;
            }
            catch (Exception ex)
            {
                message.Status = 0;
                message.Message = ex.Message;
                return message;
            }
        }
        public VisitorModel FetchProfileDetails(int ID)
        {
            List<VisitorModel> allprofiledetails = new List<VisitorModel>();
            VisitorModel ds = accountRepostory.FetchProfileDetails(ID);
            return ds;
        }

        public DataTable GetUserData(int UserID, int RoleID)
        {
            DataTable dt = new DataTable();

            dt = accountRepostory.GetUserData(UserID, RoleID);
            return dt;

        }

    }
}
