using System.Security.Cryptography;
using System.Text;

namespace Blocksharp.Core.Utils;

public class CryptoWrapper
{
    public static byte[] CalculateSha256(string input)
    {
        ArgumentNullException.ThrowIfNull("The input string cannot be Null!");

        byte[] inputBytes = Encoding.UTF8.GetBytes(input);
        byte[] hashValue = SHA256.HashData(inputBytes);

        return hashValue;
    }
}
