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
    public class FilesService : IFilesService
    {

        private readonly IDataBaseManager _dataBaseManager;

        public FilesService(IDataBaseManager dataBaseManager)
        {
            _dataBaseManager = dataBaseManager;
        }

        public async Task<bool> AddFile(IFile file)
        {
            var param = new
            {
                file.UID,
                file.Date,
                file.FIL_UID_Origin,
                file.FIL_Name,
                file.FIL_Path
            };

            return await _dataBaseManager.Add("SP_ADD_File",param);
        }

        public async Task<bool> DeleteFile(string UID)
        {
            var param = new { UID };

            return await _dataBaseManager.Delete("SP_DELETE_File", param);
        }

        public async Task<bool> FileExists(IFile file)
        {
            var param = new {
                file.UID,
                file.FIL_Name,
                file.FIL_Path
            };
            string query = @"SELECT * FROM Files WHERE 
                             [UID] LIKE @UID OR 
                             (TRIM(LOWER(FIL_Name)) LIKE TRIM(LOWER(@FIL_Name)) 
                              AND TRIM(LOWER(FIL_Path)) LIKE TRIM(LOWER(@FIL_Path)))";

            return await _dataBaseManager.Find<File>(query, param) != null;
        }

        public async Task<IFile> FindFile(string UID)
        {
            var param = new
            {
                UID
            };
            string query = @"SELECT * FROM Files WHERE [UID] LIKE @UID ";

            return await _dataBaseManager.Find<File>(query, param) ;
        }

        public async Task<IFile> FindFile(string FilePath, string FileName)
        {
            var param = new
            {
                FIL_Name= FileName,
                FIL_Path = FilePath
            };
            string query = @"SELECT * FROM Files WHERE 
                             TRIM(LOWER(FIL_Name)) LIKE TRIM(LOWER(@FIL_Name)) AND 
                             TRIM(LOWER(FIL_Path)) LIKE TRIM(LOWER(@FIL_Path)) ";

            return await _dataBaseManager.Find<File>(query, param);
        }

        public async Task<IEnumerable<IFile>> GetFiles()
        {
            string query = @"SELECT * FROM Files ";

            return await _dataBaseManager.Read<File>(query);
        }

        public async Task<IEnumerable<IFile>> GetFiles(int numberOfFiles)
        {
            string query = @"SELECT TOP(@number) * FROM Files ";
            var param = new { number = numberOfFiles };

            return await _dataBaseManager.Read<File>(query, param);
        }

        public async Task<bool> ModifyFile(IFile modifiedFile)
        {
            var param = new
            {
                modifiedFile.UID,
                modifiedFile.Date,
                modifiedFile.FIL_UID_Origin,
                modifiedFile.FIL_Name,
                modifiedFile.FIL_Path
            };

            return await _dataBaseManager.Modify("SP_UPDATE_File", param);
        }
    }
}
