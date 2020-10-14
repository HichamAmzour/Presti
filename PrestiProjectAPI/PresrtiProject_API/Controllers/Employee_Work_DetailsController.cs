using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrestiProject_Models.Interfaces;
using PrestiProject_Models.Models;
using PrestiProject_Models.Services.Interfaces;

namespace PresrtiProject_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class Employee_Work_DetailsController : ControllerBase
    {

        private readonly IEmployee_Work_DetailsService _employee_Work_DetailsService;
        private readonly INotificationProvider _notification;
        private readonly string Title = "Employee work details ";

        public Employee_Work_DetailsController(IEmployee_Work_DetailsService employee_Work_DetailsService, INotificationProvider notification)
        {
            _employee_Work_DetailsService = employee_Work_DetailsService;
            _notification = notification;
        }


        [HttpGet("get")]
        public async Task<IEnumerable<IEmployee_Work_Details>> GetEmployee_Work_Details()
        {
            return await _employee_Work_DetailsService.GetEmployee_Work_Details();
        }

        [HttpGet("get/{number}")]
        public async Task<IEnumerable<IEmployee_Work_Details>> GetEmployee_Work_Details(int numberOfEmployee_Work_Details)
        {
            return await _employee_Work_DetailsService.GetEmployee_Work_Details(numberOfEmployee_Work_Details);
        }

        [HttpPost("add")]
        public async Task<object> Add(Employee_Work_Details employee_Work_Details)
        {
            bool isValid = await _employee_Work_DetailsService.AddEmployee_Work_Detail(employee_Work_Details);

            _notification.SetNotificationMessage(isValid, Title, employee_Work_Details.UID);

            return _notification;
        }

        [HttpPost("edite")]
        public async Task<object> Edite(Employee_Work_Details employee_Work_Details)
        {
            bool isValid = await _employee_Work_DetailsService.ModifyEmployee_Work_Detail(employee_Work_Details);

            _notification.SetNotificationMessage(isValid, Title, employee_Work_Details.UID);

            return _notification;
        }

        [HttpPost("delete")]
        public async Task<object> Delete(string UID)
        {
            bool isValid = await _employee_Work_DetailsService.DeleteEmployee_Work_Detail(UID);
            _notification.SetNotificationMessage(isValid, Title, UID);

            return _notification;
        }
    }
}
