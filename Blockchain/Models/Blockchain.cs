namespace Blockchain.Models;

public class Blockchain
{
    public LinkedList<Block> BlockList = new();
    public int Difficulty { get; set; }
}