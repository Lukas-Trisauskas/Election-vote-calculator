using System;
using System.Collections.Generic;
using System.Text;

namespace Voting_Calculator
{
    class Calculator
    {
        // Properties
        private int _round = 0;
        private int _quotients = 0;
        private int _seatsWon = 0;

        public Calculator(IEnumerable<Object> myList)
        {
            foreach (Party party in myList)
            {
                Console.WriteLine($"Party: {party.Name} | Votes: {party.TotalVotes} | Total Seats: {party.TotalSeats}");
            }

            /*
             * [D'Hondt Method]
             * V = is total number of votes that party received
             * S = is the number of seats that party has been allocated so far, initially 0 for all parties
             * 
             * The total voates for each part is divided, first by 1, and upto the total amount of seats that can be allocated -
             * per party, which is 5. This gives us the quotient.
             * At each round, the part whith highest quotient wins 1 seat.
             * quotient = V / (S + 1)
           */


        }

    }
}
