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
    public class Product_CommandService : IProduct_CommandService
    {


        private readonly IDataBaseManager _dataBaseManager;

        public Product_CommandService(IDataBaseManager dataBaseManager)
        {
            _dataBaseManager = dataBaseManager;
        }

        public async Task<bool> AddProduct_Command(IProduct_Command product_Command)
        {
            var param = new
            {
                product_Command.UID,
                product_Command.Date,
                product_Command.UID_Supplier
            };

            return await _dataBaseManager.Add("SP_ADD_Product_Command",param);
        }

        public async Task<bool> DeleteProduct_Command(string UID)
        {
            var param = new
            {
               UID
            };

            return await _dataBaseManager.Delete("SP_DELETE_Product_Command",param);
        }

        public async Task<IProduct_Command> FindProduct_Command(string UID)
        {
            string query = @"SELECT * FROM Product_Command WHERE UID LIKE @UID";
            var param = new
            {
                UID
            };

            return await _dataBaseManager.Find<Product_Command>(query, param);
        }

        public async Task<IProduct_Command> FindProduct_Command(DateTime date)
        {
            string query = @"SELECT * FROM Product_Command WHERE [Date] LIKE @date";
            var param = new
            {
                date= date.ToShortDateString()
            };

            return await _dataBaseManager.Find<Product_Command>(query, param);
        }

        public async Task<IEnumerable<IProduct_Command>> GetProduct_Commands()
        {
            string query = @"SELECT * FROM Product_Command";

            return await _dataBaseManager.Read<Product_Command>(query);
        }

        public async Task<IEnumerable<IProduct_Command>> GetProduct_Commands(int numberOfProduct_Commands)
        {
            string query = @"SELECT TOP(@number) * FROM Product_Command";
            var param = new
            {
               number=numberOfProduct_Commands
            };

            return await _dataBaseManager.Read<Product_Command>(query, param);
        }

        public async Task<bool> ModifyProduct_Command(IProduct_Command modifiedProduct_Command)
        {
            var param = new
            {
                modifiedProduct_Command.UID,
                modifiedProduct_Command.Date,
                modifiedProduct_Command.UID_Supplier
            };

            return await _dataBaseManager.Modify("SP_UPDATE_Product_Command", param);
        }

        public async Task<bool> Product_CommandExists(IProduct_Command product_Command)
        {
            string query = @"SELECT * FROM Product_Command WHERE [Date] LIKE @date AND UID_Supplier LIKE @UID_Supplier";
            var param = new
            {
                date = product_Command.Date.ToShortDateString(),
                product_Command.UID_Supplier
            };

            return await _dataBaseManager.Find<Product_Command>(query, param) !=null;
        }
    }
}
