using CRM_SYSTEM.BLL.Interfaces;
using CRM_SYSTEM.DAL.Data;
using CRM_SYSTEM.DAL.Helpers;
using CRM_SYSTEM.DAL.Models;
using CRM_SYSTEM.DAL.ViewModel;
using CRM_SYSTEM.DAL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace CRM_SYSTEM.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ValidateHelper _validate;
        public UserController(IUserService userService, ValidateHelper validate)
        {
            _userService = userService;
            _validate = validate;
        }

        [HttpGet("value")]
        public async Task<IActionResult> GetByName(string value) =>
            Ok(await _userService.GetUserByName(value));

        [Route("/getall")]
        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _userService.GetAllUserAsync());

        [Route("/getcount")]
        [HttpGet]
        public ActionResult GetCount() =>
            Ok(_userService.GetUserCount());

        [Route("/register")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] User user)
        {
            await _userService.CreateUser(user);
            return Ok("Регистрация прошла успешно");
        }

        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> UserLogin([FromBody] LoginViewModel model)
        {
            var user = await _validate.ValidateUser(model.Email, model.Password);
            if (user == null) throw new ArgumentException("Error");
            else
            {
                var token = JwtData.GenerateToken(model.Email);
                return Ok(new { token });
            }
        }

        [HttpGet]
        [Route("/authuser")]
        public IActionResult Auth(string token) =>
            Ok(_userService.AuthUser(token));

        [HttpGet]
        [Route("/getavatar")]
        public async Task<IActionResult> GetAvatar(string username)
        {
            return Ok(await _userService.GetUserAvatar(username));
        }

        [HttpPut]
        [Route("/uploadavatar")] 
        public async Task<IActionResult> UploadAvatar(AvatarViewModel avatarViewModel)
        {
            return Ok(await _userService.UploadAvatar(avatarViewModel));
        }

        [HttpGet]
        [Route("/getinfo")]
        public async Task<IActionResult> GetInfo(string username)
        {
            return Ok(await _userService.GetUserInfo(username));
        }

        [HttpGet]
        [Route("/getinfobyid")]
        public async Task<IActionResult> GetInfoById(int userId) =>
            Ok(await _userService.GetUserById(userId));

        [HttpPost("upload")]
        public ActionResult UploadImage()
        {
            var file = Request.Form.Files[0];
            var username = Request.Form["username"].ToString();
            var uniqueFileName = Guid.NewGuid().ToString() + $"{username}" + file.FileName;
            var filePath = Path.Combine("UserAvatar", uniqueFileName);
            using var fileStream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fileStream);
            return Ok(new { imageUrl = filePath });
        }
        [HttpGet]
        [Route("api/getimage")]
        public IActionResult GetImage(string avatarName)
        {
            var directoryPath = @"D:\crm_system\crm_system_backend\CRM_SYSTEM.API\UserAvatar";
            var files = Directory.GetFiles(directoryPath, $"*{avatarName}*.jpg");

            if (files.Length > 0)
            {
                var imagePath = files[0];
                var imageBytes = System.IO.File.ReadAllBytes(imagePath);
                return File(imageBytes, "image/jpeg");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
