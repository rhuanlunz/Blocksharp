using Blockchain.Utils;

namespace Blockchain.Models;

public class Block
{
    private int _id = 0;
    private int _nonce = 0;
    private string? _data;
    private string _previousHash;
    private byte[] _hashValue = [];
    
    public int Id 
    {
        get => _id;
        set
        { 
            _id = value;
            CalculateBlockHash();
        }
    }
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
    public string PreviousHash
    {
        get => _previousHash;
        set
        {
            _previousHash = value;
            CalculateBlockHash();
        }
    }
    public byte[] Hash { get => _hashValue; }
    public readonly long Timestamp;
    
    public Block(int id, int nonce, string? data, string previousHash)
    {
        _id = id;
        _nonce = nonce;
        _data = data;
        _previousHash = previousHash;
        Timestamp = TimeProvider.System.GetTimestamp();
        CalculateBlockHash();
    }

    private void CalculateBlockHash()
    {
        _hashValue = CryptoWrapper.CalculateSha256($"{Id}{Nonce}{Data}{PreviousHash}{Timestamp}");
    }

    public override string ToString()
    {
        return $"{Id}:{Nonce}:{Data}:{Hash}:{PreviousHash}:{Timestamp}";
    }
}