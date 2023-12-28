using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.Model
{
    public class EmployeeModel
	{
		public int ID { get; set; }
		public string FirstName { get; set; }

		public string PhotoForedit { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string JoiningDate { get; set; }
		public int Gender { get; set; }
		public int Department { get; set; }
		public string DepartmentName { get; set; }
		public int Designation { get; set; }
		public string DesignationName { get; set; }
		public string Password1 { get; set; }
		public string Password2 { get; set; }
		public string About { get; set; }
		public string Image { get; set; }
		public int IsActive { get; set; }

		public string AddedBy { get; set; }
		public DateTime AddedOn { get; set; }
		public string ModifiedBy { get; set; }
		public DateTime ModifiedOn { get; set; }


	}

}
