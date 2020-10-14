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
    public class EmployeesService : IEmployeesService
    {

        private readonly IDataBaseManager _dataBaseManager;

        public EmployeesService(IDataBaseManager dataBaseManager)
        {
            _dataBaseManager = dataBaseManager;
        }

        public async Task<bool> AddEmployee(IEmployee employee)
        {
            var param = new
            {
              employee.UID,
              employee.UID_Address,
              employee.EMP_Employee_Number,
              employee.EMP_Employee_Service,
              employee.EMP_Extension_Number,
              employee.EMP_Last_Login_Date,
              employee.EMP_Phone,
              EMP_BirthDay        = employee.USR_BirthDay,
              EMP_Create_Date     = employee.USR_Create_Date,
              EMP_Email           = employee.USR_Email,
              EMP_First_Name      = employee.USR_First_Name,
              EMP_Hashed_Password = employee.USR_Hashed_Password,
              EMP_Last_Name       = employee.USR_Last_Name,
              EMP_Phone_Mobile    = employee.USR_Phone_Mobile,
              EMP_Salt            = employee.USR_Salt,
              EMP_Username        = employee.USR_Username
            };
            return await _dataBaseManager.Add("SP_ADD_Employee", param);
        }

        public async Task<bool> DeleteEmployee(string UID)
        {
            var param = new { UID };
            return await _dataBaseManager.Delete("SP_DELETE_Employee", param);
        }

        public async Task<bool> EmployeeExists(IEmployee employee)
        {
            string query = @"SELECT * FROM Employees WHERE
                            UID LIKE @UID OR ( TRIM(LOWER(EMP_Username)) LIKE TRIM(LOWER(@USR_Username)) )";
            var param = new
            {
                employee.UID,
                employee.USR_Username
            };
            return await _dataBaseManager.Find<Employee>(query, param) != null;
        }
        
        public async Task<IEmployee> FindEmployee(string UID)
        {
            string query = @"SELECT * FROM Employees WHERE UID LIKE @UID ";
            var param = new
            {
                UID
            };
            return await _dataBaseManager.Find<Employee>(query, param);
        }

        public async Task<IEmployee> FindEmployee(string fisrtName, string lastName)
        {
            string query = @"SELECT * FROM Employees WHERE 
                            TRIM(LOWER(EMP_First_Name)) LIKE TRIM(LOWER(@fisrtName)) AND
                            TRIM(LOWER(EMP_Last_Name)) LIKE TRIM(LOWER(@lastName))";
            var param = new
            {
                fisrtName,
                lastName
            };
            return await _dataBaseManager.Find<Employee>(query, param);
        }

        public async Task<IEmployee> FindEmployeeByUserName(string userName)
        {
             string query = @"SELECT * FROM Employees WHERE 
                            TRIM(LOWER(EMP_Username)) LIKE TRIM(LOWER(@userName))";
            var param = new
            {
                userName
            };
            return await _dataBaseManager.Find<Employee>(query, param);
        }

        public async Task<IEnumerable<IEmployee>> GetEmployees()
        {
            string query = @"SELECT * FROM Employees ";
            return await _dataBaseManager.Read<Employee>(query);
        }

        public async Task<IEnumerable<IEmployee>> GetEmployees(int numberOfEmployees)
        {
            string query = @"SELECT TOP(@number) * FROM Employees ";
            var param = new { number = numberOfEmployees };

            return await _dataBaseManager.Read<Employee>(query, param);
        }

        public async Task<bool> ModifyEmployee(IEmployee mofiedEmployee)
        {
            var param = new
            {
                mofiedEmployee.UID,
                mofiedEmployee.UID_Address,
                mofiedEmployee.EMP_Employee_Number,
                mofiedEmployee.EMP_Employee_Service,
                mofiedEmployee.EMP_Extension_Number,
                mofiedEmployee.EMP_Last_Login_Date,
                mofiedEmployee.EMP_Phone,
                EMP_BirthDay = mofiedEmployee.USR_BirthDay,
                EMP_Create_Date = mofiedEmployee.USR_Create_Date,
                EMP_Email = mofiedEmployee.USR_Email,
                EMP_First_Name = mofiedEmployee.USR_First_Name,
                EMP_Hashed_Password = mofiedEmployee.USR_Hashed_Password,
                EMP_Last_Name = mofiedEmployee.USR_Last_Name,
                EMP_Phone_Mobile = mofiedEmployee.USR_Phone_Mobile,
                EMP_Salt = mofiedEmployee.USR_Salt,
                EMP_Username = mofiedEmployee.USR_Username
            };

            return await _dataBaseManager.Modify("SP_UPDATE_Employee", param);
        }
    }
}
