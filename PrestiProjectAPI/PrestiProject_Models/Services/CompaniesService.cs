using PrestiProject_DataAccess.Dapper;
using PrestiProject_Models.Interfaces;
using PrestiProject_Models.Models;
using PrestiProject_Models.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrestiProject_Models.Services
{
    public class CompaniesService : ICompaniesService
    {
        private readonly IDataBaseManager _dataBaseManager;

        public CompaniesService(IDataBaseManager dataBaseManager)
        {
            _dataBaseManager = dataBaseManager;
        }

        public Task<bool> AddCompany(ICompany company)
        {
            var param = new
            {
                company.UID,
                company.COM_GCR,
                company.COM_Name,
                company.COM_NEQ,
                company.COM_RBQ,
                company.COM_TPS,
                company.COM_TVQ,
                company.UID_Address
            };

            return _dataBaseManager.Add("SP_ADD_Company", param);
        }

        public async Task<bool> CompanyExists(ICompany company)
        {
            var param = new { company.UID, company.COM_Name };
            string query = "SELECT * FROM Companies WHERE UID=@UID AND TRIM(LOWER(@COM_Name))=TRIM(LOWER(COM_Name))";
            return await _dataBaseManager.Find<Company>(query, param) != null;
        }

        public async Task<bool> DeleteCompany(string UID)
        {
            var param = new { UID};
            return await _dataBaseManager.Delete("SP_DELETE_Company", param);
        }

        public async Task<ICompany> FindCompany(string UID)
        {
            var param = new { UID };
            string query = "SELECT * FROM Companies WHERE UID=@UID";
            return await _dataBaseManager.Find<Company>(query, param);
        }

        public async Task<IEnumerable<ICompany>> GetCompanies(int numberOfCompanies)
        {
            var param = new { numberOfCompanies };
            string query = "SELECT TOP(@numberOfCompanies) * FROM Companies";
            return await _dataBaseManager.Read<Company>(query, param);
        }

        public async Task<IEnumerable<ICompany>> GetCompanies()
        {
            string query = "SELECT * FROM Companies";
            return await _dataBaseManager.Read<Company>(query);
        }

        public Task<bool> ModifyCompany(ICompany ModifiedCompany)
        {
            var param = new
            {
                ModifiedCompany.UID,
                ModifiedCompany.COM_GCR,
                ModifiedCompany.COM_Name,
                ModifiedCompany.COM_NEQ,
                ModifiedCompany.COM_RBQ,
                ModifiedCompany.COM_TPS,
                ModifiedCompany.COM_TVQ,
                ModifiedCompany.UID_Address
            };

            return _dataBaseManager.Modify("SP_UPDATE_Company", param);
        }
    }
}
