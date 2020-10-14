using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PresrtiProject_API;
using PrestiProject_Models.Interfaces;
using PrestiProject_Models.Models;
using PrestiProject_Models.Services.Interfaces;

namespace PresrtiProject_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {

        private readonly IPropertiesService _propertiesService;
        private readonly INotificationProvider _notification;
        private readonly string Title = "Property ";

        public PropertiesController(IPropertiesService propertyService, INotificationProvider notification)
        {
            _propertiesService = propertyService;
            _notification = notification;
        }


        [HttpGet("get")]
        public async Task<IEnumerable<IProperty>> GetProperties()
        {
            return await _propertiesService.GetProperties();
        }

        [HttpGet("get/{number}")]
        public async Task<IEnumerable<IProperty>> GetProperties(int numberOfProperties)
        {
            return await _propertiesService.GetProperties(numberOfProperties);
        }

        [HttpPost("add")]
        public async Task<object> Add(Property property)
        {
            bool isValid = await _propertiesService.AddProperty(property);

            _notification.SetNotificationMessage(isValid, Title, property.UID);

            return _notification;
        }

        [HttpPost("edite")]
        public async Task<object> Edite(Property property)
        {
            bool isValid = await _propertiesService.ModifyProperty(property);

            _notification.SetNotificationMessage(isValid, Title, property.UID);

            return _notification;
        }

        [HttpPost("delete")]
        public async Task<object> Delete(string UID)
        {
            bool isValid = await _propertiesService.DeleteProperty(UID);
            _notification.SetNotificationMessage(isValid, Title, UID);

            return _notification;
        }
    }
}
