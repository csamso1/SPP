// Define -- Parse tree node strategy for printing the special form define

using System;

namespace Tree
{
    public class Define : Special
    {
        // TODO: Add any fields needed.

        // TODO: Add an appropriate constructor.
	public Define() {
		Console.Write("made it to define"); 
		 }

        public override void print(Node t, int n, bool p)
        {
        Console.Write("made it to print"); 
            Console.Write("define ");
        }
    }
}


