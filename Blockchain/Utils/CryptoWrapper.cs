using System.Security.Cryptography;
using System.Text;

namespace Blockchain.Utils;

public class CryptoWrapper
{
    public static string Sha256Hash(string input)
    {
        ArgumentNullException.ThrowIfNull("The input string cannot be Null!");

        byte[] hashValue;

        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            hashValue = sha256.ComputeHash(inputBytes);
        }

        string hash = Convert.ToHexString(hashValue).ToLower();
        return hash;
    }
}
