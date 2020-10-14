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
    public class Product_Command_DetailsController : ControllerBase
    {

        private readonly IProduct_Command_DetailsService _product_Command_DetailsService;
        private readonly INotificationProvider _notification;
        private readonly string Title= "Product command details";

        public Product_Command_DetailsController(IProduct_Command_DetailsService product_Command_DetailsService, INotificationProvider notification)
        {
            _product_Command_DetailsService = product_Command_DetailsService;
            _notification = notification;
        }


        [HttpGet("get")]
        public async Task<IEnumerable<IProduct_Command_Details>> GetProduct_Command_Details()
        {
            return await _product_Command_DetailsService.GetProduct_Command_Details();
        }

        [HttpGet("get/{number}")]
        public async Task<IEnumerable<IProduct_Command_Details>> GetProduct_Command_Details(int numberOfProduct_Command_Details)
        {
            return await _product_Command_DetailsService.GetProduct_Command_Details(numberOfProduct_Command_Details);
        }

        [HttpPost("add")]
        public async Task<object> Add(Product_Command_Details product_Command_Details)
        {
            bool isValid = await _product_Command_DetailsService.AddProduct_Command_Details(product_Command_Details);

            _notification.SetNotificationMessage(isValid, Title, product_Command_Details.UID);

            return _notification;
        }

        [HttpPost("edite")]
        public async Task<object> Edite(Product_Command_Details product_Command_Details)
        {
            bool isValid = await _product_Command_DetailsService.ModifyProduct_Command_Details(product_Command_Details);

            _notification.SetNotificationMessage(isValid, Title, product_Command_Details.UID);

            return _notification;
        }

        [HttpPost("delete")]
        public async Task<object> Delete(string UID)
        {
            bool isValid = await _product_Command_DetailsService.DeleteProduct_Command_Details(UID);
            _notification.SetNotificationMessage(isValid, Title , UID);

            return _notification;
        }
    }
}
