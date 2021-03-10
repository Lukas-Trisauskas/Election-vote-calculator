using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Voting_Calculator
{
    class Calculator
    {
        // Fields
        private List<Party> _parties = new List<Party>();
        private string _results = "Results have not been caculated, use Caculate() method first!";
        private string _electionName;
        private int _seatsToBeAllocated;

        // Properties
        public string Results
        {
            get { return _results; }
            private set { _results = value; }
        }

        public string ElectionName
        {
            get { return _electionName; }
            private set { _electionName = value; }
        }

        private int SeatsToBeAllocated
        {
            get { return _seatsToBeAllocated; }
            set { _seatsToBeAllocated = value; }
        }

        private List<Party> Parties
        {
            get { return _parties; }
            set { _parties = value; }
        }


        public Calculator(string electionName, List<Party> parties, int seatsToBeAllocated)
        {
            ElectionName = electionName;
            
        }

        public void Calculate(List<Party> parties, int seatsToBeAllocated, string electionName)
        {
            List<int> votes = new List<int>();
            List<int> roundsWon = new List<int>();

            foreach (Party party in parties)
            {
                votes.Add(party.TotalVotes);
                roundsWon.Add(0);
            }


            int highestVoteCount = 0;


            for (int round = 1; round < seatsToBeAllocated + 1; round++)
            {

                highestVoteCount = votes.Max();
                
                int highestVoteIndex = votes.IndexOf(highestVoteCount);

                if (round > 1)
                {
                    votes[highestVoteIndex] /= 2;
                }

                parties[highestVoteIndex].AppointMep();
            }


            _results = "";
            AddResult(electionName);

            foreach (Party party in parties)
            {
                if (party.MepsGained.Count > 0) 
                {
                    AddResult($"{party.Name},{String.Join(",", party.MepsGained)};");
                }
            }
        }

        private void AddResult(string line)
        {
            _results = _results + "\n" + line;
        }
    }
}