// Begin -- Parse tree node strategy for printing the special form begin

using System;

namespace Tree
{
    public class Begin : Special
    {
        // TODO: Add any fields needed.
 
        // TODO: Add an appropriate constructor.
	public Begin(Node a) {
		print(a, 0, true); }

        public override void print(Node t, int n, bool p)
        {
            Console.Write("begin ");
        }
    }
}

