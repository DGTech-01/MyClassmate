using MVC.Domain.Model;

namespace MVC.Services
{
    public interface IVisitorService
    {
        VisitorModel EditVisitorByID(int ID);
    }
}