using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrestiProject_Models.Interfaces;
using PrestiProject_Models.Models;
using PrestiProject_Models.Services;

namespace PresrtiProject_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class Product_StockController : ControllerBase
    {

        private readonly IProduct_StockService _product_StockService;
        private readonly INotificationProvider _notification;
        private readonly string Title = "Product stock";

        public Product_StockController(IProduct_StockService product_StockService, INotificationProvider notification)
        {
            _product_StockService = product_StockService;
            _notification = notification;
        }


        [HttpGet("get")]
        public async Task<IEnumerable<IProduct_Stock>> GetProduct_Stock()
        {
            return await _product_StockService.GetProducts_Stock();
        }

        [HttpGet("get/{number}")]
        public async Task<IEnumerable<IProduct_Stock>> GetProduct_Stock(int numberOfProduct_Stock)
        {
            return await _product_StockService.GetProducts_Stock(numberOfProduct_Stock);
        }

        [HttpPost("add")]
        public async Task<object> Add(Product_Stock product_Stock)
        {
            bool isValid = await _product_StockService.AddProduct_Stock(product_Stock);

            _notification.SetNotificationMessage(isValid, Title, product_Stock.UID);

            return _notification;
        }

        [HttpPost("edite")]
        public async Task<object> Edite(Product_Stock product_Stock)
        {
            bool isValid = await _product_StockService.ModifyProduct_Stock(product_Stock);

            _notification.SetNotificationMessage(isValid, Title, product_Stock.UID);

            return _notification;
        }

        [HttpPost("delete")]
        public async Task<object> Delete(string UID)
        {
            bool isValid = await _product_StockService.DeleteProduct_Stock(UID);
            _notification.SetNotificationMessage(isValid, Title, UID);

            return _notification;
        }
    }
}
