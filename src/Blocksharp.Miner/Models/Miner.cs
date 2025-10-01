using Blocksharp.Core;
using System.Diagnostics;

namespace Blocksharp.Miner.Models;

public class Minerator
{
    public Chain Blockchain { get; set; }
    public readonly Stopwatch Timer = new();
    public double MaxNonce = Math.Pow(2, 32);

    public Minerator(Chain chain)
    {
        Blockchain = chain;
    }

    public void ShowChainInformation()
    {
        Console.WriteLine("Target: " + Blockchain.Target);
        Console.WriteLine("Difficulty: " + Blockchain.Difficulty + '\n');
    }

    public static void ShowBlockInformation(Block block)
    {
        string blockHash = Convert.ToHexString(block.Hash).ToLower();
        string previousHash = string.Empty;
        if (block.PreviousHash != null)
        {
            previousHash = Convert.ToHexString(block.PreviousHash).ToLower();
        }

        Console.WriteLine("Id: " + block.Id);
        Console.WriteLine("Nonce: " + block.Nonce);
        Console.WriteLine("Data: " + block.Data);
        Console.WriteLine("Previous SHA256 hash: " + previousHash);
        Console.WriteLine("SHA256 Hash: " + blockHash + '\n');
    }
    
    public void StartMiningTimer()
    {
        Timer.Start();
        Console.WriteLine("Starting mining at " + DateTime.Now.ToString());
    }

    public void StopMiningTimer()
    {
        Timer.Stop();
        Console.WriteLine("Stop mining at " + DateTime.Now.ToString());
    }

    public void ShowTotalMiningTime()
    {
        string formatedElapsedTime = Timer.Elapsed.ToString(@"s\.fff");
        Console.WriteLine("Total time mining was " + formatedElapsedTime + " seconds\n");
        Timer.Reset();
    }

    public Block MineBlock(string data)
    {
        while (true)
        {
            Block block = Blockchain.CreateNewBlock();
            block.Data = data;

            for (block.Nonce = 0; block.Nonce < MaxNonce; block.Nonce++)
            {
                try
                {
                    Blockchain.AddNewBlock(block);
                    return block;
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }
    }
}
