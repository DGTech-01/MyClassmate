using MVC.Domain.Model;

namespace MVC.Repository
{
    public interface IEmployeeRepository
    {
        EmployeeModel FetchEmployeeByID(int ID);
    }
}