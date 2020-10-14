using System.Collections.Generic;
using System.Threading.Tasks;
using PrestiProject_Models.Interfaces;

namespace PrestiProject_Models.Services.Interfaces
{
    public interface IProduct_CompositionService
    {
        Task<bool> AddProduct_Composition(IProduct_Composition droduct_Composition);
        Task<bool> DeleteProduct_Composition(string UID);
        Task<IProduct_Composition> FindProduct_Composition(string UID);
        Task<IProduct_Composition> FindProduct_CompositionByName(string libelle);
        Task<IEnumerable<IProduct_Composition>> GetProduct_Compositions();
        Task<IEnumerable<IProduct_Composition>> GetProduct_Compositions(int numberOfProduct_Compositions);
        Task<bool> ModifyProduct_Composition(IProduct_Composition modifiedProduct_Composition);
        Task<bool> Product_CompositionExists(IProduct_Composition droduct_Composition);
    }
}