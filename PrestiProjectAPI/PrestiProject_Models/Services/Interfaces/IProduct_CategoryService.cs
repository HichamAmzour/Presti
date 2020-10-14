using System.Collections.Generic;
using System.Threading.Tasks;
using PrestiProject_Models.Interfaces;

namespace PrestiProject_Models.Services.Interfaces
{
    public interface IProduct_CategoryService
    {
        Task<bool> AddProduct_Category(IProduct_Category product_Category);
        Task<bool> DeleteProduct_Category(string UID);
        Task<IProduct_Category> FindProduct_Category(string UID);
        Task<IProduct_Category> FindProduct_CategoryByName(string name);
        Task<IEnumerable<IProduct_Category>> GetProduct_Categories();
        Task<IEnumerable<IProduct_Category>> GetProduct_Categories(int numberOfProduct_Categories);
        Task<bool> ModifyProduct_Category(IProduct_Category modifiedProduct_Category);
        Task<bool> Product_CategoryExists(IProduct_Category product_Category);
    }
}