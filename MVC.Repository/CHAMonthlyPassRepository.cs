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
    public class ChaPassRepository : IChaPassRepository
    {

        private CommonService commonConnectivity = new CommonService();


   
        public DataTable AddChaPassDetail(MonthlyPassModel MonthlyPassModel)
        {
            DataTable dt = new DataTable();

            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@ID", MonthlyPassModel.ID);
            sqlParameters[1] = new SqlParameter("@FromDate", MonthlyPassModel.fromDate);
            sqlParameters[2] = new SqlParameter("@ToDate", MonthlyPassModel.toDate);
            sqlParameters[3] = new SqlParameter("@AddedBy", MonthlyPassModel.AddedBy);
            


            dt = commonConnectivity.ExecuteStoredProcedures("[uspAddChaPass]", sqlParameters);

            return dt;
        }

        public List<MonthlyPass> FetchChaMonthPassList(int roleid, int userid)

        {
            List<MonthlyPass> allmonthlypass = new List<MonthlyPass>();
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@roleid", roleid);
            sqlParameters[1] = new SqlParameter("@userid", userid);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspFetchChaMonthPassList]", sqlParameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    MonthlyPass monthpass = new MonthlyPass();
                    monthpass.ID = Convert.ToInt32(row["ID"]);
                    monthpass.ChaID = Convert.ToString(row["CHAID"]);
                    monthpass.FromDate = Convert.ToDateTime(row["FromDate"]);
                    monthpass.ToDate = Convert.ToDateTime(row["ToDate"]);
                    monthpass.IsApproved = Convert.ToInt32(row["StatusID"]);
                    monthpass.TokenNo = Convert.ToString(row["TokenNo"]);
                    if (!String.IsNullOrEmpty(row["ChaFullName"].ToString()))
                    {
                        monthpass.ChaFullName = Convert.ToString(row["ChaFullName"]);
                    }
                    
                    allmonthlypass.Add(monthpass);

                }
            }
            return allmonthlypass;
        }

        //public List<DepartmentModel> FetchEmployee()

        //{
        //    List<DepartmentModel> alldepartment = new List<DepartmentModel>();
        //    SqlParameter[] sqlParameters = new SqlParameter[0];
        //    DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspFetchDepartment]", sqlParameters);

        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            DepartmentModel department = new DepartmentModel();
        //            department.ID = Convert.ToInt32(row["ID"]);
        //            department.Department = Convert.ToString(row["Department"]);
        //            department.IsActive = Convert.ToInt32(row["IsActive"]);

        //            alldepartment.Add(department);

        //        }
        //    }
        //    return alldepartment;
        //}

        public List<DepartmentModel> FetchDepartmentByID(int ID)
        {

            List<DepartmentModel> alldepartment = new List<DepartmentModel>();
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspEditDepartment]", sqlParameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    DepartmentModel department = new DepartmentModel();
                    department.ID = Convert.ToInt32(row["ID"]);
                    department.Department = Convert.ToString(row["Department"]);
                    department.IsActive = Convert.ToInt32(row["IsActive"]);

                    alldepartment.Add(department);

                }
            }
            return alldepartment;
        }

        public DataTable DeleteEnquiry(int ID,int userid)
        {

            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            sqlParameters[1] = new SqlParameter("@userid", userid);

            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspChaMonthPassRejected]", sqlParameters);
            return dt;
        }

        public int AddChaPassDetails(MonthlyPass monthlypass)
        {
            throw new NotImplementedException();
        }

        public DataTable GetchasummaryList()
        {
            throw new NotImplementedException();
        }

        public DataTable Getchareject(int ID)
        {
            throw new NotImplementedException();
        }

        public DataTable GetchaAccept(int ID)
        {
            throw new NotImplementedException();
        }
        public DataTable ChaMonthPassApproved(int ID)
        {

            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspChaMonthPassAccept]", sqlParameters);
            return dt;
        }


        public ChaRegisterEntity Getchaview(int ID)
        {
            throw new NotImplementedException();
        }


        public MonthlyPass FetchMonthyPassDetails(string token)
        {

            MonthlyPass monthly = new MonthlyPass();
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@TokenNo", token);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspViewChaMonthPassByID]", sqlParameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {

                    
                    monthly.FirstName = Convert.ToString(row["VisitorFirstName"]);
                    monthly.LastName = Convert.ToString(row["VISITORLASTNAME"]);
                    monthly.Email = Convert.ToString(row["Email"]);
                    monthly.Gender = Convert.ToInt32(row["GENDERID"]);
                    monthly.Phone = Convert.ToString(row["Phone"]);
                    monthly.AadharNo = Convert.ToString(row["AadharNo"]);
                    monthly.OfficerName = Convert.ToString(row["OfficerName"]);
                    monthly.VisitPurpose = Convert.ToString(row["VisitPurpose"]);
                    monthly.AddedOn = Convert.ToDateTime(row["AddedOn"]);
                    monthly.VisitorAddress = Convert.ToString(row["VisitorAddress"]);
                    monthly.IsApproved = Convert.ToInt32(row["IsApproved"]);
                    monthly.CompanyName = Convert.ToString(row["CompanyName"]);
                    monthly.VisitorPic = Convert.ToString(row["VisitorPic"]);



                }
            }
            return monthly;
        }


    }
}
