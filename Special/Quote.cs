// Quote -- Parse tree node strategy for printing the special form quote

using System;

namespace Tree
{
    public class Quote : Special
    {
        // TODO: Add any fields needed.
        Boolean closed;
  
        // TODO: Add an appropriate constructor.
	public Quote(Node a) {
		print(a,0,true);
	 }

        public override void print(Node t, int n, bool p)
        {
            Console.Write("\' ");
        }
    }
}

