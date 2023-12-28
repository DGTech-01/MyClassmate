using MVC.Domain.Model;
using MVC.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IAccountRepository accountRepository;

        public CustomerService(ICustomerRepository customerRepository, IAccountRepository accountRepository)
        {
            this.customerRepository = customerRepository;
            this.accountRepository = accountRepository;
        }

        public User UserList()
        {
            User user = new User();

            accountRepository.Login("", "");
            customerRepository.CustomerList(user);


            return user;

        }
    }
}
