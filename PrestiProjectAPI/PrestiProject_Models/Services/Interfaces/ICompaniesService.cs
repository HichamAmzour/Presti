using System.Collections.Generic;
using System.Threading.Tasks;
using PrestiProject_Models.Interfaces;

namespace PrestiProject_Models.Services.Interfaces
{
    public interface ICompaniesService
    {
         Task<bool> AddCompany(ICompany company);
         Task<bool> CompanyExists(ICompany company);
         Task<bool> DeleteCompany(string UID);
         Task<ICompany> FindCompany(string UID);
         Task<IEnumerable<ICompany>> GetCompanies(int numberOfCompanies);
         Task<IEnumerable<ICompany>> GetCompanies();
         Task<bool> ModifyCompany(ICompany ModifiedCompany);
    }
}