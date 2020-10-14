using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PrestiProject_Models.Interfaces;

namespace PrestiProject_Models.Services.Interfaces
{
    public interface IProduct_CommandService
    {
        Task<bool> AddProduct_Command(IProduct_Command product_Command);
        Task<bool> DeleteProduct_Command(string UID);
        Task<IProduct_Command> FindProduct_Command(string UID);
        Task<IProduct_Command> FindProduct_Command(DateTime date);
        Task<IEnumerable<IProduct_Command>> GetProduct_Commands();
        Task<IEnumerable<IProduct_Command>> GetProduct_Commands(int numberOfProduct_Commands);
        Task<bool> ModifyProduct_Command(IProduct_Command modifiedProduct_Command);
        Task<bool> Product_CommandExists(IProduct_Command product_Command);
    }
}