using API.DataObjects;
using API.Security;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/user-games")]
    [RequireSession]
    public class UserGamesController : ControllerBase
    {
        private readonly GameService gameService = new GameService();
        private readonly ILogger<UserGamesController> _logger;

        public UserGamesController(ILogger<UserGamesController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{userId}")]
        public IActionResult GetUserGames(int userId)
        {
            if (userId <= 0)
                return BadRequest("UserId tidak valid.");

            try
            {
                var games = gameService.GetAllGames(userId);
                return Ok(games);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Gagal mengambil game untuk user {UserId}", userId);
                return NotFound("Data game untuk user tidak ditemukan.");
            }
        }

        [HttpPost("add-to-cart")]
        public IActionResult AddToCart([FromBody] UserGameRequest request)
        {
            if (request.UserId <= 0 || request.GameId <= 0)
                return BadRequest("UserId dan GameId harus valid.");

            try
            {
                string message = gameService.AddToCart(request.UserId, request.GameId);
                return Ok(message);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Gagal menambahkan game {GameId} ke cart user {UserId}", request.GameId, request.UserId);
                return BadRequest("Gagal menambahkan game ke cart.");
            }
        }

        [HttpPost("remove-from-cart")]
        public IActionResult RemoveFromCart([FromBody] UserGameRequest request)
        {
            if (request.UserId <= 0 || request.GameId <= 0)
                return BadRequest("UserId dan GameId harus valid.");

            try
            {
                string message = gameService.RemoveFromCart(request.UserId, request.GameId);
                return Ok(message);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Gagal menghapus game {GameId} dari cart user {UserId}", request.GameId, request.UserId);
                return BadRequest("Gagal menghapus game dari cart.");
            }
        }

        [HttpPost("buy")]
        public IActionResult Buy([FromBody] UserGameRequest request)
        {
            if (request.UserId <= 0 || request.GameId <= 0)
                return BadRequest("UserId dan GameId harus valid.");

            try
            {
                string message = gameService.BuyGame(request.UserId, request.GameId);
                return Ok(message);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Gagal memproses pembelian game {GameId} oleh user {UserId}", request.GameId, request.UserId);
                return BadRequest("Gagal memproses pembelian.");
            }
        }

        [HttpPost("checkout/{userId}")]
        public IActionResult Checkout(int userId)
        {
            if (userId <= 0)
                return BadRequest("UserId tidak valid.");

            try
            {
                string message = gameService.CheckoutCart(userId);
                return Ok(message);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Gagal checkout cart user {UserId}", userId);
                return BadRequest("Gagal melakukan checkout.");
            }
        }

        [HttpPost("request-refund")]
        public IActionResult RequestRefund([FromBody] UserGameRequest request)
        {
            if (request.UserId <= 0 || request.GameId <= 0)
                return BadRequest("UserId dan GameId harus valid.");

            try
            {
                string message = gameService.RequestRefund(request.UserId, request.GameId);
                return Ok(message);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Gagal mengajukan refund game {GameId} oleh user {UserId}", request.GameId, request.UserId);
                return BadRequest("Gagal mengajukan refund.");
            }
        }
    }
}
