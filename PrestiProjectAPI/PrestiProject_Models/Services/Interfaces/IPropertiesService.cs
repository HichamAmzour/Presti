using System.Collections.Generic;
using System.Threading.Tasks;
using PrestiProject_Models.Interfaces;

namespace PrestiProject_Models.Services.Interfaces
{
    public interface IPropertiesService
    {
        Task<bool> AddProperty(IProperty property);
        Task<bool> DeleteProperty(string UID);
        Task<IProperty> FindProperty(string UID);
        Task<IEnumerable<IProperty>> GetProperties();
        Task<IEnumerable<IProperty>> GetProperties(int numberOfProperties);
        Task<bool> ModifyProperty(IProperty modifiedProperty);
        Task<bool> PropertyExists(IProperty property);
    }
}