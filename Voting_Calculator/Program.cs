using System;
using System.Collections.Generic;
using System.IO;

namespace Voting_Calculator
{
    class Program
    {
        private static List<Party> partyList = new List<Party>();

        static void Main(string[] args)
        {
            /*
             * Creates a new instance of a class, which takse 1 arg
             * partyList is sent to the main class method [Calculator()]
            */
            Calculator newElection = new Calculator(partyList);

        }
        static void CreateParty()
        {
            // Calls the function and stores contents of the file inside a new variable
            string data = ReadFile();


            // Splits each line as individual string and stores it in an array
            String[] splitLines = data.Split(Char.Parse("\n"));


            /*
             * [i = 3] means that it starts from the third line
             * Each individual line is passed to main class method [Party()], which will seperate individual data inside that line
             * E.g. Name, Votes, Seats etc.
             * The seperated data is then added inside list object List<Party>
            */
            for (int i = 3; i < splitLines.Length; i++)
            {
                partyList.Add(new Party(splitLines[i]));
            }

        }
        static string ReadFile()
        {
            // Returns current working directory
            string currentDirectory = Directory.GetCurrentDirectory();

            /*
             * Combines two strings into a single path, currentDirectory + filename
             * Each [..\] means that it moves backup 1 directory from \..\bin\Debug\netcoreapp2.0\
            */
            string path = Path.Combine(currentDirectory, @"..\..\..\..\Assessment1Data.txt");

            // Returns actual path for the file
            string filePath = Path.GetFullPath(path);

            // Takes file path as an argument and reads the text file
            string text = File.ReadAllText(filePath);

            return text;
        }
    }
}
