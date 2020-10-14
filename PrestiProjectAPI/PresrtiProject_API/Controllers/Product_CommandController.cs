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
    public class Product_CommandController : ControllerBase
    {

        private readonly IProduct_CommandService _product_CommandService;
        private readonly INotificationProvider _notification;
        private readonly string Title = "Product Command";

        public Product_CommandController(IProduct_CommandService product_CommandService, INotificationProvider notification)
        {
            _product_CommandService = product_CommandService;
            _notification = notification;
        }


        [HttpGet("get")]
        public async Task<IEnumerable<IProduct_Command>> GetProduct_Command()
        {
            return await _product_CommandService.GetProduct_Commands();
        }

        [HttpGet("get/{number}")]
        public async Task<IEnumerable<IProduct_Command>> GetProduct_Command(int numberOfProduct_Command)
        {
            return await _product_CommandService.GetProduct_Commands(numberOfProduct_Command);
        }

        [HttpPost("add")]
        public async Task<object> Add(Product_Command product_Command)
        {
            bool isValid = await _product_CommandService.AddProduct_Command(product_Command);

            _notification.SetNotificationMessage(isValid, Title, product_Command.UID);

            return _notification;
        }

        [HttpPost("edite")]
        public async Task<object> Edite(Product_Command product_Command)
        {
            bool isValid = await _product_CommandService.ModifyProduct_Command(product_Command);

            _notification.SetNotificationMessage(isValid, Title, product_Command.UID);

            return _notification;
        }

        [HttpPost("delete")]
        public async Task<object> Delete(string UID)
        {
            bool isValid = await _product_CommandService.DeleteProduct_Command(UID);
            _notification.SetNotificationMessage(isValid, Title, UID);

            return _notification;
        }
    }
}
