using Blockchain.Utils;

namespace Blockchain.Models;

public class Block
{
    public int Id { get; set; }
    public int Nounce { get; set; }
    public string? Data { get; set; }
    public string Hash { get; set; } = string.Empty;
    public string PreviousHash { get; set; } = string.Empty;
    public long Timestamp { get; set; } = TimeProvider.System.GetTimestamp();
    
    public Block(int id, int nounce, string? data, string previousHash)
    {
        Id = id;
        Nounce = nounce;
        Data = data;
        PreviousHash = previousHash;
        Hash = CryptoWrapper.Sha256Hash($"{id}{nounce}{data}{previousHash}");
    }

    public override string ToString()
    {
        return $"{Id}:{Nounce}:{Data}:{Hash}:{PreviousHash}:{Timestamp}";
    }
}
