// Set -- Parse tree node strategy for printing the special form set!

using System;

namespace Tree
{
    public class Set : Special
    {
        // TODO: Add any fields needed.
 
        // TODO: Add an appropriate constructor.
	public Set(Node a) {
	print(a, 0, true); }
	
        public override void print(Node t, int n, bool p)
        {
            Console.Write("set!");
        }
    }
}

