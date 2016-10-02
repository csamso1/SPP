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
            Token t = scanner.getNextToken();
            
            switch (t.getTokenType()) {
            	case LPAREN:
            		return parseRest();
            		break;
            	case FALSE:
            		return BoolLit(false);
            		break;
            	case TRUE:
            		return BoolLit(true);
            		break;
            	case QUOTE:
            		return parseExp();
            		break;
            	case INT:
            		return IntLit(t.getIntVal());
            		break;
            	case STRING:
            		return StringLit(t.getStringVal());
            		break;
            	case IDENT:
            		return Ident(t.getName());
            		break;
            
            }
            return null;
        }
  
        protected Node parseRest()
        {
            // TODO: write code for parsing a rest
            
            Token t = scanner.PeakNextToken();
           
            //Creates a special node with two empty list.. Need help with this
            Tree special = new Cons(new Nil(), new Nil());
            
            if (t.getTokenType() == 'RPAREN') {
            		return Nil;
            		}
            else {
            //Alright, so there's either one expression then a right paren or multiple expressions, either way it has to end on a right paren which has to be called here sooo this should work..right?
            	return special(return parseExp(), return parseRest());
            }
            	
            
            
            }
            return null;
        }

        // TODO: Add any additional methods you might need.
    }
}

