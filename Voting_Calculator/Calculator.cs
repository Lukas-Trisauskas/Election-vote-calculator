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

            Calculate();
        }
        // Class method; that implements the D'Hondt method to simulate an electoral system
        private void Calculate()
        {
            List<int> quotientList = new List<int>();
            foreach (Party party in Parties)
            {
                quotientList.Add(party.TotalVotes);
            }
            for (int round = 0; round < SeatsToAllocate; round++)
            {
                int highestQuotient = quotientList.Max();
                int highestQuotientIndex = quotientList.IndexOf(highestQuotient);
              
                // D'Hondt method
                // First we find the party with the highest votes and appoint it a seat / MEP
                // Total votes are divided by the number of seats/MEPs the party has + 1
                // Then we find the next party with the highest votes, until no more seats/MEPs can be appointed.

                Parties[highestQuotientIndex].AppointMep();
                quotientList[highestQuotientIndex] = Parties[highestQuotientIndex].TotalVotes / (Parties[highestQuotientIndex].MEPsEarned.Count + 1);
                
            }

            AddResult(ElectionName);
            // Prints parties that only have acquired 1 or more seat/MEP
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