using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PrestiProject_Models.Interfaces;

namespace PrestiProject_Models.Services.Interfaces
{
    public interface IEmployee_Work_DetailsService
    {
        Task<bool> AddEmployee_Work_Detail(IEmployee_Work_Details employee_Work_Detail);
        Task<bool> DeleteEmployee_Work_Detail(string UID);
        Task<bool> Employee_Work_DetailExists(IEmployee_Work_Details employee_Work_Detail);
        Task<IEmployee_Work_Details> FindEmployee_Work_Detail(DateTime date, string employeeUID = "", string projectUID = "");
        Task<IEnumerable<IEmployee_Work_Details>> GetEmployee_Work_Details();
        Task<IEnumerable<IEmployee_Work_Details>> GetEmployee_Work_Details(int numberOfEmployee_Work_Details);
        Task<bool> ModifyEmployee_Work_Detail(IEmployee_Work_Details modifiedEmployee_Work_Detail);
    }
}