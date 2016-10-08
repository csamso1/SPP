// Let -- Parse tree node strategy for printing the special form let

using System;

namespace Tree
{
    public class Let : Special
    {
        // TODO: Add any fields needed.
 
        // TODO: Add an appropriate constructor.
	public Let(Node a) { 
		print(a, 0, true); }

        public override void print(Node t, int n, bool p)
        {
            Console.Write("let ");
        }
    }
}


