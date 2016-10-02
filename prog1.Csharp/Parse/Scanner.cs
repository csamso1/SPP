// Scanner -- The lexical analyzer for the Scheme printer and interpreter

using System;
using System.IO;
using Tokens;

namespace Parse
{
    public class Scanner
    {
        private TextReader In;

        // maximum length of strings and identifier
        private const int BUFSIZE = 1000;
        private char[] buf = new char[BUFSIZE];

        public Scanner(TextReader i) { In = i; }
  
        // TODO: Add any other methods you need
        
        public Token peakNextToken() {
        	TextReader willThisWork = In;
        	Token temp = getNextToken();
        	In = willThisWork;
        	return temp;
		}

        public Token getNextToken()
        {
            int ch;

            try
            {
                // It would be more efficient if we'd maintain our own
                // input buffer and read characters out of that
                // buffer, but reading individual characters from the
                // input stream is easier.
                ch = In.Read();
   
                // Skips comments
                if(ch == 59)
                {
                    while (ch != 10)
                    {
                        ch = In.Read();
                    }
                    return getNextToken();
                }

                //Skips white space
                if(ch == 32)
                {
                    return getNextToken();
                }

                if (ch == -1)
                    return null;
        
                // Special characters
                else if (ch == '\'')
                    return new Token(TokenType.QUOTE);
                else if (ch == '(')
                    return new Token(TokenType.LPAREN);
                else if (ch == ')')
                    return new Token(TokenType.RPAREN);
                else if (ch == '.')
                    // We ignore the special identifier `...'.
                    return new Token(TokenType.DOT);
                
                // Boolean constants
                else if (ch == '#')
                {
                    ch = In.Read();

                    if (ch == 't')
                        return new Token(TokenType.TRUE);
                    else if (ch == 'f')
                        return new Token(TokenType.FALSE);
                    else if (ch == -1)
                    {
                        Console.Error.WriteLine("Unexpected EOF following #");
                        return null;
                    }
                    else
                    {
                        Console.Error.WriteLine("Illegal character '" +
                                                (char)ch + "' following #");
                        return getNextToken();
                    }
                }

                // String constants
                else if (ch == '"')
                {
                    int i = 0;
                    do
                    {
                        buf[i] = (char)ch;
                        ch = In.Read();
                        i++;
                    } while (ch != '"');
                    return new StringToken(new String(buf, 0, 0));
                }

    
                // Integer constants
                else if (ch >= '0' && ch <= '9')
                {
                    int i = ch - '0';
                    // TODO: scan the number and convert it to an integer

                    // make sure that the character following the integer
                    // is not removed from the input stream
                    return new IntToken(i);
                }

                // Identifiers or ch is some other valid first character for an identifier
                else if (ch >= 'A' && ch <= 'Z' || ch == 33 || ch >= 36 && ch <= 38 || ch == 47
                    || ch >= 58 && ch <= 63 || ch == 94 || ch == 95 || ch == 126)
                {
                    int i = 0;
                    do
                    {
                        buf[i] = (char)ch;
                        i++;
                        ch = In.Read();
                    } while (ch >= 48 && ch <= 57 || ch >= 65 && ch <= 90 || ch >= 97 && ch <= 122);
                    return new IdentToken(new String(buf, 0, 0));
                }
    
                // Illegal character
                else
                {
                    Console.Error.WriteLine("Illegal input character '"
                                            + (char)ch + '\'');
                    return getNextToken();
                }
            }
            catch (IOException e)
            {
                Console.Error.WriteLine("IOException: " + e.Message);
                return null;
            }
        }
    }

}