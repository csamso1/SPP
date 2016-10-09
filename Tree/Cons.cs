// Cons -- Parse tree node class for representing a Cons node

using System;
using System.IO;
namespace Tree
{
    public class Cons : Node
    {
        private Node car;
        private Node cdr;
        private Special form;
    
        public Cons(Node a, Node d)
        {
            car = a;
            cdr = d;
            form = parseList();
        }
    
        // parseList() `parses' special forms, constructs an appropriate
        // object of a subclass of Special, and stores a pointer to that
        // object in variable form.  It would be possible to fully parse
        // special forms at this point.  Since this causes complications
        // when using (incorrect) programs as data, it is easiest to let
        // parseList only look at the car for selecting the appropriate
        // object from the Special hierarchy and to leave the rest of
        // parsing up to the interpreter.
        public Special parseList()
        {
        	if (car == null) 
        	{ return null; }
        	try {
        	if  (car.isString() || car.isSymbol()) 
        	{
        		String obj = ""; 
        		if (car.isString()) 
        		{
        			obj = car.getString();
        		} 
        		else 
        		{
        			obj = car.getSymbol();
        		}
        		
        		switch (obj) 
        		{
        			case "begin":
        				return new Begin();
        			case "cond":
        				return new Cond();
        			case "define":
        				return new Define();
        			case ("if"):
        				return new If();
        			case ("lambda"):
        				return new Lambda();
        			case ("let"):
        				return new Let();
        			case ("set!"):
        				return new Set();
        			case ("\'"):
        				return new Quote();
        			default:
        				return new Regular();
        		}
        	
        	}
        	else {
        		form = new Regular();
        		} 
        	} catch (IOException e) {
            Console.Error.WriteLine("IOException: " + e.Message);
            return null;
        }
            return new Regular();
        }
 
        public override void print(int n)
        {
        	//Console.Write("(");
            form.print(car, n, true);
            form.print(cdr, n, false);
        }

        public override void print(int n, bool p)
        {	     
          	//Console.Write("(");
            form.print(car, n, p);
            form.print(cdr, n, p);
        }
        
        public virtual bool isPair()   { return true; }
        
        
        public virtual Node getCar() { return car; }
        public virtual Node getCdr() { return cdr; }
        public virtual void setCar(Node a) {
        	car = a;
        	parseList();
         }
         
        public virtual void setCdr(Node d) {
        	cdr = d;
        }
    }
}

