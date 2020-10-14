using PrestiProject_DataAccess.Dapper;
using PrestiProject_Models.Interfaces;
using PrestiProject_Models.Models;
using PrestiProject_Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrestiProject_Models.Services
{
    public class Used_Products_DetailsService : IUsed_Products_DetailsService
    {

        private readonly IDataBaseManager _dataBaseManager;

        public Used_Products_DetailsService(IDataBaseManager dataBaseManager)
        {
            _dataBaseManager = dataBaseManager;
        }

        public async Task<bool> AddUsed_Products_Details(IUsed_Products_Details used_Products_Details)
        {
            var param = new
            {
                used_Products_Details.UID,
                used_Products_Details.Date,
                used_Products_Details.Damaged_numb,
                used_Products_Details.Qte,
                used_Products_Details.UID_PRO,
                used_Products_Details.UID_Project
            };

            return await _dataBaseManager.Add("SP_ADD_Used_Products_Details", param);
        }

        public async Task<bool> DeleteUsed_Products_Details(string UID)
        {
            var param = new
            {
                UID
            };

            return await _dataBaseManager.Delete("SP_DELETE_Used_Products_Details", param);
        }

        public async Task<IUsed_Products_Details> FindUsed_Products_Details(string UID)
        {
            string query = @"SELECT * FROM Used_Products_Details WHERE [UID] LIKE @UID";
            var param = new
            {
                UID
            };

            return await _dataBaseManager.Find<Used_Products_Details>(query, param);
        }

        public async Task<IEnumerable<IUsed_Products_Details>> GetUsed_Products_Details()
        {
            string query = @"SELECT * FROM Used_Products_Details";

            return await _dataBaseManager.Read<Used_Products_Details>(query);
        }

        public async Task<IEnumerable<IUsed_Products_Details>> GetUsed_Products_Details(int numberOfUsed_Products_Details)
        {
            string query = @"SELECT TOP(@number) * FROM Used_Products_Details";
            var param = new
            {
                number= numberOfUsed_Products_Details
            };

            return await _dataBaseManager.Read<Used_Products_Details>(query, param);
        }

        public async Task<bool> ModifyUsed_Products_Details(IUsed_Products_Details modifiedUsed_Products_Details)
        {
            var param = new
            {
                modifiedUsed_Products_Details.UID,
                modifiedUsed_Products_Details.Date,
                modifiedUsed_Products_Details.Damaged_numb,
                modifiedUsed_Products_Details.Qte,
                modifiedUsed_Products_Details.UID_PRO,
                modifiedUsed_Products_Details.UID_Project
            };

            return await _dataBaseManager.Modify("SP_UPDATE_Used_Products_Details", param);
        }

        public async Task<bool> Used_Products_DetailsExists(IUsed_Products_Details used_Products_Details)
        {
            string query = @"SELECT * FROM Used_Products_Details 
                              WHERE [Date] LIKE @Date AND UID_PRO LIKE @UID_PRO AND UID_Project LIKE @UID_Project";
            var param = new
            {
                used_Products_Details.Date,
                used_Products_Details.UID_PRO,
                used_Products_Details.UID_Project
            };

            return await _dataBaseManager.Find<Used_Products_Details>(query,param) != null;
        }
    }
}
