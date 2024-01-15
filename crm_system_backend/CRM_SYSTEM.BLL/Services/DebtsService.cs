using CRM_SYSTEM.BLL.Interfaces;
using CRM_SYSTEM.DAL.Interfaces;
using CRM_SYSTEM.DAL.Models;
using CRM_SYSTEM.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_SYSTEM.BLL.Services
{
    public class DebtsService : IDebtsService
    {
        private readonly IDebtsRepository _debtsRepository;
        public DebtsService(IDebtsRepository debtsRepository)
        {
            _debtsRepository = debtsRepository;
        }
        public Task<Debts> AddDebtsAsync(int userId, string lesson)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Debts>> GetAllDebtsAsync()
        {
            return await _debtsRepository.GetAllDebtsAsync();
        }

        public async Task<List<DebtsViewModel>> GetDebtsByIdAsync(int userId)
        {
            return await _debtsRepository.GetDebtsByIdAsync(userId);
        }
    }
}
