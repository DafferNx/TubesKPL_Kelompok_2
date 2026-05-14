using API.DataObjects;
using Microsoft.AspNetCore.Mvc;
using TubesKPL_Kelompok_2.Database;

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
            try
            {
                DatabaseHelper.GetUserById(userId);
                return Ok(DatabaseHelper.GetGamesForUser(userId));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("add-to-cart")]
        public IActionResult AddToCart([FromBody] UserGameRequest request)
        {
            try
            {
                var game = DatabaseHelper.GetGameForUser(request.UserId, request.GameId);
                string message = gameService.addToCart(request.UserId, game);
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
            try
            {
                var game = DatabaseHelper.GetGameForUser(request.UserId, request.GameId);
                string message = gameService.removeFromCart(request.UserId, game);
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
            try
            {
                var user = DatabaseHelper.GetUserById(request.UserId);
                var game = DatabaseHelper.GetGameForUser(request.UserId, request.GameId);
                string message = gameService.buyGame(user, game);
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
            try
            {
                var user = DatabaseHelper.GetUserById(userId);
                string message = gameService.checkoutCart(user);
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
            try
            {
                var game = DatabaseHelper.GetGameForUser(request.UserId, request.GameId);
                string message = gameService.requestRefund(request.UserId, game);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
