using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.Model
{
	public class DepartmentModel
	{
		public int ID { get; set; }
		public string Department { get; set; }
		public int IsActive { get; set; }


	}
	public class SelectDepartmentList
	{
		public int ID { get; set; }
		public string Department_Name { get; set; }

	}
}
