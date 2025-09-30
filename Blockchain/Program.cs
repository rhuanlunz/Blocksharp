using Blockchain.Models;
using System.Diagnostics;

static void showChainInformation(Chain chain)
{
    Console.WriteLine("Target: " + chain.Target);
    Console.WriteLine("Difficulty: " + chain.Difficulty + '\n');
}
static void showBlockInformation(Block block)
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
static void showMiningTime(Stopwatch stopwatch)
{
    string formatedElapsedTime = stopwatch.Elapsed.ToString(@"s\.fff");
    Console.WriteLine("Stop mining at " + DateTime.Now.ToString());
    Console.WriteLine("Total time mining was " + formatedElapsedTime + " seconds\n");
}
static Block mineBlock(Chain chain, string data)
{
    double maxNonce = Math.Pow(2, 32);
    while (true)
    {
        Block block = chain.CreateNewBlock();
        block.Data = data;

        for (block.Nonce = 0; block.Nonce < maxNonce; block.Nonce++)
        {
            try
            {
                chain.AddNewBlock(block);
                return block;
            }
            catch (Exception)
            {
                continue;
            }
        }
    }
}

const int totalMinedBlocks = 4;
var stopwatch = new Stopwatch();
var chain = new Chain(regTest: true);
showChainInformation(chain);

for (int minedBlocks = 0; minedBlocks < totalMinedBlocks; minedBlocks++)
{
    Console.WriteLine("Starting mining at " + DateTime.Now.ToString());

    stopwatch.Start();
    Block minedBlock = mineBlock(chain, "24 karat gold labaibe thank you so much very very nice");
    stopwatch.Stop();

    showBlockInformation(minedBlock);
    showMiningTime(stopwatch);
    stopwatch.Reset();
}