using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.Model
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public int UserRoleID { get; set; }
        public string UserRole { get; set; }
        public string EmailID { get; set; }
        // token to authorize each individual request 
        public string Token { get; set; }

        public string message { get; set; }
        public bool Remember { get; set; }

       
    }
}
