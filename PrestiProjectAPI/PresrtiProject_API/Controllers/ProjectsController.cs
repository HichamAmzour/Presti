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
    public class ProjectsController : ControllerBase
    {

        private readonly IProjectService _projectService;
        private readonly INotificationProvider _notification;
        private readonly string Title = "Project ";

        public ProjectsController(IProjectService projectService, INotificationProvider notification)
        {
            _projectService = projectService;
            _notification = notification;
        }


        [HttpGet("get")]
        public async Task<IEnumerable<IProject>> GetProject()
        {
            return await _projectService.GetProjects();
        }

        [HttpGet("get/{number}")]
        public async Task<IEnumerable<IProject>> GetProject(int numberOfProject)
        {
            return await _projectService.GetProjects(numberOfProject);
        }

        [HttpPost("add")]
        public async Task<object> Add(Project project)
        {
            bool isValid = await _projectService.AddProject(project);

            _notification.SetNotificationMessage(isValid, Title, project.UID);

            return _notification;
        }

        [HttpPost("edite")]
        public async Task<object> Edite(Project project)
        {
            bool isValid = await _projectService.ModifyProject(project);

            _notification.SetNotificationMessage(isValid, Title, project.UID);

            return _notification;
        }

        [HttpPost("delete")]
        public async Task<object> Delete(string UID)
        {
            bool isValid = await _projectService.DeleteProject(UID);
            _notification.SetNotificationMessage(isValid, Title, UID);

            return _notification;
        }
    }
}
