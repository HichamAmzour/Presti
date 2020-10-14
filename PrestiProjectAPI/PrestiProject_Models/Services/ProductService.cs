using PrestiProject_DataAccess.Dapper;
using PrestiProject_Models.Interfaces;
using PrestiProject_Models.Models;
using PrestiProject_Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestiProject_Models.Services
{
    public class ProductService : IProductService
    {

        private readonly IDataBaseManager _dataBaseManager;

        public ProductService(IDataBaseManager dataBaseManager)
        {
            _dataBaseManager = dataBaseManager;
        }

        public async Task<bool> AddProduct(IProduct product)
        {
            var param = new
            {
                product.UID,
                product.PDTC_Unite,
                product.PRO_Description,
                product.PRO_Enable_Retail_Sales,
                product.PRO_Model_Number,
                product.PRO_Name,
                product.PRO_Price,
                product.PRO_Retail_Price,
                product.PRO_Retail_Tax,
                product.PRO_Special_Price,
                product.PRO_Supply_Price,
                product.PRO_Type,
                product.PRO_UID_Brand,
                product.PRO_UID_Category,
                product.PRO_Video_URL
            };

            return await _dataBaseManager.Add("SP_ADD_Product", param);
        }

        public async Task<bool> DeleteProduct(string UID)
        {
            var param = new { UID };
            return await _dataBaseManager.Delete("SP_ADD_Product", param);
        }

        public async Task<IProduct> FindProduct(string UID)
        {
            var param = new { UID };
            string query = "SELECT * FROM Products WHERE [UID] LIKE @UID";

            return await _dataBaseManager.Find<Product>(query, param);
        }

        public async Task<IProduct> FindProductByName(string name)
        {
            var param = new { name };
            string query = @"SELECT * FROM Products WHERE 
                            TRIM(LOWER([PRO_Name])) LIKE TRIM(LOWER(@name))";

            return await _dataBaseManager.Find<Product>(query, param);
        }

        public async Task<IProduct> FindProductByModelNumber(string modelNumber)
        {
            var param = new { modelNumber };
            string query = "SELECT * FROM Products WHERE [PRO_Model_Number] LIKE @modelNumber";
            return await _dataBaseManager.Find<Product>(query, param);
        }

        public async Task<IEnumerable<IProduct>> GetProducts()
        {
            string query = "SELECT * FROM Products";
            return await _dataBaseManager.Read<Product>(query);
        }

        public async Task<IEnumerable<IProduct>> GetProducts(int numberOfProducts)
        {
            string query = @"SELECT TOP(@number) * FROM Products";
            var param = new { number= numberOfProducts };

            return await _dataBaseManager.Read<Product>(query, param);
        }

        public async Task<bool> ModifyProduct(IProduct modifiedProduct)
        {
            var param = new
            {
                modifiedProduct.UID,
                modifiedProduct.PDTC_Unite,
                modifiedProduct.PRO_Description,
                modifiedProduct.PRO_Enable_Retail_Sales,
                modifiedProduct.PRO_Model_Number,
                modifiedProduct.PRO_Name,
                modifiedProduct.PRO_Price,
                modifiedProduct.PRO_Retail_Price,
                modifiedProduct.PRO_Retail_Tax,
                modifiedProduct.PRO_Special_Price,
                modifiedProduct.PRO_Supply_Price,
                modifiedProduct.PRO_Type,
                modifiedProduct.PRO_UID_Brand,
                modifiedProduct.PRO_UID_Category,
                modifiedProduct.PRO_Video_URL
            };

            return await _dataBaseManager.Modify("SP_UPDATE_Product", param);
        }

        public async Task<bool> ProductExists(IProduct product)
        {
            return await FindProductByName(product.PRO_Name) != null;
        }
    }
}
