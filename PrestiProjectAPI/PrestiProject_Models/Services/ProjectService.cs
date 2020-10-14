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
    public class ProjectService : IProjectService
    {

        private readonly IDataBaseManager _dataBaseManager;

        public ProjectService(IDataBaseManager dataBaseManager)
        {
            _dataBaseManager = dataBaseManager;
        }

        public async Task<bool> AddProject(IProject project)
        {
            var param = new
            {
                project.UID,
                project.Cost,
                project.Finished_Date,
                project.Start_Date,
                project.Status,
                project.Project_Title,
                project.Progression,
                project.UID_Property,
                project.Canceled_or_stoped_cause
            };

            return await _dataBaseManager.Add("SP_ADD_Project", param);
        }

        public async Task<bool> DeleteProject(string UID)
        {
            var param = new
            {
                UID
            };

            return await _dataBaseManager.Delete("SP_ADD_Project", param);
        }

        public async Task<IProject> FindProject(string UID)
        {
            string query = @"SELECT * FROM Projects WHERE [UID] LIKE @UID";
            var param = new
            {
                UID
            };

            return await _dataBaseManager.Find<Project>(query, param);
        }

        public async Task<IProject> FindProjectByName(string title)
        {
            string query = @"SELECT * FROM Projects WHERE TRIM(LOWER(Project_Title)) LIKE TRIM(LOWER(title))";
            var param = new
            {
                title
            };

            return await _dataBaseManager.Find<Project>(query, param);
        }

        public async Task<IEnumerable<IProject>> GetProjects()
        {
            string query = @"SELECT * FROM Projects ORDER BY Start_Date";

            return await _dataBaseManager.Read<Project>(query);
        }

        public async Task<IEnumerable<IProject>> GetProjects(int numberOfProjects)
        {
            string query = @"SELECT TOP(number) * FROM Projects ORDER BY Start_Date";
            var param = new
            {
                number= numberOfProjects
            };

            return await _dataBaseManager.Read<Project>(query, param);
        }

        public async Task<bool> ModifyProject(IProject modifiedProject)
        {
            var param = new
            {
                modifiedProject.UID,
                modifiedProject.Cost,
                modifiedProject.Finished_Date,
                modifiedProject.Start_Date,
                modifiedProject.Status,
                modifiedProject.Project_Title,
                modifiedProject.Progression,
                modifiedProject.UID_Property,
                modifiedProject.Canceled_or_stoped_cause
            };

            return await _dataBaseManager.Modify("SP_UPDATE_Project", param);
        }
    

        public async Task<bool> ProjectExists(IProject project)
        {
            return await FindProjectByName(project.Project_Title) != null; 
        }
    }
}
