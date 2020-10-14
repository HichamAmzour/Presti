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
    public class Product_CategoryController : ControllerBase
    {

        private readonly IProduct_CategoryService _product_CategoryService;
        private readonly INotificationProvider _notification;
        private readonly string Title= "Product category";

        public Product_CategoryController(IProduct_CategoryService product_CategoryService, INotificationProvider notification)
        {
            _product_CategoryService = product_CategoryService;
            _notification = notification;
        }


        [HttpGet("get")]
        public async Task<IEnumerable<IProduct_Category>> GetProduct_Categories()
        {
            return await _product_CategoryService.GetProduct_Categories();
        }

        [HttpGet("get/{number}")]
        public async Task<IEnumerable<IProduct_Category>> GetProduct_Categories(int numberOfProduct_Category)
        {
            return await _product_CategoryService.GetProduct_Categories(numberOfProduct_Category);
        }

        [HttpPost("add")]
        public async Task<object> Add(Product_Category product_Category)
        {
            bool isValid = await _product_CategoryService.AddProduct_Category(product_Category);

            _notification.SetNotificationMessage(isValid, Title, product_Category.UID);

            return _notification;
        }

        [HttpPost("edite")]
        public async Task<object> Edite(Product_Category product_Category)
        {
            bool isValid = await _product_CategoryService.ModifyProduct_Category(product_Category);

            _notification.SetNotificationMessage(isValid, Title , product_Category.UID);

            return _notification;
        }

        [HttpPost("delete")]
        public async Task<object> Delete(string UID)
        {
            bool isValid = await _product_CategoryService.DeleteProduct_Category(UID);
            _notification.SetNotificationMessage(isValid, Title , UID);

            return _notification;
        }
    }
}
