using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.InteropServices;
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
else if (command == "cat-file" && args[1] == "-p")
{
    Console.WriteLine($"Folder {args[2][2..]}");
    Console.WriteLine($"File {args[2][..2]}");

    string path = Path.Combine(".git", "objects" , args[2][2..], args[2][..2]);
    
    FileStream fileStream = new(path, FileMode.Open);
    ZLibStream zLibStream = new(fileStream, CompressionMode.Decompress);
    StreamReader streamReader = new(zLibStream);
    
    var content = streamReader.ReadToEnd();

    Console.Write(content.Split('\x00')[1]);
}
else
{
    throw new ArgumentException($"Unknown command {command}");
}