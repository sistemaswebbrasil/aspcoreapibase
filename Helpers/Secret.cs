using CryptSharp;

namespace Base.Helpers
{
    /// <summary>
    /// Manage secret keys
    /// </summary>
    public class Secret
    {

        /// <summary>
        /// Manager passwords using Blowfish Encryption , compatible with standard PHP encryption
        /// </summary>
        /// <param name="text">Text to be encrypted</param>
        /// <returns></returns>
        public static string GenerateHash(string text)
        {
            return Crypter.Blowfish.Crypt(text, Crypter.Blowfish.GenerateSalt(10));
        }

        /// <summary>
        /// validates the encrypted key with the decrypted key
        /// </summary>
        /// <param name="text">plain text</param>
        /// <param name="hash">encrypted text</param>
        /// <returns></returns>
        public static bool Validate(string text, string hash)
        {
            try
            {
                return Crypter.CheckPassword(text, hash);
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
