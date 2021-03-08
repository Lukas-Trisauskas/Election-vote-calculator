using System;
using System.Collections.Generic;
using System.Text;

namespace Voting_Calculator
{
    class Party
    {
        private string _name;
        private int _votes;
        private int _totalSeats = 0;
        private List<String> _seats = new List<String>();

        public string Name 
        { 
            get { return _name; }
        }

        public int TotalVotes 
        {
            get { return _votes; }
            set { _votes = value; }
        }

        public int TotalSeats
        {
            get { return _totalSeats; }
            set { _totalSeats = value; }
        }

        public List<String> Seats 
        {
            get { return _seats; }
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
                    _seats.Add(substrings[i]);
                }

                // Counts how many elements are inside _seats list
                _totalSeats = _seats.Count;
            }
            catch (Exception exception)
            {
                Console.WriteLine($" Unable to interpret data for {data} \nException occured: {exception.Message}\n");
            }
            
        }
    }
}
