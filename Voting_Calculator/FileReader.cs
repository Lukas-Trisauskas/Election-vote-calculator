using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Voting_Calculator
{
    static class FileReader
    {
        // Properties
        private static string _raw;
        private static String[] _lines;

        // Property methods
        private static string Raw
        {
            get { return _raw ?? "Have not read file yet"; }
            set { _raw = value; }
        }
        private static String[] Lines
        {
            get { return _lines ?? new string[] { "Have not read file yet" }; }
            set { _lines = value; }
        }
        // Constructor 
        public static String[] GetLines(string directory, string fileName)
        {

            /*
             * Combines two strings into a single path, currentDirectory + filename
             * Each [..\] means that it moves backup 1 directory from \..\bin\Debug\netcoreapp2.0\
             */
            string filePath = Path.Combine(directory, fileName);

            // Returns file path
            filePath = Path.GetFullPath(filePath);

            // Takes file path as argument, reads the entire text file
            Raw = File.ReadAllText(filePath);

            // Seperates each line as individual string
            return Raw.Split(Char.Parse("\n"));
        }
    }
}
