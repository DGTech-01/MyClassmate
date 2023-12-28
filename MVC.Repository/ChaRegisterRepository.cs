using MVC.DB;
using MVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Repository
{
    public class ChaRegisterRepository
    {
        private CommonService commonConnectivity = new CommonService();

        public int AddChaRegisterDetails(ChaRegisterEntity objComplaintEntity)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[13];

                sqlParameters[0] = new SqlParameter("@FirstName", objComplaintEntity.FirstName);
                sqlParameters[1] = new SqlParameter("@LastName", objComplaintEntity.LastName);
                sqlParameters[2] = new SqlParameter("@UserTypeID", objComplaintEntity.UserTypeID);
                sqlParameters[3] = new SqlParameter("@CHACode", objComplaintEntity.CHACode);
                sqlParameters[4] = new SqlParameter("@Document", objComplaintEntity.Document);
                sqlParameters[5] = new SqlParameter("@MobileNumber", objComplaintEntity.MobileNumber);
                sqlParameters[6] = new SqlParameter("@EmailID", objComplaintEntity.EmailID);
                sqlParameters[7] = new SqlParameter("@Password", objComplaintEntity.Password);
                sqlParameters[8] = new SqlParameter("@IsActive", objComplaintEntity.IsActive);
                sqlParameters[9] = new SqlParameter("@Gender", objComplaintEntity.Gender);
                sqlParameters[10] = new SqlParameter("@LiveImage", objComplaintEntity.LivePhoto);
                sqlParameters[11] = new SqlParameter("@DocumentType", objComplaintEntity.DocumentType);
                sqlParameters[12] = new SqlParameter("@otherGovernmentOfficer", objComplaintEntity.otherGovernmentOfficer);
                int i = commonConnectivity.ExecuteInsertQueryReturn("AddchaRegister", sqlParameters);
                return i;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

          


        public DataTable GetchasummaryList()
        {
            DataTable dt = new DataTable();

            SqlParameter[] sqlParameters = new SqlParameter[0];
            dt = commonConnectivity.ExecuteStoredProcedures("[uspchaSummary]", sqlParameters);

            return dt;

        }

        public DataTable Getchareject(int ID, int userid)
        {
            
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            sqlParameters[1] = new SqlParameter("@userid", userid);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspchaReject]", sqlParameters);
            return dt;
        }

        public DataTable GetchaAccept(int ID,int userid)
        {

            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            sqlParameters[1] = new SqlParameter("@userid", userid);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspchaAccept]", sqlParameters);
            return dt;
        }

        public ChaRegisterEntity Getchaview(int ID)
        {
            ChaRegisterEntity ViewDetailslst = new ChaRegisterEntity();

            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ID", ID);


            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspchaViewByCId]", sqlParameters);
            //DataTable dt1 = ds.Tables[0];
            //DataTable dt2 = ds.Tables[1];

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                ViewDetailslst.FirstName = Convert.ToString(row["FirstName"]);

                ViewDetailslst.LastName = Convert.ToString(row["LastName"]);

                ViewDetailslst.UserTypeID = Convert.ToInt32(row["UserTypeID"]);

                ViewDetailslst.CHACode = Convert.ToString(row["CHACode"]);

                ViewDetailslst.Document = Convert.ToString(row["Document"]);

                ViewDetailslst.MobileNumber = Convert.ToString(row["MobileNumber"]);

                ViewDetailslst.EmailID = Convert.ToString(row["EmailID"]);

                ViewDetailslst.IsActive = Convert.ToInt32(row["IsActive"]);

                ViewDetailslst.Gender = Convert.ToString(row["Gender"]);

                //ViewDetailslst.RegistrationDate = Convert.ToDateTime(row["RegistrationDate"]);
                ViewDetailslst.RegistrationDate = Convert.ToDateTime(row["RegistrationDate"]).ToString("yyyy/MM/dd");

                ViewDetailslst.Password = Convert.ToString(row["Password"]);

                

            }

            return ViewDetailslst;
        }


        public String EmailValidation(string email)
        {

            string Email = null;
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Email", email);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspEmailValidation]", sqlParameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Email = Convert.ToString(row["msg"]);
                }
            }
            return Email;
        }
    }
}
