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

    public class FilesController : ControllerBase
    {

        private readonly IFilesService _fileService;
        private readonly INotificationProvider _notification;
        private readonly string Title = "File ";

        public FilesController(IFilesService fileService, INotificationProvider notification)
        {
            _fileService = fileService;
            _notification = notification;
        }


        [HttpGet("get")]
        public async Task<IEnumerable<IFile>> GetFiles()
        {
            return await _fileService.GetFiles();
        }

        [HttpGet("get/{number}")]
        public async Task<IEnumerable<IFile>> GetFiles(int numberOfFile)
        {
            return await _fileService.GetFiles(numberOfFile);
        }

        [HttpPost("add")]
        public async Task<object> Add(File file)
        {
            bool isValid = await _fileService.AddFile(file);

            _notification.SetNotificationMessage(isValid, Title, file.UID);

            return _notification;
        }

        [HttpPost("edite")]
        public async Task<object> Edite(File file)
        {
            bool isValid = await _fileService.ModifyFile(file);

            _notification.SetNotificationMessage(isValid, Title, file.UID);

            return _notification;
        }

        [HttpPost("delete")]
        public async Task<object> Delete(string UID)
        {
            bool isValid = await _fileService.DeleteFile(UID);
            _notification.SetNotificationMessage(isValid, Title, UID);

            return _notification;
        }
    }
}
