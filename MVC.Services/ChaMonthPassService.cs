using MVC.Domain.Model;
using MVC.Services.Interface;
using MVC.Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MVC.Services
{
    
    public class ChaMonthPassService : IChaMonthPassService
    {

        ChaPassRepository chaPassRepository = new ChaPassRepository();

   

        public DataTable Rejectcha(int ID)
        {
            List<ChaRegisterEntity> allchadetails = new List<ChaRegisterEntity>();
            DataTable ds = chaPassRepository.Getchareject(ID);
            return ds;
        }

        public DataTable ChaMonthPassApproved(int ID)
        {
            List<MonthlyPass> monthlyPasses = new List<MonthlyPass>();
            DataTable ds = chaPassRepository.ChaMonthPassApproved(ID);
            return ds;
        }

        public DataTable RejectChaMonthPass(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
