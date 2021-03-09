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
            // At the start the initial seats are set to 0 for all parties

            int allocatedSeats = 0;
            while (allocatedSeats < 5)
            {
                Console.WriteLine($"Round: {_round}");

                // Loops through each list object
                foreach (Party party in partyList)
                {
                    // Checks if TotalSeats can be divided by the total amount of seats that can be allocated 5
                    // As TotalSeats is divided by 1, 2, 3 upto the total maximum seats
                    if (party.TotalSeats >= _round)
                    {
                        party.Quotient = party.TotalVotes / (allocatedSeats + 1);
                        Console.WriteLine($"Party: {party.Name} | Votes: {party.TotalVotes} | Quotient: {party.Quotient}");
                    }    
                }
                _round += 1;
                allocatedSeats++;
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
