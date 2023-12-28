using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Repository.Interface
{
    public interface IAccountRepository
    {
        DataTable Login(string username, string password);
        //DataTable UserLogin(User user);
        DataTable UserRights();
        //DataTable GetSideMenu(int userid);
        DataTable ResetPassword(string userid, int loginid, string otp, string action);
    }
}
