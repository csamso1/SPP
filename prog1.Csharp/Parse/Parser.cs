// Parser -- the parser for the Scheme printer and interpreter
//
// Defines
//
//   class Parser;
//
// Parses the language
//
//   exp  ->  ( rest
//         |  #f
//         |  #t
//         |  ' exp
//         |  integer_constant
//         |  string_constant
//         |  identifier
//    rest -> )
//         |  exp+ [. exp] )
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

using System;
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
            Boolean quoteStatus = true;
            Token t = scanner.getNextToken();
            
            switch (t.getType()) {
            	case TokenType.LPAREN:
            		return parseRest();
            	case TokenType.FALSE:
            		return new BoolLit(false);
            	case TokenType.TRUE:
            		return new BoolLit(true);
            	case TokenType.QUOTE:
            		quoteStatus = !quoteStatus;
            		if (quoteStatus) {
            		 	return new Cons(new StringLit("\'"), parseExp());
            		 } else {
            			return new Cons(new StringLit("\'2"), parseExp()); 
            		}
            	case TokenType.DOT:
            		return new Cons(new StringLit("."), parseExp());
            	case TokenType.INT:
            		return new IntLit(t.getIntVal());
            	case TokenType.STRING:
            		return new StringLit(t.getStringVal());
            	case TokenType.IDENT:
            		return new Ident(t.getName());
	            default:
	            	return null;
            
            } 
            //return null;
  }
        protected Node parseRest()
        {
            // TODO: write code for parsing a rest
            
            Scanner letsTryThis = scanner;
            Token t = letsTryThis.getNextToken();
           
            if (t.getType() == TokenType.RPAREN)  
            {
            	return new Nil();
            }
            
            else 
            {
            	return new Cons(parseExp(), parseRest());
            }
            
            //return null;
        }

        // TODO: Add any additional methods you might need.
    }
}

