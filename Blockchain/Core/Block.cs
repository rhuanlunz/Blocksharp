using Blockchain.Core.Utils;

namespace Blockchain.Models;

public class Block
{
    private readonly int _id;
    private int _nonce;
    private string? _data;
    private readonly byte[]? _previousHash = [];
    private byte[] _hashValue = [];
    
    public int Id { get => _id; }
    public int Nonce 
    { 
        get => _nonce; 
        set
        {
            _nonce = value;
            CalculateBlockHash();
        }

    }
    public string? Data 
    {
        get => _data; 
        set
        {
            _data = value;
            CalculateBlockHash();
        }
    }
    public byte[]? PreviousHash { get => _previousHash; }
    public byte[] Hash { get => _hashValue; }
    public readonly long Timestamp;
    
    public Block(int id, byte[]? previousHash)
    {
        _id = id;
        _previousHash = previousHash;
        Timestamp = TimeProvider.System.GetTimestamp();
        CalculateBlockHash();
    }

    private void CalculateBlockHash()
    {
        _hashValue = CryptoWrapper.CalculateSha256($"{Id}{Nonce}{Data}{PreviousHash}{Timestamp}");
    }
}