using System;
using System.Security.Cryptography;

namespace TubesKPL_Kelompok_2.Security
{
    /// <summary>
    /// Hashing password menggunakan PBKDF2 (Rfc2898DeriveBytes) — bagian dari
    /// System.Security.Cryptography, sudah built-in di .NET tanpa perlu NuGet
    /// tambahan. Format hasil: {iterations}.{saltBase64}.{hashBase64}
    /// sehingga salt unik per user dan iterasi bisa dinaikkan di masa depan
    /// tanpa merusak hash lama.
    /// </summary>
    public static class PasswordHasher
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 100_000;

        public static string Hash(string plainPassword)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                plainPassword, salt, Iterations, HashAlgorithmName.SHA256, HashSize);

            return $"{Iterations}.{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
        }

        public static bool Verify(string plainPassword, string storedHash)
        {
            string[] parts = storedHash.Split('.', 3);
            if (parts.Length != 3)
                return false;

            if (!int.TryParse(parts[0], out int iterations))
                return false;

            byte[] salt = Convert.FromBase64String(parts[1]);
            byte[] expectedHash = Convert.FromBase64String(parts[2]);

            byte[] actualHash = Rfc2898DeriveBytes.Pbkdf2(
                plainPassword, salt, iterations, HashAlgorithmName.SHA256, expectedHash.Length);

            return CryptographicOperations.FixedTimeEquals(actualHash, expectedHash);
        }

        /// <summary>
        /// Mendeteksi apakah suatu string sudah berformat hash PBKDF2 kami,
        /// dipakai untuk migrasi data lama yang masih plaintext.
        /// </summary>
        public static bool IsHashed(string value)
        {
            string[] parts = value.Split('.', 3);
            return parts.Length == 3 && int.TryParse(parts[0], out _);
        }
    }
}
