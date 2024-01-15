using CRM_SYSTEM.DAL.Data;
using CRM_SYSTEM.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CRM_SYSTEM.DAL.Helpers
{
    public class ValidateHelper
    {
        private readonly ApplicationContext _context;
        public ValidateHelper(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<User> ValidateUser(string email, string password)
        {
            User? validateUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == email &&
                u.Password == HashPasswordHelper.HashPassword(password));
            if (validateUser == null) return null;
            else return validateUser;
        }
    }
}
