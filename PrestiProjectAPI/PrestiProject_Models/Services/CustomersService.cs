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
    public class CustomersService : ICustomersService
    {
        private readonly IDataBaseManager _dataBaseManager;

        public CustomersService(IDataBaseManager dataBaseManager)
        {
            _dataBaseManager = dataBaseManager;
        }

        public async Task<bool> AddCustomer(ICustomer customer)
        {
            var param = new
            {
                customer.UID,
                CUS_First_Name      = customer.USR_First_Name,
                CUS_Last_Name       = customer.USR_Last_Name,
                CUS_Hashed_Password = customer.USR_Hashed_Password,
                CUS_Salt            = customer.USR_Salt,
                CUS_Email           = customer.USR_Email,
                CUS_Created_DateTime= customer.USR_Create_Date,
                CUS_Birth_Day       = customer.USR_BirthDay,
                CUS_Mobile          = customer.USR_Phone_Mobile,
                CUS_Username        = customer.USR_Username,
                customer.UID_Address,
                customer.CUS_Spouse_First_Name,
                customer.CUS_Spouse_Last_Name,
                customer.CUS_Phone,
                customer.CUS_Notes,
                customer.CUS_Notes_2,
            };

            return await _dataBaseManager.Add("SP_ADD_Customer",param);
        }

        public async Task<bool> CustomerExists(ICustomer customer)
        {
            var param = new
            {
                customer.USR_First_Name,
                customer.USR_Last_Name,
                customer.USR_Username
            };
            string query = @"SELECT * FROM Customers WHERE 
                            TRIM(LOWER(@USR_First_Name))=TRIM(LOWER(CUS_First_Name))
                            TRIM(LOWER(@USR_Last_Name)  =TRIM(LOWER(CUS_Last_Name))
                            TRIM(LOWER(@USR_Username))  =TRIM(LOWER(CUS_Username))";

            return await _dataBaseManager.Find<Customer>(query, param) != null;
        }

        public async Task<bool> DeleteCustomer(string UID)
        {
            var param = new { UID };
            return await _dataBaseManager.Delete("SP_DELETE_Customer", param);
        }

        public async Task<ICustomer> FindCustomer(string UID="", string firstName="", string lastName="", string userName="")
        {
            var param = new
            {
              UID,
              firstName,
              lastName,
              userName
            };
            string query = @"SELECT * FROM Customers WHERE
                            UID=@UID OR (
                            TRIM(LOWER(@firstName))=TRIM(LOWER(CUS_First_Name))
                            TRIM(LOWER(@lastName)  =TRIM(LOWER(CUS_Last_Name))
                            TRIM(LOWER(@userName))  =TRIM(LOWER(CUS_Username)) )";

            return await _dataBaseManager.Find<Customer>(query, param);
        }

        public async Task<IEnumerable<ICustomer>> GetCustomers()
        {
            return await _dataBaseManager.Read<Customer>("SELECT * FROM Customers");
        }

        public async Task<IEnumerable<ICustomer>> GetCustomers(int numberOfCustomers)
        {
            string query = "SELECT TOP(@numberOfCustomers) * FROM Customers";
            var param = new
            {
                numberOfCustomers
            };
            return await _dataBaseManager.Read<Customer>(query,param);
        }

        public async Task<bool> ModifyCustomer(ICustomer ModifiedCustomer)
        {
            var param = new
            {
                ModifiedCustomer.UID,
                CUS_First_Name       = ModifiedCustomer.USR_First_Name,
                CUS_Last_Name        = ModifiedCustomer.USR_Last_Name,
                CUS_Hashed_Password  = ModifiedCustomer.USR_Hashed_Password,
                CUS_Salt             = ModifiedCustomer.USR_Salt,
                CUS_Email            = ModifiedCustomer.USR_Email,
                CUS_Created_DateTime = ModifiedCustomer.USR_Create_Date,
                CUS_Mobile           = ModifiedCustomer.USR_Phone_Mobile,
                CUS_Birth_Day        = ModifiedCustomer.USR_BirthDay,
                CUS_Username         = ModifiedCustomer.USR_Username,
                ModifiedCustomer.UID_Address,
                ModifiedCustomer.CUS_Spouse_First_Name,
                ModifiedCustomer.CUS_Spouse_Last_Name,
                ModifiedCustomer.CUS_Phone,
                ModifiedCustomer.CUS_Notes,
                ModifiedCustomer.CUS_Notes_2,
            };

            return await _dataBaseManager.Modify("SP_UPDATE_Customer", param);
        }
    }
}
