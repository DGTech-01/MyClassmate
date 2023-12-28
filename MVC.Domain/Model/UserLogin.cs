using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.Model
{
    public class UserLogin
    {
        [Key]
        public int LoginId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserRoleId { get; set; }
        public int ActiveAttempCount { get; set; }
        public int IncorrectAttempCount { get; set; }
        public DateTime LastIncorrectAttemptOn { get; set; }
        public string SysGenPwd { get; set; }
        public bool SysPwdFlag { get; set; }
        public bool IsMobileAccess { get; set; }
        public bool IsWebAccess { get; set; }
        public bool IsLogin { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool BlockedStatus { get; set; }
        public int BlockeedBy { get; set; }
        public DateTime BlockedOn { get; set; }
        public string Comment { get; set; }

        public bool IsSessionAlive { get; set; }
    }
}
