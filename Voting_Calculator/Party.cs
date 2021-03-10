using System;
using System.Collections.Generic;
using System.Text;

namespace Voting_Calculator
{
    class Party
    {
        // Properties
        private string _name;
        private int _totalVotes;
        private List<String> _mepsAvailable = new List<String>();
        private List<String> _mepsEarned = new List<String>();
        private int _mepsTotal = 0;

        // Property methods
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
        public List<String> MEPsAvailable
        {
            get { return _mepsAvailable; }
            private set { _mepsAvailable = value; }
        }
        public List<String> MEPsEarned
        {
            get { return _mepsEarned; }
            private set { _mepsEarned = value; }
        }
        public int  MEPsTotal
        {
            get { return _mepsTotal; }
            private set { _mepsTotal = value; }
        }
        // Constructor
        public Party(string data)
        {
            // Error handling
            try
            {
                // Remove [;] in every line
                data = data.Replace(Char.Parse(";"), Char.Parse(" "));

                // Seperates each string data after every comma and stores that data into an array.
                String[] substrings = data.Split(Char.Parse(","));

                // Set the name and number of votes from the array
                Name = substrings[0];
                TotalVotes = Int32.Parse(substrings[1]);

                // For every string after the first two strings in the array add to the seats array
                for (int i = 2; i < substrings.Length; i++)
                {
                    MEPsAvailable.Add(substrings[i]);
                }
            }
            // Takes the list of MEPs earned and counts the elements inside, giving us the final result
            catch (Exception exception)
            {
                Console.WriteLine($" Unable to interpret data for {data} \nException occured: {exception.Message}\n");
            }
        }

        /*
         * Appoints a MEP to party with the most votes to a new list _mepsEarned
         * Removes the MEP that was appointed from _mepsAvailable
         * The next MEP will be at index 0
         */
        public void AppointMep()
        {
            if (MEPsAvailable.Count > 0)
            {
                MEPsEarned.Add(MEPsAvailable[0]);
                MEPsAvailable.RemoveAt(0);
            }
        }
    }
}
