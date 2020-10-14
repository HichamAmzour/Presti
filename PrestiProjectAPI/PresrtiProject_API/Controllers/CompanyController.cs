using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrestiProject_Models.Interfaces;
using PrestiProject_Models.Models;
using PrestiProject_Models.Services.Interfaces;

namespace PresrtiProject_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        private readonly ICompaniesService _companiesService;
        private readonly INotificationProvider _notification;
        private readonly string Title = "Company ";

        public CompanyController(ICompaniesService companyService, INotificationProvider notification)
        {
            _companiesService = companyService;
            _notification = notification;
        }


        [HttpGet("get")]
        public async Task<IEnumerable<ICompany>> GetCompanies()
        {
            return await _companiesService.GetCompanies();
        }

        [HttpGet("get/{number}")]
        public async Task<IEnumerable<ICompany>> GetCompanies(int numberOfcompany)
        {
            return await _companiesService.GetCompanies(numberOfcompany);
        }

        [HttpPost("add")]
        public async Task<object> Add(Company company)
        {
            bool isValid = await _companiesService.AddCompany(company);

            _notification.SetNotificationMessage(isValid, Title, company.UID);

            return _notification;
        }

        [HttpPost("edite")]
        public async Task<object> Edite(Company company)
        {
            bool isValid = await _companiesService.ModifyCompany(company);

            _notification.SetNotificationMessage(isValid, Title, company.UID);

            return _notification;
        }

        [HttpPost("delete")]
        public async Task<object> Delete(string UID)
        {
            bool isValid = await _companiesService.DeleteCompany(UID);
            _notification.SetNotificationMessage(isValid, Title, UID);

            return _notification;
        }
    }
}
