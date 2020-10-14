using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrestiProject_Models.Interfaces;
using PrestiProject_Models.Models;
using PrestiProject_Models.Services;
using PrestiProject_Models.Services.Interfaces;

namespace PresrtiProject_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {

        private readonly ISuppliersService _supplierService;
        private readonly INotificationProvider _notification;
        private readonly string Title = "Supplier ";

        public SuppliersController(SuppliersService supplierService, INotificationProvider notification)
        {
            _supplierService = supplierService;
            _notification = notification;
        }


        [HttpGet("get")]
        public async Task<IEnumerable<ISupplier>> GetSuppliers()
        {
            return await _supplierService.GetSuppliers();
        }

        [HttpGet("get/{number}")]
        public async Task<IEnumerable<ISupplier>> GetSuppliers(int numberOfSupplier)
        {
            return await _supplierService.GetSuppliers(numberOfSupplier);
        }

        [HttpPost("add")]
        public async Task<object> Add(Supplier supplier)
        {
            bool isValid = await _supplierService.AddSupplier(supplier);

            _notification.SetNotificationMessage(isValid, Title, supplier.UID);

            return _notification;
        }

        [HttpPost("edite")]
        public async Task<object> Edite(Supplier supplier)
        {
            bool isValid = await _supplierService.ModifySupplier(supplier);

            _notification.SetNotificationMessage(isValid, Title, supplier.UID);

            return _notification;
        }

        [HttpPost("delete")]
        public async Task<object> Delete(string UID)
        {
            bool isValid = await _supplierService.DeleteSupplier(UID);
            _notification.SetNotificationMessage(isValid, Title , UID);

            return _notification;
        }
    }
}
