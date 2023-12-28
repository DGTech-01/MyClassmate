using MVC.Domain.Model;
using MVC.Repository;
using MVC.Services.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Services
{
    public class SubjectService : ISubjectService
    {
        SubjectRepository subjectRepository = new SubjectRepository();

        public List<Subject> GetSubjectByClass(int standardid)
        {
            List<Subject> lstexamSubjectMarks = new List<Subject>();
            DataTable dt = subjectRepository.GetSubjectByClass(standardid);

            foreach (DataRow row in dt.Rows)
            {
                Subject examSubjectMark = new Subject();

                examSubjectMark.ID = Convert.ToInt32(row["SubjectID"]);
                examSubjectMark.SubjectName = Convert.ToString(row["SubjectName"]);
                examSubjectMark.SubjectCode = Convert.ToString(row["SubjectCode"]);
                //examSubjectMark.SortOrder = Convert.ToString(row["SubjectCode"]);


                lstexamSubjectMarks.Add(examSubjectMark);
            }

            return lstexamSubjectMarks;
        }
    }
}
