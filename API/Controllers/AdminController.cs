using Microsoft.AspNetCore.Mvc;
using API.DataObjects;

namespace API.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        private readonly AdminService adminService = new AdminService();

        [HttpGet("games")]
        public IActionResult GetGames()
        {
            return Ok(adminService.GetAllGames());
        }

        [HttpGet("games/{id}")]
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

        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            return Ok(adminService.GetAllUsers());
        }

        [HttpPost("games")]
        public IActionResult AddGame([FromBody] AddGameRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Title))
                return BadRequest("Nama game tidak boleh kosong.");

            if (request.Price <= 0)
                return BadRequest("Harga game harus lebih dari 0.");

            string result = adminService.AddGame(request.Title.Trim(), request.Price);
            return Ok(new { message = result });
        }

        [HttpPut("games/{id}")]
        public IActionResult EditGame(int id, [FromBody] UpdateGameRequest request)
        {
            if (id <= 0)
                return BadRequest("ID game tidak valid.");

            if (string.IsNullOrWhiteSpace(request.Title))
                return BadRequest("Nama game tidak boleh kosong.");

            if (request.Price <= 0)
                return BadRequest("Harga game harus lebih dari 0.");

            try
            {
                string result = adminService.EditGame(id, request.Title.Trim(), request.Price);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("games/{id}")]
        public IActionResult DeleteGame(int id)
        {
            if (id <= 0)
                return BadRequest("ID game tidak valid.");

            try
            {
                string result = adminService.DeleteGame(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("pending-refunds")]
        public IActionResult GetPendingRefunds()
        {
            return Ok(adminService.GetPendingRefundGames());
        }

        [HttpPost("approve-refund")]
        public IActionResult ApproveRefund([FromBody] UserGameRequest request)
        {
            if (request.UserId <= 0 || request.GameId <= 0)
                return BadRequest("UserId dan GameId harus valid.");

            try
            {
                string result = adminService.ProcessRefund(request.UserId, request.GameId, approve: true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("reject-refund")]
        public IActionResult RejectRefund([FromBody] UserGameRequest request)
        {
            if (request.UserId <= 0 || request.GameId <= 0)
                return BadRequest("UserId dan GameId harus valid.");

            try
            {
                string result = adminService.ProcessRefund(request.UserId, request.GameId, approve: false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("ban-wallet/{userId}")]
        public IActionResult BanWallet(int userId)
        {
            if (userId <= 0)
                return BadRequest("UserId tidak valid.");

            try
            {
                string result = adminService.BanWallet(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("unban-wallet/{userId}")]
        public IActionResult UnbanWallet(int userId)
        {
            if (userId <= 0)
                return BadRequest("UserId tidak valid.");

            try
            {
                string result = adminService.UnbanWallet(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
