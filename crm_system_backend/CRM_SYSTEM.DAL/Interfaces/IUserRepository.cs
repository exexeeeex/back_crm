using CRM_SYSTEM.DAL.Models;
using CRM_SYSTEM.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_SYSTEM.DAL.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<User>> GetAllUserAsync();
        public Task<User> GetUserById(int userId);
        public Task<User> GetUserByName(string value);
        public Task<User> CreateUser(User user);
        public Task<User> UploadAvatar(AvatarViewModel avatarViewModel);
        public string AuthUser(string token);
        public int GetUserCount();
        public Task<User> GetUserInfo(string username);
        public Task<string> GetUserAvatar(string username);
    }
}
