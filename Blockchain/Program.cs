using Blockchain.Models;
using System.Diagnostics;

var chain = new Chain(regTest: true);
var newBlock = new Block(0, 0, "Hello, Blockchain?!", string.Empty);
var stopwatch = new Stopwatch();

Console.WriteLine("Target: " + chain.Target);
Console.WriteLine("Difficulty: " + chain.Difficulty);
Console.WriteLine("Starting mining at " + DateTime.Now.ToString());

stopwatch.Restart();

for (newBlock.Nonce = 0; newBlock.Nonce < Math.Pow(2, 32); newBlock.Nonce++)
{
    if (chain.IsValidBlockHash(newBlock.Hash))
    {
        stopwatch.Stop();
        string formatedElapsedTime = stopwatch.Elapsed.ToString(@"s\.fff");
        Console.WriteLine("Stop mining at " + DateTime.Now.ToString() + '\n');
        Console.WriteLine("Total time mining was " + formatedElapsedTime + " seconds");

        Console.WriteLine(" -=-=-=- Block Found -=-=-=-");
        Console.WriteLine("Id: " + newBlock.Id);
        Console.WriteLine("Nonce: " + newBlock.Nonce);
        Console.WriteLine("Data: " + newBlock.Data);
        Console.WriteLine("Previous SHA256 hash: " + newBlock.PreviousHash);
        Console.WriteLine("Timestamp: " + newBlock.Timestamp);
        Console.WriteLine("SHA256 Hash: " + Convert.ToHexString(newBlock.Hash).ToLower());
        break;
    }
}
