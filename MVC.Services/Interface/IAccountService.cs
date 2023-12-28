using MVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Services.Interface
{
    public interface IAccountService
    {
        LoginUserDetail UserLogin(string name, string pass);
       // List<UserRights> GetUserRigths();
       // List<Menus> GetSideMenu(int userid);

        int ResetPassword(string userid, int loginid, string otp, string action);
        
    }
}
