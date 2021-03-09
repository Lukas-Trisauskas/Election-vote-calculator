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

        public Calculator(IEnumerable<Object> partyList)
        {

            int seatsAllocated = 0;
            while (seatsAllocated < 5)
            {
                Console.WriteLine($"Round: {_round}");
                foreach (Party party in partyList)
                {
                    if (party.TotalSeats >= _round)
                    {
                        party.Quotient = party.TotalVotes / (seatsAllocated + 1);
                        Console.WriteLine($"Party: {party.Name} | Votes: {party.TotalVotes} | Quotient: {party.Quotient}");
                    }    
                }
                _round += 1;
                seatsAllocated++;
            }

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
    }
}
