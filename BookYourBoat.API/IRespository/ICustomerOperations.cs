using BookYourBoat.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourBoat.API.Repository
{
    public interface ICustomerOperations
    {
        List<Customer> GetListOfCustomers();
        void SaveCustomer(Customer customer);
    }
}
