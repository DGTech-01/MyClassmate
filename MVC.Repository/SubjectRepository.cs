using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.DB;
using MVC.Domain.Model;
using MVC.Repository.Interface;

namespace MVC.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private CommonService _commonService = new CommonService();

        public DataTable GetSubjectByClass(int standardid)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@StandardID", standardid);


            DataTable dt = _commonService.ExecuteStoredProcedures("[uspGetSubjectByClass]", sqlParameters);

            return dt;
        }

    }
}
