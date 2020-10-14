using PrestiProject_DataAccess.Dapper;
using PrestiProject_Models.Interfaces;
using PrestiProject_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestiProject_Models.Services
{
    public class Product_StockService : IProduct_StockService
    {
        /*not that We stock product quantity history in Total_Qte field*/
        private readonly IDataBaseManager _dataBaseManager;

        public Product_StockService(IDataBaseManager dataBaseManager)
        {
            _dataBaseManager = dataBaseManager;
        }

        public async Task<bool> AddProduct_Stock(IProduct_Stock product_Stock)
        {
            var param = new
            {
                product_Stock.UID,
                product_Stock.Init_Qte,
                product_Stock.Status,
                product_Stock.Date,
                product_Stock.Product_UID
            };

            return await _dataBaseManager.Add("SP_ADD_Product_Stock", param);
        }

        public async Task<bool> DeleteProduct_Stock(string UID)
        {
            var param = new { UID };

            return await _dataBaseManager.Delete("SP_DELETE_Product_Stock", param);
        }

        public async Task<IProduct_Stock> FindProduct_Stock(string UID_Prod)
        {
            var param = new
            {
               UID_Prod
            };
            string query = @"SELECT * FROM Product_Stock WHERE [Product_UID] LIKE @UID_Prod ";

            return await _dataBaseManager.Find<Product_Stock>(query, param) ;
        }

        public async Task<IEnumerable<IProduct_Stock>> GetProducts_Stock()
        {
            string query = @"SELECT * FROM Product_Stock ";

            return await _dataBaseManager.Read<Product_Stock>(query);
        }

        public async Task<IEnumerable<IProduct_Stock>> GetProducts_Stock(int numberOfProduct_Stock)
        {
            var param = new
            {
                number=numberOfProduct_Stock
            };
            string query = @"SELECT TOP(@number) * FROM Product_Stock";

            return await _dataBaseManager.Read<Product_Stock>(query, param);
        }

        public async Task<bool> ModifyProduct_Stock(IProduct_Stock modifiedProduct_Stock)
        {
            var param = new
            {
                modifiedProduct_Stock.UID,
                modifiedProduct_Stock.Init_Qte,
                modifiedProduct_Stock.Current_Qte,
                modifiedProduct_Stock.Status,
                modifiedProduct_Stock.Date,
                modifiedProduct_Stock.Product_UID
            };

            return await _dataBaseManager.Modify("SP_UPDATE_Product_Stock", param);
        }

        public async Task<bool> Product_StockExists(IProduct_Stock product_Stock)
        {
            var param = new
            {
                Date=product_Stock.Date.ToShortDateString(),
                product_Stock.Product_UID
            };
            string query = @"SELECT * FROM Product_Stock WHERE [Product_UID] LIKE @Product_UID AND [Date] LIKE @Date ";

            return await _dataBaseManager.Find<Product_Stock>(query, param) != null;
        }
    }
}
