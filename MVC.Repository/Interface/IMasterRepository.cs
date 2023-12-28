using MVC.Domain.Model;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Repository.Interface
{
    public interface IMasterRepository
    {
        //DataTable BankMaster(int Id);
   


        //<-----------End CustomerRepository ---------->



        //<-----------Start WalletRepository ---------->
        //DataTable AddCustWalletDetails(PMWalletModel objWalletEntity);
        //DataTable GetWalletPayRequest(PMWalletModel objWalletEntity);
        //DataTable GetTransactionHistory(PMAdminModel objAdminEntity);
       // DataTable GetWalletBalance(double UserID, int RoleID, string Action);
        //DataTable GetAllTransactionHistory(PMAdminModel objAdminEntity);
        //DataTable GetCompanyTransactionHistory(PMAdminModel objAdminEntity);
        //DataTable GetCompanyWalletBalance(double UserID, int RoleID, string Action);

        //<-----------End WalletRepository ---------->



        //<-----------End PaymentRepository ---------->

    }
}
