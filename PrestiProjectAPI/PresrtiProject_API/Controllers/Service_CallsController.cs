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
    public class Service_CallsController : ControllerBase
    {

        private readonly IService_CallsService _service_callService;
        private readonly INotificationProvider _notification;
        private readonly string Title = "Service Call ";

        public Service_CallsController(IService_CallsService service_callService, INotificationProvider notification)
        {
            _service_callService = service_callService;
            _notification = notification;
        }


        [HttpGet("get")]
        public async Task<IEnumerable<IService_Call>> GetService_Calls()
        {
            return await _service_callService.GetService_Calls();
        }

        [HttpGet("get/{number}")]
        public async Task<IEnumerable<IService_Call>> GetService_Calls(int numberOfService_Calls)
        {
            return await _service_callService.GetService_Calls(numberOfService_Calls);
        }

        [HttpPost("add")]
        public async Task<object> Add(Service_Call service_call)
        {
            bool isValid = await _service_callService.AddService_Call(service_call);

            _notification.SetNotificationMessage(isValid, Title, service_call.UID);

            return _notification;
        }

        [HttpPost("edite")]
        public async Task<object> Edite(Service_Call service_call)
        {
            bool isValid = await _service_callService.ModifyService_Call(service_call);

            _notification.SetNotificationMessage(isValid, Title, service_call.UID);

            return _notification;
        }

        [HttpPost("delete")]
        public async Task<object> Delete(string UID)
        {
            bool isValid = await _service_callService.DeleteService_Call(UID);
            _notification.SetNotificationMessage(isValid, Title, UID);

            return _notification;
        }
    }
}
