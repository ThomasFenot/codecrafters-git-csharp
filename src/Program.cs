using System;
using System.IO;


if (args.Length < 1)
{
    Console.WriteLine("Please provide a command.");
    return;
}

string command = args[0];

if (command == "init")
{
    Directory.CreateDirectory(".git");
    Directory.CreateDirectory(".git/objects");
    Directory.CreateDirectory(".git/refs");
    File.WriteAllText(".git/HEAD", "ref: refs/heads/main\n");
    Console.WriteLine("Initialized git directory");
}
else if (command == "cat-file")
{
    var toto = args;
    Console.WriteLine($"Arg 1 : {args[1]}");
    Console.WriteLine($"Arg 2 : {args[2]}");


}
else
{
    throw new ArgumentException($"Unknown command {command}");
}