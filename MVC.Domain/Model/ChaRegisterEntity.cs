using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.Model
{
    public class ChaRegisterEntity
    {

        public int ID { get; set; }
        public string FirstName { get; set; }
        public int DocumentType { get; set; }
        public string LivePhoto { get; set; }
        public string LastName { get; set; }
        public int UserTypeID { get; set; }
        public string CHACode { get; set; }
        public string Document { get; set; }
        public string PhotoForedit { get; set; }
        public string MobileNumber { get; set; }
        public string EmailID { get; set; }
        public string Password { get; set; }
        public string otherGovernmentOfficer { get; set; }
        public int IsActive { get; set; }
        public string RegistrationDate { get; set; }

        public bool IsApprove { get; set; }
        public int ApprovedBy { get; set; }

        public string Message { get; set; }
        public DateTime ApprovedOn { get; set; }
        public bool IsRejected { get; set; }
        public int RejectedBy { get; set; }
        public DateTime RejectedOn { get; set; }
        public string Gender { get; set; }
        

    }
}
