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
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;
        private readonly INotificationProvider _notification;
        private readonly string Title = "Product ";

        public ProductsController(IProductService productService, INotificationProvider notification)
        {
            _productService = productService;
            _notification = notification;
        }


        [HttpGet("get")]
        public async Task<IEnumerable<IProduct>> GetProduct()
        {
            return await _productService.GetProducts();
        }

        [HttpGet("get/{number}")]
        public async Task<IEnumerable<IProduct>> GetProduct(int numberOfProduct)
        {
            return await _productService.GetProducts(numberOfProduct);
        }

        [HttpPost("add")]
        public async Task<object> Add(Product product)
        {
            bool isValid = await _productService.AddProduct(product);

            _notification.SetNotificationMessage(isValid, Title, product.UID);

            return _notification;
        }

        [HttpPost("edite")]
        public async Task<object> Edite(Product product)
        {
            bool isValid = await _productService.ModifyProduct(product);

            _notification.SetNotificationMessage(isValid, Title, product.UID);

            return _notification;
        }

        [HttpPost("delete")]
        public async Task<object> Delete(string UID)
        {
            bool isValid = await _productService.DeleteProduct(UID);
            _notification.SetNotificationMessage(isValid, Title, UID);

            return _notification;
        }
    }
}
