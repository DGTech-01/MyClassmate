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
using System.Configuration;

namespace MVC.Repository
{
    public class VisitorRepository : IVisitorRepository
    {

        private CommonService commonConnectivity = new CommonService();

        public int AddVisitorDetails(VisitorModel visitorEntity)
        {


            SqlParameter[] sqlParameters = new SqlParameter[15];

            sqlParameters[0] = new SqlParameter("@VISITORFIRSTNAME", visitorEntity.FirstName);
            sqlParameters[1] = new SqlParameter("@VISITORLASTNAME", visitorEntity.LastName);
            sqlParameters[2] = new SqlParameter("@COMPANYNAME", visitorEntity.CompanyName);
            sqlParameters[3] = new SqlParameter("@GENDERID", visitorEntity.Gender);
            sqlParameters[4] = new SqlParameter("@VISITORTYPEID", visitorEntity.VisitorType);
            sqlParameters[5] = new SqlParameter("@DEPARTMENTID", visitorEntity.Department);
            sqlParameters[6] = new SqlParameter("@OFFICERID", visitorEntity.Officer);
            sqlParameters[7] = new SqlParameter("@AADHARNO", visitorEntity.AadharNo);
            sqlParameters[8] = new SqlParameter("@DOCUMENTTYPEID", visitorEntity.DocumentType);
            sqlParameters[9] = new SqlParameter("@VISITORADDRESS", visitorEntity.VisitorAddress);
            sqlParameters[10] = new SqlParameter("@VISITPURPOSE", visitorEntity.VisitPurpose);
            sqlParameters[11] = new SqlParameter("@Phone", visitorEntity.Phone);
            sqlParameters[12] = new SqlParameter("@Email", visitorEntity.Email);
            sqlParameters[13] = new SqlParameter("@TOKENNO", visitorEntity.TokenNo);
            sqlParameters[14] = new SqlParameter("@DocumentName", visitorEntity.DocumentName);

            int result = commonConnectivity.ExecuteInsertQueryReturn("[uspAddVisitorDetail]", sqlParameters);

            return result;
        }

        public int AddVisitorByAdmin(VisitorModel visitorEntity)
        {

            SqlParameter[] sqlParameters = new SqlParameter[16];
            sqlParameters[0] = new SqlParameter("@VISITORFIRSTNAME", visitorEntity.FirstName);
            sqlParameters[1] = new SqlParameter("@VISITORLASTNAME", visitorEntity.LastName);
            sqlParameters[2] = new SqlParameter("@COMPANYNAME", visitorEntity.CompanyName);
            sqlParameters[3] = new SqlParameter("@GENDERID", visitorEntity.Gender);
            sqlParameters[4] = new SqlParameter("@VISITORTYPEID", visitorEntity.VisitorType);
            sqlParameters[5] = new SqlParameter("@DEPARTMENTID", visitorEntity.Department);
            sqlParameters[6] = new SqlParameter("@OFFICERID", visitorEntity.Officer);
            sqlParameters[7] = new SqlParameter("@AADHARNO", visitorEntity.AadharNo);
            sqlParameters[8] = new SqlParameter("@DOCUMENTTYPEID", visitorEntity.DocumentType);
            sqlParameters[9] = new SqlParameter("@VISITORADDRESS", visitorEntity.VisitorAddress);
            sqlParameters[10] = new SqlParameter("@VISITPURPOSE", visitorEntity.VisitPurpose);
            sqlParameters[11] = new SqlParameter("@Phone", visitorEntity.Phone);
            sqlParameters[12] = new SqlParameter("@Email", visitorEntity.Email);
            sqlParameters[13] = new SqlParameter("@VISITORPIC", visitorEntity.VisitorPic);
            sqlParameters[14] = new SqlParameter("@TOKENNO", visitorEntity.TokenNo);
            sqlParameters[15] = new SqlParameter("@ID", visitorEntity.VisitorID);

            int result = commonConnectivity.ExecuteInsertQueryReturn("[uspAddVisitorByAdmin]", sqlParameters);

            return result;
        }

