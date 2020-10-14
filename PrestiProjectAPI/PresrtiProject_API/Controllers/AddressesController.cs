using Microsoft.AspNetCore.Mvc;
using PresrtiProject_API.ID_Provider;
using PresrtiProject_API.Notifications;
using PrestiProject_Models.Interfaces;
using PrestiProject_Models.Models;
using PrestiProject_Models.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PresrtiProject_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {

        private readonly IAddresseService _addressService;
        private readonly INotificationProvider _notification;
        private readonly string Title = "Address ";

        public AddressesController(IAddresseService addressService, INotificationProvider notification)
        {
            _addressService = addressService;
            _notification   = notification;
        }


        [HttpGet("get")]
        public async Task<IEnumerable<IAddress>> GetAddresses()
        {
            return await _addressService.GetAddresses();
        }

        [HttpGet("get/{number}")]
        public async Task<IEnumerable<IAddress>> GetAddress(int numberOfAddress)
        {
            return await _addressService.GetAddresses(numberOfAddress);
        }

        [HttpPost("add")]
        public async Task<object> Add(Address address)
        {
            /***********/
            address.UID  = UIDKeys.ADD+"-"+ UID_Provider.GetUID();
            bool isValid = await _addressService.AddAddress(address);

            _notification.SetNotificationMessage(isValid, Title, address.UID);

            return _notification;
        }

        [HttpPost("edite")]
        public async Task<object> Edite(Address address)
        {
            bool isValid = await _addressService.ModifyAddress(address);

            _notification.SetNotificationMessage(isValid, Title, address.UID);

            return _notification;
        }

        [HttpPost("delete")]
        public async Task<object> Delete(string UID)
        {
            bool isValid = await _addressService.DeleteAddress(UID);
            _notification.SetNotificationMessage(isValid, Title, UID);

            return _notification;
        }


    }
}
