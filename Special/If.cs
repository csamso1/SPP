// If -- Parse tree node strategy for printing the special form if

using System;

namespace Tree
{
    public class If : Special
    {
        // TODO: Add any fields needed.
 
        // TODO: Add an appropriate constructor.
	public If(Node a) { 
		print(a, 0, true); }

        public override void print(Node t, int n, bool p)
        {
            Console.Write("if ");
        }
    }
}

