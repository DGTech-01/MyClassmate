using MVC.DB;
using MVC.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Domain.Model;

namespace MVC.Repository
{
    public class AccountRepository : IAccountRepository
    {

        private CommonService commonConnectivity = new CommonService();
        //public AccountRepository(ICommonConnectivity commonConnectivity)
        //{
        //    this.commonConnectivity = commonConnectivity;
        //}
        public DataTable Login(string Email, string password)
        {
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@strUserEmail", Email);
            sqlParameters[1] = new SqlParameter("@strPassword", password);

            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspLogin]", sqlParameters);

            return dt;
        }

        //public DataTable UserLogin(User user)
        //{
        //    SqlParameter[] sqlParameters = new SqlParameter[8];
        //    sqlParameters[0] = new SqlParameter("@UserName", user.UserName);
        //    sqlParameters[1] = new SqlParameter("@", password);
        //    return 
        //}

        public DataTable UserLogin(string userid, string password)
        {
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@strUserEmail", userid);
            sqlParameters[1] = new SqlParameter("@strPassword", password);


            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspLogin]", sqlParameters);

            return dt;
        }


        public DataTable UserRights()
        {
            SqlParameter[] sqlParameters = new SqlParameter[0];
            //sqlParameters[0] = new SqlParameter("@UserID", userid);

            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspGetUserRights]", sqlParameters);

            return dt;
        }
        public List<Menus> getUserMenus(int roleId, int userID)
        {
            List<Menus> menuList = new List<Menus>();
            DataTable dt = new DataTable();

            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@RoleID", roleId);
            sqlParameters[1] = new SqlParameter("@UserID", userID);

            dt = commonConnectivity.ExecuteStoredProcedures("[uspGetUserMenus]", sqlParameters);

            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Menus menus = new Menus();
                    menus.MenuId = Convert.ToInt32(row["MenuID"]);
                    menus.ParentMenuId = Convert.ToInt32(row["ParentID"]);
                    menus.Title = Convert.ToString(row["Text"]);
                    menus.Description = Convert.ToString(row["Description"]);
                    menus.Url = Convert.ToString(row["NavigateUrl"]);
                    menus.Icons = Convert.ToString(row["Icons"]);
                    menus.NewUrl = Convert.ToString(row["NewNavigateUrl"]);
                    // menus.NewIcons = Convert.ToString(row["NewIcons"]);

                    menuList.Add(menus);
                }
            }
            return menuList;
        }












        //public DataTable GetSideMenu(int roleID)
        //{
        //    SqlParameter[] sqlParameters = new SqlParameter[1];
        //    sqlParameters[0] = new SqlParameter("@RoleID", roleID);

        //    DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspGetUserMenus]", sqlParameters);

        //    return dt;
        //}

        public DataTable ResetPassword(string userid, int loginid, string otp, string action)
        {
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@intUserID", userid);
            sqlParameters[1] = new SqlParameter("@intLoginID", loginid);
            sqlParameters[2] = new SqlParameter("@strOTP", otp);
            sqlParameters[3] = new SqlParameter("@Action", action);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspForgetPassword]", sqlParameters);
            return dt;
        }



        //vivekworks


        public UserLogin IsUserValid(string pUserEmail, string pPassword)
        {
            UserLogin ReturnData = null;

            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[2];
                sqlParameters[0] = new SqlParameter("@strUserEmail", pUserEmail);
                sqlParameters[1] = new SqlParameter("@strPassword", pPassword);
     
                DataTable dt = commonConnectivity.ExecuteStoredProcedures("uspLogin", sqlParameters);

                if (dt.Rows.Count > 0)
                {
                    #region Set values of the user login object
                    ReturnData = new UserLogin()
                    {
                        UserId = dt.Rows[0]["UserID"].ToString(),
                        UserName = dt.Rows[1]["UserName"].ToString(),
                  
                
                        IsSessionAlive = true,
                        BlockedOn = DateTime.Now,
                    };

                    #endregion
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return ReturnData;
        }
        public DataTable CheckInVisitorByTokenNo(string Token)
        {

            DataTable dt = new DataTable();

            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@TokenNo", Token);
            sqlParameters[1] = new SqlParameter("@Time", DateTime.Now);



            dt = commonConnectivity.ExecuteStoredProcedures("[uspVisitorCheckInOutLog]", sqlParameters);

            return dt;
        }
        public VisitorModel FetchProfileDetails(int ID)
        {

            VisitorModel profiledetails = new VisitorModel();
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspFetchProfileDetails]", sqlParameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {

                    profiledetails.ID = Convert.ToInt32(row["VisitorID"]);
                    profiledetails.FirstName = Convert.ToString(row["VisitorFirstName"]);
                    profiledetails.LastName = Convert.ToString(row["VisitorLastName"]);
                    profiledetails.Email = Convert.ToString(row["Email"]);
                    profiledetails.Phone = Convert.ToString(row["Phone"]);
                    profiledetails.VisitorPic = Convert.ToString(row["VisitorPic"]);
                    profiledetails.VisitorAddress = Convert.ToString(row["VisitorAddress"]);
                    profiledetails.UserName = Convert.ToString(row["UserName"]);

                    
                }
            }
            return profiledetails;
        }

        public DataTable GetUserData(int UserID, int RoleID)
        {
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@UserID", UserID);
            sqlParameters[1] = new SqlParameter("@RoleID", RoleID);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspGetUserData]", sqlParameters);
            return dt;
        }

    }
}
