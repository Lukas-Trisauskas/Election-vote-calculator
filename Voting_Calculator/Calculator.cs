using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Voting_Calculator
{
    class Calculator
    {
        // Properties
        private List<Party> _parties = new List<Party>();
        private string _results;
        private string _electionName;
        private int _seatsToAllocate;

        // Property methods
        public string Results
        {
            get { return _results ?? "Results have not been caculated, use Caculate() method first!"; }
            private set { _results = value; }
        }
        public string ElectionName
        {
            get { return _electionName; }
            private set { _electionName = value; }
        }
        private int SeatsToAllocate
        {
            get { return _seatsToAllocate; }
            set { _seatsToAllocate = value; }
        }
        private List<Party> Parties
        {
            get { return _parties; }
            set { _parties = value; }
        }
        // Constructor
        public Calculator(string electionName, List<Party> partyList, int seatsToAllocate)
        {
            ElectionName = electionName;
            Parties = partyList;
            SeatsToAllocate = seatsToAllocate;
        }
        // Class method
        public void Calculate()
        {

            
            List<int> votes = new List<int>();
            foreach (Party party in Parties)
            {
                votes.Add(party.TotalVotes);
            }
            int highestVote = 0;
            for (int round = 1; round < SeatsToAllocate; round++)
            {
                highestVote = votes.Max();
                int highestVoteIndex = votes.IndexOf(highestVote);
                if (round > 1)
                {
                    votes[highestVoteIndex] /= (Parties[highestVoteIndex].MEPsEarned.Count + 2);
                }
                //votes.Clear();
                Parties[highestVoteIndex].AppointMep();
            }

            AddResult(ElectionName);
            foreach (Party party in Parties)
            {
                if (party.MEPsEarned.Count > 0) 
                {
                    AddResult($"{party.Name},{String.Join(",", party.MEPsEarned)};");
                }
            }
        }
        // Class method; combines the final result into a single string which is then called inside main
        private void AddResult(string line)
        {
            Results = _results + line + "\n";
        }
    }
}