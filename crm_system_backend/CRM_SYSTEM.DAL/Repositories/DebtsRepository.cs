using CRM_SYSTEM.DAL.Data;
using CRM_SYSTEM.DAL.Interfaces;
using CRM_SYSTEM.DAL.Models;
using CRM_SYSTEM.DAL.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CRM_SYSTEM.DAL.Repositories
{
    public class DebtsRepository : IDebtsRepository
    {
        private readonly ApplicationContext _context;
        public DebtsRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Task<Debts> AddDebtsAsync(int userId, string lesson)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Debts>> GetAllDebtsAsync()
        {
            return await _context.Debts.ToListAsync();
        }


        public async Task<List<DebtsViewModel>> GetDebtsByIdAsync(int userId)
        {
            var userDebts = await _context.Debts
                .Where(d => d.UserId == userId)
                .Select(d => new DebtsViewModel
                {
                    Id = d.Id,
                    UserId = d.UserId,
                    Lesson = d.LessonId == 1 ? "Math" : d.LessonId == 2 ? "Physics" : "Russian Language",
                    Date = d.Date.ToString("dd.MM.yyyy"),
                })
                .ToListAsync();

            if (userDebts.Any()) return userDebts;
            else throw new ArgumentException("Пользователь не найден");
        }
    }
}
