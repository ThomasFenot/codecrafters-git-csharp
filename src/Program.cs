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
    var fileNameArgument = args[2];
    var folder = fileNameArgument[2..];
    var fileName = fileNameArgument[..2];
    var path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
    Console.WriteLine($"Path is : {path}");
    string readText = File.ReadAllText($".git/objects/{folder}/{fileName}");
    Console.WriteLine(readText);
}
else
{
    throw new ArgumentException($"Unknown command {command}");
}