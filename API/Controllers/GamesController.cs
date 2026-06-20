using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/games")]
    public class GamesController : ControllerBase
    {
        private readonly AdminService adminService = new AdminService();
        private readonly ILogger<GamesController> _logger;

        public GamesController(ILogger<GamesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetGames()
        {
            return Ok(adminService.GetAllGames());
        }

        [HttpGet("{id}")]
        public IActionResult GetGameById(int id)
        {
            if (id <= 0)
                return BadRequest("ID game tidak valid.");

            try
            {
                return Ok(adminService.GetGameById(id));
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Game dengan ID {GameId} tidak ditemukan", id);
                return NotFound("Game tidak ditemukan.");
            }
        }
    }
}
