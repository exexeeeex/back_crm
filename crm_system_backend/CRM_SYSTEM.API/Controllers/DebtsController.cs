using CRM_SYSTEM.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRM_SYSTEM.API.Controllers
{
    [ApiController]
    [Route("api/debts")]
    public class DebtsController : ControllerBase
    {
        private readonly IDebtsService _debtsService;
        public DebtsController(IDebtsService debtsService)
        {
            _debtsService = debtsService;
        }

        [HttpGet]
        [Route("/alldebts")]
        public async Task<IActionResult> GetAllDebts() =>
            Ok(await _debtsService.GetAllDebtsAsync());

        [HttpGet]
        [Route("/debtsbyid")]
        public async Task<IActionResult> GetDebtsById(int userId) =>
            Ok(await _debtsService.GetDebtsByIdAsync(userId));
    }
}
