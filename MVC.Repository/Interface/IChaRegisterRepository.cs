using MVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Repository.Interface
{
    public interface IChaRegisterRepository
    {
        int AddDepartmentDetails(ChaRegisterEntity objchaEntity);
        DataTable GetchasummaryList();

        DataTable Getchareject(int ID);
        DataTable GetchaAccept(int ID);
        ChaRegisterEntity Getchaview(int ID);
    }
}
