using System.Collections.Generic;
using System.Threading.Tasks;
using PrestiProject_Models.Interfaces;

namespace PrestiProject_Models.Services
{
    public interface IProduct_StockService
    {
        Task<bool>  AddProduct_Stock(IProduct_Stock product_Stock);
        Task<bool>  DeleteProduct_Stock(string UID);
        Task<IProduct_Stock>  FindProduct_Stock(string UID_Prod);
        Task<IEnumerable<IProduct_Stock>>  GetProducts_Stock();
        Task<IEnumerable<IProduct_Stock>>  GetProducts_Stock(int numberOfProduct_Stock);
        Task<bool>  ModifyProduct_Stock(IProduct_Stock modifiedProduct_Stock);
        Task<bool> Product_StockExists(IProduct_Stock product_Stock);
    }
}