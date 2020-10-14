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
    public class Used_Products_DetailsController : ControllerBase
    {

        private readonly IUsed_Products_DetailsService _used_Products_DetailsService;
        private readonly INotificationProvider _notification;
        private readonly string Title = "Used product details ";

        public Used_Products_DetailsController(IUsed_Products_DetailsService used_Products_DetailsService, INotificationProvider notification)
        {
            _used_Products_DetailsService = used_Products_DetailsService;
            _notification = notification;
        }


        [HttpGet("get")]
        public async Task<IEnumerable<IUsed_Products_Details>> GetUsed_Products_Details()
        {
            return await _used_Products_DetailsService.GetUsed_Products_Details();
        }

        [HttpGet("get/{number}")]
        public async Task<IEnumerable<IUsed_Products_Details>> GetUsed_Products_Details(int numberOfUsed_Products_Details)
        {
            return await _used_Products_DetailsService.GetUsed_Products_Details(numberOfUsed_Products_Details);
        }

        [HttpPost("add")]
        public async Task<object> Add(Used_Products_Details used_Products_Details)
        {
            bool isValid = await _used_Products_DetailsService.AddUsed_Products_Details(used_Products_Details);

            _notification.SetNotificationMessage(isValid, Title, used_Products_Details.UID);

            return _notification;
        }

        [HttpPost("edite")]
        public async Task<object> Edite(Used_Products_Details used_Products_Details)
        {
            bool isValid = await _used_Products_DetailsService.ModifyUsed_Products_Details(used_Products_Details);

            _notification.SetNotificationMessage(isValid, Title, used_Products_Details.UID);

            return _notification;
        }

        [HttpPost("delete")]
        public async Task<object> Delete(string UID)
        {
            bool isValid = await _used_Products_DetailsService.DeleteUsed_Products_Details(UID);
            _notification.SetNotificationMessage(isValid, Title, UID);

            return _notification;
        }
    }
}
