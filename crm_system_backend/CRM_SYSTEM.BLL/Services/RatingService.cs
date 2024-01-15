using CRM_SYSTEM.BLL.Interfaces;
using CRM_SYSTEM.DAL.Interfaces;
using CRM_SYSTEM.DAL.Models;
using CRM_SYSTEM.DAL.ViewModels;

namespace CRM_SYSTEM.BLL.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepostitory _ratingRepository;
        public RatingService(IRatingRepostitory ratingRepostitory)
        {
            _ratingRepository = ratingRepostitory;
        }

        public async Task<Rating> EvaluateUser(int userId, string lesson, int grade)
        {
            return await _ratingRepository.EvaluateUser(userId, lesson, grade);
        }

        public double GetGPA(int userId)
        {
            return _ratingRepository.GetGPA(userId);
        }

        public async Task<List<LastGradesViewModel>> GetGradesById(int userId)
        {
            return await _ratingRepository.GetGradesById(userId);
        }

        public int GetPasses(int userId)
        {
            return _ratingRepository.GetPasses(userId);
        }

        public RatingViewModel GetUserRatingAsync(int userId)
        {
            return _ratingRepository.GetUserRatingAsync(userId);
        }

    }
}
