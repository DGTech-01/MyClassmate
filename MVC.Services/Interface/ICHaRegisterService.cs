using MVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Services.Interface
{
    public interface ICHaRegisterService
    {

        int AddChaRegister(ChaRegisterEntity objchaEntity);
        List<ChaRegisterEntity> GetChaSummaryList();

        DataTable Rejectcha(int ID,int userid);
        DataTable Acceptcha(int ID, int userid);
        ChaRegisterEntity getChadetail(int ID);
    }
}
