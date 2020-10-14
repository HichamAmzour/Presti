using System.Collections.Generic;
using System.Threading.Tasks;
using PrestiProject_Models.Interfaces;

namespace PrestiProject_Models.Services.Interfaces
{
    public interface IUsed_Products_DetailsService
    {
        Task<bool> AddUsed_Products_Details(IUsed_Products_Details used_Products_Details);
        Task<bool> DeleteUsed_Products_Details(string UID);
        Task<IUsed_Products_Details> FindUsed_Products_Details(string UID);
        Task<IEnumerable<IUsed_Products_Details>> GetUsed_Products_Details();
        Task<IEnumerable<IUsed_Products_Details>> GetUsed_Products_Details(int numberOfUsed_Products_Details);
        Task<bool> ModifyUsed_Products_Details(IUsed_Products_Details NewUsed_Products_Details);
        Task<bool> Used_Products_DetailsExists(IUsed_Products_Details used_Products_Details);
    }
}