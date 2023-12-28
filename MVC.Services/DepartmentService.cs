using MVC.Domain.Model;
using MVC.Repository;
using MVC.Repository.Interface;
using MVC.Services.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Services
{
    public class DepartmentService : IDepartmentService
    {
        public DepartmentRepository departmentRepository = new DepartmentRepository();

     

        


    }
}
