using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.Model
{
    public class LoginUserDetail
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserType { get; set; }
        public int RoleID { get; set; }
        public int DeptID { get; set; }
        public string UserDisplayName { get; set; }
        public string UserImage { get; set; }//= "dist/img/neutral.png";
        public string DomainName { get; set; }
        public bool IsLocalAppUser { get; set; }
        public string SessionSource { get; set; }
        public string SessionID { get; set; }
        public bool IsSessionAlive { get; set; }
        public int SessionTimeOutTime { get; set; }
        public DateTime SessionStartDateTime { get; set; }
        public string LastSessionLoginDateTime { get; set; }
        public string LastSessionFrom { get; set; }
        public bool IsUserPasswordNeedToChange { get; set; }
    }
}
