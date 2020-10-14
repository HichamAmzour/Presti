using System.Collections.Generic;
using System.Threading.Tasks;
using PrestiProject_Models.Interfaces;

namespace PrestiProject_Models.Services.Interfaces
{
    public interface IFilesService
    {
        Task<bool> AddFile(IFile file);
        Task<bool> DeleteFile(string UID);
        Task<bool> FileExists(IFile file);
        Task<IFile> FindFile(string UID);
        Task<IFile> FindFile(string FilePath, string FileName);
        Task<IEnumerable<IFile>> GetFiles();
        Task<IEnumerable<IFile>> GetFiles(int numberOfFiles);
        Task<bool> ModifyFile(IFile modifiedFile);
    }
}