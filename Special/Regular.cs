// Regular -- Parse tree node strategy for printing regular lists

using System;

namespace Tree
{
    public class Regular : Special
    {
        // TODO: Add any fields needed.
    
        // TODO: Add an appropriate constructor.
        public Regular(Node a) { 
        	print(a, 0, true);}

        public override void print(Node t, int n, bool p)
        {
     
     if (t == null) {
     return; }
        if (t.isPair()) 
        {
        	t.print(0);
        }
        else {
        t.print(0); }
      }
    }
}


