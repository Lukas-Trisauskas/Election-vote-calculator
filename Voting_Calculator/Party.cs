﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Voting_Calculator
{
    class Party
    {
        private string _name;
        private int _totalVotes;
        private List<String> _mepsAvailable = new List<String>();
        private List<String> _mepsGained = new List<String>();

        public string Name 
        { 
            get { return _name; }
            private set { _name = value; }
        }

        public int TotalVotes 
        {
            get { return _totalVotes; }
            private set { _totalVotes = value; }
        }

        public List<String> MepsAvailable
        {
            get { return _mepsAvailable; }
            private set { _mepsAvailable = value; }
        }

        public List<String> MepsGained
        {
            get { return _mepsGained; }
            private set { _mepsGained = value; }
        }

        public Party(string data)
        {

            try
            {
                // Remove semi colon from the end of the line
                data = data.Replace(Char.Parse(";"), Char.Parse(" "));

                // Split the data at every comma into seperate strings and put into an array
                String[] substrings = data.Split(Char.Parse(","));

                // Set the name and number of votes from the array
                Name = substrings[0];
                TotalVotes = Int32.Parse(substrings[1]);

                // For every string after the first two strings in the array add to the seats array
                for (int i = 2; i < substrings.Length; i++)
                {
                    MepsAvailable.Add(substrings[i]);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($" Unable to interpret data for {data} \nException occured: {exception.Message}\n");
            }
        }

        public void AppointMep()
        {
            if (MepsAvailable.Count > 0)
            {
                MepsGained.Add(MepsAvailable[0]);
                MepsAvailable.RemoveAt(0);
            }
        }
    }
}
