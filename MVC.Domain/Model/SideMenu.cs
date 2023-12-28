using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.Model
{
    public class SideMenu
    {
        public int ID { get; set; }

        public int CompanyID { get; set; }

        public string SubMenu { get; set; }

        public int Priority { get; set; }

        public int MenuID { get; set; }

        public string FormName { get; set; }

        public string View { get; set; }

        public string Controller { get; set; }

        public string SubMenuID { get; set; }

        public DateTime AddedDATE { get; set; }

        public DateTime ModifiedDATE { get; set; }

        public int AddedBy { get; set; }

        public int ModifiedBy { get; set; }

        public bool IsActive { get; set; }

        public string Action { get; set; }
        public string ControllerName { get; set; }
        public Nullable<int> ParentID { get; set; }
        public string MenuText { get; set; }
        public string Description { get; set; }

        public string Icons { get; set; }
        public bool Status { get; set; }

        public string NavigateUrl { get; set; }

    }
}
