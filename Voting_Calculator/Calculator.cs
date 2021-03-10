using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Voting_Calculator
{
    class Calculator
    {
        // Properties
        private int _round = 1;
        private string _results = "Results have not been caculated, use Caculate() method first!";

        public string Results
        {
            get { return _results; }
        }

        public Calculator(IEnumerable<Object> partyList)
        {
            // At the start the initial seats are set to 0 for all parties

           // int allocatedSeats = 0;
          //  while (allocatedSeats < 5)
          //  {
               // Console.WriteLine($"Round: {_round}");

                // Loops through each list object
                foreach (Party party in partyList)
                {
                    // Checks if TotalSeats can be divided by the total amount of seats that can be allocated 5
                    // As TotalSeats is divided by 1, 2, 3 upto the total maximum seats
                    /*if (party.TotalSeats >= _round)
                    {
                        party.Quotient = party.TotalVotes / (allocatedSeats + 1);
                        Console.WriteLine($"Party: {party.Name} | Votes: {party.TotalVotes} | Quotient: {party.Quotient}");

                        /*
                         * TODO:
                         * Need to find maximum quotient
                         * Assigne a seat to the party with the highest quotient
                        */


                        // }
                        // }
                        // _round += 1;
                        //allocatedSeats++;

                    //}


                    /*
                     * [D'Hondt Method]
                     * V = is total number of votes that party received
                     * S = is the number of seats that party has been allocated so far, initially 0 for all parties
                     * 
                     * The total voates for each party is divided, first by 1, and upto the total amount of seats that can be allocated -
                     * per party, which is 5. This gives us the quotient.
                     * At each round, the party whith highest quotient wins 1 seat.
                     * quotient = V / (S + 1)
                   */

        
                }

                
           // }
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

                votes[highestVoteIndex] /= round;

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
