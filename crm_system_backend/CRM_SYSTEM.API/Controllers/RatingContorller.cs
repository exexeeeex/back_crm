using CRM_SYSTEM.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRM_SYSTEM.API.Controllers
{
    [ApiController]
    [Route("api/rating")]
    public class RatingContorller : ControllerBase
    {
        private readonly IRatingService _ratingService;
        public RatingContorller(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpGet]
        [Route("/userrating")]
        public ActionResult GetUserRating(int userId)
        {
            return Ok(_ratingService.GetUserRatingAsync(userId));
        }

        [HttpGet]
        [Route("/getgpa")]
        public ActionResult GetGPA(int userId) =>
            Ok(_ratingService.GetGPA(userId));

        [HttpGet]
        [Route("/getpasses")]
        public ActionResult GetPasses(int useId) =>
            Ok(_ratingService.GetPasses(useId));

        [HttpPost]
        [Route("/rateuser")]
        public async Task<IActionResult> Rate(int userId, string lesson, int grade) =>
            Ok(await _ratingService.EvaluateUser(userId, lesson, grade));

        [HttpGet]
        [Route("/lastgrade")]
        public async Task<IActionResult> GetLastGrades(int userId) =>
            Ok(await _ratingService.GetGradesById(userId));
    }
}
