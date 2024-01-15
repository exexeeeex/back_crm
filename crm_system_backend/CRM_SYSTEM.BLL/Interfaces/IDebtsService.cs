using CRM_SYSTEM.DAL.Models;
using CRM_SYSTEM.DAL.ViewModels;

namespace CRM_SYSTEM.BLL.Interfaces
{
    public interface IDebtsService
    {
        public Task<Debts> AddDebtsAsync(int userId, string lesson);
        public Task<List<Debts>> GetAllDebtsAsync();
        public Task<List<DebtsViewModel>> GetDebtsByIdAsync(int userId);
    }
}
