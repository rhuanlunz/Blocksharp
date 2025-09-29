using System.Numerics;

namespace Blockchain.Models;

public class Chain
{
    public LinkedList<Block> BlockList = new();
    public int Difficulty = 1;
    public const uint MaxCompactTarget = 0x200000f;
    public BigInteger Target;

    public Chain()
    {
        Target = ConvertCompactToTarget(MaxCompactTarget) / Difficulty;
    }

    public bool IsValidBlockHash(byte[] hashValue)
    {
        BigInteger decimalHashValue = new(hashValue, true, true);
        if (decimalHashValue <= Target)
        {
            return true;
        }

        return false;
    }

    private BigInteger ConvertCompactToTarget(uint nBits)
    {
        const int baseNumber = 256;
        const int bytesInSignificand = 3;
        
        string hexIndex = nBits.ToString("x")[0..2];
        string hexCoefficient = nBits.ToString("x")[3..];

        byte exponent = Convert.ToByte(hexIndex, 16);
        uint mantissa = Convert.ToUInt32(hexCoefficient, 16);

        BigInteger target = mantissa * BigInteger.Pow(baseNumber, exponent - bytesInSignificand);

        return target;
    }
}