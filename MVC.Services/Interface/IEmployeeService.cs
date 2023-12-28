using MVC.Domain.Model;

namespace MVC.Services
{
    public interface IEmployeeService
    {
        EmployeeModel FetchEmployeeByID(int ID);
    }
}