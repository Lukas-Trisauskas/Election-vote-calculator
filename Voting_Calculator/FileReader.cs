using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Voting_Calculator
{
    class FileReader
    {
        private string _raw;
        private String[] _lines;

        public string Raw
        {
            get { return _raw ?? "Have not read file yet"; }
            private set { _raw = value; }
        }

        public String[] Lines
        {
            get { return _lines ?? new string[] { "Have not read file yet" }; }
            private set { _lines = value; }
        }

        public FileReader(string directory, string fileName)
        {
            string filePath = Path.Combine(directory, fileName);
                
            filePath = Path.GetFullPath(filePath);

            Raw = File.ReadAllText(filePath);
            Lines = Raw.Split(Char.Parse("\n"));
        }
    }
}
