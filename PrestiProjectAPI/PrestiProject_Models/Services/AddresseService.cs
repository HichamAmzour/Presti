using PrestiProject_DataAccess.Dapper;
using PrestiProject_Models.Interfaces;
using PrestiProject_Models.Models;
using PrestiProject_Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrestiProject_Models.Services
{
    public class AddresseService : IAddresseService
    {
        
        private readonly IDataBaseManager _dataBaseManager;

        public AddresseService(IDataBaseManager dataBaseManager)
        {
            _dataBaseManager = dataBaseManager;
        }

        public async Task<bool> AddAddress(IAddress InsertedAddress)
        {
            var param = new
            {
                InsertedAddress.UID,
                InsertedAddress.ADR_City,
                InsertedAddress.ADR_Country,
                InsertedAddress.ADR_Number,
                InsertedAddress.ADR_Postal_Code,
                InsertedAddress.ADR_State,
                InsertedAddress.ADR_Street,
                InsertedAddress.ADR_Suite
            };

            return await _dataBaseManager.Add("SP_ADD_Address", param);
        }

        public async Task<bool> ModifyAddress(IAddress Newaddress)
        {
            var param = new
            {
                Newaddress.UID,
                Newaddress.ADR_City,
                Newaddress.ADR_Country,
                Newaddress.ADR_Number,
                Newaddress.ADR_Postal_Code,
                Newaddress.ADR_State,
                Newaddress.ADR_Street,
                Newaddress.ADR_Suite
            };

            return await _dataBaseManager.Modify("SP_UPDATE_Address", param);

        }

        public async Task<bool> DeleteAddress(string UID)
        {
            var param = new
            {
                UID
            };

            return await _dataBaseManager.Delete("SP_DELETE_Address",param);
        }

        public async Task<IEnumerable<IAddress>> GetAddresses()
        {
            return await _dataBaseManager.Read<Address>($"SELECT * FROM Addresses");
        }

        public async Task<IEnumerable<IAddress>> GetAddresses(int numberOfaddresses)
        {
            string query = $"SELECT TOP(@numberOfaddresses) * FROM Addresses";
            var param = new { numberOfaddresses };

            return  await _dataBaseManager.Read<Address>(query,param);
        }

        public async Task<bool> AddressExists(IAddress address)
        {
            string query = @"SELECT * FROM Addresses WHERE ADR_City LIKE @ADR_City AND ADR_Country LIKE @ADR_Country 
                             ADR_Street LIKE @ADR_Street AND ADR_Number LIKE @ADR_Number AND ADR_State LIKE @ADR_State";

            var param = new {
                   address.ADR_City,
                   address.ADR_Country,
                   address.ADR_Number,
                   address.ADR_State,
                   address.ADR_Street
            };

            return await _dataBaseManager.Find<Address>(query, param) != null;
        }

        public async Task<IAddress> FindAddress(string UID)
        {
            string query = "SELECT * FROM Addresses WHERE UID=@UID";
            var param = new
            {
                UID
            };

            return await _dataBaseManager.Find<Address>(query, param);
        }

    }
}
