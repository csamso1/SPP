// Ident -- Parse tree node class for representing identifiers

using System;

namespace Tree
{
    public class Ident : Node
    {
        private string name;

        public Ident(string n)
        {
            name = n;
        }

        public override void print(int n)
        {
	    for (int i = 0; i < n; i++)
                Console.Write(" ");

            Console.WriteLine(name);
        }
        
		public virtual bool isSymbol() { return true; }
		public virtual String getSymbol() { return name; } 
    }
}

