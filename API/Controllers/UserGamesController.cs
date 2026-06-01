using API.DataObjects;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/user-games")]
    public class UserGamesController : ControllerBase
    {
        private readonly GameService gameService = new GameService();

        [HttpGet("{userId}")]
        public IActionResult GetUserGames(int userId)
        {
            if (userId <= 0)
                return BadRequest("UserId tidak valid.");

            try
            {
                var games = gameService.getAllGames(userId);
                return Ok(games);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("add-to-cart")]
        public IActionResult AddToCart([FromBody] UserGameRequest request)
        {
            if (request.UserId <= 0 || request.GameId <= 0)
                return BadRequest("UserId dan GameId harus valid.");

            try
            {
                string message = gameService.addToCart(request.UserId, request.GameId);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("remove-from-cart")]
        public IActionResult RemoveFromCart([FromBody] UserGameRequest request)
        {
            if (request.UserId <= 0 || request.GameId <= 0)
                return BadRequest("UserId dan GameId harus valid.");

            try
            {
                string message = gameService.removeFromCart(request.UserId, request.GameId);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("buy")]
        public IActionResult Buy([FromBody] UserGameRequest request)
        {
            if (request.UserId <= 0 || request.GameId <= 0)
                return BadRequest("UserId dan GameId harus valid.");

            try
            {
                string message = gameService.buyGame(request.UserId, request.GameId);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("checkout/{userId}")]
        public IActionResult Checkout(int userId)
        {
            if (userId <= 0)
                return BadRequest("UserId tidak valid.");

            try
            {
                string message = gameService.checkoutCart(userId);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("request-refund")]
        public IActionResult RequestRefund([FromBody] UserGameRequest request)
        {
            if (request.UserId <= 0 || request.GameId <= 0)
                return BadRequest("UserId dan GameId harus valid.");

            try
            {
                string message = gameService.requestRefund(request.UserId, request.GameId);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
