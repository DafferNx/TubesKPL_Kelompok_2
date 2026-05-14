using Microsoft.AspNetCore.Mvc;
using API.DataObjects;
using TubesKPL_Kelompok_2.Database;

namespace API.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        [HttpGet("games")]
        public IActionResult GetGames()
        {
            return Ok(DatabaseHelper.GetAllGames());
        }

        [HttpGet("games/{id}")]
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

        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            return Ok(DatabaseHelper.GetAllUsers());
        }

        [HttpPost("games")]
        public IActionResult AddGame([FromBody] AddGameRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Title))
                return BadRequest("Nama game tidak boleh kosong.");

            if (request.Price <= 0)
                return BadRequest("Harga game harus lebih dari 0.");

            int id = DatabaseHelper.AddGame(request.Title.Trim(), request.Price);

            return Ok(new
            {
                message = "Game berhasil ditambahkan oleh admin.",
                gameId = id
            });
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
                DatabaseHelper.UpdateGame(id, request.Title.Trim(), request.Price);
                return Ok("Game berhasil diubah oleh admin.");
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
                DatabaseHelper.DeleteGame(id);
                return Ok("Game berhasil dihapus oleh admin.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("pending-refunds")]
        public IActionResult GetPendingRefunds()
        {
            return Ok(DatabaseHelper.GetPendingRefundGames());
        }

        [HttpPost("approve-refund")]
        public IActionResult ApproveRefund([FromBody] UserGameRequest request)
        {
            try
            {
                DatabaseHelper.ApproveRefund(request.UserId, request.GameId);
                return Ok("Refund disetujui dan saldo user dikembalikan.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("reject-refund")]
        public IActionResult RejectRefund([FromBody] UserGameRequest request)
        {
            try
            {
                DatabaseHelper.RejectRefund(request.UserId, request.GameId);
                return Ok("Refund ditolak.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("ban-wallet/{userId}")]
        public IActionResult BanWallet(int userId)
        {
            try
            {
                var user = DatabaseHelper.GetUserById(userId);
                if (user.Role == UserRole.Admin)
                    return BadRequest("Wallet admin tidak bisa dibanned.");

                DatabaseHelper.UpdateWalletState(userId, "Banned");
                return Ok("Wallet berhasil dibanned.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("unban-wallet/{userId}")]
        public IActionResult UnbanWallet(int userId)
        {
            try
            {
                var user = DatabaseHelper.GetUserById(userId);
                if (user.Role == UserRole.Admin)
                    return BadRequest("Wallet admin tidak perlu di-unban.");

                DatabaseHelper.UpdateWalletState(userId, "Active");
                return Ok("Wallet berhasil diaktifkan kembali.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
