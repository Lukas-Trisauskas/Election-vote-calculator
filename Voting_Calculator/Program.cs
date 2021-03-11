using System;
using System.Collections.Generic;
using System.IO;

namespace Voting_Calculator
{
    class Program
    {

        static void Main(string[] args)
        {

            // Returns current working directory
            string currentDirectory = Directory.GetCurrentDirectory();

            /*
             * Combines two strings into a single path, currentDirectory + filename
             * Each [..\] means that it moves backup 1 directory from \..\bin\Debug\netcoreapp2.0\ 
             */
            string path = Path.Combine(currentDirectory, @"..\..\..\..\");
            string fileName = "Assessment1Data.txt";

            String[] data = FileReader.GetLines(path, fileName);

            // Calls the function and stores contents of the file inside a new variable
            List<Party> partyList = ExtractPartyList(data);
            string electionName;
            int seatsToAllocate;

            // Retrieves the contents of the second line, which is the maximum amount of MEPs that can be appointed
            seatsToAllocate = Int32.Parse(data[1]);

            // Retrievs the concents of the first line, which is the election name.
            electionName = data[0];



            /*
             * Creates a new instance of a the clas Calculator
             * The constructor Calculator() takes three arguments, election name, partyList and seatsToAllocate
             */

            Calculator newElection = new Calculator(electionName, partyList, seatsToAllocate);

            Console.WriteLine(newElection.Results);
        }

        static List<Party> ExtractPartyList(String[] data)
        {
            /*
             * [i] denotes the start of the line
             * Each line is passed to class the constructor Party(); data inside each line is seperated
             * The seperated data is then added inside a list object List<Party>; this generates a list of objects/instance of Party class for all parties
            */
            List<Party> partyList = new List<Party>();

            for (int i = 3; i < data.Length; i++)
            {
                partyList.Add(new Party(data[i]));
            }
            return partyList;
        }
    }
}
