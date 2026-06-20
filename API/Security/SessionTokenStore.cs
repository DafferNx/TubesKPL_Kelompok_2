using System;
using System.Collections.Concurrent;

namespace API.Security
{
    /// <summary>
    /// Menyimpan token sesi login secara in-memory (server-side).
    /// Dipakai sebagai pengganti JWT karena keterbatasan akses paket NuGet
    /// di lingkungan ini — tetap memenuhi prinsip OWASP A01 (Broken Access Control)
    /// karena endpoint admin tidak lagi bisa diakses tanpa token valid.
    /// </summary>
    public static class SessionTokenStore
    {
        private record SessionInfo(int UserId, string Role, DateTime ExpiresAt);

        private static readonly ConcurrentDictionary<string, SessionInfo> _sessions = new();
        private static readonly TimeSpan _sessionLifetime = TimeSpan.FromHours(2);

        public static string CreateToken(int userId, string role)
        {
            string token = Guid.NewGuid().ToString("N");
            _sessions[token] = new SessionInfo(userId, role, DateTime.UtcNow.Add(_sessionLifetime));
            return token;
        }

        public static bool TryGetSession(string token, out int userId, out string role)
        {
            userId = 0;
            role = string.Empty;

            if (string.IsNullOrWhiteSpace(token))
                return false;

            if (!_sessions.TryGetValue(token, out var session))
                return false;

            if (session.ExpiresAt < DateTime.UtcNow)
            {
                _sessions.TryRemove(token, out _);
                return false;
            }

            userId = session.UserId;
            role = session.Role;
            return true;
        }

        public static void Revoke(string token)
        {
            _sessions.TryRemove(token, out _);
        }
    }
}
