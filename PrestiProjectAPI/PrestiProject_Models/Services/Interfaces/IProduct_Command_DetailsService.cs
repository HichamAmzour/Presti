using System.Collections.Generic;
using System.Threading.Tasks;
using PrestiProject_Models.Interfaces;

namespace PrestiProject_Models.Services.Interfaces
{
    public interface IProduct_Command_DetailsService
    {
        Task<bool> AddProduct_Command_Details(IProduct_Command_Details product_Command_Details);
        Task<bool> DeleteProduct_Command_Details(string UID);
        Task<IProduct_Command_Details> FindProduct_Command_Details(string UID);
        Task<IEnumerable<IProduct_Command_Details>> GetProduct_Command_Details();
        Task<IEnumerable<IProduct_Command_Details>> GetProduct_Command_Details(int numberOfProduct_Command_Details);
        Task<bool> ModifyProduct_Command_Details(IProduct_Command_Details modifiedProduct_Command_Details);
        Task<bool> Product_Command_DetailsExists(IProduct_Command_Details product_Command_Details);
    }
}