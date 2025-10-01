using Blocksharp.Core;
using Blocksharp.Miner.Models;

namespace Blocksharp.Miner;

public class Program
{
    static void Main(string[] args)
    {
        const int totalMinedBlocks = 4;
        const string blockData = "24 karat gold labaibe thank you so much very very nice";

        var chain = new Chain(regTest: true);
        var minerator = new Minerator(chain);
        minerator.ShowChainInformation();

        for (int minedBlocks = 0; minedBlocks < totalMinedBlocks; minedBlocks++)
        {
            minerator.StartMiningTimer();
            Block minedBlock = minerator.MineBlock(blockData);
            minerator.StopMiningTimer();

            Minerator.ShowBlockInformation(minedBlock);
            minerator.ShowTotalMiningTime();
        }
    }
}