using System;
using System.Collections.Generic;
using System.Text;

namespace MVC.Domain.Model
{

    public class Subject 
    {
        public int ID { get; set; }
        public string SubjectName { get; set; }
        public string SubjectCode { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime? AddedOn { get; set; }
        public int AddedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
        //public virtual ICollection<SubjectMapping> SubjectMapping_SubjectIDs { get; set; }
        //public virtual ICollection<ExamMark> ExamMark_SubjectIDs { get; set; }
        //public virtual ICollection<ExamSubjectMark> ExamSubjectMarkMapping_SubjectIDs { get; set; }
    }
}
