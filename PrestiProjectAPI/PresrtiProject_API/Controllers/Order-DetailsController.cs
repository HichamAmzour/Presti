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
    public class Order_DetailsController : ControllerBase
    {

        private readonly IOrder_DetailsService _order_DetailsService;
        private readonly INotificationProvider _notification;
        private readonly string Title = "Order details ";

        public Order_DetailsController(IOrder_DetailsService order_DetailsService, INotificationProvider notification)
        {
            _order_DetailsService = order_DetailsService;
            _notification = notification;
        }


        [HttpGet("get")]
        public async Task<IEnumerable<IOrder_Details>> GetOrder_Details()
        {
            return await _order_DetailsService.GetOrder_Details();
        }

        [HttpGet("get/{number}")]
        public async Task<IEnumerable<IOrder_Details>> GetOrder_Details(int numberOfOrder_Details)
        {
            return await _order_DetailsService.GetOrder_Details(numberOfOrder_Details);
        }

        [HttpPost("add")]
        public async Task<object> Add(Order_Details order_Details)
        {
            bool isValid = await _order_DetailsService.AddOrder_Details(order_Details);

            _notification.SetNotificationMessage(isValid, Title, order_Details.UID);

            return _notification;
        }

        [HttpPost("edite")]
        public async Task<object> Edite(Order_Details order_Details)
        {
            bool isValid = await _order_DetailsService.ModifyOrder_Details(order_Details);

            _notification.SetNotificationMessage(isValid, Title, order_Details.UID);

            return _notification;
        }

        [HttpPost("delete")]
        public async Task<object> Delete(string UID)
        {
            bool isValid = await _order_DetailsService.DeleteOrder_Details(UID);
            _notification.SetNotificationMessage(isValid, Title, UID);

            return _notification;
        }
    }
}
