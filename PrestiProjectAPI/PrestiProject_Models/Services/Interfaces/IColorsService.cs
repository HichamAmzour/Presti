using System.Collections.Generic;
using System.Threading.Tasks;
using PrestiProject_Models.Interfaces;

namespace PrestiProject_Models.Services.Interfaces
{
    public interface IColorsService
    {
        Task<bool> AddColor(IColor color);
        Task<bool> ColorExists(IColor color);
        Task<bool> DeleteColor(string UID);
        Task<IColor> FindColor(string UID);
        Task<IEnumerable<IColor>> GetColors(int numberOfColors);
        Task<IEnumerable<IColor>> GetColors();
        Task<bool> ModifyColor(IColor NewColor);
    }
}