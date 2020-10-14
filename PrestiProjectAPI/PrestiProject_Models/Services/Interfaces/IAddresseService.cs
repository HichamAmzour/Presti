using System.Collections.Generic;
using System.Threading.Tasks;
using PrestiProject_Models.Interfaces;

namespace PrestiProject_Models.Services.Interfaces
{
    public interface IAddresseService
    {
        Task<bool> AddAddress(IAddress address);
        Task<bool> AddressExists(IAddress address);
        Task<bool> DeleteAddress(string UID);
        Task<IAddress> FindAddress(string UID);
        Task<IEnumerable<IAddress>> GetAddresses();
        Task<IEnumerable<IAddress>> GetAddresses(int numberOfaddresses);
        Task<bool> ModifyAddress(IAddress Newaddress);
    }
}