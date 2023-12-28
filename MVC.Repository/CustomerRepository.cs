using MVC.DB;
using MVC.Domain.Model;
using MVC.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ICommonConnectivity commonConnectivity;

        public CustomerRepository(ICommonConnectivity commonConnectivity)
        {
            this.commonConnectivity = commonConnectivity;
        }

        public DataTable CustomerList(User user)
        {
            DataTable dt = new DataTable();

            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@UserName", user.UserName);
            sqlParameters[1] = new SqlParameter("@UserPass", user.Password);

            dt = commonConnectivity.ExecuteStoredProcedures("[uspUserLogin]", sqlParameters);

            return dt;
        }


    }
}
