using Microsoft.AspNetCore.Mvc;
using API.DataObjects;
using API.Security;

namespace API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService authService = new AuthService();
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                return BadRequest("Username dan password wajib diisi.");

            try
            {
                var user = authService.Login(request.Username.Trim(), request.Password);
                string token = SessionTokenStore.CreateToken(user.Id, user.Role.ToString());

                // Hanya kembalikan data minimal yang diperlukan client + token sesi.
                // Tidak lagi mengembalikan seluruh objek User (termasuk wallet/balance).
                return Ok(new
                {
                    token,
                    user.Id,
                    user.Username,
                    Role = user.Role.ToString()
                });
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Percobaan login gagal untuk username {Username}", request.Username);
                return Unauthorized(new { message = "Username atau password salah." });
            }
        }
    }
}
