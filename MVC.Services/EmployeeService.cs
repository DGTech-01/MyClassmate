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
    public class EmployeeService : IEmployeeService
    {
        public EmployeeRepository employeeRepository = new EmployeeRepository();



        public EmployeeModel FetchEmployeeByID(int ID)
        {
            List<EmployeeModel> allchadetails = new List<EmployeeModel>();
            EmployeeModel ds = employeeRepository.FetchEmployeeByID(ID);
            return ds;
        }

        public int AddEmployeeDetails(EmployeeModel employeeModel)
        {

            int ds = employeeRepository.AddEmployee(employeeModel);
            return ds;
        }   
       


    }
}
