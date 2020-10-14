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
    public class Product_CategoryService : IProduct_CategoryService
    {

        private readonly IDataBaseManager _dataBaseManager;

        public Product_CategoryService(IDataBaseManager dataBaseManager)
        {
            _dataBaseManager = dataBaseManager;
        }

        public async Task<bool> AddProduct_Category(IProduct_Category product_Category)
        {
            var param = new
            {
                product_Category.UID,
                product_Category.CAT_Date,
                product_Category.CAT_Description,
                product_Category.CAT_Name
            };

            return await _dataBaseManager.Add("SP_ADD_Product_Category", param);
        }

        public async Task<bool> DeleteProduct_Category(string UID)
        {
            var param = new
            {
               UID
            };

            return await _dataBaseManager.Add("SP_DELETE_Product_Category", param);
        }

        public async Task<IProduct_Category> FindProduct_Category(string UID)
        {
            string query = "SELECT * FROM Product_Category WHERE [UID] LIKE @UID";
            var param = new
            {
                UID
            };

            return await _dataBaseManager.Find<Product_Category>(query, param);
        }

        public async Task<IProduct_Category> FindProduct_CategoryByName(string name)
        {
            string query = "SELECT * FROM Product_Category WHERE TRIM(LOWER(CAT_Name)) LIKE TRIM(LOWER(@CAT_Name))";
            var param = new
            {
                CAT_Name= name
            };

            return await _dataBaseManager.Find<Product_Category>(query, param);
        }

        public async Task<IEnumerable<IProduct_Category>> GetProduct_Categories()
        {
            string query = "SELECT * FROM Product_Category";

            return await _dataBaseManager.Read<Product_Category>(query);
        }

        public async Task<IEnumerable<IProduct_Category>> GetProduct_Categories(int numberOfProduct_Categories)
        {
            string query = "SELECT TOP(@number) * FROM Product_Category";
            var param = new
            {
                number = numberOfProduct_Categories
            };

            return await _dataBaseManager.Read<Product_Category>(query, param);
        }

        public async Task<bool> ModifyProduct_Category(IProduct_Category modifiedProduct_Category)
        {
            var param = new
            {
                modifiedProduct_Category.UID,
                modifiedProduct_Category.CAT_Date,
                modifiedProduct_Category.CAT_Description,
                modifiedProduct_Category.CAT_Name
            };

            return await _dataBaseManager.Modify("SP_UPDATE_Product_Category", param);
        }

        public async Task<bool> Product_CategoryExists(IProduct_Category product_Category)
        {
            string query = @"SELECT * FROM Product_Category WHERE [UID] LIKE @UID OR
                            TRIM(LOWER(CAT_Name)) LIKE TRIM(LOWER(@CAT_Name))";
            var param = new
            {
                product_Category.UID,
                product_Category.CAT_Name
            };

            return await _dataBaseManager.Find<Product_Category>(query, param) != null;
        }
    }
}
