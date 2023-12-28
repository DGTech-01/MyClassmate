using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.Model
{
    public partial class SelectListModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class CustomFilter
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string MemberID { get; set; }
        public string Filter { get; set; }
    }
}
