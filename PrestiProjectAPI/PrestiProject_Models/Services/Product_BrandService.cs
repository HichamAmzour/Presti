using PrestiProject_DataAccess.Dapper;
using PrestiProject_Models.Interfaces;
using PrestiProject_Models.Models;
using PrestiProject_Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrestiProject_Models.Services
{
    public class Product_BrandService : IProduct_BrandService
    {

        private readonly IDataBaseManager _dataBaseManager;

        public Product_BrandService(IDataBaseManager dataBaseManager)
        {
            _dataBaseManager = dataBaseManager;
        }

        public async Task<bool> AddProduct_Brand(IProduct_Brand product_Brand)
        {
            var param = new
            {
              product_Brand.UID,
              product_Brand.BRA_Name,
              product_Brand.BRA_Description,
              product_Brand.BRA_Date
            };

            return await _dataBaseManager.Add("SP_ADD_Product_Brand", param);
        }

        public async Task<bool> DeleteProduct_Brand(string UID)
        {
            var param = new { UID };

            return await _dataBaseManager.Delete("SP_DELETE_Product_Brand", param);
        }

        public async Task<IProduct_Brand> FindProduct_Brand(string UID)
        {
            string query = "SELECT * FROM Product_Brand WHERE [UID] LIKE @UID";
            var param = new { UID };

            return await _dataBaseManager.Find<Product_Brand>(query, param);
        }

        public async Task<IProduct_Brand> FindProduct_BrandByName(string Name)
        {
            string query = "SELECT * FROM Product_Brand WHERE [BRA_Name] LIKE @Name";
            var param = new { Name };

            return await _dataBaseManager.Find<Product_Brand>(query, param);
        }

        public async Task<IEnumerable<IProduct_Brand>> GetProduct_Brands()
        {
            string query = "SELECT * FROM Product_Brand";

            return await _dataBaseManager.Read<Product_Brand>(query);
        }

        public async Task<IEnumerable<IProduct_Brand>> GetProduct_Brands(int numberOfProduct_Brands)
        {
            string query = "SELECT TOP(@number) * FROM Product_Brand";
            var param = new { number = numberOfProduct_Brands };

            return await _dataBaseManager.Read<Product_Brand>(query);
        }

        public async Task<bool> ModifyProduct_Brand(IProduct_Brand modifiedProduct_Brand)
        {
            var param = new
            {
                modifiedProduct_Brand.UID,
                modifiedProduct_Brand.BRA_Name,
                modifiedProduct_Brand.BRA_Description,
                modifiedProduct_Brand.BRA_Date
            };

            return await _dataBaseManager.Modify("SP_UPDATE_Product_Brand", param);
        }

        public async Task<bool> Product_BrandExists(IProduct_Brand product_Brand)
        {
            string query = @"SELECT * FROM Product_Brand WHERE [UID] LIKE @UID
                            OR TRIM(LOWER(BRA_Name)) LIKE TRIM(LOWER(@BRA_Name))";
            var param = new {
                 product_Brand.UID
                ,product_Brand.BRA_Name
            };
            return await _dataBaseManager.Find<Product_Brand>(query, param) != null;
        }
    }
}
