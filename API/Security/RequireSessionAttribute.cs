using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace API.Security
{
    /// <summary>
    /// Authorization filter sederhana — membaca header "X-Session-Token",
    /// memvalidasinya lewat SessionTokenStore, dan menolak akses (401/403)
    /// jika token tidak ada, kedaluwarsa, atau role tidak sesuai.
    /// Dipasang lewat attribute [RequireSession] atau [RequireSession("Admin")].
    /// </summary>
    public class RequireSessionAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string? _requiredRole;

        public RequireSessionAttribute() { }

        public RequireSessionAttribute(string requiredRole)
        {
            _requiredRole = requiredRole;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string? token = context.HttpContext.Request.Headers["X-Session-Token"].FirstOrDefault();

            if (!SessionTokenStore.TryGetSession(token ?? string.Empty, out int userId, out string role))
            {
                context.Result = new UnauthorizedObjectResult(new { message = "Sesi tidak valid atau sudah berakhir. Silakan login kembali." });
                return;
            }

            if (_requiredRole != null && !string.Equals(role, _requiredRole, StringComparison.OrdinalIgnoreCase))
            {
                context.Result = new ObjectResult(new { message = "Anda tidak memiliki akses untuk operasi ini." })
                {
                    StatusCode = StatusCodes.Status403Forbidden
                };
                return;
            }

            // Simpan UserId hasil validasi token agar bisa dipakai controller jika perlu
            context.HttpContext.Items["UserId"] = userId;
            context.HttpContext.Items["Role"] = role;
        }
    }
}
