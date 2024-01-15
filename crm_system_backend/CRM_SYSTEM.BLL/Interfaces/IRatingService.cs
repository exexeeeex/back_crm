using CRM_SYSTEM.DAL.Models;
using CRM_SYSTEM.DAL.ViewModels;

namespace CRM_SYSTEM.BLL.Interfaces
{
    public interface IRatingService
    {
        public RatingViewModel GetUserRatingAsync(int userId);
        public Task<Rating> EvaluateUser(int userId, string lesson, int grade);
        public double GetGPA(int userId);
        public int GetPasses(int userId);
        public Task<List<LastGradesViewModel>> GetGradesById(int userId);
    }
}
