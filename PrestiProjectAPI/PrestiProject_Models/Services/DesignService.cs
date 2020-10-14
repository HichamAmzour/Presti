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
    public class DesignService : IDesignService
    {
        private readonly IDataBaseManager _dataBaseManager;

        public DesignService(IDataBaseManager dataBaseManager)
        {
            _dataBaseManager = dataBaseManager;
        }

        public async Task<bool> AddDesign(IDesign design)
        {
            var param = new
            {
                design.UID,
                design.Date,
                design.Description,
                design.Design_Title,
            };
            return await _dataBaseManager.Add("SP_ADD_Design", param);
        }

        public async Task<bool> DeleteDesign(string UID)
        {
            var param = new { UID };
            return await _dataBaseManager.Add("SP_DELETE_Design", param);
        }

        public async Task<bool> DesignExists(IDesign design)
        {
            string query = @"SELECT * FROM Design WHERE 
                            TRIM(LOWER(Design_Title)) LIKE TRIM(LOWER(@Design_Title))";
            var param = new
            {
                design.Design_Title
            };
            return await _dataBaseManager.Find<Design>(query, param) != null;
        }

        public async Task<IDesign> FindDesign(string UID="", string design_title="")
        {
            string query = @"SELECT * FROM Design WHERE 
                            UID LIKE @UID OR ( TRIM(LOWER(Design_Title)) LIKE TRIM(LOWER(@design_title)) )";
            var param = new
            {
                UID,
                design_title
            };
            return await _dataBaseManager.Find<Design>(query, param);
        }

        public async Task<IEnumerable<IDesign>> GetDesignes()
        {
            string query = @"SELECT * FROM Design";
            return await _dataBaseManager.Read<Design>(query);
        }

        public async Task<IEnumerable<IDesign>> GetDesignes(int numberOfDesigns)
        {
            string query = @"SELECT TOP(@number) * FROM Design";
            var param = new { number= numberOfDesigns };
            return await _dataBaseManager.Read<Design>(query,param);
        }

        public async Task<bool> ModifyDesign(IDesign modifiedDesign)
        {
            var param = new
            {
                modifiedDesign.UID,
                modifiedDesign.Date,
                modifiedDesign.Description,
                modifiedDesign.Design_Title,
            };
            return await _dataBaseManager.Modify("SP_UPDATE_Design", param);
        }
    }
}
