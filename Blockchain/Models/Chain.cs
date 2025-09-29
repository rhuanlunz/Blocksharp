using System.Numerics;

namespace Blockchain.Models;

public class Chain
{
    public LinkedList<Block> BlockList = new();
    public int Difficulty;
    public readonly uint MaxCompactTarget;
    public BigInteger Target;

    public Chain(int difficulty = 1, bool regTest = false)
    {
        MaxCompactTarget = (uint)(regTest ? 0x200000f : 0x1d0ffff);
        Difficulty = difficulty;
        Target = ConvertCompactToTarget(MaxCompactTarget) / Difficulty;
    }

    public bool IsValidBlockHash(byte[] hashValue)
    {
        BigInteger decimalHashValue = new(hashValue, isUnsigned: true, isBigEndian: true);

        return decimalHashValue <= Target;
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