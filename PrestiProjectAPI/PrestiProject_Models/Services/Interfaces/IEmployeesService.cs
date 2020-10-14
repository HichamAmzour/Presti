using System.Collections.Generic;
using System.Threading.Tasks;
using PrestiProject_Models.Interfaces;

namespace PrestiProject_Models.Services.Interfaces
{
    public interface IEmployeesService
    {
        Task<bool> AddEmployee(IEmployee employee);
        Task<bool> DeleteEmployee(string UID);
        Task<bool> EmployeeExists(IEmployee employee);
        Task<IEmployee> FindEmployee(string UID);
        Task<IEmployee> FindEmployee(string fisrtName, string lastName);
        Task<IEmployee> FindEmployeeByUserName(string userName);
        Task<IEnumerable<IEmployee>> GetEmployees();
        Task<IEnumerable<IEmployee>> GetEmployees(int numberOfEmployees);
        Task<bool> ModifyEmployee(IEmployee mofiedEmployee);
    }
}