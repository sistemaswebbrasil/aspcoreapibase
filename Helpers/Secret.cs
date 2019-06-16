using CryptSharp;

namespace Base.Helpers
{
    public class Secret
    {

        public static string GenerateHash(string value)
        {
            return Crypter.Blowfish.Crypt(value, Crypter.Blowfish.GenerateSalt(10));
        }

        public static bool Validate(string value, string hash)
        {
            try
            {
                return Crypter.CheckPassword(value, hash);
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
