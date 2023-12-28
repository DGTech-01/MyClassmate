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
    public class DesignationRepository : IDepartmentRepository
    {

        private CommonService commonConnectivity = new CommonService();


   
        public DataTable AddDesignation(DesignationModel designationEntity)
        {
            DataTable dt = new DataTable();

            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@ID", designationEntity.ID);
            sqlParameters[1] = new SqlParameter("@Designation", designationEntity.Designation);
            sqlParameters[2] = new SqlParameter("@IsActive", designationEntity.IsActive);


            dt = commonConnectivity.ExecuteStoredProcedures("[uspAddDesignation]", sqlParameters);

            return dt;
        }

        public List<DesignationModel> FetchDesignationType()

        {
            List<DesignationModel> alldepartment = new List<DesignationModel>();
            SqlParameter[] sqlParameters = new SqlParameter[0];
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspFetchDesignation]", sqlParameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    DesignationModel designation = new DesignationModel();
                    designation.ID = Convert.ToInt32(row["ID"]);
                    designation.Designation = Convert.ToString(row["Designation"]);
                    designation.IsActive = Convert.ToInt32(row["IsActive"]);

                    alldepartment.Add(designation);

                }
            }
            return alldepartment;
        }

      
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

        public DataTable DeleteDesignation(int ID)
        {

            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspDeleteTest]", sqlParameters);
            return dt;
        }

    }
}
