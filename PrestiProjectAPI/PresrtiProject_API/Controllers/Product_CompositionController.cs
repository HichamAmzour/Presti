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
    public class Product_CompositionController : ControllerBase
    {

        private readonly IProduct_CompositionService _product_CompositionService;
        private readonly INotificationProvider _notification;
        private readonly string Title = "Product composition";

        public Product_CompositionController(IProduct_CompositionService product_CompositionService, INotificationProvider notification)
        {
            _product_CompositionService = product_CompositionService;
            _notification = notification;
        }


        [HttpGet("get")]
        public async Task<IEnumerable<IProduct_Composition>> GetProduct_Composition()
        {
            return await _product_CompositionService.GetProduct_Compositions();
        }

        [HttpGet("get/{number}")]
        public async Task<IEnumerable<IProduct_Composition>> GetProduct_Composition(int numberOfProduct_Composition)
        {
            return await _product_CompositionService.GetProduct_Compositions(numberOfProduct_Composition);
        }

        [HttpPost("add")]
        public async Task<object> Add(Product_Composition product_Composition)
        {
            bool isValid = await _product_CompositionService.AddProduct_Composition(product_Composition);

            _notification.SetNotificationMessage(isValid, Title, product_Composition.UID);

            return _notification;
        }

        [HttpPost("edite")]
        public async Task<object> Edite(Product_Composition product_Composition)
        {
            bool isValid = await _product_CompositionService.ModifyProduct_Composition(product_Composition);

            _notification.SetNotificationMessage(isValid, Title, product_Composition.UID);

            return _notification;
        }

        [HttpPost("delete")]
        public async Task<object> Delete(string UID)
        {
            bool isValid = await _product_CompositionService.DeleteProduct_Composition(UID);
            _notification.SetNotificationMessage(isValid, Title, UID);

            return _notification;
        }
    }
}
