// Nil -- Parse tree node class for representing the empty list

using System;

namespace Tree
{
    public class Nil : Node
    {
    
    	private Boolean status;
        public Nil() { }
  
        public override void print(int n)
        {
            print(n, false);
        }

        public override void print(int n, bool p) {
	    for (int i = 0; i < n; i++)
                Console.Write(" ");

            if (p)
                Console.WriteLine(")");
            else
                Console.WriteLine("()");
        }
        public void setStatus(Boolean s) {status = s; }
        public virtual bool isNull()   { return true; } 
        public virtual bool getStatus()   { return status; }
    }
}
