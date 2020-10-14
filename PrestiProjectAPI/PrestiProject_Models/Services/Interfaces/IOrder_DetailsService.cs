using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PrestiProject_Models.Interfaces;

namespace PrestiProject_Models.Services.Interfaces
{
    public interface IOrder_DetailsService
    {
        Task<bool> AddOrder_Details(IOrder_Details order_Details);
        Task<bool> DeleteOrder_Details(string UID);
        Task<IOrder_Details> FindOrder_Details(string UID = "", string customerID = "");
        Task<IOrder_Details> FindOrder_Details(DateTime date);
        Task<IEnumerable<IOrder_Details>> GetOrder_Details();
        Task<IEnumerable<IOrder_Details>> GetOrder_Details(int numberOfOrder_Detailss);
        Task<bool> ModifyOrder_Details(IOrder_Details modifiedOrder_Details);
        Task<bool> Order_DetailsExists(IOrder_Details order_Details);
    }
}