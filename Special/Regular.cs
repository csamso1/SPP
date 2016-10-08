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
       
        if (t.isNumber()) {
        	t.print(0);
        }
        else if (t.isNull())
        	{ t.print(0); }
        else if (t.isBool()) 
        	{ t.print(0); }
        else if (t.isPair()) 
        {
        	Node a = t.getCar();
        	a.print(0);
        	Node b = t.getCdr();
        	b.print(0); 
        }
      }
    }
}


