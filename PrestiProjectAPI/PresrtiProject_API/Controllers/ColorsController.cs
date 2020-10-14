using Microsoft.AspNetCore.Mvc;
using PrestiProject_Models.Interfaces;
using PrestiProject_Models.Models;
using PrestiProject_Models.Services;
using PrestiProject_Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresrtiProject_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {

        private readonly IColorsService _colorService;
        private readonly INotificationProvider _notification;
        private readonly string Title = "Color ";

        public ColorsController(IColorsService colorService, INotificationProvider notification)
        {
            _colorService = colorService;
            _notification = notification;
        }


        [HttpGet("get")]
        public async Task<IEnumerable<IColor>> GetColors()
        {
            return await _colorService.GetColors();
        }

        [HttpGet("get/{number}")]
        public async Task<IEnumerable<IColor>> GetColors(int numberOfColor)
        {
            return await _colorService.GetColors(numberOfColor);
        }

        [HttpPost("add")]
        public async Task<object> Add(Color color)
        {
            bool isValid = await _colorService.AddColor(color);

            _notification.SetNotificationMessage(isValid, Title, color.UID);

            return _notification;
        }

        [HttpPost("edite")]
        public async Task<object> Edite(Color color)
        {
            bool isValid = await _colorService.ModifyColor(color);

            _notification.SetNotificationMessage(isValid, Title, color.UID);

            return _notification;
        }

        [HttpPost("delete")]
        public async Task<object> Delete(string UID)
        {
            bool isValid = await _colorService.DeleteColor(UID);
            _notification.SetNotificationMessage(isValid, Title, UID);

            return _notification;
        }
    }
}
