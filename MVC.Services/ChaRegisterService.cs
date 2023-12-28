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
    
    public class ChaRegisterService : ICHaRegisterService
    {
#pragma warning disable CS0436 // Type conflicts with imported type
        ChaRegisterRepository charegisterRepository = new ChaRegisterRepository();
#pragma warning restore CS0436 // Type conflicts with imported type
        public int AddChaRegister(ChaRegisterEntity objchaEntity)
        {
            int result = charegisterRepository.AddChaRegisterDetails(objchaEntity);
            return result;
        }


        public List<ChaRegisterEntity> GetChaSummaryList()
        {

            List<ChaRegisterEntity> allchadetails = new List<ChaRegisterEntity>();
            DataTable ds = charegisterRepository.GetchasummaryList();
            if (ds != null && ds.Rows.Count > 0)
            {

                foreach (DataRow row in ds.Rows)
                {
                    ChaRegisterEntity unitDetail = new ChaRegisterEntity();
                    unitDetail.ID = Convert.ToInt32(row["ID"]);

                    unitDetail.FirstName = Convert.ToString(row["FirstName"]);

                 
                    unitDetail.LastName = Convert.ToString(row["LastName"]);

                    unitDetail.CHACode = Convert.ToString(row["CHACode"]);

                    unitDetail.EmailID = Convert.ToString(row["EmailID"]);
                    unitDetail.IsActive = Convert.ToInt32(row["IsActive"]);
                    if (!String.IsNullOrEmpty(row["IsApprove"].ToString()))
                    {
                        unitDetail.IsApprove = Convert.ToBoolean(row["IsApprove"]);
                    }
                    
                    unitDetail.RegistrationDate = Convert.ToString(row["RegistrationDate"]);
                    unitDetail.Gender = Convert.ToString(row["Gender"]);
                    allchadetails.Add(unitDetail);

                }
            }
            return allchadetails;
        }


        public DataTable Rejectcha(int ID, int userid)
        {
            List<ChaRegisterEntity> allchadetails = new List<ChaRegisterEntity>();
            DataTable ds = charegisterRepository.Getchareject(ID, userid);
            return ds;
        }

        public DataTable Acceptcha(int ID, int userid)
        {
            List<ChaRegisterEntity> allchadetails = new List<ChaRegisterEntity>();
            DataTable ds = charegisterRepository.GetchaAccept(ID, userid);
            return ds;
        }

        public ChaRegisterEntity getChadetail(int ID)
        {
            List<ChaRegisterEntity> allchadetails = new List<ChaRegisterEntity>();
            ChaRegisterEntity ds = charegisterRepository.Getchaview(ID);
            return ds;
        }


        public int AddChaDetails(ChaRegisterEntity chaRegister)
        {

            int ds = charegisterRepository.AddChaRegisterDetails(chaRegister);
            return ds;
        }





    }
}