        public List<VisitorModel> FetchAllVisitor(int roleid ,int userid)

        {
            List<VisitorModel> allvisitors = new List<VisitorModel>();
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@roleid", roleid);
            sqlParameters[1] = new SqlParameter("@userid", userid);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspFetchAllVisitor]", sqlParameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    VisitorModel visitor = new VisitorModel();
                    visitor.ID = Convert.ToInt32(row["VisitorID"]);
                    visitor.FirstName = Convert.ToString(row["Name"]);
                    visitor.Email = Convert.ToString(row["Email"]);
                    visitor.OfficerName = Convert.ToString(row["Officer"]);
                    visitor.CheckIn = Convert.ToString(row["CheckIn"]);
                    visitor.CheckOut = Convert.ToString(row["CheckOut"]);
                    visitor.VisitorPic = Convert.ToString(row["VisitorPic"]);
                    visitor.IsActive = Convert.ToInt32(row["IsActive"]);
                    visitor.TokenNo = Convert.ToString(row["TokenNo"]);
                    if (!String.IsNullOrEmpty(row["IsBlocked"].ToString()))
                    {
                        visitor.IsBlocked = Convert.ToInt32(row["IsBlocked"]);
                    }
                    if (!String.IsNullOrEmpty(row["Feedback"].ToString()))
                    {
                        visitor.Feedback = Convert.ToString(row["Feedback"]);
                    }
                    //visitor.IsBlocked = Convert.ToInt32(row["IsBlocked"]);

