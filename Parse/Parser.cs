// Parser -- the parser for the Scheme printer and interpreter
//
// Defines
//
//   class Parser;
//
// Parses the language
//

//
// and builds a parse tree.  Lists of the form (rest) are further
// `parsed' into regular lists and special forms in the constructor
// for the parse tree node class Cons.  See Cons.parseList() for
// more information.
//
// The parser is implemented as an LL(0) recursive descent parser.
// I.e., parseExp() expects that the first token of an exp has not
// been read yet.  If parseRest() reads the first token of an exp
// before calling parseExp(), that token must be put back so that
// it can be reread by parseExp() or an alternative version of
// parseExp() must be called.
//
// If EOF is reached (i.e., if the scanner returns a NULL) token,
// the parser returns a NULL tree.  In case of a parse error, the
// parser discards the offending token (which probably was a DOT
// or an RPAREN) and attempts to continue parsing with the next token.
//   exp  ->  ( rest
//         |  #f
//         |  #t
//         |  ' exp
//         |  integer_constant
//         |  string_constant
//         |  identifier
//    rest -> )
//         |  exp+ [. exp] )

using System;
using System.IO;
using Tokens;
using Tree;

namespace Parse
{
    public class Parser {
	
        private Scanner scanner;

        public Parser(Scanner s) { scanner = s; }
  
        public Node parseExp()
        {
            // TODO: write code for parsing an exp
            //bool quoteStatus = true;
            Token t = scanner.getNextToken();
            Node lp;
            if (t == null)
             { return null; }
            try {
            switch (t.getType()) {
            	case TokenType.LPAREN:
            		lp = parseRest();
            		return lp;
            	case TokenType.FALSE:
            		lp = new BoolLit(false);
            		return lp;
            	case TokenType.TRUE:
            		lp = new BoolLit(true);
            		return lp;
            	case TokenType.QUOTE:
            		lp = parseRest();
            		return lp;
            	case TokenType.DOT:
            		lp = new Cons(new StringLit("."), parseExp());
            		return lp;
            	case TokenType.INT:
            		lp = new IntLit(t.getIntVal());
            		return lp;
            	case TokenType.STRING:
            		lp = new StringLit(t.getStringVal());
            		return lp;
            	case TokenType.IDENT:
            		lp = new Ident(t.getName());
            		return lp;
            } 
            } catch (IOException e) {
            Console.Error.WriteLine("IOException: " + e.Message);
           
            return parseExp();
        }
            lp = new Nil();
            return null;
  }
        protected Node parseRest()
        {
            // TODO: write code for parsing a rest
            
//             Scanner letsTryThis = scanner;
            Token t = scanner.peekNextToken();
           if (t == null) {
           return null; }
           try {
            if (t.getType() == TokenType.RPAREN)  
            {
            	t = scanner.getNextToken();
            	Node rp = new Nil();
            	return rp;
            }
            
            else 
            {
            	Node car = parseExp();
            	Node cdr = parseRest();
            	return new Cons(car, cdr);
            }
            } catch (IOException e) {
            Console.Error.WriteLine("IOException: " + e.Message);
           
            return parseExp();
        }
            
            //return null;
        }

        // TODO: Add any additional methods you might need.
    }
}

