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
    public class DepartmentRepository :IDepartmentRepository
    {

        private CommonService commonConnectivity = new CommonService();


   
        public DataTable AddDepartment(DepartmentModel departmentEntity)
        {
            DataTable dt = new DataTable();

            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@ID", departmentEntity.ID);
            sqlParameters[1] = new SqlParameter("@Department", departmentEntity.Department);
            sqlParameters[2] = new SqlParameter("@IsActive", departmentEntity.IsActive);


            dt = commonConnectivity.ExecuteStoredProcedures("[uspAddDepartment]", sqlParameters);

            return dt;
        }

        public List<DepartmentModel> FetchDepartmentType()

        {
            List<DepartmentModel> alldepartment = new List<DepartmentModel>();
            SqlParameter[] sqlParameters = new SqlParameter[0];
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspFetchDepartment]", sqlParameters);

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

        public DataTable DeleteEnquiry(int ID)
        {

            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspDeleteDepartment]", sqlParameters);
            return dt;
        }

    }
}
