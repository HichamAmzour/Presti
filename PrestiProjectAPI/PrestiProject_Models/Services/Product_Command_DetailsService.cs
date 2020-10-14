using PrestiProject_DataAccess.Dapper;
using PrestiProject_Models.Interfaces;
using PrestiProject_Models.Models;
using PrestiProject_Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrestiProject_Models.Services
{
    public class Product_Command_DetailsService : IProduct_Command_DetailsService
    {

        private readonly IDataBaseManager _dataBaseManager;

        public Product_Command_DetailsService(IDataBaseManager dataBaseManager)
        {
            _dataBaseManager = dataBaseManager;
        }


        public async Task<bool> AddProduct_Command_Details(IProduct_Command_Details product_Command_Details)
        {
            var param = new
            {
                product_Command_Details.UID,
                product_Command_Details.PRO_Qte,
                product_Command_Details.Total_Price,
                product_Command_Details.UID_PRO,
                product_Command_Details.UID_PRO_Command,
            };

            return await _dataBaseManager.Add("SP_ADD_Product_Command_Details",param);
        }

        public async Task<bool> DeleteProduct_Command_Details(string UID)
        {
            var param = new { UID };
            return await _dataBaseManager.Delete("SP_DELETE_Product_Command_Details", param);
        }

        public async Task<IProduct_Command_Details> FindProduct_Command_Details(string UID)
        {
            string query = @"SELECT * FROM Product_Command_Details WHERE 
                              UID LIKE @UID OR UID_PRO LIKE @UID OR UID_PRO_Command LIKE @UID";

            var param = new { UID };

            return await _dataBaseManager.Find<Product_Command_Details>(query, param);
        }

        public async Task<IEnumerable<IProduct_Command_Details>> GetProduct_Command_Details()
        {
            string query = @"SELECT * FROM Product_Command_Details";

            return await _dataBaseManager.Read<Product_Command_Details>(query);
        }

        public async Task<IEnumerable<IProduct_Command_Details>> GetProduct_Command_Details(int numberOfProduct_Command_Details)
        {
            string query = @"SELECT TOP(@number) * FROM Product_Command_Details";

            var param = new { number= numberOfProduct_Command_Details };

            return await _dataBaseManager.Read<Product_Command_Details>(query, param);
        }

        public async Task<bool> ModifyProduct_Command_Details(IProduct_Command_Details modifiedProduct_Command_Details)
        {
            var param = new
            {
                modifiedProduct_Command_Details.UID,
                modifiedProduct_Command_Details.PRO_Qte,
                modifiedProduct_Command_Details.Total_Price,
                modifiedProduct_Command_Details.UID_PRO,
                modifiedProduct_Command_Details.UID_PRO_Command,
            };

            return await _dataBaseManager.Modify("SP_UPDATE_Product_Command_Details", param);
        }

        public async Task<bool> Product_Command_DetailsExists(IProduct_Command_Details product_Command_Details)
        {
            string query = @"SELECT * FROM Product_Command_Details WHERE 
                              UID LIKE @UID OR UID_PRO_Command LIKE @UID";

            var param = new {
                product_Command_Details.UID,
                product_Command_Details.UID_PRO_Command
            };

            return await _dataBaseManager.Find<Product_Command_Details>(query, param) != null;
        }
    }
}
