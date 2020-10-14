using System.Collections.Generic;
using System.Threading.Tasks;
using PrestiProject_Models.Interfaces;

namespace PrestiProject_Models.Services.Interfaces
{
    public interface IProjectService
    {
        Task<bool> AddProject(IProject project);
        Task<bool> DeleteProject(string UID);
        Task<IProject> FindProject(string UID);
        Task<IEnumerable<IProject>> GetProjects();
        Task<IEnumerable<IProject>> GetProjects(int numberOfProjects);
        Task<bool> ModifyProject(IProject modifiedProject);
        Task<bool> ProjectExists(IProject project);
    }
}