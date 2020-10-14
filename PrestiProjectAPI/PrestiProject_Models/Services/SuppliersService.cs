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
    public class SuppliersService : ISuppliersService
    {
        private readonly IDataBaseManager _dataBaseManager;

        public SuppliersService(IDataBaseManager dataBaseManager)
        {
            _dataBaseManager = dataBaseManager;
        }

        public async Task<bool> AddSupplier(ISupplier supplier)
        {
            var param = new
            {
                supplier.UID,
                supplier.SUP_Contact_Name,
                supplier.SUP_Email,
                supplier.SUP_Name,
                supplier.SUP_Phone,
                supplier.SUP_Type,
                supplier.SUP_URL,
                supplier.UID_Address

            };

            return await _dataBaseManager.Add("SP_ADD_Supplier",param);
        }

        public async Task<bool> DeleteSupplier(string UID)
        {
            var param = new { UID };

            return await _dataBaseManager.Delete("SP_DELETE_Supplier", param);
        }

        public async Task<ISupplier> FindSupplier(string UID)
        {
            string query = @"SELECT * FROM Suppliers WHERE [UID] LIKE @UID";

            var param = new { UID };

            return await _dataBaseManager.Find<Supplier>(query, param);
        }

        public async Task<ISupplier> FindSupplierByPhone(string phoneNumber)
        {
            string query = @"SELECT * FROM Suppliers WHERE [SUP_Phone] LIKE @SUP_Phone";

            var param = new { phoneNumber };

            return await _dataBaseManager.Find<Supplier>(query, param);
        }

        public async Task<ISupplier> FindSupplierByName(string name)
        {
            string query = @"SELECT * FROM Suppliers WHERE [SUP_Name] LIKE @name";

            var param = new { name };

            return await _dataBaseManager.Find<Supplier>(query, param);
        }

        public async Task<IEnumerable<ISupplier>> GetSuppliers()
        {
            string query = @"SELECT * FROM Suppliers";

            return await _dataBaseManager.Read<Supplier>(query);
        }

        public async Task<IEnumerable<ISupplier>> GetSuppliers(int numberOfSuppliers)
        {
            string query = @"SELECT TOP(@number) * FROM Suppliers";

            var param = new { number= numberOfSuppliers };

            return await _dataBaseManager.Read<Supplier>(query, param);
        }

        public async Task<bool> ModifySupplier(ISupplier modifiedSupplier)
        {
            var param = new
            {
                modifiedSupplier.UID,
                modifiedSupplier.SUP_Contact_Name,
                modifiedSupplier.SUP_Email,
                modifiedSupplier.SUP_Name,
                modifiedSupplier.SUP_Phone,
                modifiedSupplier.SUP_Type,
                modifiedSupplier.SUP_URL,
                modifiedSupplier.UID_Address

            };

            return await _dataBaseManager.Modify("SP_UPDATE_Supplier", param);
        }

        public async Task<bool> SupplierExists(ISupplier supplier)
        {
            return await FindSupplier(supplier.UID)!=null || FindSupplierByName(supplier.SUP_Name)!=null || FindSupplierByPhone(supplier.SUP_Phone) !=null;
        }
    }
}
