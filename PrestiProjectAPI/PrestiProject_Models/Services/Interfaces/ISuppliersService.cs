using System.Collections.Generic;
using System.Threading.Tasks;
using PrestiProject_Models.Interfaces;

namespace PrestiProject_Models.Services.Interfaces
{
    public interface ISuppliersService
    {
        Task<bool> AddSupplier(ISupplier supplier);
        Task<bool> DeleteSupplier(string UID);
        Task<ISupplier> FindSupplier(string UID);
        Task<ISupplier> FindSupplierByPhone(string phoneNumber);
        Task<ISupplier> FindSupplierByName(string name);
        Task<IEnumerable<ISupplier>> GetSuppliers();
        Task<IEnumerable<ISupplier>> GetSuppliers(int numberOfSuppliers);
        Task<bool> ModifySupplier(ISupplier modifiedSupplier);
        Task<bool> SupplierExists(ISupplier supplier);
    }
}