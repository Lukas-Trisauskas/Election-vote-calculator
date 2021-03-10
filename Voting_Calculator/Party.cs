using System;
using System.Collections.Generic;
using System.Text;

namespace Voting_Calculator
{
    class Party
    {
        private string _name;
        private int _votes;
        private List<String> _mepsAvailable = new List<String>();
        private List<String> _meps = new List<String>();
        private int _mepsTotal = 0;
        public string Name 
        { 
            get { return _name; }
        }

        public int TotalVotes 
        {
            get { return _votes; }
            set { _votes = value; }
        }
        public List<String> MepsAvailable
        {
            get { return _mepsAvailable; }
        }
        public List<String> MepsGained
        {
            get { return _meps; }
            set { _meps = value; }
        }
        public int MepsTotal 
        {
            get { return _mepsTotal; }
            set { _mepsTotal = value; }
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
                _name = substrings[0];
                _votes = Int32.Parse(substrings[1]);

                // For every string after the first two strings in the array add to the seats array
                for (int i = 2; i < substrings.Length; i++)
                {
                    _mepsAvailable.Add(substrings[i]);
                }

                // Counts how many MEPs partie has won
                _mepsTotal = _meps.Count;

            }
            catch (Exception exception)
            {
                Console.WriteLine($" Unable to interpret data for {data} \nException occured: {exception.Message}\n");
            }
        }
        public string AppointMep()
        {
            if (_mepsAvailable.Count > 0)
            {
                _meps.Add(_mepsAvailable[0]);
                _mepsAvailable.RemoveAt(0);
            }
            string mep = string.Join(",", _meps);
            return mep;
        }
    }
}
