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
    public class PropertiesService : IPropertiesService
    {

        private readonly IDataBaseManager _dataBaseManager;

        public PropertiesService(IDataBaseManager dataBaseManager)
        {
            _dataBaseManager = dataBaseManager;
        }


        public async Task<bool> AddProperty(IProperty property)
        {
            var param = new
            {
                property.UID,
                property.Construction_Date,
                property.Description,
                property.Parts_To_Build,
                property.PRO_Lot_Number,
                property.PRO_Name,
                property.PRO_UID_Customer,
                property.PRO_UID_Type,
                property.Size,
                property.Size_Unit,
                property.UID_Address
            };

            return await _dataBaseManager.Add("SP_ADD_Property",param);
        }

        public async Task<bool> DeleteProperty(string UID)
        {
            var param = new { UID };
            return await _dataBaseManager.Delete("SP_DELETE_Property", param);
        }

        public async Task<IProperty> FindProperty(string UID)
        {
            string query = @"SELECT * FROM Properties WHERE [UID] LIKE @UID";

            var param = new { UID };
            return await _dataBaseManager.Find<Property>(query, param);
        }

        public async Task<IProperty> FindPropertyByName(string name)
        {
            string query = @"SELECT * FROM Properties WHERE TRIM(LOWER(PRO_Name)) LIKE TRIM(LOWER(@name))";
            var param = new { name };

            return await _dataBaseManager.Find<Property>(query, param);
        }

        public async Task<IEnumerable<IProperty>> GetProperties()
        {
            string query = @"SELECT * FROM Properties ORDER BY Construction_Date";

            return await _dataBaseManager.Read<Property>(query);
        }

        public async Task<IEnumerable<IProperty>> GetProperties(int numberOfProperties)
        {
            string query = @"SELECT TOP(@number) * FROM Properties ORDER BY Construction_Date";
            var param = new { number=numberOfProperties };

            return await _dataBaseManager.Read<Property>(query, param);
        }

        public async Task<bool> ModifyProperty(IProperty modifiedProperty)
        {
            var param = new
            {
                modifiedProperty.UID,
                modifiedProperty.Construction_Date,
                modifiedProperty.Description,
                modifiedProperty.Parts_To_Build,
                modifiedProperty.PRO_Lot_Number,
                modifiedProperty.PRO_Name,
                modifiedProperty.PRO_UID_Customer,
                modifiedProperty.PRO_UID_Type,
                modifiedProperty.Size,
                modifiedProperty.Size_Unit,
                modifiedProperty.UID_Address
            };

            return await _dataBaseManager.Modify("SP_UPDATE_Property", param);
        }

        public async Task<bool> PropertyExists(IProperty property)
        {
            throw new NotImplementedException();
        }
    }
}
