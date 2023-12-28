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
    public class EmployeeRepository : IEmployeeRepository
    {

        private CommonService commonConnectivity = new CommonService();


   
        public int AddEmployee(EmployeeModel employeeEntity)
        {
          
            SqlParameter[] sqlParameters = new SqlParameter[14];
            sqlParameters[0] = new SqlParameter("@ID", employeeEntity.ID);
            sqlParameters[1] = new SqlParameter("@FirstName", employeeEntity.FirstName);
            sqlParameters[2] = new SqlParameter("@LastName", employeeEntity.LastName);
            sqlParameters[3] = new SqlParameter("@Email", employeeEntity.Email);
            sqlParameters[4] = new SqlParameter("@Phone", employeeEntity.Phone);
            sqlParameters[5] = new SqlParameter("@JoiningDate", employeeEntity.JoiningDate);
            sqlParameters[6] = new SqlParameter("@Gender", employeeEntity.Gender);
            sqlParameters[7] = new SqlParameter("@Department", employeeEntity.Department);
            sqlParameters[8] = new SqlParameter("@Designation", employeeEntity.Designation);
            sqlParameters[9] = new SqlParameter("@Password1", employeeEntity.Password1);
            sqlParameters[10] = new SqlParameter("@Password2", employeeEntity.Password2);
            sqlParameters[11] = new SqlParameter("@IsActive", employeeEntity.IsActive);
            sqlParameters[12] = new SqlParameter("@About", employeeEntity.About);
            sqlParameters[13] = new SqlParameter("@Image", employeeEntity.Image);
            
            int result = commonConnectivity.ExecuteInsertQueryReturn("[uspAddEmployee]", sqlParameters);

            return result;
        }


        

        public List<EmployeeModel> FetchEmployeeType()

        {
            List<EmployeeModel> allemployee = new List<EmployeeModel>();
            SqlParameter[] sqlParameters = new SqlParameter[0];
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspAllFetchEmployee]", sqlParameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    EmployeeModel employee = new EmployeeModel();
                    employee.ID = Convert.ToInt32(row["ID"]);
                    employee.FirstName = Convert.ToString(row["FirstName"]);
                    employee.LastName = Convert.ToString(row["LastName"]);
                    employee.Email = Convert.ToString(row["Email"]);
                    employee.Phone = Convert.ToString(row["Phone"]);

                    employee.Gender = Convert.ToInt32(row["Gender"]);
                    employee.DepartmentName = Convert.ToString(row["Department"]);
                    employee.DesignationName = Convert.ToString(row["Designation"]);
                    //employee.Password = Convert.ToString(row["Password"]);
                    employee.Image = Convert.ToString(row["OfficerPic"]);
                    employee.IsActive = Convert.ToInt32(row["IsActive"]);
                    employee.JoiningDate = Convert.ToString(row["JoiningDate"]);

                    allemployee.Add(employee);

                }
            }
            return allemployee;
        }

        public EmployeeModel FetchEmployeeByID(int ID)
        {

            EmployeeModel employee = new EmployeeModel();
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspEditEmployee]", sqlParameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    
                    employee.ID = Convert.ToInt32(row["ID"]);
                    employee.FirstName = Convert.ToString(row["FirstName"]);
                    employee.LastName = Convert.ToString(row["LastName"]);
                    employee.Email = Convert.ToString(row["Email"]);
                    employee.Phone = Convert.ToString(row["Phone"]);
                    //employee.JoiningDate = Convert.ToString(row["JoiningDate"]).ToString("dd/mm/yyyy");
                    employee.JoiningDate = Convert.ToDateTime(row["JoiningDate"]).ToString("yyyy/MM/dd");
                    employee.Gender = Convert.ToInt32(row["Gender"]);
                    employee.Department = Convert.ToInt32(row["DepartmentID"]);
                    employee.Designation = Convert.ToInt32(row["DesignationID"]);
                    employee.Password1 = Convert.ToString(row["Password1"]);
                    employee.Password2 = Convert.ToString(row["Password2"]);
                    employee.Image = Convert.ToString(row["Image"]);
                    employee.About = Convert.ToString(row["About"]);
                    employee.IsActive = Convert.ToInt32(row["IsActive"]);

                }
            }
            return employee;
        }

        public DataTable DeleteEnquiry(int ID)
        {

            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspDeleteEmployee]", sqlParameters);
            return dt;
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
                lstModel1.Name = "Select Department";
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


        public List<SelectListModel> GetDesignation()
        {
            List<SelectListModel> selectListModels = new List<SelectListModel>();

            SqlParameter[] sqlParameters = new SqlParameter[0];
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspSelect_Designation_Name]", sqlParameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                SelectListModel lstModel1 = new SelectListModel();
                lstModel1.ID = 0;
                lstModel1.Name = "--Select Designation--";
                selectListModels.Add(lstModel1);


                foreach (DataRow row in dt.Rows)
                {
                    SelectListModel lstModel = new SelectListModel();

                    lstModel.ID = Convert.ToInt32(row["ID"].ToString());

                    lstModel.Name = Convert.ToString(row["Designation"]);

                    selectListModels.Add(lstModel);

                }
            }
            return selectListModels;
        }
    }
}
