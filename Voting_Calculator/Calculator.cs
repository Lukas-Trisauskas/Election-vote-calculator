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
        private string _results;
        private string _electionName;
        private int _seatsToBeAllocated;

        // Properties
        public string Results
        {
            get
            {
                return _results ?? "Results have not been caculated, use Caculate() method first!";
            }

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
            Parties = parties;
            SeatsToBeAllocated = seatsToBeAllocated;
        }

        public void Calculate()
        {
            List<int> votes = new List<int>();
            List<int> roundsWon = new List<int>();

            foreach (Party party in Parties)
            {
                votes.Add(party.TotalVotes);
                roundsWon.Add(0);
            }

            for (int round = 1; round < SeatsToBeAllocated + 1; round++)
            {

                int highestVoteCount = votes.Max();
                
                int highestVoteIndex = votes.IndexOf(highestVoteCount);

                if (round > 1)
                {
                    votes[highestVoteIndex] /= 2;
                }

                Parties[highestVoteIndex].AppointMep();
            }

            AddResult(ElectionName);

            foreach (Party party in Parties)
            {
                if (party.MepsGained.Count > 0) 
                {
                    AddResult($"{party.Name},{String.Join(",", party.MepsGained)};");
                }
            }
        }

        private void AddResult(string line)
        {
            Results = _results + line + "\n";
        }
    }
}