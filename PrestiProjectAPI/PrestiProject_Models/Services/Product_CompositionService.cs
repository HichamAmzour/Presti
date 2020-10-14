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
    public class Product_CompositionService : IProduct_CompositionService
    {

        private readonly IDataBaseManager _dataBaseManager;

        public Product_CompositionService(IDataBaseManager dataBaseManager)
        {
            _dataBaseManager = dataBaseManager;
        }

        public async Task<bool> AddProduct_Composition(IProduct_Composition product_Composition)
        {
            var param = new
            {
                product_Composition.UID,
                product_Composition.PDTC_Description,
                product_Composition.PDTC_Extended_Cost,
                product_Composition.PDTC_Libelle,
                product_Composition.PDTC_Price,
                product_Composition.PDTC_Quantity,
                product_Composition.PDTC_Unite,
                product_Composition.PDTC_Unit_Cost,
                product_Composition.PDTC_UID_Compose,
                product_Composition.PDTC_UID_Composant
            };

            return await _dataBaseManager.Add("SP_ADD_Product_Composition", param);
        }

        public async Task<bool> DeleteProduct_Composition(string UID)
        {
            var param = new
            {
                UID
            };

            return await _dataBaseManager.Delete("SP_DELETE_Product_Composition", param);
        }

        public async Task<IProduct_Composition> FindProduct_Composition(string UID)
        {
            string query = @"SELECT * FROM Product_Composition WHERE UID LIKE @UID";
            var param = new
            {
                UID
            };

            return await _dataBaseManager.Find<Product_Composition>(query, param);
        }

        public async Task<IProduct_Composition> FindProduct_CompositionByName(string libelle)
        {
            string query = @"SELECT * FROM Product_Composition WHERE 
                            TRIM(LOWER(PDTC_Libelle)) LIKE TRIM(LOWER(@libelle))";
            var param = new
            {
                libelle
            };

            return await _dataBaseManager.Find<Product_Composition>(query, param);
        }

        public async Task<IEnumerable<IProduct_Composition>> GetProduct_Compositions()
        {
            string query = @"SELECT * FROM Product_Composition";

            return await _dataBaseManager.Read<Product_Composition>(query);
        }

        public async Task<IEnumerable<IProduct_Composition>> GetProduct_Compositions(int numberOfProduct_Compositions)
        {
            string query = @"SELECT TOP(@number) * FROM Product_Composition";
            var param = new
            {
                number = numberOfProduct_Compositions
            };

            return await _dataBaseManager.Read<Product_Composition>(query, param);
        }

        public async Task<bool> ModifyProduct_Composition(IProduct_Composition modifiedProduct_Composition)
        {
            var param = new
            {
                modifiedProduct_Composition.UID,
                modifiedProduct_Composition.PDTC_Description,
                modifiedProduct_Composition.PDTC_Extended_Cost,
                modifiedProduct_Composition.PDTC_Libelle,
                modifiedProduct_Composition.PDTC_Price,
                modifiedProduct_Composition.PDTC_Quantity,
                modifiedProduct_Composition.PDTC_Unite,
                modifiedProduct_Composition.PDTC_Unit_Cost,
                modifiedProduct_Composition.PDTC_UID_Compose,
                modifiedProduct_Composition.PDTC_UID_Composant
            };

            return await _dataBaseManager.Modify("SP_UPDATE_Product_Composition", param);
        }

        public async Task<bool> Product_CompositionExists(IProduct_Composition product_Composition)
        {
            return await FindProduct_CompositionByName(product_Composition.PDTC_Libelle) != null;
        }
    }
}
