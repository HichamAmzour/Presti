using System.Collections.Generic;
using System.Threading.Tasks;
using PrestiProject_Models.Interfaces;

namespace PrestiProject_Models.Services.Interfaces
{
    public interface ICustomersService
    {
        Task<bool> AddCustomer(ICustomer customer);
        Task<bool> CustomerExists(ICustomer customer);
        Task<bool> DeleteCustomer(string UID);
        Task<ICustomer> FindCustomer(string UID = "", string firstName = "", string lastName = "", string userName = "");
        Task<IEnumerable<ICustomer>> GetCustomers(int numberOfCustomers);
        Task<IEnumerable<ICustomer>> GetCustomers();
        Task<bool> ModifyCustomer(ICustomer ModifiedCustomer);
    }
}