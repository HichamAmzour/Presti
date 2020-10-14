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
    public class DesignController : ControllerBase
    {
        private readonly IDesignService _designService;
        private readonly INotificationProvider _notification;
        private readonly string Title = "Design ";

        public DesignController(IDesignService designService, INotificationProvider notification)
        {
            _designService = designService;
            _notification = notification;
        }


        [HttpGet("get")]
        public async Task<IEnumerable<IDesign>> GetDesign()
        {
            return await _designService.GetDesignes();
        }

        [HttpGet("get/{number}")]
        public async Task<IEnumerable<IDesign>> GetDesign(int numberOfDesign)
        {
            return await _designService.GetDesignes(numberOfDesign);
        }

        [HttpPost("add")]
        public async Task<object> Add(Design design)
        {
            bool isValid = await _designService.AddDesign(design);

            _notification.SetNotificationMessage(isValid, Title, design.UID);

            return _notification;
        }

        [HttpPost("edite")]
        public async Task<object> Edite(Design design)
        {
            bool isValid = await _designService.ModifyDesign(design);

            _notification.SetNotificationMessage(isValid, Title, design.UID);

            return _notification;
        }

        [HttpPost("delete")]
        public async Task<object> Delete(string UID)
        {
            bool isValid = await _designService.DeleteDesign(UID);
            _notification.SetNotificationMessage(isValid, Title, UID);

            return _notification;
        }
    }
}
