using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrestiProject_Models.Interfaces;
using PrestiProject_Models.Models;
using PrestiProject_Models.Services;
using PrestiProject_Models.Services.Interfaces;

namespace PresrtiProject_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly IEmployeesService _employeeService;
        private readonly INotificationProvider _notification;
        private readonly string Title = "Employee ";

        public EmployeesController(IEmployeesService employeeService, INotificationProvider notification)
        {
            _employeeService = employeeService;
            _notification = notification;
        }


        [HttpGet("get")]
        public async Task<IEnumerable<IEmployee>> GetEmployee()
        {
            return await _employeeService.GetEmployees();
        }

        [HttpGet("get/{number}")]
        public async Task<IEnumerable<IEmployee>> GetEmployee(int numberOfEmployee)
        {
            return await _employeeService.GetEmployees(numberOfEmployee);
        }

        [HttpPost("add")]
        public async Task<object> Add(Employee employee)
        {
            bool isValid = await _employeeService.AddEmployee(employee);

            _notification.SetNotificationMessage(isValid, Title, employee.UID);

            return _notification;
        }

        [HttpPost("edite")]
        public async Task<object> Edite(Employee employee)
        {
            bool isValid = await _employeeService.ModifyEmployee(employee);

            _notification.SetNotificationMessage(isValid, Title, employee.UID);

            return _notification;
        }

        [HttpPost("delete")]
        public async Task<object> Delete(string UID)
        {
            bool isValid = await _employeeService.DeleteEmployee(UID);
            _notification.SetNotificationMessage(isValid, Title, UID);

            return _notification;
        }
    }
}
