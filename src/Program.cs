using System;
using System.IO;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;


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
    var folder = args[2][2..];
    var fileName = args[2][..2];
    var path = Path.Combine(".git", "objects" ,folder, fileName);
    string readText = File.ReadAllText(path);
    Console.WriteLine(readText);
}
else
{
    throw new ArgumentException($"Unknown command {command}");
}