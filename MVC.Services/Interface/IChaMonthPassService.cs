﻿using MVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Services.Interface
{
    public interface IChaMonthPassService
    { 
        DataTable RejectChaMonthPass(int ID);
        DataTable ChaMonthPassApproved(int ID);
        
    }
}
