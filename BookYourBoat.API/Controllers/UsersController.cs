using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookYourBoat.API.Model;
using BookYourBoat.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookYourBoat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public ICustomerOperations DBRecords { get; set; }
        public UsersController(ICustomerOperations dBOperations)
        {
            DBRecords = dBOperations;
        }

        [HttpGet]
        [Route("GetCustomers")]
        public List<Customer> GetCustomers()
        {
            return DBRecords.GetListOfCustomers();
        }

        [HttpPost]
        [Route("SaveCustomer")]
        public void SaveCustomer([FromBody] Customer customer)
        {
            DBRecords.SaveCustomer(customer);
        }
    }
}