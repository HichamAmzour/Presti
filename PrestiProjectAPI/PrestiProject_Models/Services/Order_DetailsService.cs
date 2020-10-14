using PrestiProject_DataAccess.Dapper;
using PrestiProject_Models.Interfaces;
using PrestiProject_Models.Models;
using PrestiProject_Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrestiProject_Models.Services
{
    public class Order_DetailsService : IOrder_DetailsService
    {

        private readonly IDataBaseManager _dataBaseManager;

        public Order_DetailsService(IDataBaseManager dataBaseManager)
        {
            _dataBaseManager = dataBaseManager;
        }

        public async Task<bool> AddOrder_Details(IOrder_Details order_Details)
        {
            var param = new
            {
                order_Details.UID,
                order_Details.Date,
                order_Details.UID_Customer,
                order_Details.UID_Design
            };

            return await _dataBaseManager.Add("SP_ADD_Order_Details", param);
        }

        public async Task<bool> DeleteOrder_Details(string UID)
        {
            var param = new { UID };

            return await _dataBaseManager.Delete("SP_DELETE_Order_Details", param);
        }

        public async Task<IOrder_Details> FindOrder_Details(string UID="" , string customerID="")
        {
            string query = @"SELECT * FROM Order_Details WHERE [UID] LIKE @UID OR [UID] LIKE @UID_Customer ";
            var param = new {
                 UID,
                 UID_Customer= customerID
            };

            return await _dataBaseManager.Find<Order_Details>(query,param);
        }

        public async Task<IOrder_Details> FindOrder_Details(DateTime date)
        {
            string query = @"SELECT * FROM Order_Details WHERE [Date] LIKE @date ";
            var param = new
            {
                date=date.ToShortDateString()
            };

            return await _dataBaseManager.Find<Order_Details>(query, param);
        }

        public async Task<IEnumerable<IOrder_Details>> GetOrder_Details()
        {
            string query = "SELECT * FROM Order_Details";
            return await _dataBaseManager.Read<Order_Details>(query);
        }

        public async Task<IEnumerable<IOrder_Details>> GetOrder_Details(int numberOfOrder_Detailss)
        {
            string query = "SELECT TOP(@number) * FROM Order_Details";
            var param = new { number = numberOfOrder_Detailss };

            return await _dataBaseManager.Read<Order_Details>(query,param);
        }

        public async Task<bool> ModifyOrder_Details(IOrder_Details modifiedOrder_Details)
        {
            var param = new
            {
                modifiedOrder_Details.UID,
                modifiedOrder_Details.Date,
                modifiedOrder_Details.UID_Customer,
                modifiedOrder_Details.UID_Design
            };

            return await _dataBaseManager.Modify("SP_UPDATE_Order_Details", param);
        }

        public async Task<bool> Order_DetailsExists(IOrder_Details order_Details)
        {
            string query = @"SELECT * FROM Order_Details WHERE  [UID_Customer] LIKE @UID_Customer AND [Date] LIKE @date ";
            var param = new
            {
                order_Details.UID_Customer,
                date=order_Details.Date.ToShortDateString()
            };

            return await _dataBaseManager.Find<Order_Details>(query, param) != null;
        }
    }
}
