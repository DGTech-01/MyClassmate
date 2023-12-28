using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.Model
{
	public class DesignationModel
	{
		public int ID { get; set; }
		public string Designation { get; set; }
		public int IsActive { get; set; }


	}
    public class SelectDesignationList
    {
        public int ID { get; set; }
        public string Designation_Name { get; set; }

    }
}
