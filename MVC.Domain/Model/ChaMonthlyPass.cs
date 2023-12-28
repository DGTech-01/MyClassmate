using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.Model
{
    public class MonthlyPass
    {

        public int ID { get; set; }
        //public string Image { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        //public string TokenNo{ get; set; }
        public string ChaID { get; set; }
        
        public int VisitorPassType { get; set; }
        public int IsApproved { get; set; }
        public int AddedBy { get; set; }
		public int Officer { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string CompanyName { get; set; }
		public int Gender { get; set; }
		public int VisitorType { get; set; }
		public int Department { get; set; }
		public string TokenNo { get; set; }
		public string ChaFullName { get; set; }
		public string AadharNo { get; set; }
		public int DocumentType { get; set; }
		public int CHAID { get; set; }
		public string VisitorPic { get; set; }
		public string VisitorAddress { get; set; }
		public string VisitPurpose { get; set; }
		
		public int ApprovedBy { get; set; }
		public DateTime ApprovedOn { get; set; }
		public int IsRejected { get; set; }
		public int RejectedBy { get; set; }
		public DateTime AddedOn { get; set; }
		public string CheckIn { get; set; }
		public string CheckOut { get; set; }
		public DateTime TokenIssueDate { get; set; }
		public DateTime TokenExpiryDate { get; set; }
		public int TokenType { get; set; }
		public string OfficerName { get; set; }
		public string VisitorTypeName { get; set; }
		public string filepath { get; set; }
		public int IsActive { get; set; }

	}

	public class MonthlyPassModel
    {
		public int ID { get; set; }
		public string fromDate { get; set; }
		public string toDate { get; set; }
		public int AddedBy { get; set; }

	}
}
