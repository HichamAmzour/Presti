using System.Collections.Generic;
using System.Threading.Tasks;
using PrestiProject_Models.Interfaces;

namespace PrestiProject_Models.Services.Interfaces
{
    public interface IProductService
    {
        Task<bool> AddProduct(IProduct product);
        Task<bool> DeleteProduct(string UID);
        Task<IProduct> FindProduct(string UID);
        Task<IProduct> FindProductByName(string name);
        Task<IProduct> FindProductByModelNumber(string modelNumber);
        Task<IEnumerable<IProduct>> GetProducts();
        Task<IEnumerable<IProduct>> GetProducts(int numberOfProducts);
        Task<bool> ModifyProduct(IProduct modifiedProduct);
        Task<bool> ProductExists(IProduct product);
    }
}