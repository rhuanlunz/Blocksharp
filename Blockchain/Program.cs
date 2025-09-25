using Blockchain.Models;

Random random = new();

Block block1 = new(0, random.Next(), "Hello, World!", string.Empty);

Console.WriteLine(block1.ToString());
