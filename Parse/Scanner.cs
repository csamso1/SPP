// Scanner -- The lexical analyzer for the Scheme printer and interpreter

using System;
using System.IO;
using Tokens;

namespace 



Parse
{
    public class Scanner 
    {

    private TextReader In;

    // maximum length of strings and identifier
    private const int BUFSIZE = 1000;
    private char[] buf = new char[BUFSIZE];

    public Scanner(TextReader i) {
        In = i;
    }

    // TODO: Add any other methods you need
    public Boolean isspace(int nextChar) {
        if (nextChar == 32) {
            return true;
        } else {
            return false;
        }
    }

    public Token peekNextToken() {
        TextReader willThisWork = this.In;
        Token temp = getNextToken();
        this.In = willThisWork;
        return temp;
    }

    public Token getNextToken() {
        int ch;

        try {
            // It would be more efficient if we'd maintain our own
            // input buffer and read characters out of that
            // buffer, but reading individual characters from the
            // input stream is easier.
            ch = In.Read();

            // Skips comments
            if (ch == ';') {
                while (ch != 10) {
                    ch = In.Read();
                }
                return getNextToken();
            } //Skips white space
            else if (ch == 32 || ch == 10) {
                return getNextToken();
            } else if (ch == -1) {
                return null;
            } // Special characters
            else if (ch == '\'') {
                return new Token(TokenType.QUOTE);
            } else if (ch == '(') {
                return new Token(TokenType.LPAREN);
            } else if (ch == ')') {
                return new Token(TokenType.RPAREN);
            } else if (ch == '.') // We ignore the special identifier `...'.
            {
                return new Token(TokenType.DOT);
            } // Boolean constants
            else if (ch == '#') {
                ch = In.Read();

                if (ch == 't') {
                    return new Token(TokenType.TRUE);
                } else if (ch == 'f') {
                    return new Token(TokenType.FALSE);
                } else if (ch == -1) {
                    Console.Error.WriteLine("Unexpected EOF following #");
                    return null;
                } else {
                    Console.Error.WriteLine("Illegal character '"
                            + (char) ch + "' following #");
                    return getNextToken();
                }
            } // String constants
            else if (ch == '"') {
                int i = 0;
                ch = In.Read();
                while (ch != '"') {
                    buf[i] = (char) ch;
                    ch = In.Read();
                    i++;
                };
                return new StringToken(new String(buf, 0, i));
            } // Integer constants
            else if (ch >= '0' && ch <= '9') {
                int i = ch - '0';
                int j = In.Peek();
                while (j >= '0' && j <= '9') {
                    ch = In.Read();
                    i = 10 * i + ch - '0';
                    j = In.Peek();

                };
                return new IntToken(i);

                
            } // Identifiers or ch is some other valid first character for an identifier
            else if (ch >= 'A' && ch <= 'Z' || (ch >= 'a' && ch <= 'z') || ch == '!' || ch >= '$' && ch <= '&' || ch == '/'
                    || ch >= ':' && ch <= '?' || ch == '^' || ch == '_' || ch == '~')
            	{
                int i = 0;
                while ((ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z') || ch == '!' || (ch >= '$' && ch <= '&') || ch == '/'
                    	|| ch >= ':' && ch <= '?' || ch == '^' || ch == '_' || ch == '~') {
                    buf[i] = (char) ch;
                    i++;
                    ch = In.Read();
                	} ;
                
                return new IdentToken(new String(buf, 0, i));
            	} // Illegal character
            else {
                Console.Error.WriteLine("Illegal input character '"
                        + (char) ch + '\'');
                return getNextToken();
            }
        } catch (IOException e) {
            Console.Error.WriteLine("IOException: " + e.Message);
            return null;
        }
    }
}

}
