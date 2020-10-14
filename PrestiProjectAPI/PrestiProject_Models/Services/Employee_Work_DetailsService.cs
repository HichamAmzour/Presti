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
    public class Employee_Work_DetailsService : IEmployee_Work_DetailsService
    {

        private readonly IDataBaseManager _dataBaseManager;

        public Employee_Work_DetailsService(IDataBaseManager dataBaseManager)
        {
            _dataBaseManager = dataBaseManager;
        }

        public async Task<bool> AddEmployee_Work_Detail(IEmployee_Work_Details employee_Work_Detail)
        {
            var param = new
            {
                employee_Work_Detail.UID,
                employee_Work_Detail.Date,
                employee_Work_Detail.Worked_hours,
                employee_Work_Detail.UID_Employee,
                employee_Work_Detail.UID_Project
            };
            return await _dataBaseManager.Add("SP_ADD_Employee_Work_Details",param);
        }

        public async Task<bool> DeleteEmployee_Work_Detail(string UID)
        {
            var param = new { UID };
            return await _dataBaseManager.Delete("SP_DELETE_EmployeeWork_Details", param);
        }

        public async Task<bool> Employee_Work_DetailExists(IEmployee_Work_Details employee_Work_Detail)
        {
            string query = @"SELECT * FROM Employee_Work_Details WHERE
                            [Date]=@Date AND UID_Employee=@UID_Employee
                            AND UID_Project=@UID_Project";
            var param = new
            {
                employee_Work_Detail.Date,
                employee_Work_Detail.UID_Employee,
                employee_Work_Detail.UID_Project
            };

            return await _dataBaseManager.Find<Employee_Work_Details>(query,param) != null;
        }

        public async Task<IEmployee_Work_Details> FindEmployee_Work_Detail(DateTime date,string employeeUID="", string projectUID="")
        {
            string query = @"SELECT * FROM Employee_Work_Details WHERE 
                             [Date]=@date AND (UID_Employee LIKE @employeeUID OR UID_Project LIKE @projectUID) ";
            var param = new
            {
                date,
                employeeUID,
                projectUID
            };

            return await _dataBaseManager.Find<Employee_Work_Details>(query, param);
        }

        public async Task<IEnumerable<IEmployee_Work_Details>> GetEmployee_Work_Details()
        {
            string query = "SELECT * FROM Employee_Work_Detailes";

            return await _dataBaseManager.Read< Employee_Work_Details>(query);
        }

        public async Task<IEnumerable<IEmployee_Work_Details>> GetEmployee_Work_Details(int numberOfEmployee_Work_Details)
        {
            string query = "SELECT TOP(@number) * FROM Employee_Work_Detailes";
            var param = new { number=numberOfEmployee_Work_Details };

            return await _dataBaseManager.Read<Employee_Work_Details>(query,param);
        }

        public async Task<bool> ModifyEmployee_Work_Detail(IEmployee_Work_Details modifiedEmployee_Work_Detail)
        {
            var param = new
            {
                modifiedEmployee_Work_Detail.UID,
                modifiedEmployee_Work_Detail.Date,
                modifiedEmployee_Work_Detail.Worked_hours,
                modifiedEmployee_Work_Detail.UID_Employee,
                modifiedEmployee_Work_Detail.UID_Project
            };

            return await _dataBaseManager.Modify("SP_UPDATE_Employee_Work_Details", param);
        }
    }
}
