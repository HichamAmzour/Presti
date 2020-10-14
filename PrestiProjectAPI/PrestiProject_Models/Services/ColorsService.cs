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
    public class ColorsService : IColorsService
    {
        public IColor _color;
        private readonly IDataBaseManager _dataBaseManager;

        public ColorsService(IColor color, IDataBaseManager dataBaseManager)
        {
            _color = color;
            _dataBaseManager = dataBaseManager;
        }

        public async Task<bool> AddColor(IColor color)
        {
            var param = new
            {
                color.UID,
                color.Color_Name,
                color.Hex,
                color.RGB,
                color.UID_Product
            };

            return await _dataBaseManager.Add("SP_ADD_Color", param);
        }

        public async Task<bool> ColorExists(IColor color)
        {
            var param = new
            {
                color.UID,
                color.Color_Name
            };
            string query = "SELECT * FROM Colors WHERE UID=@UID AND Color_Name=@Color_Name";
            return await _dataBaseManager.Find<Color>(query,param) != null;
        }

        public async Task<bool> DeleteColor(string UID)
        {
            var param = new { UID };
            return await _dataBaseManager.Delete("SP_DELETE_Color",param);
        }

        public async Task<IColor> FindColor(string UID)
        {
            var param = new { UID };
            string query = "SELECT * FROM Colors WHERE UID=@UID AND Color_Name=@Color_Name";
            return await _dataBaseManager.Find<Color>(query, param);
        }

        public async Task<IEnumerable<IColor>> GetColors(int numberOfColors)
        {
            string query = @"SELECT TOP(@num) * FROM Colors";
            var param = new { num = numberOfColors };
            return await _dataBaseManager.Read<Color>(query,param);
        }

        public async Task<IEnumerable<IColor>> GetColors()
        {
            string query = @"SELECT * FROM Colors";
            return await _dataBaseManager.Read<Color>(query);
        }

        public async Task<bool> ModifyColor(IColor NewColor)
        {
            var param = new
            {
                NewColor.UID,
                NewColor.UID_Product,
                NewColor.Color_Name,
                NewColor.Hex,
                NewColor.RGB
            };

            return await _dataBaseManager.Modify("SP_UPDATE_Color", param);
        }
    }
}
