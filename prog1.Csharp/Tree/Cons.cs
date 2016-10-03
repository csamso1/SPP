// Cons -- Parse tree node class for representing a Cons node

using System;

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
            parseList();
        }
    
        // parseList() `parses' special forms, constructs an appropriate
        // object of a subclass of Special, and stores a pointer to that
        // object in variable form.  It would be possible to fully parse
        // special forms at this point.  Since this causes complications
        // when using (incorrect) programs as data, it is easiest to let
        // parseList only look at the car for selecting the appropriate
        // object from the Special hierarchy and to leave the rest of
        // parsing up to the interpreter.
        void parseList()
        {
        	if  (car.isString()) {
        		String obj = car.getString();
        		if (obj == "\'") {
        			form = new Quote();
        		}
        	}
        	else if(car.isSymbol()) {
        		String symbol = car.getSymbol();
        		switch (symbol) {
        			case ("Begin"):
        				form = new Begin();
        				break;
        			case ("Cond"):
        				form = new Cond();
        				break;
        			case ("Define"):
        				form = new Define();
        				break;
        			case ("If"):
        				form = new If();
        				break;
        			case ("Lambda"):
        				form = new Lambda();
        				break;
        			case ("Let"):
        				form = new Let();
        				break;
        			case ("Set"):
        				form = new Set();
        				break;
        			
        		}
        	}
        	
            // TODO: implement this function and any helper functions
            // you might need.
        }
 
        public override void print(int n)
        {
            form.print(this, n, false);
        }

        public override void print(int n, bool p)
        {
            form.print(this, n, p);
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

