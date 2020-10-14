using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PrestiProject_Models.Interfaces;

namespace PrestiProject_Models.Services.Interfaces
{
    public interface IService_CallsService
    {
        Task<bool> AddService_Call(IService_Call service_Call);
        Task<bool> DeleteService_Call(string UID);
        Task<IService_Call> FindService_Call(string UID);
        Task<IService_Call> FindService_CallByDate(DateTime date);
        Task<IEnumerable<IService_Call>> GetService_Calls();
        Task<IEnumerable<IService_Call>> GetService_Calls(int numberOfService_Calls);
        Task<bool> ModifyService_Call(IService_Call modifiedService_Call);
        Task<bool> Service_CallExists(IService_Call service_Call);
    }
}