using System.Numerics;

namespace Blockchain.Models;

public class Chain
{
    public LinkedList<Block> BlockList = new();
    public int Difficulty;
    public readonly int MaxCompactTarget;
    public BigInteger Target;

    public Chain(int difficulty = 1, bool regTest = false)
    {
        MaxCompactTarget = regTest ? 0x200000f : 0x1d0ffff;
        Difficulty = difficulty;
        Target = ConvertCompactToTarget(MaxCompactTarget) / Difficulty;
    }

    public Block CreateNewBlock()
    {
        if (BlockList.Last == null)
        {
            var genesisBlock = new Block(id: 0, previousHash: null);
            return genesisBlock;
        }

        int totalBlocks = BlockList.Count;
        byte[] previousValidHash = BlockList.Last.Value.Hash;
        if (previousValidHash.Length == 0)
        {
            throw new NullReferenceException("Error. Last block don't have a... Hash? WTF?!");
        }

        var newBlock = new Block(id: totalBlocks, previousHash: previousValidHash);
        return newBlock;
    }

    public void AddNewBlock(Block newBlock)
    {
        if (!IsValidBlockHash(newBlock.Hash))
        {
            throw new Exception("Error. Invalid block!");
        }

        BlockList.AddLast(newBlock);
    }

    private bool IsValidBlockHash(byte[] hashValue)
    {
        BigInteger decimalHashValue = new(hashValue, isUnsigned: true, isBigEndian: true);

        return decimalHashValue <= Target;
    }

    private BigInteger ConvertCompactToTarget(int nBits)
    {
        const int baseNumber = 256;
        const int bytesInSignificand = 3;
        
        int exponent = nBits >> 20;
        int mantissa = nBits & 0x00FFFFF;

        BigInteger target = mantissa * BigInteger.Pow(baseNumber, exponent - bytesInSignificand);

        return target;
    }
}