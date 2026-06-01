using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/games")]
    public class GamesController : ControllerBase
    {
        private readonly AdminService adminService = new AdminService();

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
                return NotFound(ex.Message);
            }
        }
    }
}
