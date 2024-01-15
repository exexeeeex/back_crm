using CRM_SYSTEM.DAL.Data;
using CRM_SYSTEM.DAL.Interfaces;
using CRM_SYSTEM.DAL.Models;
using CRM_SYSTEM.DAL.ViewModels;
using Microsoft.EntityFrameworkCore;
using ZstdSharp;

namespace CRM_SYSTEM.DAL.Repositories
{
    public class RatingRepository : IRatingRepostitory
    {
        private readonly ApplicationContext _context;
        public RatingRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Rating> EvaluateUser(int userId, string lesson, int grade)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            var lessons = await _context.Lessons.FirstOrDefaultAsync(l => l.Name == lesson);
            if (user != null && lessons != null)
            {
                var rating = new Rating()
                {
                    UserId = userId,
                    Date = DateTime.Now,
                    LessonId = lessons.Id,
                    Grade = grade
                };
                _context.Ratings.Add(rating);
                await _context.SaveChangesAsync();
                return rating;
            }
            else throw new ArgumentException("Error");
        }

        public double GetGPA(int userId)
        {
            var count = _context.Ratings.Where(r => r.UserId == userId).Count();
            double totalSum = 0;
            double gpa = 0;

            foreach (var user in _context.Ratings.Where(r => r.UserId == userId))
            {
                totalSum += user.Grade;
                gpa = Math.Round((totalSum / count), 2);
            };
            return gpa;
        }

        public async Task<List<LastGradesViewModel>> GetGradesById(int userId)
        {
            var grader = await _context.Ratings
                .Where(u => u.UserId == userId)
                .Select(u => new LastGradesViewModel
                {
                    Id = u.Id,
                    UserId = u.UserId,
                    Lesson = u.LessonId == 1 ? "Math" : u.LessonId == 2 ? "Physics" : "Russian Language",
                    Grade = u.Grade,
                    Date = u.Date.ToString("dd.mm.yyyy")
                })
                .ToListAsync();
            if (grader.Count != 0) return grader;
            else throw new ArgumentException("Ошибка");
        }

        public int GetPasses(int userId)
        {
            var passes = _context.Passes.Where(r => r.UserId == userId).Count();
            return passes;
        }

        public RatingViewModel GetUserRatingAsync(int userId)
        {
            var TotalTwosMath = _context.Ratings
                .Where(r => r.UserId == userId && r.Grade == 2)
                .Count();
            var totalThreesMath = _context.Ratings
                .Where(r => r.UserId == userId && r.Grade == 3)
                .Count();
            var totalFoursMath = _context.Ratings
                .Where(r => r.UserId == userId && r.Grade == 4)
                .Count();
            var totalFivesMath = _context.Ratings
                .Where(r => r.UserId == userId && r.Grade == 5)
                .Count();

            var ratingModel = new RatingViewModel()
            {
                NumberOfTwos = TotalTwosMath,
                NumberOfTriplets = totalThreesMath,
                NumberOfFours = totalFoursMath,
                NumberOfFives = totalFivesMath
            };
            return ratingModel;
        }
    }
}
