using System;
using System.Collections.Generic;
using System.IO;

namespace Voting_Calculator
{
    class Program
    {

        static void Main(string[] args)
        {
            // Calls the function and stores contents of the file inside a new variable
            String[] data = ReadFile();
            List<Party> parties = CreatePartyList(data);

            try
            {
                int seatsToBeAllocated = Int32.Parse(data[1]);
            }
            catch
            {
                Console.WriteLine("Unable to interpret number of seats from file, please make sure it is an integer on line 2");
            }

            try
            {
                int totalVotes = Int32.Parse(data[2]);
            }
            catch
            {
                Console.WriteLine("Unable to interpret number of votes from file, please make sure it is an integer on line 3");
            }

            /*
              * Creates a new instance of a class, which takse 1 arg
              * partyList is sent to the main class method [Calculator()]
             */
            Calculator newElection = new Calculator(parties);

        }
        static List<Party> CreatePartyList(String[] data)
        {
            /*
             * [i = 3] means that it starts from the third line
             * Each individual line is passed to main class method [Party()], which will seperate individual data inside that line
             * E.g. Name, Votes, Seats etc.
             * The seperated data is then added inside list object List<Party>
            */
            List<Party> partyList = new List<Party>();

            for (int i = 3; i < data.Length; i++)
            {
                partyList.Add(new Party(data[i]));
            }

            return partyList;
        }
        static String[] ReadFile()
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

            // Splits each line as individual string and stores it in an array
            String[] fileLines = text.Split(Char.Parse("\n"));

            return fileLines;
        }
    }
}
