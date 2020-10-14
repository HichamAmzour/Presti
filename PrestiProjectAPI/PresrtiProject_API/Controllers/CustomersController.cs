using Microsoft.AspNetCore.Mvc;
using PrestiProject_Models.Interfaces;
using PrestiProject_Models.Models;
using PrestiProject_Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresrtiProject_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController: ControllerBase
    {

        private readonly ICustomersService _customersService;
        private readonly INotificationProvider _notification;
        private readonly string Title = "Customer ";

        public CustomersController(ICustomersService customersService, INotificationProvider notification)
        {
            _customersService = customersService;
            _notification = notification;
        }


        [HttpGet("get")]
        public async Task<IEnumerable<ICustomer>> GetCustomers()
        {
            return await _customersService.GetCustomers();
        }

        [HttpGet("get/{number}")]
        public async Task<IEnumerable<ICustomer>> GetCustomers(int numberOfCustomers)
        {
            return await _customersService.GetCustomers(numberOfCustomers);
        }

        [HttpPost("add")]
        public async Task<object> Add(Customer customers)
        {
            bool isValid = await _customersService.AddCustomer(customers);

            _notification.SetNotificationMessage(isValid, Title, customers.UID);

            return _notification;
        }

        [HttpPost("edite")]
        public async Task<object> Edite(Customer customers)
        {
            bool isValid = await _customersService.ModifyCustomer(customers);

            _notification.SetNotificationMessage(isValid, Title, customers.UID);

            return _notification;
        }

        [HttpPost("delete")]
        public async Task<object> Delete(string UID)
        {
            bool isValid = await _customersService.DeleteCustomer(UID);
            _notification.SetNotificationMessage(isValid, Title, UID);

            return _notification;
        }
    }
}
