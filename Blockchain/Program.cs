using Blockchain.Models;

Chain chain = new();
Block newBlock = new(0, 0, "Hello, World!", string.Empty);

for (newBlock.Nonce = 0; newBlock.Nonce < Math.Pow(2, 32); newBlock.Nonce++)
{
    if (chain.IsValidBlockHash(newBlock.Hash))
    {
        Console.WriteLine($"{Convert.ToHexString(newBlock.Hash).ToLower()} is VALID!");
        break;
    }
}
