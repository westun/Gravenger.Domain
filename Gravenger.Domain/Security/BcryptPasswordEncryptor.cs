using DevOne.Security.Cryptography.BCrypt;
using Gravenger.Domain.Core.Security;

namespace Gravenger.Domain.Security
{
    public class BcryptPasswordEncryptor : IPasswordEncryptor
    {
        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCryptHelper.CheckPassword(password, hashedPassword);
        }

        public string GenerateSalt()
        {
            return BCryptHelper.GenerateSalt();
        }

        public string HashPassword(string password, string salt)
        {
            return BCryptHelper.HashPassword(password, salt);
        }
    }
}
