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
    public class Product_brandController : ControllerBase
    {

        private readonly IProduct_BrandService _product_brandService;
        private readonly INotificationProvider _notification;
        private readonly string Title = "Product brand ";

        public Product_brandController(IProduct_BrandService product_brandService, INotificationProvider notification)
        {
            _product_brandService = product_brandService;
            _notification = notification;
        }


        [HttpGet("get")]
        public async Task<IEnumerable<IProduct_Brand>> GetProduct_brand()
        {
            return await _product_brandService.GetProduct_Brands();
        }

        [HttpGet("get/{number}")]
        public async Task<IEnumerable<IProduct_Brand>> GetProduct_brand(int numberOfProduct_brand)
        {
            return await _product_brandService.GetProduct_Brands(numberOfProduct_brand);
        }

        [HttpPost("add")]
        public async Task<object> Add(Product_Brand product_brand)
        {
            bool isValid = await _product_brandService.AddProduct_Brand(product_brand);

            _notification.SetNotificationMessage(isValid,Title, product_brand.UID);

            return _notification;
        }

        [HttpPost("edite")]
        public async Task<object> Edite(Product_Brand product_brand)
        {
            bool isValid = await _product_brandService.ModifyProduct_Brand(product_brand);

            _notification.SetNotificationMessage(isValid, Title, product_brand.UID);

            return _notification;
        }

        [HttpPost("delete")]
        public async Task<object> Delete(string UID)
        {
            bool isValid = await _product_brandService.DeleteProduct_Brand(UID);
            _notification.SetNotificationMessage(isValid, Title , UID);

            return _notification;
        }
    }
}
