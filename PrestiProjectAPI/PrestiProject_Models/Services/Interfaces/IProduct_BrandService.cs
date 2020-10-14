using System.Collections.Generic;
using System.Threading.Tasks;
using PrestiProject_Models.Interfaces;

namespace PrestiProject_Models.Services.Interfaces
{
    public interface IProduct_BrandService
    {
        Task<bool> AddProduct_Brand(IProduct_Brand product_Brand);
        Task<bool> DeleteProduct_Brand(string UID);
        Task<IProduct_Brand> FindProduct_Brand(string UID);
        Task<IProduct_Brand> FindProduct_BrandByName(string Name);
        Task<IEnumerable<IProduct_Brand>> GetProduct_Brands();
        Task<IEnumerable<IProduct_Brand>> GetProduct_Brands(int numberOfProduct_Brands);
        Task<bool> ModifyProduct_Brand(IProduct_Brand modifiedProduct_Brand);
        Task<bool> Product_BrandExists(IProduct_Brand product_Brand);
    }
}