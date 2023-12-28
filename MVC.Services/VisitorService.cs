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
    public class VisitorService : IVisitorService
    {
        public VisitorRepository visitorRepository = new VisitorRepository();



        public VisitorModel EditVisitorByID(int ID)
        {
            List<VisitorModel> editvisitor = new List<VisitorModel>();
            VisitorModel ds = visitorRepository.EditVisitorByID(ID);
            return ds;
        }
        public int AddVisitorDetails(VisitorModel visitorModel)
        {

            int ds = visitorRepository.AddVisitorDetails(visitorModel);
            return ds;
        }

        public int AddVisitorByAdmin(VisitorModel visitorModel)
        {

            int ds = visitorRepository.AddVisitorByAdmin(visitorModel);
            return ds;
        }

        public VisitorModel EditVisitorByID(string tokenNo)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeModel> GetOfficersByDepartment(int departmentId)
        {
            List<EmployeeModel> FromList = new List<EmployeeModel>();
            DataTable dt = new DataTable();

            dt = visitorRepository.GetOfficersByDepartment(departmentId);
            if (dt != null && dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    EmployeeModel officer = new EmployeeModel();

                    officer.ID = Convert.ToInt32(row["ID"].ToString());

                    officer.FirstName = Convert.ToString(row["Fullname"]);



                    FromList.Add(officer);
                }
            }
            return FromList;
        }

        public int SaveFeedback(VisitorModel visitorModel)
        {

            int ds = visitorRepository.SaveFeedback(visitorModel);
            return ds;
        }
    }
}
