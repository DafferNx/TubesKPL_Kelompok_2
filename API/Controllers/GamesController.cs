using Microsoft.AspNetCore.Mvc;
using TubesKPL_Kelompok_2.Database;

namespace API.Controllers
{
    [ApiController]
    [Route("api/games")]
    public class GamesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetGames()
        {
            return Ok(DatabaseHelper.GetAllGames());
        }

        [HttpGet("{id}")]
        public IActionResult GetGameById(int id)
        {
            if (id <= 0)
                return BadRequest("ID game tidak valid.");

            try
            {
                return Ok(DatabaseHelper.GetGameById(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