                    allvisitors.Add(visitor);

                }
            }
            return allvisitors;
        }

        public List<SelectListModel> GetDepartment()
        {
            List<SelectListModel> selectListModels = new List<SelectListModel>();

            SqlParameter[] sqlParameters = new SqlParameter[0];
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspSelect_Department_Name]", sqlParameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                SelectListModel lstModel1 = new SelectListModel();
                lstModel1.ID = 0;
                lstModel1.Name = "--Select Department--";
                selectListModels.Add(lstModel1);


                foreach (DataRow row in dt.Rows)
                {
                    SelectListModel lstModel = new SelectListModel();

                    lstModel.ID = Convert.ToInt32(row["ID"].ToString());

                    lstModel.Name = Convert.ToString(row["Department"]);

                    selectListModels.Add(lstModel);

                }
            }
            return selectListModels;
        }

        public List<SelectListModel> GetVisitor()
        {
            List<SelectListModel> selectListModels = new List<SelectListModel>();

            SqlParameter[] sqlParameters = new SqlParameter[0];
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspSelect_VisitorType]", sqlParameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                SelectListModel lstModel1 = new SelectListModel();
                lstModel1.ID = 0; 
                lstModel1.Name = "--Select Visitor Type--";
                selectListModels.Add(lstModel1);


                foreach (DataRow row in dt.Rows)
                {
                    SelectListModel lstModel = new SelectListModel();

                    lstModel.ID = Convert.ToInt32(row["VisitorTypeID"].ToString());

                    lstModel.Name = Convert.ToString(row["VisitorType"]);

                    selectListModels.Add(lstModel);

                }
            }
            return selectListModels;
        }

        public List<SelectListModel> GetOfficer()
        {
            List<SelectListModel> selectListModels = new List<SelectListModel>();

            SqlParameter[] sqlParameters = new SqlParameter[0];
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspSelect_Officer_Name]", sqlParameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                SelectListModel lstModel1 = new SelectListModel();
                lstModel1.ID = 0;
                lstModel1.Name = "--Select Office--";
                selectListModels.Add(lstModel1);


                foreach (DataRow row in dt.Rows)
                {
                    SelectListModel lstModel = new SelectListModel();

                    lstModel.ID = Convert.ToInt32(row["ID"].ToString());

                    lstModel.Name = Convert.ToString(row["Name"]);

                    selectListModels.Add(lstModel);

                }
            }
            return selectListModels;
        }
        public List<SelectListModel> GetDocument()
        {
            List<SelectListModel> selectListModels = new List<SelectListModel>();

            SqlParameter[] sqlParameters = new SqlParameter[0];
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspSelect_DocumentType]", sqlParameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                SelectListModel lstModel1 = new SelectListModel();
                lstModel1.ID = 0;
                lstModel1.Name = "--Select Document Type--";
                selectListModels.Add(lstModel1);


                foreach (DataRow row in dt.Rows)
                {
                    SelectListModel lstModel = new SelectListModel();

                    lstModel.ID = Convert.ToInt32(row["DocTypeID"].ToString());

                    lstModel.Name = Convert.ToString(row["DocType"]);

                    selectListModels.Add(lstModel);

                }
            }
            return selectListModels;
        }
         public List<SelectListModel> GetUSerType()
        {
            List<SelectListModel> selectListModels = new List<SelectListModel>();

            SqlParameter[] sqlParameters = new SqlParameter[0];
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspSelect_UserTypeID]", sqlParameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                SelectListModel lstModel1 = new SelectListModel();
                lstModel1.ID = 0;
                lstModel1.Name = "--Select User Type--";
                selectListModels.Add(lstModel1);


                foreach (DataRow row in dt.Rows)
                {
                    SelectListModel lstModel = new SelectListModel();

                    lstModel.ID = Convert.ToInt32(row["ID"].ToString());

                    lstModel.Name = Convert.ToString(row["Name"]);

                    selectListModels.Add(lstModel);

                }
            }
            return selectListModels;
        }

        public VisitorModel FetchVisitorByTokenNO(string token)
        {

            VisitorModel visitor = new VisitorModel();
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@TOKENNO", token);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspFetchVisitorByToken]", sqlParameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {


                    visitor.FirstName = Convert.ToString(row["VisitorFirstName"]);
                    visitor.LastName = Convert.ToString(row["VisitorLastName"]);
                    visitor.Phone = Convert.ToString(row["Phone"]);
                    //visitor.ID = Convert.ToInt32(row["VisitorID"]);
                    visitor.TokenNo = Convert.ToString(row["TokenNo"]);
                    visitor.OfficerName = Convert.ToString(row["Officer"]);
                    visitor.VisitorPic = Convert.ToString(row["VisitorPic"]);
                    visitor.Email = Convert.ToString(row["Email"]);


                }
            }
            return visitor;
        }
    

        public VisitorModel ViewVisitor(string token)
        {

            VisitorModel Viewvisitor = new VisitorModel();
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@TOKENNO", token);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspViewVisitorByToken]", sqlParameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {

                    Viewvisitor.ID = Convert.ToInt32(row["ID"]);
                    Viewvisitor.FirstName = Convert.ToString(row["VisitorFirstName"]);
                    Viewvisitor.LastName = Convert.ToString(row["VisitorLastName"]);
                    Viewvisitor.Phone = Convert.ToString(row["Phone"]);
                    Viewvisitor.TokenNo = Convert.ToString(row["TokenNo"]);
                    Viewvisitor.Email = Convert.ToString(row["Email"]);
                    Viewvisitor.OfficerName = Convert.ToString(row["Officer"]);
                    //Viewvisitoror.VisitorPic = Convert.ToBase64CharArray(row["VisitorPic"])
                    Viewvisitor.Email = Convert.ToString(row["Email"]);


                }
            }
            return Viewvisitor;
        }


        public int ValidateVisitor(string token)
        {

            int ID = 0;
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@TOKENNO", token);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspCheckIsValidTokenNo]", sqlParameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ID = Convert.ToInt32(row["VisitorID"]);
                }
            }
            return ID;
        } 
        
        public string EmailValidataion(string email)
        {

            string Email = null;
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Email", email);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspEmailValidation]", sqlParameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Email = Convert.ToString(row["Email"]);
                }
            }
            return Email;
        }


        //public DataTable CheckInVisitorByTokenNo(string token)
        //{


        //    SqlParameter[] sqlParameters = new SqlParameter[2];
        //    sqlParameters[0] = new SqlParameter("@TOKENNO", token);
        //    sqlParameters[1] = new SqlParameter("@Time", DateTime.Now);
        //    DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspVisitorCheckInOutLog]", sqlParameters);

        //    return dt;
        //}


        public DataTable CheckInVisitorByTokenNo(string Token)
        {

            DataTable dt = new DataTable();

            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@TokenNo", Token);
            sqlParameters[1] = new SqlParameter("@Time", DateTime.Now);

            dt = commonConnectivity.ExecuteStoredProcedures("[uspVisitorCheckInOutLog]", sqlParameters);

            return dt;
        }


        public DataTable DeleteEnquiry(int ID)
        {

            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspDeleteVisitor]", sqlParameters);
            return dt;
        }

        public DataTable BlockVisitor(int ID)
        {

            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspBlockVisitorByID]", sqlParameters);
            return dt;
        }

        public VisitorModel FetchVisitorDetailByID(int ID)
        {

            VisitorModel visitor = new VisitorModel();
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspViewVisitorByID]", sqlParameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {

                    //visitor.ID = Convert.ToInt32(row["VisitorID"]);
                    visitor.FirstName = Convert.ToString(row["VisitorFirstName"]);
                    visitor.LastName = Convert.ToString(row["VISITORLASTNAME"]);
                    visitor.CompanyName = Convert.ToString(row["COMPANYNAME"]);
                    visitor.Gender = Convert.ToInt32(row["GENDERID"]);
                    visitor.VisitorTypeName = Convert.ToString(row["VisitorType"]);
                    //visitor.Department = Convert.ToInt32(row["DEPARTMENTID"]);
                    //visitor.Officer = Convert.ToInt32(row["OFFICERID"]);
                    visitor.AadharNo = Convert.ToString(row["AADHARNO"]);
                    //visitor.DocumentType = Convert.ToInt32(row["DOCUMENTTYPEID"]);
                    visitor.VisitorPic = Convert.ToString(row["VisitorPic"]);
                    visitor.VisitorAddress = Convert.ToString(row["VisitorAddress"]);
                    visitor.VisitPurpose = Convert.ToString(row["VisitPurpose"]);
                    visitor.Phone = Convert.ToString(row["Phone"]);
                    visitor.Gender = Convert.ToInt32(row["GenderID"]);
                    visitor.Email = Convert.ToString(row["Email"]);
                    visitor.IsActive = Convert.ToInt32(row["IsActive"]);
                    visitor.IsApproved = Convert.ToInt32(row["IsApproved"]);
                    visitor.OfficerName = Convert.ToString(row["OfficerName"]);
           
                }
            }
            return visitor;
        }



        public DataTable VisitorCheckOut(string TokenNo)
        {

            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@TokenNo", TokenNo);
            sqlParameters[1] = new SqlParameter("@Time",DateTime.Now);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspVisitorCheckInOutLog]", sqlParameters);
            return dt;
        }


        public DataTable GetCountForDashboard()
        {
            DataTable dt = new DataTable();

            SqlParameter[] sqlParameters = new SqlParameter[0];

            dt = commonConnectivity.ExecuteStoredProcedures("[uspFetchTotalCount]", sqlParameters);

            return dt;
        }

        public DataTable GetCountForMonthlyPass(int userid,int roleid)
        {
            DataTable dt = new DataTable();

            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@userid", userid);
            sqlParameters[1] = new SqlParameter("@roleid", roleid);
            dt = commonConnectivity.ExecuteStoredProcedures("[uspFetchMonthlyPass]", sqlParameters);

            return dt;
        }

        public DataTable GetUserDetails(int UserID, int RoleID)
        {
            DataTable dt = new DataTable();
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@UserID", UserID);
            sqlParameters[1] = new SqlParameter("@RoleID", RoleID);
       

            dt = commonConnectivity.ExecuteStoredProcedures("[uspGetUserDetails]", sqlParameters);

            return dt;
        }


        public VisitorModel EditVisitorByID(int ID)
        {

            VisitorModel visitor = new VisitorModel();
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspEditVisitorByID]", sqlParameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {

                    visitor.ID = Convert.ToInt32(row["VisitorID"]);
                    visitor.FirstName = Convert.ToString(row["VisitorFirstName"]);
                    visitor.LastName = Convert.ToString(row["VISITORLASTNAME"]);
                    visitor.CompanyName = Convert.ToString(row["COMPANYNAME"]);
                    visitor.Gender = Convert.ToInt32(row["GENDERID"]);
                    visitor.VisitorType = Convert.ToInt32(row["VISITORTYPEID"]);
                    visitor.Department = Convert.ToInt32(row["DEPARTMENTID"]);
                    visitor.Officer = Convert.ToInt32(row["OFFICERID"]);
                    visitor.AadharNo = Convert.ToString(row["AADHARNO"]);
                    visitor.DocumentType = Convert.ToInt32(row["DOCUMENTTYPEID"]);
                    visitor.VisitorPic = Convert.ToString(row["VISITORPIC"]);
                    visitor.VisitorAddress = Convert.ToString(row["VISITORADDRESS"]);
                    visitor.VisitPurpose = Convert.ToString(row["VISITPURPOSE"]);
                    visitor.Phone = Convert.ToString(row["Phone"]);
                    visitor.Gender = Convert.ToInt32(row["GENDERID"]);
                    visitor.Email = Convert.ToString(row["Email"]);
                    visitor.IsActive = Convert.ToInt32(row["IsActive"]);

                }
            }
            return visitor;
        }

        //public DataTable GetOfficerName(int ID)
        //{
        //    DataTable dt = new DataTable();
        //    SqlParameter[] sqlParameters = new SqlParameter[1];
        //    sqlParameters[0] = new SqlParameter("@ID", ID);



        //    dt = commonConnectivity.ExecuteStoredProcedures("[uspFetchOfficerName]", sqlParameters);

        //    return dt;

        //}

       

        public int UploadLiveImage(string image, string TokenNo)
        {

            int ID = 0;
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@image", image);
            sqlParameters[1] = new SqlParameter("@TokenNo", TokenNo);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspUploadvisitorimg]", sqlParameters);

            if (dt != null )
            {
                ID = 1;
            }
            return ID;
        }
        public String EmailValidation(string email)
        {

            string Email = null;
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Email", email);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspEmailValidationOfVisitor]", sqlParameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Email = Convert.ToString(row["msg"]);
                }
            }
            return Email;
        }

        //public VisitorModel ViewVisitorPassDetails(string token)
        //{

        //    VisitorModel visitor = new VisitorModel();
        //    SqlParameter[] sqlParameters = new SqlParameter[1];
        //    sqlParameters[0] = new SqlParameter("@TokenNO", token);
        //    DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspViewVisitorByToken]", sqlParameters);

        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow row in dt.Rows)
        //        {

        //            visitor.FirstName = Convert.ToString(row["VisitorFirstName"]);
        //            visitor.LastName = Convert.ToString(row["VisitorLastName"]);
        //            visitor.OfficerName = Convert.ToString(row["Officer"]);
        //            visitor.TokenNo = Convert.ToString(row["TokenNo"]);
        //            visitor.DepartmentName = Convert.ToString(row["Department"]);
                   
                
        //        }
        //    }
        //    return visitor;
        //}

        public VisitorModel ViewVisitorPassDetails(string token)
        {

            VisitorModel visitor = new VisitorModel();
           string CS = ConfigurationManager.ConnectionStrings["dbConfig"].ConnectionString;


            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select *,e.FirstName + e.LastName as Officer from Visitor v inner join Employee e  on v.OfficerID = e.ID inner join Department d  on d.ID = v.DepartmentID where TokenNo = '" + token+"'", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    visitor.FirstName = Convert.ToString(rdr["VisitorFirstName"]);
                    visitor.LastName = Convert.ToString(rdr["VisitorLastName"]);
                    visitor.OfficerName = Convert.ToString(rdr["Officer"]);
                    visitor.TokenNo = Convert.ToString(rdr["TokenNo"]);
                    visitor.DepartmentName = Convert.ToString(rdr["Department"]);


                }

            }
            return visitor;
        }

        public DataTable GetOfficersByDepartment(int Id)
        {

            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Id", Id);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspGetOfficersByDepartment]", sqlParameters);
            return dt;
        }

        public int SaveFeedback(VisitorModel visitorEntity)
        {

            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@VisitorID", visitorEntity.VisitorID);
            sqlParameters[1] = new SqlParameter("@Feedback", visitorEntity.Feedback);

            int result = commonConnectivity.ExecuteInsertQueryReturn("[uspAddVisitorFeedBack]", sqlParameters);

            return result;
        }

        public VisitorModel GetVisitorReportDetailsList(DateTime Startdate, DateTime EndDate, int roleID, int userID)
        {
            VisitorModel ASCDetail = new VisitorModel();

            SqlParameter[] sqlParameters = new SqlParameter[4];        
            sqlParameters[0] = new SqlParameter("@strStartDate", Startdate);
            sqlParameters[1] = new SqlParameter("@strEndDate", EndDate);
            sqlParameters[2] = new SqlParameter("@roleID", roleID);
            sqlParameters[3] = new SqlParameter("@userID", userID);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[GetVisitorReportDetailsList]", sqlParameters);

            if (dt != null && dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    
                    ASCDetail.ID = Convert.ToInt16(row["VisitorID"]);

                    ASCDetail.TokenNo = Convert.ToString(row["TokenNo"]);

                    ASCDetail.InDateTime = Convert.ToString(row["InDateTime"]);

                    ASCDetail.OutDateTime = Convert.ToString(row["OutDateTime"]);

                }
            }
            return ASCDetail;
        }
        
        public List<VisitorModel> GetVisitorReportDetailsLists(DateTime Startdate, DateTime EndDate, int roleID, int userID)
        {
            List<VisitorModel> ASCDetailLst = new List<VisitorModel>();

            SqlParameter[] sqlParameters = new SqlParameter[4];        
            sqlParameters[0] = new SqlParameter("@strStartDate", Startdate);
            sqlParameters[1] = new SqlParameter("@strEndDate", EndDate);
            sqlParameters[2] = new SqlParameter("@roleID", roleID);
            sqlParameters[3] = new SqlParameter("@userID", userID);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[GetVisitorReportDetailsList]", sqlParameters);

            if (dt != null && dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    VisitorModel ASCDetail = new VisitorModel();
                    ASCDetail.ID = Convert.ToInt16(row["VisitorID"]);

                    ASCDetail.TokenNo = Convert.ToString(row["TokenNo"]);

                    ASCDetail.InDateTime = Convert.ToString(row["InDateTime"]);

                    ASCDetail.OutDateTime = Convert.ToString(row["OutDateTime"]);

                    ASCDetailLst.Add(ASCDetail);
                }
            }
            return ASCDetailLst;
        }

        public DataTable GetvisitorReportDetail(DateTime Startdate, DateTime EndDate, int roleID, int userID)
        {
            List<VisitorModel> ASCDetaillst = new List<VisitorModel>();

            SqlParameter[] sqlParameters = new SqlParameter[4];
            
            sqlParameters[0] = new SqlParameter("@strStartDate", Startdate);
            sqlParameters[1] = new SqlParameter("@strEndDate", EndDate);
            sqlParameters[2] = new SqlParameter("@roleID", roleID);
            sqlParameters[3] = new SqlParameter("@userID", userID);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[GetVisitorReportDetailsList]", sqlParameters);

            return dt;

        }
    }
}
