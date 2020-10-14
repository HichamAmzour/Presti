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
    public class Service_CallsService : IService_CallsService
    {

        private readonly IDataBaseManager _dataBaseManager;

        public Service_CallsService(IDataBaseManager dataBaseManager)
        {
            _dataBaseManager = dataBaseManager;
        }

        public async Task<bool> AddService_Call(IService_Call service_Call)
        {
            var param = new
            {
               service_Call.UID,
               service_Call.Caller_Info,
               service_Call.Call_Description,
               service_Call.Date_time,
               service_Call.UID_Customer
            };

            return await _dataBaseManager.Add("SP_ADD_Service_Call", param);
        }

        public async Task<bool> DeleteService_Call(string UID)
        {
            var param = new
            {
                UID
            };

            return await _dataBaseManager.Delete("SP_DELETE_Service_Call", param);
        }

        public async Task<IService_Call> FindService_Call(string UID)
        {
            string query = @"SELECT * FROM Service_Calls WHERE [UID] LIKE @UID";
            var param = new
            {
                UID
            };

            return await _dataBaseManager.Find<Service_Call>(query, param);
        }

        public async Task<IService_Call> FindService_CallByDate(DateTime date)
        {
            string query = @"SELECT * FROM Service_Calls WHERE
                             YEAR(Date_time)=@year AND MONTH(Date_time)=@month AND DAY(Date_time)=@day ";
            var param = new
            {
                year=date.Year,
                month=date.Month,
                day=date.Day
            };

            return await _dataBaseManager.Find<Service_Call>(query, param);
        }

        public async Task<IEnumerable<IService_Call>> GetService_Calls()
        {
            string query = @"SELECT * FROM Service_Calls ORDER BY Date_time";
           
            return await _dataBaseManager.Read<Service_Call>(query);
        }

        public async Task<IEnumerable<IService_Call>> GetService_Calls(int numberOfService_Calls)
        {
            string query = @"SELECT TOP(@number) * FROM Service_Calls ORDER BY Date_time";
            var param = new { number= numberOfService_Calls };

            return await _dataBaseManager.Read<Service_Call>(query, param);
        }

        public async Task<bool> ModifyService_Call(IService_Call modifiedService_Call)
        {
            var param = new
            {
                modifiedService_Call.UID,
                modifiedService_Call.Caller_Info,
                modifiedService_Call.Call_Description,
                modifiedService_Call.Date_time,
                modifiedService_Call.UID_Customer
            };

            return await _dataBaseManager.Modify("SP_UPDATE_Service_Call", param);
        }

        public async Task<bool> Service_CallExists(IService_Call service_Call)
        {
            string query = @"SELECT * FROM Service_Calls WHERE
                             CAST(Date_time AS DATE) LIKE @date AND ( Caller_Info LIKE @Caller_Info OR UID_Customer LIKE @UID_Customer)  ";
            var param = new
            {
               service_Call.Caller_Info,
               date=service_Call.Date_time.ToShortDateString(),
               service_Call.UID_Customer
            };

            return await _dataBaseManager.Find<Service_Call>(query, param) != null;
        }
    }
}
