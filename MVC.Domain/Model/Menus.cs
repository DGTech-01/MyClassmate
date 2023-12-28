using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.Model
{
    public class Menus
    {
        public int MenuId { get; set; }
        public int ParentMenuId { get; set; }
        public int ParentId { get; set; }
        public string Text { get; set; }
        public string NavigateURL { get; set; }
        public string MenuIcons { get; set; }
        public int SortOrder { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public string Icons { get; set; }

        public string NewIcons { get; set; }

        public string NewUrl { get; set; }
        public bool IsActive { get; set; }


        public string MenuName { get; set; }
        public int MenuID { get; set; }
        //public string Controller { get; set; }
        public string Action { get; set; }
        public string ControllerName { get; set; }
        public Nullable<int> ParentID { get; set; }
        public int Priority { get; set; }
        public string menuIcon { get; set; }

    }
   
}
