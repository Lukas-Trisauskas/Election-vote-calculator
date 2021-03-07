using System;
using System.IO;

namespace Voting_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Development Branch");

            // call the function and print the file inside the console
            string data = ReadFile();

            Console.WriteLine(data);
        }
        static string ReadFile()
        {
            // returns current working directory
            string currentDirectory = Directory.GetCurrentDirectory();

            // combines two strings into a single path, currentDirectory + filename
            // each [..\] means that it moves backup 1 directory from \..\bin\Debug\netcoreapp2.0\
            string path = Path.Combine(currentDirectory, @"..\..\..\..\Assessment1Data.txt");

            // returns actual path for the file
            string filePath = Path.GetFullPath(path);

            // takes file path as an argument and reads the text file
            string text = File.ReadAllText(filePath);

            return text;
        }
    }
}
