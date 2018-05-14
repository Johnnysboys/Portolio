namespace Joller.Lib.Helpers
{
    public interface IPasswordHasher
    {
        string[] Encrypt(string password);
        bool ValidatePassword(string password, string EncryptedPassword, string salt);
    }
}