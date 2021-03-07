using System;
using System.Collections.Generic;
using System.IO;

namespace Voting_Calculator
{
    class Program
    {
        private static List<Party> parties = new List<Party>();

        static void Main(string[] args)
        {
            Console.WriteLine("Development Branch");

            // call the function and print the file inside the console

            string data = ReadFile();

            //Console.WriteLine(data);

            String[] lines = data.Split(Char.Parse("\n"));

            // For each line create and add a new Party to the list
            for (int i = 3; i < lines.Length; i++)
            {
                parties.Add(new Party(lines[i]));
            }

            // Just testing and displaying all parties
            foreach (Party party in parties)
            {
                Console.WriteLine($"{party.Name}:   Votes: {party.Votes}    Seats: {string.Join(", ", party.Seats)}");
            }
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

            // takes file path as a an argument and reads the text file

            string text = File.ReadAllText(filePath);

            return text;
        }
    }
}
