using System.Collections.Generic;
using System.Threading.Tasks;
using PrestiProject_Models.Interfaces;

namespace PrestiProject_Models.Services.Interfaces
{
    public interface IDesignService
    {
        Task<bool> AddDesign(IDesign design);
        Task<bool> DeleteDesign(string UID);
        Task<bool> DesignExists(IDesign design);
        Task<IDesign> FindDesign(string UID = "", string design_title = "");
        Task<IEnumerable<IDesign>> GetDesignes();
        Task<IEnumerable<IDesign>> GetDesignes(int numberOfDesigns);
        Task<bool> ModifyDesign(IDesign modifiedDesign);
    }
}